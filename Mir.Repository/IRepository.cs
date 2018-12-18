/******************************************************************
* 项目名称 ：Mir.Repository 
* 项目描述 ： 
* 类 名 称 ：IRepository 
* 类 描 述 ： 
* CLR 版本 ：4.0.30319.42000 
* 版权所有 ：袁振峰
* 联系方式 ：http://www.ustuy.com/ 
******************************************************************/
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mir.Repository
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Add(TEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        bool AddBatch(IEnumerable<TEntity> entitys);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update(TEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        bool Update(IEnumerable<TEntity> entitys);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Delete(TEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool Delete(string Id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool Delete(int Id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        TEntity Get(string Id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        TEntity Get(int Id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        TEntity Get(Expression<Func<TEntity, bool>> func);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> order = null, OrderByType type = OrderByType.Asc);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        TEntity GetSingle(Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> order = null, OrderByType type = OrderByType.Asc);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DateTime GetDateTime();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        int Count(Expression<Func<TEntity, bool>> where = null);
    }
}
