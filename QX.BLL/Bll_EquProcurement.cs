using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QX.DAL;
using QX.Model;
using QX.Comm;

namespace QX.BLL
{
    public class Bll_EquProcurement
    {
        private ADOWH_Movement instance = new ADOWH_Movement();

        /// <summary>
        /// 获取所有的信息
        /// </summary>
        /// <returns></returns>
        public List<WH_Movement> GetAll()
        {
            List<WH_Movement> list = instance.GetAll();
            return list;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Insert(WH_Movement model)
        {
            bool result = false;
            try
            {
                int _result = instance.Add(model);
                if (_result > 0)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="strCondition"></param>
        /// <returns></returns>
        public WH_Movement GetModel(string strCondition)
        {
            List<WH_Movement> list = instance.GetListByWhere(strCondition);
            WH_Movement model = new WH_Movement();
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
        /// 更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(WH_Movement model)
        {
            bool result = false;
            int _rseult = instance.Update(model);
            if (_rseult > 0)
            {
                result = true;
            }
            return result;
        }
        /// <summary>
        /// 逻辑删除数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(string Code)
        {
            bool result = false;
            List<WH_Movement> list = instance.GetListByWhere(" AND Menu_Code='" + Code + "'");
            if (list.Count > 0)
            {
                WH_Movement model = list[0];
                //model.Stat = 1;
                int _rseult = instance.Update(model);
                if (_rseult > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// 获取菜单数据
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public List<WH_Movement> GetMenu(MenuLocation location)
        {
            List<WH_Movement> list = instance.GetListByWhere("  AND Menu_Location='" + location.ToString() + "' AND Menu_Enable='Enable' ORDER BY Menu_Order ASC ");
            return list;
        }

    }
}
