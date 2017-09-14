using ASHXEX.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASHXEX.DAL
{
    public class UserInfoDAL
    {

        public static List<UserInfo> GetUserInfos()
        {
            return new List<UserInfo>()
            {
                new UserInfo() {ID=1, Name="张三丰", Pwd="123456",Sex="男",Email="zj_work01@outlook.com" },
                new UserInfo() {ID=2, Name="张翠山", Pwd="123456",Sex="男",Email="zj_work02@outlook.com" },
                new UserInfo() {ID=3, Name="张无忌", Pwd="123456",Sex="男",Email="zj_work03@outlook.com" },
                new UserInfo() {ID=4, Name="小龙女", Pwd="123456",Sex="女",Email="zj_work04@outlook.com" },
                new UserInfo() {ID=5, Name="杨过", Pwd="123456",Sex="男",Email="zj_work05@outlook.com" },
                new UserInfo() {ID=6, Name="郭襄", Pwd="123456",Sex="女",Email="zj_work06@outlook.com" },
                new UserInfo() {ID=7, Name="灭绝师太", Pwd="123456",Sex="女",Email="zj_work07@outlook.com" },
                new UserInfo() {ID=8, Name="周芷若", Pwd="123456",Sex="女",Email="zj_work08@outlook.com" }
            };
        }
    }
}