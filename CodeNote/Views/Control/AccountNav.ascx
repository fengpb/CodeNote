<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<div>
    <ul>
        <li><%= Html.ActionLink("写日记","AddArticle","Article") %></li>
    </ul>
</div>
