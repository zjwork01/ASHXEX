using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASHXEX.Ashx
{
    /// <summary>
    /// Handler_Index 的摘要说明
    /// </summary>
    public class Handler_Index : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //接收命令并执行相应的命令

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