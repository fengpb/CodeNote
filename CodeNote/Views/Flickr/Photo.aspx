<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Pop.Master" Inherits="System.Web.Mvc.ViewPage<FlickrNet.PhotoInfo>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    A Pure Boy: Photo
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .mgtb10 div { margin: 8px 0px; }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PopTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="mgtb10">
        <h2>
            Photo Info
        </h2>
        <%if (Model != null)
          { %>
        <div>
            <h4>
                <%=Model.SmallUrl%>
            </h4>
            <img src="<%=Model.SmallUrl %>" alt="<%= Model.Title %>" />
        </div>
        <div>
            <h4>
                <%=Model.MediumUrl%></h4>
            <img src="<%=Model.MediumUrl %>" alt="<%= Model.Title %>" />
        </div>
        <div>
            <h4>
                <%=Model.LargeUrl%>
            </h4>
            <img src="<%=Model.LargeUrl %>" alt="<%= Model.Title %>" />
        </div>
        <%}
          else
          { %>
        <p class="null">
            暂无图片数据信息！
        </p>
        <%} %>
        <div>
            <h5>
                <a href="/Flickr">返回继续上传</a>
            </h5>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="BodyBottomContent" runat="server">
</asp:Content>
