// ***********************************************************************
// Assembly         : Lee.Infrastructure
// Author           : yubaolee
// Created          : 06-19-2015
//
// Last Modified By : yubaolee
// Last Modified On : 06-19-2015
// ***********************************************************************
// <copyright file="Class1.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary>对象校验</summary>
// ***********************************************************************

using System;

namespace Lee.Infrastructure
{
    public class Check
    {
        /// <summary>
        /// 检验输入是否为0
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="input">The input.</param>
        /// <exception cref="System.ArgumentException"></exception>
        public static void IsNotZero(string name, int input)
        {
            if (input == 0)
            {
                throw new ArgumentException(string.Format("{0}不能为0", name));
            }
        }
        /// <summary>
        /// 检验对象是否为空
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="obj">The object.</param>
        /// <exception cref="System.ArgumentException"></exception>
        public static void IsNotNull(string name, object obj)
        {
            if (obj == null)
            {
                throw new ArgumentException(string.Format("{0}不能为空", name));
            }
        }
        /// <summary>
        /// 检验字符串是否为空
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="input">The input.</param>
        /// <exception cref="System.ArgumentException"></exception>
        public static void IsNotNullOrEmpty(string name, string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException(string.Format("{0}不能为空", name));
            }
        }
        /// <summary>
        /// 检验字符串是否为空或空串
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="input">The input.</param>
        /// <exception cref="System.ArgumentException"></exception>
        public static void IsNotNullOrWhiteSpace(string name, string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException(string.Format("{0}不能为空", name));
            }
        }
        /// <summary>
        /// 检验字符串是否相等
        /// </summary>
        /// <param name="id1">The id1.</param>
        /// <param name="id2">The id2.</param>
        /// <param name="errorMessageFormat">The error message format.</param>
        /// <exception cref="System.ArgumentException"></exception>
        public static void AreEqual(string id1, string id2, string errorMessageFormat)
        {
            if (id1 != id2)
            {
                throw new ArgumentException(string.Format(errorMessageFormat, id1, id2));
            }
        }
    }
}
