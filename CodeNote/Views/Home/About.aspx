<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Pop.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    About
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="PopTitle" runat="server">
    <li><a href="/" title="Home">首页</a> </li>
    <li class="cur"><a title="About">关于我们</a> </li>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="magtlf10">
        <h4 class="mgb10">
            关于</h4>
        <p>
            此网站由<a>Feng</a>提供。<br />
            代码发布在<a href="http://github.com/fpobin/CodeNote">github.com</a>中。有需要的盆友可以到<a href="http://github.com/fpobin/CodeNote">github.com</a>获取。
        </p>
        <h4 class="mgtb10">
            声明
        </h4>
        <p>
            此网站内容均为用户分享类数据，转载请注明出处。<br />
            对于网站中侵犯了您的权利的信息，请联系我们。我们会尽快处理。<br />
            对于<a>Hake</a>朋友，我只是小地方，就不劳您大驾了。如有冒犯，请联系我们.<br />
            <br />
            最后！<br />
            <br />
            请大家都<a>和谐</a>上网。
            <br />
            <br />
            致此!<br />
            谢谢!
        </p>
        <h4 class="mgtb10">
            联系
        </h4>
        <p>
            Email：fengpengbin@live.cn
            <br />
            QQ：&nbsp;&nbsp; 673208900
        </p>
    </div>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="BodyBottomContent" runat="server">
</asp:Content>
