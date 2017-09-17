<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfoDetail.aspx.cs" Inherits="ASHXEX.View.UserInfoDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户详细信息</title>
    <script src="Script/jquery-1.8.3.min.js"></script>
    <script type="text/javascript">
        $(function () {
            //修改用户信息
            $('#edit').click(function () {
                var url = document.referrer;
                var name = $('#uname').val();
                var pwd = $('#pwd').val();
                var rpwd = $('#rpwd').val();
                var email = $('#email').val();
                var sex =$('input[name="sex"]:checked').val();
                //判断数据是否合法
                if(pwd != rpwd){
                    alert("密码和确认密码不一致");
                    return;
                }
                //提交请求
                $.ajax({
                    url: "../Ashx/Handler_Index.ashx?type=edit&uid=<%=MUserInfo.ID%>",
                    type: "POST",
                    data: { "name": name, "pwd": pwd, "email": email, "sex": sex },
                    success: function (result) {
                        var msg = JSON.parse(result);
                        if (msg.result == "success") {
                            alert("修改成功");
                            window.location.href = url;
                        } else {
                            alert("修改失败");
                        }
                    }
                });
            });

            //添加用户信息
            $('#add').click(function () {
                var name = $('#uname').val();
                var pwd = $('#pwd').val();
                var rpwd = $('#rpwd').val();
                var email = $('#email').val();
                var sex = $('input[name="sex"]:checked').val();
                //判断数据是否合法
                if (pwd != rpwd) {
                    alert("密码和确认密码不一致");
                    return;
                }
                //提交请求
                $.ajax({
                    url: "../Ashx/Handler_Index.ashx?type=add",
                    type: "POST",
                    data: { "name": name, "pwd": pwd, "email": email, "sex": sex },
                    success: function (result) {
                        var msg = JSON.parse(result);
                        if (msg.result == "success") {
                            alert("添加信息成功");
                            window.location.href = "UserInfoList.aspx";
                        } else {
                            alert("添加信息失败");
                        }
                    }
                });
            });

        })
        
    </script>
</head>
<body>
    <div class="Main">
        <table>
            <tr>
                <td class="left">用户名：</td>
                <td class="right">
                    <input id="uname" type="text" value="<%=MUserInfo.Name %>" /></td>
            </tr>
            <tr>
                <td class="left">密码：</td>
                <td class="right">
                    <input id="pwd" type="password" value="<%=MUserInfo.Pwd %>" /></td>
            </tr>
            <tr>
                <td class="left">确认密码：</td>
                <td class="right">
                    <input id="rpwd" type="password" value="<%=MUserInfo.Pwd %>" /></td>
            </tr>
            <tr>
                <td class="left">性别：</td>
                <%if (MUserInfo.Sex != null)
                  {
                      if (MUserInfo.Sex == "男")
                      {%>
                <td class="right">
                    <input type="radio" name="sex" checked="checked" value="男" />男<input type="radio" name="sex" value="女" />女</td>
                <%}
                      else
                      {%>
                <td class="right">
                    <input type="radio" name="sex" value="男"/>男<input type="radio" name="sex" checked="checked" value="女"/>女</td>
                <%}%>
                <%}
                  else
                  {%>
                <td class="right">
                    <input type="radio" name="sex" checked="checked" value="男"/>男<input type="radio" name="sex" value="女"/>女</td>
                <%} %>
            </tr>
            <tr>
                <td class="left">邮箱：</td>
                <td class="right">
                    <input id="email" type="text" value="<%=MUserInfo.Email %>" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <%
                        if (MUserInfo.ID != null && !string.IsNullOrEmpty(MUserInfo.ID.ToString()))
                        {%>
                    <input type="button" id="edit" value="修改" />
                    <%}
                        else
                        {%>
                    <input type="button" id="add" value="添加" />
                    <%} %>
                </td>

            </tr>
        </table>
    </div>
</body>
</html>
