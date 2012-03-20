using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QX.DAL;
using QX.Model;

namespace QX.BLL
{
    [Serializable]
    public partial class Bll_Menus_Move
    {
        private ADOSystem_Menu instance = new ADOSystem_Menu();
        /// <summary>
        /// 排序 - 向上
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ln">LINENO</param>
        public void sortUp(string id)
        {
           // ADOSystem_Menu.sortUp(id);
            //string sql = " SELECT TOP 1 menu_id,Menu_Order FROM  system_menu WHERE Menu_Order<" + int.Parse(id.Split(',')[1]) + " AND Menu_Location='top' ORDER BY Menu_Order";
            string[] ids = id.Split(',');
            if (ids.Count()>0)
            {
                string filter = @"Menu_Order<{0} AND Menu_Location='top' ORDER BY Menu_Order ";
                List<System_Menu> list = instance.GetListByWhere(string.Format(filter, ids[1]));
                System_Menu firstModel = list[0];

                System_Menu F1_Model = instance.GetByKey(int.Parse(ids[0]));
                //System_Menu F2_Model = instance.GetByKey(int.Parse(ids[1]));
                
            }
        }

        /// <summary>
        /// 排序 - 向下
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ln">LINENO</param>
        /// <param name="id1">/param>
        public static void sortDown(string id)
        {
            ADOSystem_Menu.sortDown(id);
        }

      
    }
}
