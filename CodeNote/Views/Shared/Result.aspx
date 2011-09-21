<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Pop.Master" Inherits="System.Web.Mvc.ViewPage<ReturnMessage>" %>

<%@ Import Namespace="CodeNote.Web.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%: Model.Title %>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PopTitle" runat="server">
    <li class="cur"><a>
        <%: Model.Title %></a></li></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="magtlf10 mgt10">
        <p>
            <%= Model.Content %></p>
        <% if (!string.IsNullOrEmpty(Model.BackUrl))
           { %>
        <div class="mgt10">
            <a href="<%=Model.BackUrl %>" title="Back">返回继续</a>
        </div>
        <%} %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BodyBottomContent" runat="server">
</asp:Content>
