using ASHXEX.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASHXEX.DAL
{
    public class UserInfoDAL
    {
        private List<UserInfo> database = new List<UserInfo>()
        {
            new UserInfo() {ID=1, Name="张三丰", Pwd="123456",Sex="男",Email="zj_work01@outlook.com" },
            new UserInfo() {ID=2, Name="张翠山", Pwd="123456",Sex="男",Email="zj_work02@outlook.com" },
            new UserInfo() {ID=3, Name="张无忌", Pwd="123456",Sex="男",Email="zj_work03@outlook.com" },
            new UserInfo() {ID=4, Name="小龙女", Pwd="123456",Sex="女",Email="zj_work04@outlook.com" },
            new UserInfo() {ID=5, Name="杨过", Pwd="123456",Sex="男",Email="zj_work05@outlook.com" },
            new UserInfo() {ID=6, Name="郭襄", Pwd="123456",Sex="女",Email="zj_work06@outlook.com" },
            new UserInfo() {ID=7, Name="灭绝师太", Pwd="123456",Sex="女",Email="zj_work07@outlook.com" },
            new UserInfo() {ID=8, Name="周芷若", Pwd="123456",Sex="女",Email="zj_work08@outlook.com" },
            new UserInfo() {ID=9, Name="赵敏", Pwd="123456",Sex="女",Email="zj_work08@outlook.com" },
            new UserInfo() {ID=10, Name="宋青书", Pwd="123456",Sex="女",Email="zj_work08@outlook.com" },
            new UserInfo() {ID=11, Name="金毛狮王", Pwd="123456",Sex="女",Email="zj_work08@outlook.com" },
            new UserInfo() {ID=12, Name="紫衫龙王", Pwd="123456",Sex="女",Email="zj_work08@outlook.com" },
            new UserInfo() {ID=13, Name="白眉鹰王", Pwd="123456",Sex="女",Email="zj_work08@outlook.com" },
            new UserInfo() {ID=14, Name="青翼蝠王", Pwd="123456",Sex="女",Email="zj_work08@outlook.com" },
            new UserInfo() {ID=15, Name="成昆", Pwd="123456",Sex="女",Email="zj_work08@outlook.com" },
            new UserInfo() {ID=16, Name="纪晓岚", Pwd="123456",Sex="女",Email="zj_work08@outlook.com" }
        };

        /// <summary>
        /// 获取全部用户信息
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> GetUserInfos()
        {
            return database;
        }

        /// <summary>
        /// 通过ID获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserInfo GetUserInfoById(int id)
        {
            List<UserInfo> list = database.Where(s => s.ID == id).ToList<UserInfo>();
            if(list.Count > 0)
            {
                return list[0];
            }else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="condition">条件 Lambda表达式</param>
        /// <returns></returns>
        public List<UserInfo> GetUserInfoByCondition(Func<UserInfo,bool> condition)
        {
            return database.Where(condition).ToList<UserInfo>();
        }

        /// <summary>
        /// 根据ID删除用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteUserInfoById(int id)
        {
            List<UserInfo> list = database.Where<UserInfo>(s => s.ID == id).ToList<UserInfo>();
            if(list.Count > 0)
            {
                database.Remove(list[0]);
                return true;
            }else
            {
                return false;
            }
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddUserInfo(UserInfo user)
        {
            try
            {
                database.Add(user);
                return true;
            }catch
            {
                return false;
            }
        }

        /// <summary>
        /// 批量添加用户
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public bool AddUserInfo(IEnumerable<UserInfo> users)
        {
            try
            {
                database.AddRange(users);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool UpdateUserInfo(UserInfo user)
        {
            try
            {
                List<UserInfo> list = database.Where<UserInfo>(s => s.ID == user.ID).ToList<UserInfo>();
                if(list.Count > 0)
                {
                    list[0] = user;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch 
            {
                return false;
            }
        }

    }
}