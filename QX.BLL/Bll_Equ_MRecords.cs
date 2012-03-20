using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QX.Model;
namespace QX.BLL
{
    public partial class Bll_Equ_MRecords
    {
        /// <summary>
        /// 新增或者更新
        /// </summary>
        /// <param name="Es"></param>
        /// <returns></returns>
        public bool AddOrUpdateObject(Equ_MRecords Es)
        {
            if (Es.MR_ID.Equals(0))
            {
                return instance.Add(Es).Equals(1);
            }
            else
                return instance.Update(Es).Equals(1);
        }
    }
}
