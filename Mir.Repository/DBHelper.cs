/******************************************************************
* 项目名称 ：Mir.Repository 
* 项目描述 ： 
* 类 名 称 ：DBHelper 
* 类 描 述 ： 
* CLR 版本 ：4.0.30319.42000 
* 版权所有 ：袁振峰
* 联系方式 ：http://www.ustuy.com/ 
******************************************************************/
using Mir.Commons.Extensions;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mir.Repository
{
    /// <summary>
    /// 使用帮助：https://github.com/sunkaixuan/SqlSugar
    /// </summary>
    public static class DBHelper
    {
        /// <summary>
        /// 获取数据库链接实例
        /// </summary>
        /// <param name="conStr">链接字符串</param>
        /// <param name="type"></param>
        /// <param name="isAutoClose"></param>
        /// <param name="isEnableLog">是否在控制台输出SQL语句</param>
        /// <returns></returns>
        public static SqlSugarClient GetInstance(string conStr, DbType type, bool isAutoClose, bool isEnableLog = false)
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = conStr,
                DbType = type,
                IsAutoCloseConnection = isAutoClose
            });

            db.Ado.IsEnableLogEvent = false;
            db.Ado.LogEventStarting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(s => s.ParameterName, s => s.Value)));
                Console.WriteLine();
            };
            return db;
        }

        /// <summary>
        /// 获取数据库链接实例
        /// </summary>
        /// <param name="conStr"></param>
        /// <param name="type"></param>
        /// <param name="isAutoClose"></param>
        /// <param name="isEnableLog">是否在控制台输出SQL语句</param>
        /// <returns></returns>
        public static SqlSugarClient GetInstance(string conStr, string type, bool isAutoClose, bool isEnableLog = false)
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = conStr,
                DbType = type.ToEnum<DbType>(),
                IsAutoCloseConnection = isAutoClose
            });

            db.Ado.IsEnableLogEvent = false;
            db.Ado.LogEventStarting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(s => s.ParameterName, s => s.Value)));
                Console.WriteLine();
            };
            return db;
        }

        /// <summary>
        /// 获取数据库链接实例
        /// </summary>
        /// <param name="config"></param>
        /// <param name="isEnableLog">是否在控制台输出SQL语句</param>
        /// <returns></returns>
        public static SqlSugarClient GetInstance(ConnectionConfig config, bool isEnableLog = false)
        {
            SqlSugarClient db = new SqlSugarClient(config);
            db.Ado.IsEnableLogEvent = false;
            db.Ado.LogEventStarting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(s => s.ParameterName, s => s.Value)));
                Console.WriteLine();
            };
            return db;
        }
    }
}
