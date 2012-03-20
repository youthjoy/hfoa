
                                    using System;
                                    using System.Collections.Generic;
                                    using System.Linq;
                                    using System.Text;
                                    using QX.DAL;
                                    using QX.Model;
                                    using QX.Comm;
                                    
namespace QX.BLL
{
   /// <summary>
   /// 路线规划明细
   /// </summary>
   [Serializable]
   public partial class Bll_SD_Route
   {

        private ADOSD_Route instance = new ADOSD_Route();

        /// <summary>
        /// 获取所有的信息
        /// </summary>
        /// <returns>list</returns>
        public List<SD_Route> GetAll()
        {
            List<SD_Route> list = instance.GetAll();
            return list;
        }
             
        /// <summary>
        /// 根据条件获取List
        /// </summary>
        /// <param name='strCondition'>条件(' AND Code='11'')</param>
        /// <returns>list</returns>
        public List<SD_Route> GetListByCode(string strCondition)
        {
            return instance.GetListByWhere(strCondition);
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name='model'>实体</param>
        /// <returns>bool</returns>
        public bool Insert(SD_Route model)
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
        /// 插入数据
        /// </summary>
        /// <param name='model'>实体</param>
        /// <param name='model'>是否完成验证</param>
        /// <returns>bool</returns>
        public bool Insert(SD_Route model,bool IsValid)
        { 
            var e = new ModelExceptions();
            bool result = false;
            if (e.IsValid && IsValid)
            {
                //完成了验证，开始更新数据库了
                int _result = instance.Add(model);
                if (_result > 0)
                {
                    result = true;
                }               
            }
            return result;
        }        
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name='strCondition'>条件(AND Code='11')</param>
        /// <returns>model</returns>
        public SD_Route GetModel(string strCondition)
        {
            List<SD_Route> list = instance.GetListByWhere(strCondition);
            SD_Route model = new SD_Route();
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
        /// 获取实体数据
        /// </summary>
        /// <param name='strCondition'>条件(AND Code='11')</param>
        /// <returns>model</returns>
        public SD_Route GetModel(int id)
        {
            SD_Route model = instance.GetByKey(id);          
            return model;
        }    

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name='model'>实体</param>
        /// <returns>bool</returns>
        public bool Update(SD_Route model)
        {            
            bool result = false;
            var e = new ModelExceptions();
            int _rseult = instance.Update(model);
            if (_rseult > 0)
            {
                result = true;
            }
            return result;
        }   

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name='model'>实体</param>
        /// <returns>bool</returns>
        public bool Update(SD_Route model,bool IsValid)
        {
            
            bool result = false;
            var e = new ModelExceptions();
            if(e.IsValid && IsValid){
                int _rseult = instance.Update(model);
                if (_rseult > 0)
                {
                    result = true;
                }
            }
            return result;
        }
        /// <summary>
        /// 逻辑删除数据
        /// </summary>
        /// <param name='model'>model</param>
        /// <returns>bool</returns>
        public bool Delete(string Condition)
        {
            bool result = false;
            List<SD_Route> list = instance.GetListByWhere(Condition);
            if (list.Count > 0)
            {
                SD_Route model = list[0];
                model.Stat = 1;
                int _rseult = instance.Update(model);
                if (_rseult > 0)
                {
                    result = true;
                }
            }
            return result;
        }
           }
}
