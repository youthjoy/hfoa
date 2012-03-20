using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QX.DAL;
using QX.Model;

namespace QX.BLL
{
    [Serializable]
    public partial class BLL_Invoice_Operate
    {
        private ADOWH_Invoice instance = new ADOWH_Invoice();
        public bool AddUpdatePlanObject(WH_Invoice info)
        {
            int result = 0;
            if (info != null)
            {
                if (info.WHI_ID.Equals(0))
                {
                    result = instance.Add(info);
                }
                else
                {
                    result = instance.Update(info);
                }
            }
            return result > 0 ? true : false;
        }
    }
}
