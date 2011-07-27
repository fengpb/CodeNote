<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Pop.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    AddArticle
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/Content/Article.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/CodeNote.Article.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="poptitle">
        <h4>
            添加文章
        </h4>
    </div>
    <% Html.RenderAction("EditArticle", "Article"); %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BodyBottomContent" runat="server">
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            $('#savearticle').click(function () {
                alert('12');
                AddArticle();
            });
        });
    </script>
</asp:Content>
