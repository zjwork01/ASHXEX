using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ASHXEX.Tools
{
    public class PublicMethod
    {
        /// <summary>
        /// 获取分页字符串
        /// </summary>
        /// <param name="url"></param>
        /// <param name="pagesize"></param>
        /// <param name="pid"></param>
        /// <param name="allcount"></param>
        /// <param name="content"></param>
        /// <param name="currentPageStyle"></param>
        /// <returns></returns>
        public static string GetPageTabs(string url,int pagesize,int pid,int allcount,string content,string currentPageStyle)
        {
            StringBuilder sb = new StringBuilder();
            int pagecount = 0;
            pagecount = allcount % pagesize > 0 ? (allcount / pagesize + 1) : allcount / pagesize;//计算总页码
            if (pagecount >= 1) //超过一页才显示
            {
                int start = 1, end = 1;
                start = pid > 6 ? (pid - 6) : 1;//起始页
                end = (start + 9) > pagecount ? pagecount : (start + 9);//结束页
                if (end == pagecount && pagecount > 10) //如果是最后一页显示页码向前13个页面
                {
                    start = pagecount - 9;
                }
                if (pid > 1)
                {
                    sb.Append("<li><a  href=\"" + url + (pid - 1) + "\" " + content + "  rel=\"nofollow\">上一页</a> </li>");
                }

                while (start <= end)
                {
                    if (start == pid)
                    {
                        //sb.Append("   <li><a  href=\"" + url + (pid-1) + "\" " + currentPageStyle + ">" + start + "</a></li> ");

                        sb.Append("   <li><a  href=\"" + url + pid + "\" " + currentPageStyle + ">" + start + "</a></li> ");
                    }
                    else
                    {
                        sb.Append("<li><a  href=\"" + url + start + "\" " + content + "   rel=\"nofollow\">" + start + "</a></li> ");
                    }
                    start++;
                }
                if (pid < end)
                {
                    sb.Append("<li><a  href=\"" + url + (pid + 1) + "\" " + content + "   rel=\"nofollow\">下一页</a></li> ");
                }
            }

            return sb.ToString();
        }
    }
}