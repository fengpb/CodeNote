<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Category>" %>

<%@ Import Namespace="CodeNote.Entity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Category
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="/Content/Categroy.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="leftwrap">
        <div class="leftbox">
            <ul class="articlelist">
                <li>
                    <h4>
                        <label>
                            对于我来说你就是我的整个世界</label></h4>
                    <div>
                        他背她 她问他沉吗？
                        <br />
                        - 整个世界都在背上你说沉不沉？
                        <p class="tar">
                            对于我来说你就是我的整个世界</p>
                    </div>
                </li>
                <li>
                    <h4>
                        生活因你而精彩</h4>
                    <div>
                        <p>
                            生活因你而变的如此精彩<br />
                            老了<br />
                            看着某些照片会是什么味道<br />
                            生活<br />
                            如此可爱</p>
                    </div>
                </li>
            </ul>
        </div>
    </div>
    <div id="rightwrap">
        <div class="rightbox">
            <% Html.RenderAction("CategoryList", "Category", new { categoryID = Model.CategoryID }); %>
            <div>
                <h4>
                    <label>
                        最近更新</label></h4>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BodyBottomContent" runat="server">
</asp:Content>
