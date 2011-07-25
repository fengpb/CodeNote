<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<Category>>" %>
<%@ Import Namespace="CodeNote.Entity" %>
<!-- start navigation -->
<div id="navigation">
    <ul>
        <li><a href="#" class="cur">首页</a> </li>
        <% if (Model != null && Model.Count > 0)
           { %>
        <% foreach (Category item in Model)
           { %>
        <li><a href="#">
            <%: item.Name %></a></li>
        <%} %>
        <%} %>
    </ul>
</div>
<!-- end navigation -->
