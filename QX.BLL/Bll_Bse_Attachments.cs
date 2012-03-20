using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QX.DAL;
using QX.Model;
using QX.Comm;

namespace QX.BLL
{
   public partial  class Bll_Bse_Attachments
    {
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name='strCondition'>条件(AND Code='11')</param>
        /// <returns>model</returns>
       public Bse_Attachments GetModels(string strCondition)
        {
            string where = string.Format(" AND AT_CDate='{0}'", strCondition);
            List<Bse_Attachments> list = instance.GetListByWhere(where);
            Bse_Attachments model = new Bse_Attachments();
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
       /// <summary>
       /// 新增或更新对象
       /// </summary>
       /// <param name="Mn"></param>
       /// <returns></returns>
       public bool AddUpdatePlanObject(Bse_Attachments info)
       {
           int result = 0;
          
           if (info != null)
           {
               if (info.AT_ID.Equals(0))
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

