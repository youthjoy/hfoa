using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QX.DAL;
using QX.Model;

namespace QX.BLL
{
    public partial class Bll_Audit_Template
    {

        public Audit_Template GetModelByCode(string code)
        {
            return GetModel(string.Format("AND Template_Code='{0}'", code));
            //return null;
        }

    }
}
