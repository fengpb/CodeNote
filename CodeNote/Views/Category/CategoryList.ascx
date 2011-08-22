<%@ Control Language="C#" Inherits="CodeNote.Web.ViewUserControl<IList<Category>>" %>
<%@ Import Namespace="CodeNote.Entity" %>
<%@ Import Namespace="CodeNote.Web.Common" %>
<div class="search">
    <form action="" method="post">
    <dl class="edit">
        <dd>
            <div class="searchbox">
                <input type="text" class="text" />
            </div>
        </dd>
        <dd>
            <input type="button" class="button" value="找找看" /></dd>
    </dl>
    </form>
</div>
<%if (Model != null && Model.Count > 0)
  { %>
<div class="itembox">
    <h4>
        <label>
            <%: ViewData["partitle"]%></label></h4>
    <ul class="rightlist">
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