<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Category>" %>
<%@ Import Namespace="CodeNote.Entity" %>
<!-- 添加修改分类信息 -->
<div>
    <dl class="edit">
        <dt>
            <label for="categoryid">
                代&nbsp;&nbsp;&nbsp;码 <span class="required">*</span></label>
        </dt>
        <dd>
            <%=Model!=null? Model.CategoryID:"" %>
            <input id="categoryid" type="text" class="text" name="categoryid" />
        </dd>
        <dt>
            <label for="enname">
                英文名 <span class="required">*</span></label></dt>
        <dd>
            <input id="enname" type="text" class="text" name="name" />
        </dd>
        <dt>
            <label for="cnname">
                中文名 <span class="required">*</span></label>
        </dt>
        <dd>
            <input id="cnname" type="text" class="text" name="title" />
        </dd>
        <dd class="btn">
            <input type="submit" value="保存" class="button" />
        </dd>
    </dl>
</div>
