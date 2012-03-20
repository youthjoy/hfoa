using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QX.DAL;
using QX.Model;

namespace QX.BLL
{
    [Serializable]
    public partial class Bll_Menus_Operate
    {
        private ADOSystem_Menu instance = new ADOSystem_Menu();
        public bool AddUpdatePlanObject(System_Menu info)
        {
            int result = 0;
            if (info != null)
            {
                if (info.Menu_ID.Equals(0))
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
