<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Account/Account.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Catgegory
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <% Html.RenderAction("EditCategory", "Category"); %>
    </div>
    <div>
        <% Html.RenderAction("CategoryTree","Category"); %>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BodyBottomContent" runat="server">
</asp:Content>
