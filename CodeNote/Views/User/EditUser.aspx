<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Account/Account.Master" Inherits="System.Web.Mvc.ViewPage<LoginUser>" %>

<%@ Import Namespace="CodeNote.Entity" %>
<%@ Import Namespace="CodeNote.Web.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    编辑用户信息
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="TopContent" runat="server">
    <style type="text/css">
        .mgt10 dl { margin: 5px 0px; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="magtlf10 mgt10">
        <% Html.BeginForm("DoModify", "User", FormMethod.Post); %>
        <input type="hidden" name="userid" value="<%= Model!=null?Model.ID:0 %>" />
        <input type="hidden" name="usertype" value="<%= Model!=null?Model.Type:0 %>" />
        <dl>
            <dt>
                <%= Html.Avatar(Model!=null? Model.Email:"nobody") %>
                <%= Html.ActionLink("关于头像", "Avatar", "Home", null, new { })%>
            </dt>
        </dl>
        <dl class="dlinput">
            <dt>
                <label for="loginname">
                    登陆名
                </label>
            </dt>
            <dd>
                <input id="loginname" name="loginname" type="text" onblur="IsRegister(this)" value="<%= Model!=null?Model.LoginName:"" %>"
                    class="text" />
                <label id="loginnameinfo" class="message">
                </label>
            </dd>
            <dt>
                <label for="email">
                    注册邮箱
                </label>
            </dt>
            <dd>
                <input id="email" disabled="disabled" name="email" type="text" value="<%= Model!=null?Model.Email:"" %>"
                    class="text" />
            </dd>
        </dl>
        <dl class="dlinput">
            <dt>
                <label>
                    旧密码</label>
            </dt>
            <dd>
                <% if (Model != null && Model.Type == (int)CodeNote.Web.Models.Constans.UserType.NoReg)
                   { %>
                <input id="oldpassword" name="oldpassword" type="text" value="<%= Model.PassWord %>"
                    class="text" />
                <span class="required">首次设置，必须修改这个秘密</span>
                <%}
                   else
                   { %>
                <input id="oldpassword" name="oldpassword" type="password" class="text" />
                <%} %>
            </dd>
            <dt>
                <label for="newpassword">
                    新密码</label>
            </dt>
            <dd>
                <input id="newpassword" name="newpassword" type="password" class="text" />
                <label id="lblnewpassword" class="message">
                </label>
            </dd>
            <dt>
                <label for="newpwssword2">
                    确定新密码</label>
            </dt>
            <dd>
                <input id="newpwssword2" name="newpwssword2" onblur="pwd2blur(this)" type="password"
                    class="text" />
                <label id="lblnewpassword2" class="message">
                </label>
            </dd>
        </dl>
        <dl class="dlinput hide">
            <dt>
                <label for="realname">
                    姓名<span>(不公开)</span></label>
            </dt>
            <dd>
                <input id="realname" name="realname" type="text" class="text" />
            </dd>
            <dt>
                <label for="age">
                    年龄</label>
            </dt>
            <dd>
                <input id="age" name="age" type="text" class="text" />
            </dd>
            <dt>
                <label for="birthday">
                    生日</label>
            </dt>
            <dd>
                <input id="birthday" name="age" type="text" class="text" />
            </dd>
            <dt>
                <label for="mobel">
                    手机<span>(不公开)</span></label>
            </dt>
            <dd>
                <input id="mobel" name="mobel" type="text" class="text" />
            </dd>
            <dt>
                <label for="resume">
                    简介</label>
            </dt>
            <dd>
                <textarea id="resumne" cols="50" rows="8" class="area"></textarea>
            </dd>
        </dl>
        <dl>
            <dd class="btn">
                <input id="submit" type="submit" value="保存" class="button" /></dd>
        </dl>
        <% Html.EndForm(); %>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BodyBottomContent" runat="server">
    <script type="text/javascript">
        function IsRegister(ev) {
            var key = $(ev).val();

            jQuery.ajax({
                url: '<%= Html.Url("IsNull", "User", null)%>',
                type: 'post',
                data: { 'key': key },
                success: function (data) {
                    if (!data.IsExists) {
                        $('#loginnameinfo').html(data.Message).show();
                    } else {
                        $('#loginnameinfo').html("").show();
                    }
                }
            });
        }
        function pwd2blur(eve) {
            var p2 = $(eve).val();
            var p = $('#newpassword').val();

            if (p2 != p) {
                $('#lblnewpassword2').html('两次输入密码不相同');
                //disabled="disabled"
                $('#submit').attr('disabled', 'disabled');
            } else {
                $('#lblnewpassword2').html('');
                $('#submit').removeAttr('disabled');
            }
        }
    </script>
</asp:Content>
