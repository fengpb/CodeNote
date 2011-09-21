///设置当前导航菜单
function InitCurMenu() {
    var url = window.location.href.substring(7);
    var temp = url.indexOf('/');
    if (temp > 0) {
        url = url.substring(temp);
    }
    $('a[href="' + url + '"]').parents('li').addClass('cur');
}
jQuery(function () {
    InitCurMenu();
});

