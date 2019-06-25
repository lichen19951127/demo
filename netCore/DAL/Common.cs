using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Common
{
    //添加引用
    using System.Data;
    using System.Data.SqlClient;
    using System.Reflection;
    public static class Common
    {
        /// <summary>
        /// DataTable转泛型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this DataTable dt) where T : class, new()
        {
            //获取类型
            Type t = typeof(T);
            //获取属性
            PropertyInfo[] propertys = t.GetProperties();
            //定义泛型
            List<T> list = new List<T>();
            //定义变量接收属性名称
            var typeName = string.Empty;
            //遍历每行
            foreach (DataRow dr in dt.Rows)
            {
                //实例化
                T entity = new T();
                //遍历属性
                foreach (PropertyInfo pi in propertys)
                {
                    //赋值
                    typeName = pi.Name;
                    //判断是否存在该属性名
                    if (dt.Columns.Contains(typeName))
                    {
                        //判断是否可写 不可写则跳出
                        if (!pi.CanWrite) continue;
                        //获取值
                        object value = dr[typeName];
                        //判断是否有值  没有值则跳出
                        if (value == DBNull.Value) continue;
                        //判断类型
                        if (pi.PropertyType == typeof(string))
                        {
                            //写入
                            pi.SetValue(entity, value.ToString(), null);
                        }
                        else if (pi.PropertyType == typeof(int))
                        {
                            //写入
                            pi.SetValue(entity, int.Parse(value.ToString()), null);
                        }
                        else if (pi.PropertyType == typeof(DateTime))
                        {
                            //写入
                            pi.SetValue(entity, DateTime.Parse(value.ToString()), null);
                        }
                        else
                        {
                            //写入
                            pi.SetValue(entity,value, null);
                        }
                    }
                }
                //将实体加入泛型集合中
                list.Add(entity);
            }
            //返回泛型集合
            return list;
        }

    }
}