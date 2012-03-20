using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QX.DAL;
using QX.Model;
using QX.Comm;
namespace QX.BLL
{
    public partial class Bll_BSE_SysInfo
    {
       
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name='strCondition'>条件(AND Code='11')</param>
        /// <returns>model</returns>
        public BSE_SysInfo GetModels(string strCondition)
        {
            string where = string.Format(" AND Sys_code='{0}'", strCondition);
            List<BSE_SysInfo> list = instance.GetListByWhere(where);
            BSE_SysInfo model = new BSE_SysInfo();
            if (list != null && list.Count > 0)
            {
                model = list[0];
            }
            else
            {
                model = null;
            }
            return model;
        }
    }

}
