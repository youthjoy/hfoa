using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QX.DAL;
using QX.Model;

namespace QX.BLL
{
    public partial class Bll_HR_AA
    {

        public List<HR_AA> GetAAListByCode(string code)
        {
            string where = string.Format(" AND AA_ECde='{0}'", code);
            List<HR_AA> list = instance.GetListByWhere(where);
            return list;
        }





        public HR_AA GetModelByCode(string code)
        {
            return GetModel(string.Format("AND AA_ICode='{0}'", code));
        }

    }
}
