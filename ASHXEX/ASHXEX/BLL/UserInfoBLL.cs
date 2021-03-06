﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASHXEX.DAL;
using ASHXEX.MODEL;

namespace ASHXEX.BLL
{
    public class UserInfoBLL
    {
        /// <summary>
        /// 管理页面加载用户数据
        /// </summary>
        public List<UserInfo> LoadUserInfo(string uname)
        {
            UserInfoDAL ud = new UserInfoDAL();
            return ud.GetUserInfoByCondition(s => s.Name.Contains(uname));
        }

        /// <summary>
        /// 获取分页的数据
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="pageSize"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<UserInfo> GetPageData(int pid,int pageSize,int allcount,List<UserInfo> data)
        {
            if(pid*pageSize > allcount)
            {
                return data.Skip((pid - 1) * pageSize).Take(allcount - (pid - 1) * pageSize).ToList<UserInfo>();
            }
            else
            {
                return data.Skip((pid - 1) * pageSize).Take(pageSize).ToList<UserInfo>();
            }
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserInfo GetUserInfoById(int id)
        {
            return new UserInfoDAL().GetUserInfoById(id);
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool EditUserInfo(UserInfo user)
        {
            return new UserInfoDAL().UpdateUserInfo(user);
        }

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteUserInfo(int id)
        {
            return new UserInfoDAL().DeleteUserInfoById(id);
        }
    }
}