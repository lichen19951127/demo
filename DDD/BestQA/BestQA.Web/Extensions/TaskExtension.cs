// ***********************************************************************
// Assembly         : BestQA.Web
// Author           : Administrator
// Created          : 06-22-2015
//
// Last Modified By : Administrator
// Last Modified On : 06-22-2015
// ***********************************************************************
// <copyright file="TaskExtension.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// <summary>task超时扩展</summary>
// ***********************************************************************

using System;
using System.Threading;
using System.Threading.Tasks;

namespace BestQA.Web.Extensions
{
    public static class TaskExtension
    {
        /// <summary>
        /// 无返回Task超时设置
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="millisecondsDelay">超时时间（毫秒）</param>
        /// <returns>Task.</returns>
        /// <exception cref="System.TimeoutException">The operation has timed out.</exception>
        public static async Task TimeoutAfter(this Task task, int millisecondsDelay)
        {
            var timeoutCancellationTokenSource = new CancellationTokenSource();
            var completedTask = await Task.WhenAny(task, Task.Delay(millisecondsDelay, timeoutCancellationTokenSource.Token));
            if (completedTask == task)
            {
                timeoutCancellationTokenSource.Cancel();
            }
            else
            {
                throw new TimeoutException("The operation has timed out.");
            }
        }
        /// <summary>
        /// 有返回Task超时设置
        /// </summary>
        /// <typeparam name="TResult">The type of the attribute result.</typeparam>
        /// <param name="task">The task.</param>
        /// <param name="millisecondsDelay">The milliseconds delay.</param>
        /// <returns>Task{``0}.</returns>
        /// <exception cref="System.TimeoutException">The operation has timed out.</exception>
        public static async Task<TResult> TimeoutAfter<TResult>(this Task<TResult> task, int millisecondsDelay)
        {
            var timeoutCancellationTokenSource = new CancellationTokenSource();
            var completedTask = await Task.WhenAny(task, Task.Delay(millisecondsDelay, timeoutCancellationTokenSource.Token));
            if (completedTask == task)
            {
                timeoutCancellationTokenSource.Cancel();
                return task.Result;
            }
            else
            {
                throw new TimeoutException("The operation has timed out.");
            }
        }
    }
}