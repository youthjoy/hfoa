
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QX.DAL;
using QX.Model;
using QX.Comm;
namespace QX.BLL
{
   [Serializable]
   public partial class Bll_DeptEmployee_Relation
   {

       private ADODeptEmployee_Relation instance = new ADODeptEmployee_Relation();

       ///// <summary>
       ///// 获取所有的信息
       ///// </summary>
       ///// <returns>list</returns>
       //public List<DeptEmployee_Relation> GetAll()
       //{
       //    List<DeptEmployee_Relation> list = instance.GetAll();
       //    return list;
       //}

       ///// <summary>
       ///// 根据条件获取List
       ///// </summary>
       ///// <param name='strCondition'>条件(' AND Code='11'')</param>
       ///// <returns>list</returns>
       //public List<DeptEmployee_Relation> GetListByCode(string strCondition)
       //{
       //    return instance.GetListByWhere(strCondition);
       //}

       ///// <summary>
       ///// 插入数据
       ///// </summary>
       ///// <param name='model'>实体</param>
       ///// <returns>bool</returns>
       //public bool Insert(DeptEmployee_Relation model)
       //{
       //    bool result = false;
       //    try
       //    {
       //        int _result = instance.Add(model);
       //        if (_result > 0)
       //        {
       //            result = true;
       //        }
       //    }
       //    catch (Exception ex)
       //    {
       //        throw ex;
       //    }

       //    return result;
       //}
       ///// <summary>
       ///// 插入数据
       ///// </summary>
       ///// <param name='model'>实体</param>
       ///// <param name='model'>是否完成验证</param>
       ///// <returns>bool</returns>
       //public bool Insert(DeptEmployee_Relation model, bool IsValid)
       //{
       //    var e = new ModelExceptions();
       //    bool result = false;
       //    if (e.IsValid && IsValid)
       //    {
       //        //完成了验证，开始更新数据库了
       //        int _result = instance.Add(model);
       //        if (_result > 0)
       //        {
       //            result = true;
       //        }
       //    }
       //    return result;
       //}
       ///// <summary>
       ///// 获取实体数据
       ///// </summary>
       ///// <param name='strCondition'>条件(AND Code='11')</param>
       ///// <returns>model</returns>
       //public DeptEmployee_Relation GetModel(string strCondition)
       //{
       //    List<DeptEmployee_Relation> list = instance.GetListByWhere(strCondition);
       //    DeptEmployee_Relation model = new DeptEmployee_Relation();
       //    if (list != null && list.Count > 0)
       //    {
       //        model = list[0];
       //    }
       //    else
       //    {
       //        model = null;
       //    }
       //    return model;
       //}

       ///// <summary>
       ///// 获取实体数据
       ///// </summary>
       ///// <param name='strCondition'>条件(AND Code='11')</param>
       ///// <returns>model</returns>
       //public DeptEmployee_Relation GetModel(int id)
       //{
       //    DeptEmployee_Relation model = instance.GetByKey(id);
       //    return model;
       //}

       ///// <summary>
       ///// 更新数据
       ///// </summary>
       ///// <param name='model'>实体</param>
       ///// <returns>bool</returns>
       //public bool Update(DeptEmployee_Relation model)
       //{
       //    bool result = false;
       //    var e = new ModelExceptions();
       //    int _rseult = instance.Update(model);
       //    if (_rseult > 0)
       //    {
       //        result = true;
       //    }
       //    return result;
       //}

       ///// <summary>
       ///// 更新数据
       ///// </summary>
       ///// <param name='model'>实体</param>
       ///// <returns>bool</returns>
       //public bool Update(DeptEmployee_Relation model, bool IsValid)
       //{

       //    bool result = false;
       //    var e = new ModelExceptions();
       //    if (e.IsValid && IsValid)
       //    {
       //        int _rseult = instance.Update(model);
       //        if (_rseult > 0)
       //        {
       //            result = true;
       //        }
       //    }
       //    return result;
       //}
       ///// <summary>
       ///// 逻辑删除数据
       ///// </summary>
       ///// <param name='model'>model</param>
       ///// <returns>bool</returns>
       //public bool Delete(string Condition)
       //{
       //    bool result = false;
       //    List<DeptEmployee_Relation> list = instance.GetListByWhere(Condition);
       //    if (list.Count > 0)
       //    {
       //        DeptEmployee_Relation model = list[0];
       //        //model.Stat = 1;
       //        int _rseult = instance.Update(model);
       //        if (_rseult > 0)
       //        {
       //            result = true;
       //        }
       //    }
       //    return result;
       //}
           }
}