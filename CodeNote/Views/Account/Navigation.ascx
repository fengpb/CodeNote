<%@ Control Language="C#" Inherits="CodeNote.Web.ViewUserControl<dynamic>" %>
<div id="navigation">
    <div class="navbg">
    </div>
    <ul>
        <% if (SiteData.IsAdmin)
           { %>
        <li>
            <%= Html.ActionLink("新日志", "AddArticle", "Article")%></li>
        <%} %>
    </ul>
</div>
