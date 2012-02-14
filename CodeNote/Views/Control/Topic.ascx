<%@ Control Language="C#" Inherits="CodeNote.Web.ViewUserControl<IList<Category>>" %>
<%@ Import Namespace="CodeNote.Entity" %>
<%@ Import Namespace="CodeNote.Web.Common" %>
<div class="itembox">
    <h4>
        <label>
            分类归档</label>
    </h4>
    <ul class="rightlist">
        <% string curCategoryID = ViewData["curCategoryID"].ToString();%>
        <% if (Model != null && Model.Count > 0)
           { %>
        <% foreach (Category item in Model)
           { %>
        <% string curClass = "";
           if (curCategoryID.StartsWith(item.CategoryID))
           {
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
