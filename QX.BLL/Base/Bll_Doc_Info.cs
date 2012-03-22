
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QX.DAL;
using QX.Model;
using QX.Comm;

namespace QX.BLL
{
    /// <summary>
    /// 文档信息
    /// </summary>
    [Serializable]
    public partial class Bll_Doc_Info
    {

        private ADODoc_Info instance = new ADODoc_Info();

        private ADODoc_Attachment aInstance = new ADODoc_Attachment();

        #region 公文

        /// <summary>
        /// 获取所有的信息
        /// </summary>
        /// <returns>list</returns>
        public List<Doc_Info> GetAll()
        {
            List<Doc_Info> list = instance.GetAll();
            return list;
        }

        /// <summary>
        /// 根据条件获取List
        /// </summary>
        /// <param name='strCondition'>条件(' AND Code='11'')</param>
        /// <returns>list</returns>
        public List<Doc_Info> GetListByCode(string strCondition)
        {
            return instance.GetListByWhere(strCondition);
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name='model'>实体</param>
        /// <returns>bool</returns>
        public bool Insert(Doc_Info model)
        {
            bool result = false;
            try
            {
                int _result = instance.Add(model);
                if (_result > 0)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name='model'>实体</param>
        /// <param name='model'>是否完成验证</param>
        /// <returns>bool</returns>
        public bool Insert(Doc_Info model, bool IsValid)
        {
            var e = new ModelExceptions();
            bool result = false;
            if (e.IsValid && IsValid)
            {
                //完成了验证，开始更新数据库了
                int _result = instance.Add(model);
                if (_result > 0)
                {
                    result = true;
                }
            }
            return result;
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name='strCondition'>条件(AND Code='11')</param>
        /// <returns>model</returns>
        public Doc_Info GetModel(string strCondition)
        {
            List<Doc_Info> list = instance.GetListByWhere(strCondition);
            Doc_Info model = new Doc_Info();
            if (list != null && list.Count > 0)
            {
                model = list[0];
            }
            else
            {
                model = null;
            }
            return model;
        }

        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name='strCondition'>条件(AND Code='11')</param>
        /// <returns>model</returns>
        public Doc_Info GetModel(int id)
        {
            Doc_Info model = instance.GetByKey(id);
            return model;
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name='model'>实体</param>
        /// <returns>bool</returns>
        public bool Update(Doc_Info model)
        {
            bool result = false;
            var e = new ModelExceptions();
            int _rseult = instance.Update(model);
            if (_rseult > 0)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name='model'>实体</param>
        /// <returns>bool</returns>
        public bool Update(Doc_Info model, bool IsValid)
        {

            bool result = false;
            var e = new ModelExceptions();
            if (e.IsValid && IsValid)
            {
                int _rseult = instance.Update(model);
                if (_rseult > 0)
                {
                    result = true;
                }
            }
            return result;
        }
        /// <summary>
        /// 逻辑删除数据
        /// </summary>
        /// <param name='model'>model</param>
        /// <returns>bool</returns>
        public bool Delete(string Condition)
        {
            bool result = false;
            List<Doc_Info> list = instance.GetListByWhere(Condition);
            if (list.Count > 0)
            {
                Doc_Info model = list[0];
                model.Stat = 1;
                int _rseult = instance.Update(model);
                if (_rseult > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        #endregion

        #region 附件

        public List<Doc_Attachment> GetAttachmentList(string module,string refCode,string filter)
        {
            string where = string.Format(" AND Dat_Module='{0}' AND Dat_RefCode='{1}' AND {2}",module,refCode,filter);
            return aInstance.GetListByWhere(where);
        }


        public List<Doc_Attachment> GetAttachmentList(string where)
        {
            return aInstance.GetListByWhere(where);
        }

        /// <summary>
        /// 根据不同的模式获取该模式对应的文件列表（下载或查看）
        /// </summary>
        /// <param name="refcode"></param>
        /// <param name="ftype"></param>
        /// <returns></returns>
        public List<Doc_Attachment> GetAttachmentListByFtype(string refcode,string ftype)
        {
            List<Doc_Attachment> list = new List<Doc_Attachment>();

            //如果是查看则获取图片类型
            //if (ftype == "Pic")
            //{
                //var view = ConfigHelper.GetApp("FileExtention");
                //var views = view.Split(',');
                //StringBuilder sb = new StringBuilder();
                //foreach (var d in views)
                //{
                //    sb.AppendFormat("'{0}',", d);
                //}
                list = GetAttachmentList(string.Format("AND DAT_Code='{0}' ", refcode));
            //}//如果是下载则获取下载类型
            //else
            //{
                //var download = ConfigHelper.GetApp("DownloadExtention");
                //var downloads = download.Split(',');
                //StringBuilder sb = new StringBuilder();
                //foreach (var d in downloads)
                //{
                //    sb.AppendFormat("'{0}',", d);
                //}
               // list = GetAttachmentList(string.Format("AND DAT_Code='{0}' AND DAT_Type in ({1})", refcode, sb.ToString().TrimEnd(',')));
          //  }

            return list;
        }

        public Doc_Attachment GetAttachModel(string code)
        {
            return aInstance.GetListByWhere(string.Format("AND Dat_Code='{0}'", code)).FirstOrDefault();
        }

        public string GenerateAttachmentCode()
        {
            return comInstance.GetTableKeyCode("Doc_Attachment");
        }

        public bool AddAttachment(Doc_Attachment model)
        {
            if (aInstance.Add(model) > 0)
            {
                return true;
            }

            return false;
        }

        public bool UpdateAttachment(Doc_Attachment model)
        {
            if (aInstance.Update(model) > 0)
            {
                return true;
            }

            return false;
        }

        public bool DelAttachment(Doc_Attachment model)
        {
            model.Stat = 1;
            if (aInstance.Update(model) > 0)
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
