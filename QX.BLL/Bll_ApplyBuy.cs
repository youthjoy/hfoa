using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QX.DAL;
using QX.Model;
using QX.Comm;
using QX.Comm.Utils;

namespace QX.BLL
{
    public class Bll_ApplyBuy
    {
        public ADOApplyBuy instance = new ADOApplyBuy();

        public bool InsertOrUpdateApplyBuy(List<WH_ApplyBuy> detail)
        {
            bool result = false;

            result = instance.InsertOrUpdateApplyBuy(detail);

            return result;
        }

        public List<WH_ApplyBuy> GetApplyBuyDetailByVendor(string code,string auditStat)
        {
            return instance.GetApplyBuyDetailByVender(code, auditStat);
        }
    }
}
