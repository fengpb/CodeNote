<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="CodeNote.Web.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    A Pure Boy: Topic
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="nav" ContentPlaceHolderID="Navigation" runat="server">
    <% Html.RenderAction("AccountNav", "Control"); %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftBox" runat="server">
    <div id="editcategory">
        <% Html.RenderAction("Edit", "Category"); %>
    </div>
    <div id="treecategory">
        <% Html.RenderAction("Tree", "Category"); %>
    </div>
</asp:Content>
<asp:Content ID="rightbox" ContentPlaceHolderID="RightBox" runat="server">
    <% Html.RenderAction("AccountLeft", "Control"); %>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BodyBottomContent" runat="server">
    <script type="text/javascript">

        function ChkCategoryChange(that)
        {
            if (that.checked)
            {
                AjaxLoad('<%= Html.Url("Edit", "Category",null)%>', 'editcategory', { 'categoryID': $(that).val() });
            }
        }

        function AddOrEdit()
        {
            var parentid = $('#parentid').val();
            var categoryID = $('#categoryid').val();
            var name = $('#enname').val();
            var title = $('#cnname').val();
            jQuery.ajax({
                url: '<%= Html.Url("DoEdit", "Category",null)%>',
                type: 'post',
                data: { 'parentid': parentid, 'categoryID': categoryID, 'name': name, 'title': title },
                success: function (data)
                {
                    $('#addoreditmsg').html(data.Message);
                    TimerHide('addoreditmsg', 2000);
                    RefreshTree();
                }, error: function ()
                {
                    alert('Add or edit error !');
                }
            });
        }

        function DelCategory()
        {
            var selectedCategory = $(':checkbox[name="chkCategory"][checked]');
            var arrCategory = new Array();
            selectedCategory.each(function (i, v)
            {
                arrCategory.push($(v).val());
            });

            if (arrCategory.length < 1)
            {
                return;
            }
            if (confirm("确定删除选择的分类信息?"))
            {
                var strCategory = arrCategory.join(',');
                jQuery.ajax({
                    url: '<%= Html.Url("DelCategory","Category",null) %>',
                    type: 'post',
                    data: { 'ids': strCategory },
                    success: function (data)
                    {
                        $('#delMessage').html(data.Message);
                        TimerHide('delMessage', 2000);
                        RefreshTree();
                    }
                , error: function ()
                {
                    alert("Ajax error!");
                }
                });
            }
        }

        function RefreshTree()
        {
            AjaxLoad('<%= Html.Url("Tree","Category",null) %>', 'treecategory', null);
        }
       
    </script>
</asp:Content>
