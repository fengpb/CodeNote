<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PageList<VwArticle>>" %>

<%@ Import Namespace="CodeNote.Entity" %>
<%@ Import Namespace="CodeNote.Common" %>
<%@ Import Namespace="CodeNote.Web.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    A Pure Boy: Search
    <%=ViewData["key"] %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .shret { text-align: right; font-size: 12px; margin-bottom: 15px; }
        #searchresult { max-width: 650px; }
        /* 搜索结果*/
        .shritem { margin-bottom: 13px; }
        .end { margin-bottom: 5px; }
        .shritem h3 { font-size: 14px; margin: 2px 0; padding: 0px; line-height: 14px; font-weight: normal; }
        .shritem h3 a,.shritem h3 a:hover { background: none; color: #261cdc; text-decoration: underline; border: none; }
        .shritem em { color: #CC0000; text-decoration: underline; font-style: normal; }
        .shritem div { font-size: 12px; color: #232323; line-height: 15px; }
        .shritem div em { text-decoration: none; }
        .shritem div p { color: #008000; }
        .shritem div p span { color: #232323; }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Navigation" runat="server">
    <% Html.RenderAction("Navigation", "Control"); %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftBox" runat="server">
    <div class="shret">
        找到相关内容<%:Model.RecordCount %>条，用时<%:Model.Msecond %>毫秒
    </div>
    <div id="searchresult">
        <% Html.RenderPartial("PartSearch", Model); %>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="RightBox" runat="server">
    <% Html.RenderAction("CategoryList", "Category"); %>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="BodyBottomContent" runat="server">
</asp:Content>
