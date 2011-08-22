<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<div id="editarticle">
    <% Html.BeginForm("DoAdd", "Article", FormMethod.Post); %>
    <dl class="edit">
        <dt>
            <label for="articlesubject">
                标题</label></dt>
        <dd>
            <input id="articlesubject" type="text" name="subject" class="text subject" maxlength="200" /></dd>
        <dt>
            <label for="articlebody">
                正文</label>&nbsp;
            <%= Html.ActionLink("?", "Help", "MarkDown", null, new { @class="help"})%>
        </dt>
        <dd>
            <textarea id="articlebody" name="body" cols="50" rows="10" class="abody"></textarea>
        </dd>
        <dt>
            <label for="selcategory">
                分类</label></dt>
        <dd>
            <span>
                <input id="hidcategory" name="category" type="hidden" />
                <select id="selcategory">
                </select>
            </span>
        </dd>
        <dt>
            <label for="tag">
                标签</label></dt>
        <dd>
            <input id="tag" type="text" maxlength="50" name="artitag" class="text tag" />
            <a href="#" title="根据正文自动匹配">自动匹配</a>
        </dd>
        <!--
        <dt>
            <label>
                设置</label></dt>
        <dd>
            <div>
                <label>
                    <input type="radio" name="replyleve" value="all" />允许所有人评论</label>
                <label>
                    <input type="radio" name="replyleve" value="user" />不允许匿名评论</label>
                <label>
                    <input type="radio" name="replyleve" value="no" />不允许评论</label>
            </div>
            <div>
                <label>
                    <input type="checkbox" name="isvisible" />仅自己可见</label>
                <label>
                    <input type="checkbox" name="isreprint" />禁止转载</label>
            </div>
        </dd>
        -->
        <dd class="btndiv">
            <input type="submit" id="savearticle" class="button" value="保存" />
        </dd>
    </dl>
    <% Html.EndForm(); %>
</div>
