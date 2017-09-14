using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASHXEX.BLL;
using ASHXEX.MODEL;

namespace ASHXEX.View
{
    public partial class UserInfoDetail : System.Web.UI.Page
    {

        public UserInfo MUserInfo = new UserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            if (Request.QueryString["uid"] != null)
            {
                int uid = 0;
                if(int.TryParse(Request.QueryString["uid"],out uid))
                {
                    MUserInfo = new UserInfoBLL().GetUserInfoById(uid);
                }
            }
        }
    }
}