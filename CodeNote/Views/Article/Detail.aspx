<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<VwArticle>" %>

<%@ Import Namespace="CodeNote.Entity" %>
<%@ Import Namespace="CodeNote.Web.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%:Model.Subject %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .subject h2 { color: #1B26A4; }
        .desinfo dd { font-size: 12px; color: #AAA; }
        .content { margin: 10px 2px; }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Navigation" runat="server">
    <% Html.RenderAction("Navigation", "Control", new { categoryID = Model.CategoryID }); %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="LeftBox" runat="server">
    <div class="subject">
        <h2>
            <%: Model.Subject %></h2>
    </div>
    <div class="content">
        <%= Model.Body %>
    </div>
    <div class="desinfo">
        <input id="hidArtilceID" type="hidden" value="<%= Model.ID %>" />
        <dl>
            <dd>
                所属分类：<label><%: Model.CategoryName%></label></dd>
            <dd>
                关联标签：<label><%: Model.Tag %></label></dd>
            <dd>
                生产工人：<label><%:Model.CreateName %></label></dd>
            <dd>
                生产日期：<label><%: Model.CreateDate %></label></dd>
        </dl>
    </div>
    <h3 class="title mgt10">
        <label title="Reply">
            评论</label></h3>
    <div id="replyList" class="replyList">
        <% Html.RenderAction("ReplyList", "Reply", new { articleID = Model.ID }); %>
    </div>
    <div class="replay">
        <dl class="edit">
            <dd>
                <label>
                    <input id="replayNick" type="text" name="nick" />&nbsp; 昵称<b title="必填">*</b></label>
                <input id="articleId" type="hidden" value="<%= Model.ID %>" />
            </dd>
            <dd>
                <label>
                    <input id="replayEmail" type="text" name="email" />&nbsp; 邮件(不公开)<b title="必填">*</b></label>
            </dd>
            <dd>
                <label>
                    <textarea id="replayBody" name="body" cols="50" rows="5"></textarea>
                </label>
            </dd>
            <dt>
                <input type="button" onclick="Replay()" value="提交评论" />&nbsp;<span id="replayMessage"
                    class="message"></span></dt>
        </dl>
    </div>
</asp:Content>
<asp:Content ID="RightBox" ContentPlaceHolderID="RightBox" runat="server">
    <% Html.RenderAction("CategoryList", "Category", new { categoryID = Model.CategoryID }); %>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="BodyBottomContent" runat="server">
    <script type="text/javascript">
        function Replay() {
            var nick = $('#replayNick').val();
            var email = $('#replayEmail').val();
            var body = $('#replayBody').val();
            var articleID = $('#articleId').val();
            jQuery.ajax({
                url: '/Reply/Add',
                type: 'post',
                data: { 'articleID': articleID, 'nick': nick, 'email': email, 'body': body },
                success: function (data) {
                    $('#replayMessage').html(data.Message);
                    TimerHide('replayMessage', 2000);
                    var refreshUrl = $('#hid_RefreshUrl').val();
                    if (refreshUrl) {
                        AjaxLoad(refreshUrl, 'replyList', null);
                    } else {
                        AjaxLoad('<%= Html.Url("ReplyList", "Reply",null)%>', 'replyList', { 'articleID': $('#hidArtilceID').val() });
                    }
                }, error: function () {
                    alert("replay");
                }
            });
        }
    </script>
</asp:Content>
