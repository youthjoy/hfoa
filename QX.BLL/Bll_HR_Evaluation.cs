using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QX.DAL;
using QX.Model;

namespace QX.BLL
{
    public partial class Bll_HR_Evaluation
    {

        public List<HR_Evaluation> GetEvaluationListByCode(string code)
        {
            string where = string.Format(" AND Eva_StuffCode='{0}'", code);
            List<HR_Evaluation> list = instance.GetListByWhere(where);
            return list;
        }


        public HR_Evaluation GetModelByCode(string code)
        {
            return GetModel(string.Format("AND Eva_Code='{0}'", code));
        }
        /// <summary>
        /// 新增或更新对象
        /// </summary>
        /// <param name="Mn"></param>
        /// <returns></returns>
        public bool AddUpdatePlanObject(HR_Evaluation ev)
        {
            if (ev.Eva_ID.Equals(0))
            {
                return instance.Add(ev).Equals(0);
            }
            else
            {
                return instance.Update(ev).Equals(1);
            }
        }
    }
}
