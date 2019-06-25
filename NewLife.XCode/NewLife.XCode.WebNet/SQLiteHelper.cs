﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace NewLife.XCode.WebNet
{
    /// <summary>
    /// SQLite数据库帮助类
    /// </summary>
    public class SQLiteHelper
    {
        /// <summary>
        /// 检查数据库是否存在不存在创建
        /// </summary>
        /// <returns></returns>
        public static bool CheckDataBase()
        {
            try
            {
                //判断数据文件是否存在
                bool dbExist = File.Exists("mesclient.sqlite");
                if (!dbExist)
                {
                    SQLiteConnection.CreateFile("mesclient.sqlite");
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// 检查数据表是否存在，不存在创建
        /// </summary>
        /// <returns></returns>
        public static bool CheckDataTable(string connStr)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connStr))
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "SELECT count(*) FROM sqlite_master WHERE type = 'table' AND name = 'serverinfo'";
                    object ob = cmd.ExecuteScalar();
                    long tableCount = Convert.ToInt64(ob);
                    if (tableCount == 0)
                    {
                        //创建表
                        cmd.CommandText = @"
            BEGIN;
                create table serverinfo 
                (Id INTEGER PRIMARY KEY AUTOINCREMENT,Name TEXT,
                Url text,DelayTime integer,UsageCounter INTEGER,
                 Status integer,CreateTime DATETIME);
                CREATE UNIQUE INDEX idx_serverInfo ON serverinfo (Name);
            COMMIT;
            ";
                        //此语句返回结果为0
                        int rowCount = cmd.ExecuteNonQuery();
                        return true;
                    }
                    else if (tableCount > 1)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private readonly static string connStr = ConfigurationManager.ConnectionStrings["Data Source=mesclient.sqlite;Version=3"].ConnectionString;

        //获取 appsetting 设置的值
        //private readonly static string appStr = ConfigurationManager.AppSettings["TestKey"];

        //获取 connection 对象
        public static IDbConnection CreateConnection()
        {
            IDbConnection conn = new SQLiteConnection(connStr);//MySqlConnection //SqlConnection
            conn.Open();
            return conn;
        }

        //执行非查询语句
        public static int ExecuteNonQuery(IDbConnection conn, string sql, Dictionary<string, object> parameters)
        {
            using (IDbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                foreach (KeyValuePair<string, object> keyValuePair in parameters)
                {
                    IDbDataParameter parameter = cmd.CreateParameter();
                    parameter.ParameterName = keyValuePair.Key;
                    parameter.Value = keyValuePair.Value;
                    cmd.Parameters.Add(parameter);
                }
                return cmd.ExecuteNonQuery();
            }
        }

        //执行非查询语句-独立连接
        public static int ExecuteNonQuery(string sql, Dictionary<string, object> parameters)
        {
            using (IDbConnection conn = CreateConnection())
            {
                return ExecuteNonQuery(conn, sql, parameters);
            }
        }

        //查询首行首列
        public static object ExecuteScalar(IDbConnection conn, string sql, Dictionary<string, object> parameters)
        {
            using (IDbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                foreach (KeyValuePair<string, object> keyValuePair in parameters)
                {
                    IDbDataParameter parameter = cmd.CreateParameter();
                    parameter.ParameterName = keyValuePair.Key;
                    parameter.Value = keyValuePair.Value;
                    cmd.Parameters.Add(parameter);
                }
                return cmd.ExecuteScalar();
            }
        }

        //查询首行首列-独立连接
        public static object ExecuteScalar(string sql, Dictionary<string, object> parameters)
        {
            using (IDbConnection conn = CreateConnection())
            {
                return ExecuteScalar(conn, sql, parameters);
            }
        }

        //查询表
        public static DataTable ExecuteQuery(IDbConnection conn, string sql, Dictionary<string, object> parameters)
        {
            DataTable dt = new DataTable();
            using (IDbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                foreach (KeyValuePair<string, object> keyValuePair in parameters)
                {
                    IDbDataParameter parameter = cmd.CreateParameter();
                    parameter.ParameterName = keyValuePair.Key;
                    parameter.Value = keyValuePair.Value;
                    cmd.Parameters.Add(parameter);
                }
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }

            return dt;
        }

        //查询表--独立连接
        public static DataTable ExecuteQuery(string sql, Dictionary<string, object> parameters)
        {
            using (IDbConnection conn = CreateConnection())
            {
                return ExecuteQuery(conn, sql, parameters);
            }
        }
    }

}