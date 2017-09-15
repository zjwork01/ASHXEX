using ASHXEX.MODEL;
using ASHXEX.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace ASHXEX.Ashx
{
    /// <summary>
    /// Handler_Index 的摘要说明
    /// </summary>
    public class Handler_Index : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string type = string.Empty;
            //接收命令并执行相应的命令
            if(context.Request.QueryString["type"]!=null && !string.IsNullOrEmpty(context.Request.QueryString["type"].ToString()))
            {
                type = context.Request.QueryString["type"].ToString();
            }
            switch (type)
            {
                case "add":
                    AddUserInfo(context);
                    break;
                case "edit":
                    EditUserInfo(context);
                    break;
                case "delete":
                    DeleteUserInfo(context);
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// 添加用户信息
        /// </summary>
        private void AddUserInfo(HttpContext context)
        {
            object msg = new { result = "success" };
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            context.Response.Write(serializer.Serialize(msg));   
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        private void EditUserInfo(HttpContext context)
        {
            int id = Int32.Parse(context.Request["uid"]);
            string name = context.Request["name"];
            string sex = context.Request["sex"];
            string pwd = context.Request["pwd"];
            string email = context.Request["email"];
            UserInfo user = new UserInfo() {ID=id, Name=name,Sex=sex,Pwd=pwd,Email=email};
            if(new UserInfoBLL().EditUserInfo(user))
            {
                object msg = new { result = "success" };
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                context.Response.Write(serializer.Serialize(msg));
            }else
            {
                object msg = new { result = "error" };
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                context.Response.Write(serializer.Serialize(msg));
            }
        }
        /// <summary>
        /// 删除用户信息
        /// </summary>
        private void DeleteUserInfo(HttpContext context)
        {
            int id = Int32.Parse(context.Request["uid"]);
            if(new UserInfoBLL().DeleteUserInfo(id))
            {
                object msg = new { result = "success" };
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                context.Response.Write(serializer.Serialize(msg));
            }else
            {
                object msg = new { result = "error" };
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                context.Response.Write(serializer.Serialize(msg));
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}