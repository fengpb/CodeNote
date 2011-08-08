<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<TreeWrap<Category>>" %>
<%@ Import Namespace="CodeNote.Entity" %>
<%@ Import Namespace="CodeNote.Common" %>
<%@ Import Namespace="CodeNote.Web.Common" %>
<!-- 分类树 -->
<%= Html.Tree(Model) %>
