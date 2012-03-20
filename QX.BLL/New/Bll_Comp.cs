using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QX.Model;
using QX.DAL;
using QX.Comm;
using QX.Config;
using QX.ERP.DAL;

namespace QX.BLL
{
    public class Bll_Comp
    {
        private ADOBse_Components cInstance = new ADOBse_Components();
        private ADOBse_CompHistory chInstance = new ADOBse_CompHistory();

        private ADOSD_Customer sdInstance = new ADOSD_Customer();

        private Bll_Comm comInstance = new Bll_Comm();

        public List<Bse_Components> GetCompDraftList(string filter)
        {
            List<Bse_Components> list = new List<Bse_Components>();
            string where = string.Format(" AND Comp_Stat='{0}' AND Comp_Creator ='{1}' AND {2} ", "Draft", SessionConfig.UserId(), filter, AllotType.Distribution.ToString());
            return cInstance.GetListByWhere(where);
        }

        public Bse_Components GetModel(string where)
        {
            return cInstance.GetListByWhere(where).FirstOrDefault();
        }

        private Bll_Audit auditInstance = new Bll_Audit();

       

        public List<SD_Customer> GetCustomerList(string where)
        {
            return sdInstance.GetListByWhere(string.Format("AND {0} AND Cust_Type='GCustomer'", where));
        }

        public List<TheTreeNode> GenerateCompTree()
        {
            //获取客户列表-->转换成TheTreeNode
            List<SD_Customer> list = sdInstance.GetListByWhere(string.Format(" AND Cust_Type='GCustomer'"));
            List<Bse_Components> compList = cInstance.GetAll();
            List<TheTreeNode> root = (from c in list select new TheTreeNode {parent="", state = c.Cust_Code, data = c.Cust_Name }).ToList();

            foreach (var c in root)
            {
                GenerateChild(c, compList);
            }

            //获取客户图号列表-->转换成TheTreeNode
            return root;
        }

        private void GenerateChild(TheTreeNode dict, List<Bse_Components> allData)
        {
            dict.childrenenum = (from c in allData where c.Comp_Customer == dict.state select new TheTreeNode {parent=dict.state, state = c.Comp_CCode, data = c.Comp_CCode }).Distinct(o => o.state).ToList();

            //if (dict.childrenenum.Count() == 0)
            //{
            //    return;
            //}

            //foreach (var d in dict.childrenenum)
            //{
            //    GenerateChild(d, allData);
            //}
        }



        /// <summary>
        /// 获取文档列表（不是草稿状态的代办)--已审核，但未进一步操作的（比如分发）
        /// </summary>
        /// <returns></returns>
        public List<Bse_Components> GetNormalCompList(string where)
        {
            string condition = string.Format(" AND AuditStat ='{3}' AND Comp_Stat='{0}'AND DA_Allot='{2}' AND DA_Module='{4}' AND DA_iType='{5}' AND {1}", "Normal", where, SessionConfig.UserId(), AudtiOperaTypeEnum.LastAudit.ToString(), "Bse_ComponentsModule", AllotType.Distribution.ToString());
            return cInstance.GetListByWhereExtend(condition);
        }

        public List<Bse_Components> GetCCNormalCompList(string where)
        {
            string condition = string.Format(" AND Comp_Stat='{0}'AND DA_Allot='{2}' AND DA_Module='{3}' AND DA_iType='{4}' AND {1}", "Normal", where, SessionConfig.UserId(), "Bse_ComponentsModule", AllotType.CC.ToString());
            return cInstance.GetListByWhereExtend(condition);
        }

        /// <summary>
        /// 获取与用户相关的所有图纸（可以查看的（分发、审核））
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<Bse_Components> GetAllCompList(string where)
        {
            //string condition = string.Format("AND isnull(Comp_Stat,'')='{0}' AND {1}", "Normal", where);
            // return cInstance.GetListByWhere(condition);

            //所有文档
            List<Bse_Components> allList = new List<Bse_Components>();
            List<Bse_Components> list = new List<Bse_Components>();
            string condition = string.Format("AND isnull(Comp_Stat,'')='{0}'  AND (Comp_Code in (select DA_DocCode from doc_allot where da_allot='{2}' and isnull(da_ishandle,'NoHandle')='{3}')) AND {1}", DocStat.Normal.ToString(), where, SessionConfig.UserId(), "Handle");
            list = cInstance.GetListByWhere(condition);
            List<Verify_TemplateConfig> rlNodes = auditInstance.GetVerifyNodesByCurUser(AuditModuleEnum.DocumentAudit.ToString(), SessionConfig.UserId());

            if (rlNodes.Count != 0)
            {
                var list2 = cInstance.GetListByWhere(string.Format("AND Comp_Stat='{0}' AND {1}", "Normal", where));
                allList = list.Union(list2).Distinct(o => o.Comp_Code).ToList();
            }

            return allList;
        }

        /// <summary>
        /// 获取图号以及客户相关的图纸列表(id是图号或者客户编号)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<Bse_Components> GetAllCompList(string id,string parent, string where)
        {

            //客户
            List<Bse_Components> allList = new List<Bse_Components>();
            //图号
            List<Bse_Components> list = new List<Bse_Components>();

            if (!string.IsNullOrEmpty(parent))
            {
                //获取图号相关图纸
                string condition = string.Format("AND isnull(Comp_Stat,'')='{0}' AND Comp_CCode='{2}' AND Comp_Customer='{3}'  AND {1}", DocStat.Normal.ToString(), where, id, parent);
                list = cInstance.GetListByWhere(condition);
                return list;

            }

            //否则返回客户相关图号的所有图纸
            var list2 = cInstance.GetListByWhere(string.Format("AND Comp_Stat='{0}' AND Comp_Customer='{2}' AND {1}", "Normal", where, id));
            return list2;
        }


        /// <summary>
        /// 获取用户相关已提交图纸
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<Bse_Components> GetMyCompList(string where)
        {
            //string condition = string.Format("AND isnull(Comp_Stat,'')='{0}' AND {1}", "Normal", where);
            // return cInstance.GetListByWhere(condition);

            //所有文档
            // List<Bse_Components> allList = new List<Bse_Components>();
            List<Bse_Components> list = new List<Bse_Components>();
            string condition = string.Format("AND isnull(Comp_Stat,'')='{0}' AND Comp_Creator='{1}' AND {2}", "Normal", SessionConfig.UserId(), where);
            list = cInstance.GetListByWhere(condition);
            // List<Verify_TemplateConfig> rlNodes = auditInstance.GetVerifyNodesByCurUser(AuditModuleEnum.CompAudit.ToString(), SessionConfig.UserId());

            return list;
        }

        public List<Bse_Components> GetAuditCompList(string where)
        {
            string filterSql = auditInstance.GetAuditFilterWhere(AuditModuleEnum.CompAudit.ToString(), SessionConfig.UserId());
            string condition = string.Format("AND Comp_Stat='{0}' AND AuditStat<>'LastAudit'  AND {2} AND {1}", "Normal", where, filterSql);
            return cInstance.GetListByWhere(condition);
        }

        public string GenerateCompCode()
        {
            return comInstance.GetTableKeyCode("Bse_Components");
        }

        public bool AddComp(Bse_Components model)
        {
            if (cInstance.Add(model) > 0)
            {
                return true;
            }

            return false;
        }

        public bool UpdateComp(Bse_Components model)
        {
            if (cInstance.Update(model) > 0)
            {
                return true;
            }

            return false;
        }

        public bool DeleteComp(Bse_Components model)
        {
            model.Stat = 1;
            if (cInstance.Update(model) > 0)
            {
                return true;
            }

            return false;
        }

        #region 图纸情况跟踪

        public List<Bse_CompHistory> GetCompHisList(string id, string where)
        {

            //return chInstance.GetListByWhere(string.Format("AND CH_CompCode='{1}' AND isnull(CH_iType,'')<>'File' AND {0}", where, id));
            return chInstance.GetListByWhere(string.Format("AND CH_CompCode='{1}'  AND {0}", where, id));
        }


        public List<Bse_CompHistory> GetCompHisList(string where)
        {
            return chInstance.GetListByWhere(where);
        }

        public Bse_CompHistory GetHisModel(string where)
        {
            return chInstance.GetListByWhere(where).FirstOrDefault();
        }

        public string GenerateHistoryCode()
        {
            return comInstance.GetTableKeyCode("Bse_CompHistory");
        }

        public bool AddHis(Bse_CompHistory model)
        {
            if (chInstance.Add(model) > 0)
            {
                return true;
            }

            return false;

        }

        public bool UpdateHis(Bse_CompHistory model)
        {
            if (chInstance.Update(model) > 0)
            {
                return true;
            }

            return false;

        }
        #endregion
    }
}
