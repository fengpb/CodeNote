function AjaxPager(url, target) {
    if (url == null || url == '') {
        alert('place set page url');
    }
    if (target == null || target == '') {
        alert('place set target id');
    }
    $('#' + target).html('<div>正在为您加载，请稍候...</div>');
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

function AjaxLoad(url, target, data) {
    if (url == null || url == '') {
        alert('place set page url');
    }
    if (target == null || target == '') {
        alert('place set target id');
    }
    //$('#' + target).html('<div>正在为您加载，请稍候...</div>');
    $.ajax({
        url: encodeURI(url),
        type: 'post',
        data: data,
        success: function (data) {
            $('#' + target).html(data);
        },
        error: function () {
            alert('pager error');
        }
    });
}

function TimerHide(target, time) {
    window.setTimeout(function () {
        $('#' + target).hide();
    }, time);
}