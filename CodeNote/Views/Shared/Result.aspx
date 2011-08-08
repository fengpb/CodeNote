<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Pop.Master" Inherits="System.Web.Mvc.ViewPage<ReturnMessage>" %>

<%@ Import Namespace="CodeNote.Web.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: Model.Title %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="poptitle">
        <h4>
            <%: Model.Title %></h4>
    </div>
    <div>
        <p>
            <%: Model.Content %></p>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BodyBottomContent" runat="server">
</asp:Content>
