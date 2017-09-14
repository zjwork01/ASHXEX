<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfoList.aspx.cs" Inherits="ASHXEX.View.UserInfoList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户列表</title>
    <style type="text/css">
        #all {
            width: 70%;
            height: 800px;
            margin: 0px auto;
            background-color: lightgray;
            text-align: center;
        }

        #head {
            padding-top: 10px;
            padding-bottom: 10px;
        }

        .page li {
            float: left;
            margin-left: 5px;
            list-style-type: none;
        }
    </style>
    <script src="Script/jquery-1.8.3.min.js"></script>
    <script type="text/javascript">
        $(function () {

            //查询
            $('#search').click(function () {
                var name = $('#txtName').val();
                window.location.href = "UserInfoList.aspx?uname=" + name + "&pid=<%=pid%>";
            });

        })
    </script>
</head>

<body>
    <div id="all">
        <div id="head">
            姓名：<input type="text" id="txtName" />
            <input id="search" type="button" value="搜索" />
        </div>
        <hr />
        <div id="main">
            <%
                if (LUserInfo.Count > 0)
                {%>
            <table>
                <tr>
                    <th>编号</th>
                    <th>用户名</th>
                    <th>性别</th>
                    <th>邮箱</th>
                </tr>
                <%for (int i = 0; i < LUserInfo.Count; i++)
                  {%>
                <tr>
                    <td><%=LUserInfo[i].ID %></td>
                    <td><%=LUserInfo[i].Name %></td>
                    <td><%=LUserInfo[i].Sex %></td>
                    <td><%=LUserInfo[i].Email %></td>
                    <td><a href="UserInfoDetail.aspx?uid=<%=LUserInfo[i].ID %>">修改</a></td>
                    <td><a href="../Ashx/Handler_Index.ashx?type=delete&uid=<%=LUserInfo[i].ID %>">删除</a></td>
                </tr>
                <%}%>
            </table>
            <div class="page">
                <%=pageUI %>
            </div>
            <%}
                    else
                    {%>
            <div id="None">
                <h2>还没有用户呢。。。。</h2>
                <a href="UserInfoDetail.aspx">添加用户</a>
            </div>
            <%}
                %>
        </div>
    </div>
</body>
</html>
