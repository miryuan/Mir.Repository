/******************************************************************
* 项目名称 ：Mir.Repository 
* 项目描述 ： 
* 类 名 称 ：BaseRepository 
* 类 描 述 ： 
* CLR 版本 ：4.0.30319.42000 
* 版权所有 ：袁振峰
* 联系方式 ：http://www.ustuy.com/ 
******************************************************************/
using Microsoft.Extensions.Options;
using Mir.Core;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mir.Repository
{
    public class BaseRepository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class, new()
    {
        public readonly SqlSugarClient Client;
        public BaseRepository()
        {
            var setting = Core.AutofacExt.Resolve<ConnectionStrings>();
            Client = DBHelper.GetInstance(setting.DBConnectString, setting.DBType, setting.IsAutoCloseConnection);
        }

        /// <summary>
        /// 插入一个数据库实体
        /// </summary>
        /// <param name="entity">实体类</param>
        /// <returns>bool</returns>
        public virtual bool Add(TEntity entity)
        {
            return Client.Insertable(entity).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 批量插入实体
        /// </summary>
        /// <param name="entitys">实体类集合</param>
        /// <returns>bool</returns>
        public virtual bool AddBatch(IEnumerable<TEntity> entitys)
        {
            return Client.Insertable(new List<TEntity>(entitys)).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 查询数据量
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns>数量</returns>
        public virtual int Count(Expression<Func<TEntity, bool>> where = null)
        {
            return Client.Queryable<TEntity>().Count(where);
        }

        /// <summary>
        /// 删除一条实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>bool</returns>
        public virtual bool Delete(TEntity entity)
        {
            return Client.Deleteable(entity).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 删除以主键为条件的数据
        /// </summary>
        /// <param name="Id">字符串主键</param>
        /// <returns>bool</returns>
        public virtual bool Delete(string Id)
        {
            return Client.Deleteable<TEntity>().In(Id).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 删除以主键为条件的数据
        /// </summary>
        /// <param name="Id">数值型主键</param>
        /// <returns>bool</returns>
        public bool Delete(int Id)
        {
            return Client.Deleteable<TEntity>().In(Id).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 获取以主键为条件的数据
        /// </summary>
        /// <param name="Id">字符型主键</param>
        /// <returns>实体</returns>
        public virtual TEntity Get(string Id)
        {
            return Client.GetSimpleClient().GetById<TEntity>(Id);
        }

        /// <summary>
        /// 获取以主键为条件的数据
        /// </summary>
        /// <param name="Id">数值型主键</param>
        /// <returns>实体</returns>
        public virtual TEntity Get(int Id)
        {
            return Client.GetSimpleClient().GetById<TEntity>(Id);
        }

        /// <summary>
        /// 获取符合条件中的第一条数据
        /// </summary>
        /// <param name="func">查询条件</param>
        /// <returns>实体</returns>
        public virtual TEntity Get(Expression<Func<TEntity, bool>> func)
        {
            return Client.Queryable<TEntity>().First(func);
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns>List</returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return Client.Queryable<TEntity>().ToList();
        }

        /// <summary>
        /// 获取数据库时间
        /// </summary>
        /// <returns></returns>
        public virtual DateTime GetDateTime()
        {
            return Client.GetDate();
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="order">排序</param>
        /// <param name="type">排序方式</param>
        /// <returns>List</returns>
        public virtual IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, object>> order = null, OrderByType type = OrderByType.Asc)
        {
            if (order == null)
                return Client.Queryable<TEntity>().Where(where).ToList();
            else
                return Client.Queryable<TEntity>().Where(where).OrderBy(order, type).ToList();
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>bool</returns>
        public virtual bool Update(TEntity entity)
        {
            return Client.Updateable(entity).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 批量更新实体集合
        /// </summary>
        /// <param name="entitys">实体集合</param>
        /// <returns>bool</returns>
        public bool Update(IEnumerable<TEntity> entitys)
        {
            return Client.Updateable<TEntity>(entitys).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 释放
        /// </summary>
        public virtual void Dispose()
        {
            Client.Close();
            Client.Dispose();
        }
    }
}
