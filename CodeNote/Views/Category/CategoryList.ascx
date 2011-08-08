<%@ Control Language="C#" Inherits="CodeNote.Web.ViewUserControl<IList<Category>>" %>
<%@ Import Namespace="CodeNote.Entity" %>
<%@ Import Namespace="CodeNote.Web.Common" %>
<%if (Model != null && Model.Count > 0)
  { %>
<div class="categorylist">
    <h4>
        <label>
            <%: ViewData["partitle"]%></label></h4>
    <ul>
        <% foreach (Category item in Model)
           {
        %><li>
            <%= Html.ActionLink(item.Title,"Category","Category",
                                          new RouteValueDictionary(DictionaryWrap.CreateNew().Add("categoryName", item.Name).Init()),
                                          DictionaryWrap.CreateNew().Add("title", item.Title).Init())%>
            &nbsp;<%= item.Count > 0 ? string.Format("<small>{0}</small>",item.Count) : ""%></li>
        <%   
           } %>
    </ul>
</div>
<%} %>