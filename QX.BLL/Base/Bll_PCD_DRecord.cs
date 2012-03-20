
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
   /// 异常记录
   /// </summary>
   [Serializable]
   public partial class Bll_PCD_DRecord
   {

        private ADOPCD_DRecord instance = new ADOPCD_DRecord();

        /// <summary>
        /// 获取所有的信息
        /// </summary>
        /// <returns>list</returns>
        public List<PCD_DRecord> GetAll()
        {
            List<PCD_DRecord> list = instance.GetAll();
            return list;
        }
             
        /// <summary>
        /// 根据条件获取List
        /// </summary>
        /// <param name='strCondition'>条件(' AND Code='11'')</param>
        /// <returns>list</returns>
        public List<PCD_DRecord> GetListByCode(string strCondition)
        {
            return instance.GetListByWhere(strCondition);
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name='model'>实体</param>
        /// <returns>bool</returns>
        public bool Insert(PCD_DRecord model)
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
        public bool Insert(PCD_DRecord model,bool IsValid)
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
        public PCD_DRecord GetModel(string strCondition)
        {
            List<PCD_DRecord> list = instance.GetListByWhere(strCondition);
            PCD_DRecord model = new PCD_DRecord();
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
        public PCD_DRecord GetModel(int id)
        {
            PCD_DRecord model = instance.GetByKey(id);          
            return model;
        }    

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name='model'>实体</param>
        /// <returns>bool</returns>
        public bool Update(PCD_DRecord model)
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
        public bool Update(PCD_DRecord model,bool IsValid)
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
            List<PCD_DRecord> list = instance.GetListByWhere(Condition);
            if (list.Count > 0)
            {
                PCD_DRecord model = list[0];
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
