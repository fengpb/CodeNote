<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<VwArticle>" %>
<%@ Import Namespace="CodeNote.Entity" %>
<!-- Edit  Article -->
<div id="editarticle">
    <% Html.BeginForm("AddOrEdit", "Article", FormMethod.Post); %>
    <dl class="edit">
        <dt>
            <label for="articlesubject">
                标题</label></dt>
        <dd>
            <input id="articleid" name="articleid" type="hidden" value="<%=Model!=null? Model.ID:0 %>" />
            <input id="articlesubject" type="text" name="subject" class="text subject" value="<%= Model!=null?Model.Subject:"" %>"
                maxlength="200" /></dd>
        <dt class="posrl">
            <label for="articlebody">
                正文</label>&nbsp; <span class="posabsbr">
                    <%= Html.ActionLink("?", "Help", "MarkDown", null, new { @class="help"})%>
                </span></dt>
        <dd>
            <textarea id="articlebody" name="body" cols="50" rows="10" class="abody"><%= Model!=null?Model.Body:"" %></textarea>
        </dd>
        <dt>
            <label for="selcategory">
                分类</label></dt>
        <dd>
            <span>
                <input id="hidcategory" name="category" type="hidden" value="<%= Model!=null?Model.CategoryID:"" %>" />
                <select id="selcategory">
                </select>
            </span>
        </dd>
        <dt>
            <label for="tag">
                标签</label></dt>
        <dd>
            <input id="tag" type="text" maxlength="50" name="artitag" value="<%= Model!=null?Model.Tag:"" %>"
                class="text tag" />
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
