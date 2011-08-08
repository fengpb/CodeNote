<%@ Control Language="C#" Inherits="CodeNote.Web.ViewUserControl<dynamic>" %>
<% if (SiteData.IsAdmin)
   { %>
<div id="navigation">
    <div class="navbg">
    </div>
    <ul>
        <li><a href="#">统计</a></li>
        <li>
            <%= Html.ActionLink("分类","Category") %>
        </li>
        <li><a href="#">标签</a></li>
    </ul>
</div>
<%} %>
