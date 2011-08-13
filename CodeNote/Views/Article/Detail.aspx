<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<VwArticle>" %>

<%@ Import Namespace="CodeNote.Entity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%:Model.Subject %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .subject h2 { color: #1B26A4; }
        .desinfo dd{ font-size: 12px; color: #AAA; }
        .content { margin: 10px 2px; }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Navigation" runat="server">
    <% Html.RenderAction("Navigation", "Control", new { categoryID = Model.CategoryID }); %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <div id="leftwrap">
        <div class="leftbox">
            <div class="subject">
                <h2>
                    <%: Model.Subject %></h2>
            </div>
            <div class="content">
                <%= Model.Body %>
            </div>
            <div class="desinfo">
                <dl>
                    <dd>
                        所属分类：<label><%: Model.CategoryName%></label></dd>
                    <dd>
                        关联标签：<label><%: Model.Tag %></label></dd>
                    <dd>
                        生产工人：<label><%:Model.CreateName %></label></dd>
                    <dd>
                        生产日期：<label><%: Model.CreateDate %></label></dd>
                </dl>
            </div>
        </div>
    </div>
    <div id="rightwrap">
        <div class="rightbox">
            <% Html.RenderAction("CategoryList", "Category", new { categoryID = Model.CategoryID }); %>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="BodyBottomContent" runat="server">
</asp:Content>
