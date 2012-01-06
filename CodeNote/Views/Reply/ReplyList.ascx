<%@ Control Language="C#" Inherits="CodeNote.Web.ViewUserControl<PageList<Reply>>" %>
<%@ Import Namespace="CodeNote.Entity" %>
<%@ Import Namespace="CodeNote.Common" %>
<%@ Import Namespace="CodeNote.Web.Common" %>
<% if (Model != null && Model.RecordCount > 0)
   { %>
<%foreach (Reply item in Model.Data)
  {
%>
<dl class="clearfix">
    <dt>
        <%= Html.Avatar(item.Email) %>
    </dt>
    <dd>
        <div class="posrl">
            <label class="nick">
                <%:item.Nick %></label>
            <div class="date posabstr">
                <%:item.CreateDate %></div>
        </div>
        <div class="bcon">
<%= HtmlEncode(item.Body) %>
        </div>
    </dd>
</dl>
<%
  } %>
<%= Html.AjaxPaging(new Pager() { Cur = Model.CurPage, Count = Model.RecordCount, Size = Model.PageSize }, "ReplyList", "Reply", new AjaxPagingOption("replyList"), new { articleID = ViewData["articleID"] })%>
<%}%>
<%        else
   { %>
<p class="null">
    暂无评论！</p>
<%} %>
