using ASHXEX.MODEL;
using ASHXEX.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace ASHXEX.View
{
    public partial class UserInfoList : System.Web.UI.Page
    {
        public List<UserInfo> LUserInfo = new List<UserInfo>();
        public int pageSize = 5;
        public int pid = 1;
        public int allCount = 0;//总数据量
        public string pageUI = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //加载数据
                LoadData();
            }
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            //获取查询条件
            string name = string.Empty;
            if (Request.QueryString["pid"] != null && !string.IsNullOrEmpty(Request.QueryString["pid"]))
            {
                pid = Int32.Parse(Request.QueryString["pid"]);
            }
            if(Request.QueryString["uname"]!= null && !string.IsNullOrEmpty(Request.QueryString["uname"]))
            {
                name = Request.QueryString["uname"].ToString();
            }
            //获取数据
            UserInfoBLL ub = new UserInfoBLL();
            LUserInfo = ub.LoadUserInfo(name);
            allCount = LUserInfo.Count;
            LUserInfo = ub.GetPageData(pid, pageSize,allCount, LUserInfo);
            //加载分页
            pageUI = Tools.PublicMethod.GetPageTabs("UserInfoList.aspx?uname=" + name + "&pid=", pageSize, pid, allCount, "", "");
        }

    }
}