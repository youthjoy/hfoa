using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using QX.Model;
using QX.BLL;
using QX.HtmlHelperLib;
using QX.HtmlHelperLib.JqGrid;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using QX.Comm;
using QX.Config;
using System.IO;
using System.Text;

namespace QX.Controllers.Controllers
{
    public class CompController : Controller
    {

        #region 操作句柄

        private Bll_RoadComponents rcInstance = new Bll_RoadComponents();
        private Bll_Comp cInstance = new Bll_Comp();
        private Bll_Doc diInstance = new Bll_Doc();
        private Bll_Doc_Info dinfoInstance = new Bll_Doc_Info();
        private BLL.Bll_Audit auditInstance = new QX.BLL.Bll_Audit();
        private BindModelHelper bmHelper = new BindModelHelper();


        #endregion
        //
        // GET: /Comp/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            ViewData["DeptList"] = cInstance.GenerateCompTree();
            return View();
        }


        public ActionResult Add()
        {
            Bse_Components info = new Bse_Components();
            info.Comp_Code = cInstance.GenerateCompCode();
            info.Comp_Creator = SessionConfig.UserId();
            info.Comp_CreatorName = SessionConfig.UserName();
            info.Comp_Date = DateTime.Now;

            GetbackUrl();

            return View(info);
        }

        public void GetbackUrl()
        {
            if (string.IsNullOrEmpty(Request["backUrl"]))
            {
                ViewData["backUrl"] = "";
            }
            else
            {
                ViewData["backUrl"] = Request["backUrl"];
            }
        }

        public ActionResult Edit(string id, string rtype)
        {
            var model = cInstance.GetModel(string.Format("AND Comp_Code='{0}'", id));
            string isView = string.Empty;

            GetbackUrl();

            ViewData["CompHis"] = cInstance.GetCompHisList(string.Format("AND CH_CompCode='{0}' AND CH_iType='File'", model.Comp_Code)).FirstOrDefault();
            return View(model);
        }

        public ActionResult Correct(string id, string rtype)
        {
            var model = cInstance.GetModel(string.Format("AND Comp_Code='{0}'", id));
            string isView = string.Empty;

            GetbackUrl();
            return View(model);
        }

        public ActionResult Delete(string id)
        {

            Bse_Components doc = cInstance.GetModel(string.Format("AND Comp_Code='{0}'", id));
            cInstance.DeleteComp(doc);

            BLL.Bll_Comm.OpLog("Bse_ComponentsModule", "Delete", string.Format("删除图纸:{0}", id));

            return Json(new { result = "success", message = "成功" }, "text/json");
        }


        public ActionResult DeleteCompHis(string id)
        {

            Bse_CompHistory doc = cInstance.GetHisModel(string.Format("AND Comp_Code='{0}'", id));
            doc.Stat = 1;
            cInstance.UpdateHis(doc);
            BLL.Bll_Comm.OpLog("Bse_CompHistoryModule", "DeleteCompHis", string.Format("删除图纸图片:{0}", id));

            return Json(new { result = "success", message = "成功" }, "text/json");
        }

        public ActionResult Show(string id, string rtype)
        {
            var model = cInstance.GetModel(string.Format("AND Comp_Code='{0}'", id));
            string isView = string.Empty;
            if (!string.IsNullOrEmpty(rtype))
            {
                isView = "view";
                ViewData["IsView"] = "view";
            }
            GetbackUrl();
            return View(model);
        }

        [ValidateInput(false)]
        public JsonResult CompOperation(FormCollection formCollect)
        {
            var flag = false;
            Bse_Components doc = new Bse_Components();
            bmHelper.BindFormToModel<Bse_Components>(doc, formCollect);
            string type = formCollect["optype"];
            int isback = 0;

            //var chlist = cInstance.GetCompHisList(string.Format("AND CH_CompCode='{0}'", doc.Comp_Code));
            //if (chlist.Count == 0)
            //{
            //    return Json(new { result = "fail", Msg = "请上传图纸图片附件！" }, "application/json");
            //}

            if (formCollect["formOper"] == "edit")
            {

                doc.UpdateTime = DateTime.Now;
                if (type == "nor")
                {
                    doc.Comp_Stat = "Draft";
                }
                else if (type == "submit")
                {
                    doc.Comp_Stat = "Normal";
                    //进入审核流程
                    doc.AuditStat = "Auditing";
                    var model = auditInstance.GetVerifyTemplateFirstNode(AuditModuleEnum.CompAudit.ToString());
                    if (model != null)
                    {
                        doc.AuditCurAudit = model.VT_VerifyNode_Code;
                    }
                }

                flag = cInstance.UpdateComp(doc);

                BLL.Bll_Comm.OpLog("Bse_ComponentsModule", "CompOperation", string.Format("更新图纸:{0}", doc.Comp_Code));
            }
            else
            {

                //doc.Doc_Code = diInstance.GenerateDocCode();
                isback = 1;
                doc.CreateTime = DateTime.Now;
                doc.UpdateTime = DateTime.Now;
                if (type == "nor")
                {
                    doc.Comp_Stat = "Draft";
                }
                else
                {
                    //var list = cInstance.GetCompHisList(string.Format("AND CH_CompCode='{0}' AND CH_iType='File'", doc.Comp_Code));

                    //if (list.Count == 0)
                    //{
                    //    return Json(new { result = "success", isBack = isback, Msg = "请上传图纸附件！" }, "application/json");
                    //}


                    doc.Comp_Stat = "Normal";
                    //进入审核流程
                    doc.AuditStat = "Auditing";
                    var model = auditInstance.GetVerifyTemplateFirstNode(AuditModuleEnum.CompAudit.ToString());
                    if (model != null)
                    {
                        doc.AuditCurAudit = model.VT_VerifyNode_Code;
                    }
                }

                flag = cInstance.AddComp(doc);
                //日志记录
                BLL.Bll_Comm.OpLog("Bse_ComponentsModule", "CompOperation", string.Format("添加图纸:{0}", doc.Comp_Code));

            }
            if (flag)
            {
                return Json(new { result = "success", isBack = isback, Msg = "数据更新成功！" }, "application/json");
            }
            else
            {
                return Json(new { result = "fail", Msg = "数据更新失败！" }, "application/json");
            }
        }

        public ActionResult GetCompDraftList(string id, string rtype, int page, int rows, string search, string sidx, string sord)
        {
            string filter = Request["filters"] != null ? Request["filters"] : "";
            string filterSql = "";
            if (!string.IsNullOrEmpty(filter))
            {
                filterSql = filter.BuildSearch("Bse_ComponentsModule");
                //filterSql = BulidJqGridSearch.BuildSearch(filter);
            }
            List<Bse_Components> list = new List<Bse_Components>();
            if (string.IsNullOrEmpty(filterSql))
            {
                list = cInstance.GetCompDraftList("1=1");
            }
            else
            {
                list = cInstance.GetCompDraftList(filterSql);
            }

            var model = list.AsQueryable<Bse_Components>();
            //var result = model.ToJqGridData(page, rows, null, search, null);

            var jsonResult = JsonConvert.SerializeObject(model.ToJqGridData(page, rows, null, search, null), new JsonDateConverter("yyyy-MM-dd"));
            return JavaScript(jsonResult);
            //return Json(result, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// 零件图纸上传(图片上传)
        /// </summary>
        /// <param name="qqfile"></param>
        /// <returns></returns>
        public ActionResult Upload(string qqfile)
        {
            var path = Server.MapPath("~/Upload");
            var dpath = Server.MapPath("~/Upload/Temp");
            string file = Comm.FileUpload.UploadFile(qqfile, path, System.Web.HttpContext.Current);
            string dfile = Path.Combine(dpath, Path.GetFileName(file));

            //业务处理 已审人数*50作为高度

            if (string.IsNullOrEmpty(file))
            {
                return Json(new { result = "fail", message = "上传失败!" }, "application/json");
            }

            ThumNail.AddWaterWord(SessionConfig.UserName(), file, dfile, 100, 100);

            return Json(new { result = "success", path = "/Upload/" + Path.GetFileName(file), message = "成功" }, "application/json");
        }


        public ActionResult DoingComp()
        {
            return View();
        }

        /// <summary>
        /// 获取零件图号
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="search"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <returns></returns>
        public ActionResult GetComponentsList(int page, int rows, string search, string sidx, string sord)
        {
            string filter = Request["filters"] != null ? Request["filters"] : "";
            string filterSql = "";
            if (!string.IsNullOrEmpty(filter))
            {
                filterSql = filter.BuildSearch("Bse_ComponentsModule");
                //filterSql = BulidJqGridSearch.BuildSearch(filter);
            }
            List<Road_Components> list = new List<Road_Components>();
            if (string.IsNullOrEmpty(filterSql))
            {
                list = rcInstance.GetCompList("1=1");
            }
            else
            {
                list = rcInstance.GetCompList(filterSql);
            }

            var model = list.AsQueryable<Road_Components>();
            //var result = model.ToJqGridData(page, rows, null, search, null);
            //return Json(result, JsonRequestBehavior.AllowGet);
            var jsonResult = JsonConvert.SerializeObject(model.ToJqGridData(page, rows, null, search, null), new JsonDateConverter("yyyy-MM-dd"));
            return JavaScript(jsonResult);
        }

        /// <summary>
        /// 获取客户列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="search"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <returns></returns>
        public ActionResult GetCustomerList(int page, int rows, string search, string sidx, string sord)
        {
            string filter = Request["filters"] != null ? Request["filters"] : "";
            string filterSql = "";
            if (!string.IsNullOrEmpty(filter))
            {
                filterSql = BulidJqGridSearch.BuildSearch(filter);
                //filterSql = BulidJqGridSearch.BuildSearch(filter);
            }
            List<SD_Customer> list = new List<SD_Customer>();
            if (string.IsNullOrEmpty(filterSql))
            {
                list = cInstance.GetCustomerList("1=1");
            }
            else
            {
                list = cInstance.GetCustomerList(filterSql);
            }

            var model = list.AsQueryable<SD_Customer>();
            //var result = model.ToJqGridData(page, rows, null, search, null);
            //return Json(result, JsonRequestBehavior.AllowGet);
            var jsonResult = JsonConvert.SerializeObject(model.ToJqGridData(page, rows, null, search, null), new JsonDateConverter("yyyy-MM-dd"));
            return JavaScript(jsonResult);
        }

        /// <summary>
        /// 获取所有图纸（非草稿  与本人相关）
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="search"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <returns></returns>
        public ActionResult GetAllList(int page, int rows, string search, string sidx, string sord)
        {
            string filter = Request["filters"] != null ? Request["filters"] : "";
            string filterSql = "";
            if (!string.IsNullOrEmpty(filter))
            {
                filterSql = filter.BuildSearch("Bse_ComponentsModule");
                //filterSql = BulidJqGridSearch.BuildSearch(filter);
            }

            List<Bse_Components> list = new List<Bse_Components>();

            string orderby = Bll_Comm.GetOrderString(sidx, sord);

            if (string.IsNullOrEmpty(filterSql))
            {
                list = cInstance.GetAllCompList("1=1 " + orderby);
            }
            else
            {
                list = cInstance.GetAllCompList(filterSql + orderby);
            }



            var model = list.AsQueryable<Bse_Components>();
            //var result = model.ToJqGridData(page, rows, null, search, null);
            //return Json(result, JsonRequestBehavior.AllowGet);
            var jsonResult = JsonConvert.SerializeObject(model.ToJqGridData(page, rows, null, search, null), new JsonDateConverter("yyyy-MM-dd"));
            return JavaScript(jsonResult);
        }

        /// <summary>
        /// 根据客户获取对应图号的相关图纸
        /// </summary>
        /// <param name="id"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="search"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <returns></returns>
        public ActionResult GetCompListByCust(string id,string parent, int page, int rows, string search, string sidx, string sord)
        {
            string filter = Request["filters"] != null ? Request["filters"] : "";
            string filterSql = "";
            if (!string.IsNullOrEmpty(filter))
            {
                filterSql = filter.BuildSearch("Bse_ComponentsModule");
                //filterSql = BulidJqGridSearch.BuildSearch(filter);
            }

            List<Bse_Components> list = new List<Bse_Components>();

            string orderby = Bll_Comm.GetOrderString(sidx, sord);
            if (string.IsNullOrEmpty(orderby))
            {
                orderby = " order by Comp_Type";
            }

            
            //是否点击了节点
            if (!string.IsNullOrEmpty(id)) 
            {
                if (string.IsNullOrEmpty(filterSql))
                {
                    list = cInstance.GetAllCompList(id,parent, "1=1 " + orderby);
                }
                else
                {
                    list = cInstance.GetAllCompList(id,parent, filterSql + orderby);
                }
            }


            var model = list.AsQueryable<Bse_Components>();
            //var result = model.ToJqGridData(page, rows, null, search, null);
            //return Json(result, JsonRequestBehavior.AllowGet);
            var jsonResult = JsonConvert.SerializeObject(model.ToJqGridData(page, rows, null, search, null), new JsonDateConverter("yyyy-MM-dd"));
            return JavaScript(jsonResult);
        }



        public ActionResult GetMySubmitList(int page, int rows, string search, string sidx, string sord)
        {
            string filter = Request["filters"] != null ? Request["filters"] : "";
            string filterSql = "";
            if (!string.IsNullOrEmpty(filter))
            {
                filterSql = filter.BuildSearch("Bse_ComponentsModule");
                //filterSql = BulidJqGridSearch.BuildSearch(filter);
            }
            List<Bse_Components> list = new List<Bse_Components>();

            string orderby = Bll_Comm.GetOrderString(sidx, sord);
            if ("".Equals(orderby))
            {
                orderby = " order by Comp_ID desc";
            }
            if (string.IsNullOrEmpty(filterSql))
            {
                list = cInstance.GetMyCompList("1=1 " +orderby);
            }
            else
            {
                list = cInstance.GetMyCompList(filterSql+orderby);
            }

            var model = list.AsQueryable<Bse_Components>();
            //var result = model.ToJqGridData(page, rows, null, search, null);
            //return Json(result, JsonRequestBehavior.AllowGet);
            var jsonResult = JsonConvert.SerializeObject(model.ToJqGridData(page, rows, null, search, null), new JsonDateConverter("yyyy-MM-dd"));
            return JavaScript(jsonResult);
        }


        /// <summary>
        /// 获取待办图纸
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="search"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <returns></returns>
        public ActionResult GetDoingList(int page, int rows, string search, string sidx, string sord)
        {
            string filter = Request["filters"] != null ? Request["filters"] : "";
            string filterSql = "";
            if (!string.IsNullOrEmpty(filter))
            {
                filterSql = filter.BuildSearch("Bse_ComponentsModule");
                //filterSql = BulidJqGridSearch.BuildSearch(filter);
            }
            List<Bse_Components> list = new List<Bse_Components>();
            string orderby = Bll_Comm.GetOrderString(sidx, sord);
            if (string.IsNullOrEmpty(filterSql))
            {
                list = cInstance.GetNormalCompList("1=1 " + orderby);
            }
            else
            {
                list = cInstance.GetNormalCompList(filterSql + orderby);
            }

            var model = list.AsQueryable<Bse_Components>();
            //var result = model.ToJqGridData(page, rows, null, search, null);

            //return Json(result, JsonRequestBehavior.AllowGet);
            var jsonResult = JsonConvert.SerializeObject(model.ToJqGridData(page, rows, null, search, null), new JsonDateConverter("yyyy-MM-dd"));
            return JavaScript(jsonResult);
        }
        /// <summary>
        /// 获取待审
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <param name="search"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <returns></returns>
        public ActionResult GetAuditList(int page, int rows, string search, string sidx, string sord)
        {
            string filter = Request["filters"] != null ? Request["filters"] : "";
            string filterSql = "";
            if (!string.IsNullOrEmpty(filter))
            {
                filterSql = filter.BuildSearch("Bse_ComponentsModule");
                //filterSql = BulidJqGridSearch.BuildSearch(filter);
            }

            List<Bse_Components> list = new List<Bse_Components>();

            string orderby = Bll_Comm.GetOrderString(sidx, sord);

            if (string.IsNullOrEmpty(filterSql))
            {
                list = cInstance.GetAuditCompList("1=1 " + orderby);
            }
            else
            {
                list = cInstance.GetAuditCompList(filterSql + orderby);
            }

            var model = list.AsQueryable<Bse_Components>();
            //var result = model.ToJqGridData(page, rows, null, search, null);
            //return Json(result, JsonRequestBehavior.AllowGet);
            var jsonResult = JsonConvert.SerializeObject(model.ToJqGridData(page, rows, null, search, null), new JsonDateConverter("yyyy-MM-dd"));
            return JavaScript(jsonResult);
        }

        public ActionResult GetPic(string id)
        {
            var attach = dinfoInstance.GetAttachModel(id);
            if (attach != null)
            {
                return File(new FileStream(attach.Dat_Path, FileMode.Open), "text/plain", Path.GetFileName(attach.Dat_Path));
            }
            else
            {
                return null;
            }

        }

        public ActionResult GetDownload(string id)
        {
            var flag = false;

            string ftype = Request["ftype"];

            if (string.IsNullOrEmpty(ftype))
            {
                ftype = "Pic";
            }

            string filepath = string.Empty;
            string filename = string.Empty;

            List<Doc_Attachment> list = dinfoInstance.GetAttachmentListByFtype(id, ftype);

            Doc_Attachment attach = new Doc_Attachment();
            if (list.Count != 0)
            {
                //通过文件类型判断是需要下载还是查看
                attach = list.FirstOrDefault();
                var path = attach.Dat_Path;
                filepath = path;
                filename = attach.Dat_Name;
                flag = true;
            }
            else
            {
                return Content("该文件并没有维护相关图纸文件!");
            }
 //if(flag)
            if (flag && IsHavePermission(id, ftype))
            {
                if (ftype == "Pic")
                {
                    BLL.Bll_Comm.OpLog("Bse_ComponentsModule", "GetDownload", string.Format("下载图纸:{0}", id));
                    ViewData["File"] = attach.Dat_Code;
                    return View("ViewPic");
                }
                else
                {
                    BLL.Bll_Comm.OpLog("Bse_ComponentsModule", "GetDownload", string.Format("下载图纸:{0}", id));
                    return File(new FileStream(filepath, FileMode.Open), "application/x-zip-compressed", filename);
                }
            }
            else
            {
                return Content("您没有操作当前文件的权限!");
            }
        }




        /// <summary>
        /// 判断用户是否有权限查看
        /// </summary>
        /// <returns></returns>
        public bool IsHavePermission(string id, string ftype)
        {
            var model=cInstance.GetModel(string.Format("AND Comp_Code='{0}'", id));
            //如果是图纸本身的创建者则具有所有权限
            if (model != null && model.Comp_Creator == SessionConfig.UserId())
            {
                return true;
            }

            //如果是Pic则判断查看权限，否则下载权限
            string type=ftype=="Pic"?"View":"Download";

            var flag1 = this.dinfoInstance.IsHaveAllotForComp(SessionConfig.UserId(), id,type);

            return flag1;
        }

        public ActionResult GetCompHisList(string id, int page, int rows, string search, string sidx, string sord)
        {
            string filter = Request["filters"] != null ? Request["filters"] : "";
            string filterSql = "";
            if (!string.IsNullOrEmpty(filter))
            {
                filterSql = filter.BuildSearch("Bse_CompHistoryModule");
                //filterSql = BulidJqGridSearch.BuildSearch(filter);
            }
            List<Bse_CompHistory> list = new List<Bse_CompHistory>();
            if (string.IsNullOrEmpty(filterSql))
            {
                list = cInstance.GetCompHisList(id, "1=1");
            }
            else
            {
                list = cInstance.GetCompHisList(id, filterSql);
            }

            var model = list.AsQueryable<Bse_CompHistory>();
            //var result = model.ToJqGridData(page, rows, null, search, null);
            //return Json(result, JsonRequestBehavior.AllowGet);
            var jsonResult = JsonConvert.SerializeObject(model.ToJqGridData(page, rows, null, search, null), new JsonDateConverter("yyyy-MM-dd"));
            return JavaScript(jsonResult);
        }



        public ActionResult UploadImg(string code, string path, string module)
        {
            var list = cInstance.GetCompHisList(string.Format("AND CH_CompCode='{0}' AND CH_iType='File'", code));
            if (list.Count >= 1)
            {
                return new JsonResult { Data = new { result = "fail", Msg = "您已上传图纸图片，不能重复上传！" } };
            }

            string fileName = Path.GetFileName(path);
            Bse_CompHistory comp = new Bse_CompHistory();
            comp.CH_Code = cInstance.GenerateHistoryCode();
            comp.CH_Date = DateTime.Now;
            comp.CH_CompCode = code;
            comp.CH_Auditor = SessionConfig.UserId();
            comp.CH_AuditorName = SessionConfig.UserName();
            comp.CH_FilePath = path;
            comp.CH_iType = "File";
            comp.CH_Type = "上传附件";
            cInstance.AddHis(comp);
            return new JsonResult { Data = new { result = "success", Msg = "数据更新成功！" } };
        }



        public ActionResult AuditCallback(string code)
        {
            var list = cInstance.GetCompHisList(string.Format("AND CH_CompCode='{0}'", code));

            Bse_CompHistory model = list.FirstOrDefault(o => o.CH_iType == "File");

            List<Bse_CompHistory> auditHis = list.Where(o => o.CH_iType != "File").ToList();

            if (model != null)
            {
                try
                {
                    var d = System.IO.Path.GetTempPath();
                    //var d = @"E:\运营方案";
                    string filename = Path.GetFileName(model.CH_FilePath);
                    string temp = Server.MapPath(model.CH_FilePath);
                    string srcpath = temp;
                    string despath = Path.Combine(d, filename);

                    ThumNail.AddWaterWord(string.Format("{0} {1}", SessionConfig.UserName(), DateTime.Now.ToString("yy-MM-dd hh:mm")), srcpath, despath, 10, auditHis.Count * 30);
                    //如果存在则表示生成成功
                    if (System.IO.File.Exists(despath))
                    {
                        System.IO.File.Copy(despath, srcpath, true);
                        System.IO.File.Delete(despath);
                    }

                }
                catch (Exception ex)
                {
                    return new JsonResult { Data = new { result = "fail", Msg = ex.Message } };
                }

                Bse_CompHistory newModel = new Bse_CompHistory();
                newModel.CH_Code = cInstance.GenerateHistoryCode();
                newModel.CH_CompCode = model.CH_CompCode;
                newModel.CH_FilePath = model.CH_FilePath;
                newModel.CH_Auditor = SessionConfig.UserId();
                newModel.CH_AuditorName = SessionConfig.UserName();
                newModel.CH_Date = DateTime.Now;
                newModel.CH_iType = "His";
                newModel.CH_Type = "审核";
                cInstance.AddHis(newModel);

                return new JsonResult { Data = new { result = "success", Msg = "数据更新成功！" } };
            }
            else
            {
                return new JsonResult { Data = new { result = "fail", Msg = "请上传图纸文件图片！" } };
            }


        }

    }
}
