using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QX.Comm;
using QX.Model;

namespace QX.BLL
{
   public partial class Bll_Document_Manage
    {
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name='model'>实体</param>
        /// <returns>bool</returns>
        public bool Update(Document_Manage model,int A)
        {
            bool result = false;
            var e = new ModelExceptions();
            int _rseult = instance.Update(model, A);
            if (_rseult > 0)
            {
                result = true;
            }
            return result;
        }   
    }
}
