// ***********************************************************************
// Assembly         : Lee.Infrastructure
// Author           : yubaolee
// Created          : 06-19-2015
//
// Last Modified By : yubaolee
// Last Modified On : 06-19-2015
// ***********************************************************************
// <copyright file="ConfigSettings.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary>获取默认的连接字符串</summary>
// ***********************************************************************

using System.Configuration;

namespace Lee.Infrastructure
{
    public class ConfigSettings
    {
        public static string ConnectionString { get; set; }

        public static void Initialize()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        }
    }
}
