<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<VwArticle>" %>

<%@ Import Namespace="CodeNote.Entity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    A Pure Boy: Edit
    <%=Model.Subject %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/css/wmd.css" rel="stylesheet" type="text/css" />
    <script src="/js/CodeNote.Article.js" type="text/javascript"></script>
    <script src="/js/Markdown.Converter.js" type="text/javascript"></script>
    <script src="/js/Markdown.Sanitizer.js" type="text/javascript"></script>
    <script src="/js/Markdown.Editor.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="nav" ContentPlaceHolderID="Navigation" runat="server">
    <% Html.RenderAction("AccountNav", "Control"); %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftBox" runat="server">
    <% Html.RenderPartial("AddOrEditArticle", Model); %>
</asp:Content>
<asp:Content ID="rightbox" ContentPlaceHolderID="RightBox" runat="server">
    <% Html.RenderAction("AccountLeft", "Control"); %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BodyBottomContent" runat="server">
    <script type="text/javascript" language="javascript">
        $(document).ready(function ()
        {

            var converter = Markdown.getSanitizingConverter();
            var editor = new Markdown.Editor(converter);
            editor.run();

            GetCategory("0", "selcategory", SelDefaultValue);

        });
    </script>
</asp:Content>
