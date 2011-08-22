<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Account/Account.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="CodeNote.Web.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Catgegory
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="editcategory">
        <% Html.RenderAction("Edit", "Category"); %>
    </div>
    <div id="treecategory">
        <% Html.RenderAction("Tree", "Category"); %>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BodyBottomContent" runat="server">
    <script type="text/javascript">

        function ChkCategoryChange(that) {
            if (that.checked) {
                AjaxLoad('<%= Html.Url("Edit", "Category",null)%>', 'editcategory', { 'categoryID': $(that).val() });
            }
        }

        function AddOrEdit() {
            var parentid = $('#parentid').val();
            var categoryID = $('#categoryid').val();
            var name = $('#enname').val();
            var title = $('#cnname').val();
            jQuery.ajax({
                url: '<%= Html.Url("DoEdit", "Category",null)%>',
                type: 'post',
                data: { 'parentid': parentid, 'categoryID': categoryID, 'name': name, 'title': title },
                success: function (data) {
                    $('#addoreditmsg').html(data.Message);
                    TimerHide('addoreditmsg', 2000);
                    RefreshTree();
                }, error: function () {
                    alert('Add or edit error !');
                }
            });
        }

        function RefreshTree() {
            AjaxLoad('<%= Html.Url("Tree","Category",null) %>', 'treecategory', null);
        }
       
    </script>
</asp:Content>
