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
    public interface IRepository<TEntity> where TEntity : class
    {
        bool Add(TEntity entity);
        bool AddBatch(IEnumerable<TEntity> entitys);
        bool Update(TEntity entity);
        bool Update(IEnumerable<TEntity> entitys);
        bool Delete(TEntity entity);
        bool Delete(string Id);
        bool Delete(int Id);
        TEntity Get(string Id);
        TEntity Get(int Id);
        TEntity Get(Expression<Func<TEntity, bool>> func);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> order = null, OrderByType type = OrderByType.Asc);
        DateTime GetDateTime();
        int Count(Expression<Func<TEntity, bool>> where = null);
    }
}
