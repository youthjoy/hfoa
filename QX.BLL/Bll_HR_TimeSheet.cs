using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using QX.DAL;
using QX.Model;

namespace QX.BLL
{
    public partial class Bll_HR_TimeSheet
    {
        private Bll_HR_Department deptInstance = new Bll_HR_Department();

        public List<HR_TimeSheet> GetTimeSheetByCode(string code)
        {
            string where = string.Format(" AND TS_StuffCode='{0}'", code);
            List<HR_TimeSheet> list = instance.GetListByWhere(where);
            return list;
        }



        public HR_TimeSheet GetModelByCode(string code)
        {
            return GetModel(string.Format("AND TS_Code='{0}'", code));
        }
        public List<HR_TimeSheet> GetTimeSheettree(string code)
        {
            List<HR_Department> list = deptInstance.GetLevelDeptListWidthSeft(code);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                var d = list[i];
                sb.AppendFormat("'{0}',", d.Dept_Code);
            }
            string where = string.Format("  AND Stuff_DepCode in ({0})", sb.ToString().Trim().TrimEnd(','));
            List<HR_TimeSheet> listS = new DAL.ADODeptEmployee_Relation().GetListByWhereKq(where);
            return listS;

        }
        public List<HR_In> GetTimeSheettreeZW(string code)
        {
            List<HR_Department> list = deptInstance.GetLevelDeptListWidthSeft(code);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                var d = list[i];
                sb.AppendFormat("'{0}',", d.Dept_Code);
            }
            string where = string.Format("  AND Stuff_DepCode in ({0})", sb.ToString().Trim().TrimEnd(','));
            List<HR_In> listS = new DAL.ADODeptEmployee_Relation().GetListByWhereZW(where);
            return listS;

        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateModel(HR_TimeSheet model)
        {
            bool result = false;
            int _rseult = instance.Update(model);
            if (_rseult > 0)
            {
                result = true;
            }
            return result;
        }
      
    }
}
