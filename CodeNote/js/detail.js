
function Replay()
{
    var nick = $('#replayNick').val();
    var email = $('#replayEmail').val();
    var body = $('#wmd-input').val();
    var articleID = $('#hidArtilceID').val();
    jQuery.ajax({
        url: '/Reply/Add',
        type: 'post',
        data: { 'articleID': articleID, 'nick': nick, 'email': email, 'body': body },
        success: function (data)
        {
            $('#replayMessage').html(data.Message);
            TimerHide('replayMessage', 2000);
            var refreshUrl = $('#hid_RefreshUrl').val();
            if (refreshUrl)
            {
                AjaxLoad(refreshUrl, 'replyList', null);
            } else
            {
                AjaxLoad('/Reply/ReplyList', 'replyList', { 'articleID': $('#hidArtilceID').val() });
            }
        }, error: function ()
        {
            alert("replay");
        }
    });
}

jQuery(function ()
{

    var converter = Markdown.getSanitizingConverter();
    var editor = new Markdown.Editor(converter);
    editor.run();
});