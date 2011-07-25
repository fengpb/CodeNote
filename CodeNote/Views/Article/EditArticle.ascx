<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<div id="editarticle">
    <dl class="edit">
        <dt><label>标题</label></dt>
        <dd>
            <input id="articlesubject" type="text" class="text subject" maxlength="200" /></dd>
            <dt><label>正文</label></dt>
        <dd>
            <div class="note">
                仅支持<a href="#" title="查看MarkDown语法规则">MarkDown</a>语法. &nbsp;&nbsp;<a href="#" title="预览正文">预览</a></div>
            <textarea id="articlebody" cols="50" rows="10" class="abody"></textarea>
        </dd>
        <dt><label>分类</label></dt>
        <dd>
            <select>
            </select>
            <a href="#" title="创建新的分类">创建分类</a>
        </dd>
        <dt><label>标签</label></dt>
        <dd>
            <input type="text" maxlength="50" class="text tag" />
            <a href="#" title="根据正文自动匹配">自动匹配</a>
        </dd>
        <dt><label>设置</label></dt>
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
        <dd class="btndiv">
            <input type="button" id="savearticle" class="button" value="保存" />
        </dd>
    </dl>
</div>
