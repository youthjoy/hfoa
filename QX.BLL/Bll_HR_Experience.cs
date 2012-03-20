using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QX.DAL;
using QX.Model;
using QX.Comm;

namespace QX.BLL
{
    public partial class Bll_HR_Experience
    {

        public List<HR_Experience> GetExperienceListByCode(string code)
        {
            string where = string.Format(" AND EXa_StuffCode='{0}'", code);
            List<HR_Experience> list = instance.GetListByWhere(where);
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="type">经历类型 （工作经历）</param>
        /// <returns></returns>
        public List<HR_Experience> GetExperienceListByType(string code)
        {
            string where = string.Format(" AND EXa_StuffCode='{0}' and  EXa_type='{1}'", code, "PersonEx");
            List<HR_Experience> list = instance.GetListByWhere(where);
            return list;
        }
        /// <summary>
        /// 经历类型 （工作经历）
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<HR_Experience> GetExperienceListByTypeJL(string code)
        {
            string where = string.Format(" AND  EXa_type='{1}'", code, "PersonEx");
            List<HR_Experience> list = instance.GetListByWhere(where);
            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="type">经历类型 （工作经历）</param>
        /// <returns></returns>
        public List<HR_Experience> GetExperienceListByTypeJY(string code)
        {
            string where = string.Format(" AND EXa_StuffCode='{0}' and  EXa_type='{1}'", code, "Education");
            List<HR_Experience> list = instance.GetListByWhere(where);
            return list;
        }
        /// <summary>
        /// 经历类型 （工作经历）
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<HR_Experience> GetExperienceListByTypeJYCOUNT(string code)
        {
            string where = string.Format(" AND  EXa_type='{1}'", code, "Education");
            List<HR_Experience> list = instance.GetListByWhere(where);
            return list;
        }
        public HR_Experience GetModelByCode(string code)
        {
            return GetModel(string.Format("AND EXa_Code='{0}'", code));
        }
        /// <summary>
        /// 新增或更新对象
        /// </summary>
        /// <param name="Mn"></param>
        /// <returns></returns>
        public bool AddUpdatePlanObject(HR_Experience Mn,string type)
        {
            if (Mn.EX_ID.Equals(0))
            {
                Mn.EX_Type = type;
                return instance.Add(Mn).Equals(1);
            }
            else
            {
                return instance.Update(Mn).Equals(1);
            }
        }
        /// <summary>
        /// 新增或更新对象
        /// </summary>
        /// <param name="Mn"></param>
        /// <returns></returns>
        public bool AddUpdatePlanObjectJY(HR_Experience Mnjy)
        {
            if (Mnjy.EX_ID.Equals(0))
            {
                Mnjy.EX_Type = "Education";
                return instance.Add(Mnjy).Equals(1);
            }
            else
            {
                return instance.Update(Mnjy).Equals(1);
            }
        }

    }
}
