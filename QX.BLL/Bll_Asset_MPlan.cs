
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QX.DAL;
using QX.Model;
using QX.Comm;
namespace QX.BLL
{
    public partial class Bll_Asset_MPlan
    {
        /// <summary>
        /// 根据条件获取List
        /// </summary>
        /// <param name='strCondition'>条件(' AND Code='11'')</param>
        /// <returns>list</returns>
        public List<Asset_MPlan> GetListByCode(string strCondition,int A)
        {
            return instance.GetListByWhere(strCondition, A);
        }

    }
}
