using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QX.DAL;
using QX.Model;

namespace QX.BLL
{
    public partial class Bll_Equ_Information
    {
        /// <summary>
        /// 新增设备信息
        /// </summary>
        /// <param name="newEqu"></param>
        /// <returns></returns>
        public bool AddNewEquInfomation(Equ_Information newEqu)
        {
            if (newEqu.EquInfo_ID.Equals(0))
            {
                return instance.Add(newEqu).Equals(1);
            }
            else
                return instance.Update(newEqu).Equals(1);
        }
    }
}
