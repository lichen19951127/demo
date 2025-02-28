﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal static class TypeExtension
    {
        //您不能插入或更新复杂类型。让我们筛选出来。
        public static bool IsSimpleType(this Type type)
        {
            Type underlyingType = Nullable.GetUnderlyingType(type);
            type = underlyingType ?? type;
            var simpleTypes = new List<Type>
        {
            typeof (byte),
            typeof (sbyte),
            typeof (short),
            typeof (ushort),
            typeof (int),
            typeof (uint),
            typeof (long),
            typeof (ulong),
            typeof (float),
            typeof (double),
            typeof (decimal),
            typeof (bool),
            typeof (string),
            typeof (char),
            typeof (Guid),
            typeof (DateTime),
            typeof (DateTimeOffset),
            typeof (byte[])
        };
            return simpleTypes.Contains(type) || type.IsEnum;
        }
    }
}
