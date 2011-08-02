<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Account/Account.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    写日记
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TopContent" runat="server">
<link href="/Content/Article.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/CodeNote.Article.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="poptitle">
        <h4>写日记</h4>
    </div>
    <% Html.RenderAction("EditArticle", "Article"); %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyBottomContent" runat="server">
     <script type="text/javascript" language="javascript">
         $(document).ready(function () {
             GetCategory("0", "selcategory");
         });
    </script>
</asp:Content>
