function AjaxPager(url, target) {
    if (url == null || url == '') {
        alert('place set page url');
    }
    if (target == null || target == '') {
        alert('place set target id');
    }

    $.ajax({
        url: encodeURI(url),
        type: 'post',
        success: function (data) {
            $('#' + target).html(data);
        },
        error: function () {
            alert('pager error');
        }
    });
}