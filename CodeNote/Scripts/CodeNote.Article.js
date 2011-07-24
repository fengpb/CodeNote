var Article = {
    AddUrl: '/Article/DoAdd'
};
function AddArticle() {
    var subject = $('#articlesubject').val();
    var body = $('#articlebody').val();
    $.ajax({
        url: Article.AddUrl,
        type:'post',
        dataType: 'json',
        data: { subject: subject, body: body },
        success: function (data) {
            alert(data.Message);
        },
        error: function () {
        }
    });
};