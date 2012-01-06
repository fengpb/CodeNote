<%@ Control Language="C#" Inherits="CodeNote.Web.ViewUserControl<dynamic>" %>
<!-- start footer  -->
<div id="footer">
    <p>
        <big>&copy;</big> Copyright 2011 纯男孩. All rights reserved. 
    </p>
    <div>
        <%=Html.ActionLink("关于", "About", "Home", null, new { target="_blank",title="About" })%>
        -
        <%=Html.ActionLink("帮助", "Help", "Home", null, new { target="_blank",title="Help",@class="help" })%>
        -
      <a target="_blank" href="/sitemap.xml">SiteMap</a> 
    </div>
</div>
<!-- end footer  -->
