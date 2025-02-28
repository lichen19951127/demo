﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZFS.Library;
using ZFS.Library.Helper;
using ZFS.Model;
using ZFSData;
using ZFSData.Manager;

namespace ZFS.ServerLibrary
{
    public partial class BaseService : IBaseService
    {

        #region IUserService

        /// <summary>
        ///  登录系统
        /// </summary>
        /// <param name="account">账户</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public async Task<byte[]> Login(string account, string password)
        {
            var User = await Factory.GetUserManager().Login(account, password);
            return ZipTools.CompressionObject(User);
        }

        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public async Task<byte[]> GetAuthority(string account)
        {
            var UserAuth = await Factory.GetUserManager().GetAuthority(account);
            return ZipTools.CompressionObject(UserAuth);
        }

        /// <summary>
        /// 根据账户获取账户信息
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public async Task<byte[]> GetModelByAccount(string account)
        {
            var User = await Factory.GetUserManager().GetModelByAccount(account);
            return ZipTools.CompressionObject(User);
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="account"></param>
        public async Task<byte[]> Logout(string account)
        {
            var log = await Factory.GetUserManager().Logout(account);
            return ZipTools.CompressionObject(log);
        }

        public async Task<byte[]> GetModelsByUser(byte[] search)
        {
            var UserSearch = ZipTools.DecompressionObject(search) as tb_User;
            var UserList = await Factory.GetUserManager().GetModels(UserSearch);
            return ZipTools.CompressionObject(UserList);
        }

        public async Task<byte[]> GetPagingModelsByUser(int pageIndex, int pageSize, byte[] search, bool Asc = false)
        {
            var UserSearch = ZipTools.DecompressionObject(search) as tb_User;
            var UserList = await Factory.GetUserManager().GetPagingModels(pageIndex, pageSize, UserSearch, Asc);
            return ZipTools.CompressionObject(UserList);
        }

        public async Task<byte[]> DeleteEntityByUser(byte[] entity)
        {
            var User = ZipTools.DecompressionObject(entity) as tb_User;
            var result = await Factory.GetUserManager().DeleteEntity(User);
            return ZipTools.CompressionObject(result);
        }

        public async Task<byte[]> UpdateEntityByUser(byte[] entity)
        {
            var User = ZipTools.DecompressionObject(entity) as tb_User;
            var result = await Factory.GetUserManager().UpdateEntity(User);
            return ZipTools.CompressionObject(result);
        }

        public async Task<byte[]> AddEntityByUser(byte[] entity)
        {
            var User = ZipTools.DecompressionObject(entity) as tb_User;
            var NewUser = await Factory.GetUserManager().AddEntity(User);
            return ZipTools.CompressionObject(NewUser);
        }

        public async Task<byte[]> ExistEntityByUser(byte[] entity)
        {
            var User = ZipTools.DecompressionObject(entity) as tb_User;
            var result = await Factory.GetUserManager().ExistEntity(User);
            return ZipTools.CompressionObject(result);
        }

        #endregion

    }
}
