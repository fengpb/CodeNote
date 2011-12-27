<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Pop.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    A Pure Boy: Flickr App
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="/js/jquery.ocupload-1.1.2.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PopTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="mgtb10">
        <form action="/Flickr/UpLoadImg" method="post" enctype="multipart/form-data">
        <dl>
            <dt>
                <label title="File">
                    文件</label></dt>
            <dd>
                <a id="selfile" href="javascript:void(0);">选择文件 </a>
                <label id="selfileName">
                </label>
            </dd>
            <dt>
                <label title="Title">
                    标题</label>
            </dt>
            <dd>
                <input id="ftitle" type="text" name="title" class="text" />
            </dd>
            <dt>
                <label title="Desp">
                    描述
                </label>
            </dt>
            <dd>
                <textarea id="fdesp" cols="50" rows="5" name="desp" class="area"></textarea>
            </dd>
            <dt>
                <label title="Tag">
                    标签</label></dt>
            <dd>
                <input id="ftags" type="text" name="tags" class="text" />
            </dd>
            <dd class="btndiv">
                <input id="btnsend" type="button" onclick="sendsubmit()" value="提交" class="button" />
                <label id="lblmessage" class="message hide">
                    <img src="/img/loading.gif" alt="" />
                </label>
            </dd>
        </dl>
        </form>
        <script type="text/javascript">
            var myUpload;
            jQuery(function ()
            {
                myUpload = $('#selfile').upload({
                    name: 'file',
                    action: '/Flickr/UpLoadImg',
                    enctype: 'multipart/form-data',
                    autoSubmit: false,
                    onSelect: function ()
                    {
                        $('#selfileName').text(myUpload.filename);
                    },
                    onComplete: function (response)
                    {
                        var ret = jQuery.parseJSON(response);
                        $('#lblmessage').html(ret.msg);
                        $('#btnsend').removeAttr('disabled');
                        if (ret.ret)
                        {
                            window.location.href = ret.refurl;
                        }
                    }
                });
            });
            function sendsubmit()
            {

                myUpload.set('params', { 'title': $('#ftitle').val(), 'desp': $('#fdesp').val(), 'tags': $('#ftags').val(), 'ajax': 'ajax' });
                myUpload.submit();
                //disabled = "disabled"
                $('#btnsend').attr('disabled', 'disabled');
                $('#lblmessage').append("上传中..").show();
            }
        </script>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="BodyBottomContent" runat="server">
</asp:Content>
