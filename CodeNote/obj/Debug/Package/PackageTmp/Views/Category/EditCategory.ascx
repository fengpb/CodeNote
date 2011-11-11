<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Category>" %>
<%@ Import Namespace="CodeNote.Entity" %>
<!-- 添加修改分类信息 -->
<div>
    <dl class="edit">
        <dt>
            <label for="parentid">
                上级代码<span class="required">*</span></label></dt>
        <dd>
            <input id="parentid" type="text" class="text" value="<%=Model!=null? Model.ParentID:"" %>" />
        </dd>
        <dt>
            <label for="categoryid">
                代&nbsp;&nbsp;&nbsp;码 <span class="required">*</span></label>
        </dt>
        <dd>
            <input id="categoryid" type="text" value="<%=Model!=null? Model.CategoryID:"" %>"
                class="text" name="categoryid" />
        </dd>
        <dt>
            <label for="enname">
                英文名 <span class="required">*</span></label></dt>
        <dd>
            <input id="enname" type="text" value="<%=Model!=null? Model.Name:"" %>" class="text"
                name="name" />
        </dd>
        <dt>
            <label for="cnname">
                中文名 <span class="required">*</span></label>
        </dt>
        <dd>
            <input id="cnname" type="text" value="<%=Model!=null? Model.Title:"" %>" class="text"
                name="title" />
        </dd>
        <dd class="btn">
            <input type="button" onclick="AddOrEdit()" value="保存" class="button" />&nbsp;<span
                id="addoreditmsg" class="message"></span>
        </dd>
    </dl>
</div>
