﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    A Pure Boy: Tag
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Leftbox" runat="server">
    <h2>
        Tag List
    </h2>
    <div id="taglist">
        <% Html.RenderAction("TagList", "Tag"); %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="RightBox" runat="server">
    <% Html.RenderAction("AccountLeft", "Control"); %>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="BodyBottomContent" runat="server">
</asp:Content>
