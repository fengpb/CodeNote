<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="CodeNote.Web.ViewPage<VwArticle>" %>

<%@ Import Namespace="CodeNote.Entity" %>
<%@ Import Namespace="CodeNote.Web.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    A Pure Boy:
    <%:Model.Subject %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/css/wmd.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <script src="/js/CodeNote.Article.js" type="text/javascript"></script>
    <script src="/js/Markdown.Converter.js" type="text/javascript"></script>
    <script src="/js/Markdown.Sanitizer.js" type="text/javascript"></script>
    <script src="/js/Markdown.Editor.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Navigation" runat="server">
    <% Html.RenderAction("Navigation", "Control", new { categoryID = Model.CategoryID }); %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="LeftBox" runat="server">
    <div class="com">
        <h2 class="posrl">
            <%: Model.Subject %>
            <% if (IsLogin && CurUser.ID == Model.CreateID)
               { %>
            <label class="posabsbr common">
                [<%= Html.ActionLink("编辑", "EditArticle", "Article", new { id = Model.ID }, null)%>]
            </label>
            <%} %>
        </h2>
        <dl>
            <dd class="end">
                <label title="日期">
                    <%: Model.CreateDate %></label></dd>
            <dd>
                <label title="作者">
                    By：<%= Html.ActionLink(Model.CreateName,"","") %></label></dd>
            <% if (!string.IsNullOrEmpty(Model.CategoryName))
               { %>
            <dd>
                <label>
                    Notic：<%= Html.ActionLink(Model.CategoryTitle, "Category", "Category", new { categoryName = Model.CategoryName }, new { title = Model.CategoryTitle })%></label>
            </dd>
            <%} %>
            <% if (!string.IsNullOrEmpty(Model.Tag))
               { %>
            <dd>
                <label title="标签">
                    Tag：<%= Html.TagLink(Model.Tag, "Tag", "Tag")%></label>
            </dd>
            <%} %>
        </dl>
    </div>
    <div class="content">
        <%=HtmlEncode(Model.Body) %>
    </div>
    <h3 class="title mgt10">
        <input id="hidArtilceID" type="hidden" value="<%= Model.ID %>" />
        <label title="Reply">
            评论</label></h3>
    <div id="replyList" class="replyList">
        <% Html.RenderAction("ReplyList", "Reply", new { articleID = Model.ID }); %>
    </div>
    <div class="replay">
        <dl class="edit">
            <dd>
                <label>
                    <input id="replayNick" type="text" class="text" name="nick" value="<%=(CurUser!=null&&CurUser.ID!=Model.CreateID)?CurUser.LoginName:"" %>" />&nbsp;
                    昵称<b title="必填">*</b></label>
            </dd>
            <dd>
                <label>
                    <input id="replayEmail" type="text" class="text" name="email" value="<%=(CurUser!=null&&CurUser.ID!=Model.CreateID)?CurUser.Email:"" %>" />&nbsp;
                    邮件(不公开)<b title="必填">*</b></label>
            </dd>
            <dd>
                <div class="wmd-panel">
                    <div id="wmd-button-bar">
                    </div>
                    <textarea id="wmd-input" class="wmd-input" name="body" cols="50" rows="5"></textarea>
                </div>
                <div id="wmd-preview" class="wmd-panel wmd-preview">
                </div>
            </dd>
            <dd class="btn">
                <input type="button" onclick="Replay()" value="提交评论" />&nbsp;<span id="replayMessage"
                    class="message"><!--Ctrl+Enter--></span></dd>
        </dl>
    </div>
</asp:Content>
<asp:Content ID="RightBox" ContentPlaceHolderID="RightBox" runat="server">
    <% Html.RenderAction("CategoryList", "Category", new { categoryID = Model.CategoryID }); %>
    <% Html.RenderAction("ArticleRec", "Article", new { articleID = Model.ID }); %>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="BodyBottomContent" runat="server">
    <script src="/js/detail.js" type="text/javascript"></script>
</asp:Content>
