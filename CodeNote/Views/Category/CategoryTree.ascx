<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<TreeWrap<Category>>" %>
<%@ Import Namespace="CodeNote.Entity" %>
<%@ Import Namespace="CodeNote.Common" %>
<%@ Import Namespace="CodeNote.Web.Common" %>
<!-- 分类树 -->
<div class="hidd">
    <input type="button" value="删除" class="button" onclick="DelCategory()" />&nbsp;<label
        id="delMessage" class="message"></label>
</div>
<%= Html.Tree(Model) %>
