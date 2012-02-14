<%@ Control Language="C#" Inherits="CodeNote.Web.ViewUserControl<IList<Category>>" %>
<%@ Import Namespace="CodeNote.Entity" %>
<%@ Import Namespace="CodeNote.Web.Common" %>
<!-- Begin:搜索 -->
<div class="search">
    <% Html.BeginForm("Index", "Home", FormMethod.Get); %>
    <dl class="edit">
        <dd>
            <div class="searchbox">
                <input type="text" name="q" class="text" />
            </div>
        </dd>
        <dd>
            <input type="submit" class="button" value="找找看" /></dd>
    </dl>
    <% Html.EndForm(); %>
</div>
<!-- End:搜索 -->
<!-- Begin:相关分类 -->
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
<!-- End:相关分类 -->
<% Html.RenderAction("Topic", "Control", new { categoryID = ViewData["categoryID"] }); %>
