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
        .shret { text-align: right; font-size: 12px; line-height:23px; margin-bottom: 10px; border-bottom:1px dashed #323232; }
        #searchresult { max-width: 650px; }
        /* 搜索结果*/
        .shritem { margin-bottom: 13px; }
        .end { margin-bottom: 5px; }
        .shritem h5 { margin: 2px 0; }
        .shritem h5 a,.shritem h3 a:hover { background: none; color: #261cdc; text-decoration: underline; border: none; }
        .shritem em { color: #CC0000; text-decoration: underline; font-style: normal; }
        .shritem div { font-size: 0.8em; line-height:150%; color: #333; word-break: break-all;}
        .shritem div em { text-decoration: none; }
        .shritem div p { color: #008000; }
        .shritem div p span { color: #ccc; }
    </style>
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
