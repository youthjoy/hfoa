using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QX.DAL;
using QX.Model;

namespace QX.BLL
{
    public partial class Bll_HR_Benefit
    {
       

        public List<HR_Benefit> GetBenefitListByCode(string code)
        {
            string where = string.Format(" AND HRB_ECode='{0}'", code);
            List<HR_Benefit> list = instance.GetListByWhere(where);
            return list;
        }

        public HR_Benefit GetModelByCode(string code)
        {
            return GetModel(string.Format("AND HRB_Code='{0}'", code));
        }


        /// <summary>
        /// 新增或更新对象
        /// </summary>
        /// <param name="Mn"></param>
        /// <returns></returns>
        public bool AddUpdatePlanObject(HR_Benefit ev)
        {
            if (ev.HRB_ID.Equals(0))
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
