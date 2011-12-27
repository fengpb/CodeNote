﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Pop.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="CodeNote.Web.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    A Pure Boy: Register
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="/js/CodeNote.Script.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="PopTitle" ContentPlaceHolderID="PopTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="magtlf10 mgt10">
        <% Html.BeginForm("DoReg", "User", FormMethod.Post); %>
        <dl class="dlinput">
            <dt>
                <label title="Email" for="regemail">
                    电子邮件</label></dt>
            <dd>
                <input id="regemail" type="text" onblur="IsRegister(this)" class="text" name="email" />
                <label id="loginemailinfo" class="message">
                </label>
            </dd>
            <dd>
                <input type="submit" value="提交" title="submit" class="button" />
            </dd>
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
                        $('#loginemailinfo').html(data.Message).show();
                        TimerHide('loginemailinfo', 2000);
                    }
                }
            });
        }
    </script>
</asp:Content>
