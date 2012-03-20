using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QX.Model;
namespace QX.BLL
{
    public partial class Bll_Equ_MPlan
    {
        /// <summary>
        /// 新增或更新对象
        /// </summary>
        /// <param name="Mn"></param>
        /// <returns></returns>
        public bool AddUpdatePlanObject(Equ_MPlan Mn)
        {
            if (Mn.MP_ID.Equals(0))
            {
                return instance.Add(Mn).Equals(1);
            }
            else
            {
                return instance.Update(Mn).Equals(1);
            }
        }
    }
}
