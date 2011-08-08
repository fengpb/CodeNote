<%@ Control Language="C#" Inherits="CodeNote.Web.ViewUserControl<IList<Category>>" %>
<%@ Import Namespace="CodeNote.Entity" %>
<%@ Import Namespace="CodeNote.Web.Common" %>
<!-- start navigation -->
<div id="navigation">
    <div class="navbg">
    </div>
    <ul>
        <% string curCategoryID = ViewData["curCategoryID"].ToString();%>
        <li <%= curCategoryID=="Index"?"class=\"cur\"":"" %>><a href="/" title="Index">首页</a> </li>
        <% if (Model != null && Model.Count > 0)
           { %>
        <% foreach (Category item in Model)
           { %>
        <% string curClass = "";
                if (curCategoryID.StartsWith(item.CategoryID)) {
                    curClass = "cur";
               }%>
        <li class="<%=curClass %>">
            <%= Html.ActionLink(item.Title,"Category","Category",
                                          new RouteValueDictionary(DictionaryWrap.CreateNew().Add("categoryName", item.Name).Init()),
                                          DictionaryWrap.CreateNew().Add("title", item.Title).Add("class",curClass).Init())%>
        </li>
        <%} %>
        <%} %>
    </ul>
</div>
<!-- end navigation -->
