using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QX.DAL;
using QX.Model;

namespace QX.BLL
{
    public partial class Bll_HR_In
    {

    

        /// <summary>
        /// 根据员工编码获取其财务信息
        /// </summary>
        /// <param name="employCode"></param>
        /// <returns></returns>
        public List<HR_In> GetEmployeeFinanceByECode(string employCode)
        {
            string where = string.Format(" AND HM_ECode='{0}'",employCode);
            List<HR_In> list = instance.GetListByWhere(where);
            return list;
        }
        public HR_In GetModelByCode(string code)
        {
            return GetModel(string.Format("AND HM_InCode='{0}'", code));
        }
        
   
    }
}
