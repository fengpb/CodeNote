function AjaxPager(url, target)
{
    if (url == null || url == '')
    {
        alert('place set page url');
    }
    if (target == null || target == '')
    {
        alert('place set target id');
    }
    $('#' + target).html('<div>正在为您加载，请稍候...</div>');
    $.ajax({
        url: encodeURI(url),
        type: 'post',
        success: function (data)
        {
            $('#' + target).html(data);
        },
        error: function ()
        {
            alert('pager error');
        }
    });
}

function AjaxLoad(url, target, data)
{
    if (url == null || url == '')
    {
        alert('place set page url');
    }
    if (target == null || target == '')
    {
        alert('place set target id');
    }
    //$('#' + target).html('<div>正在为您加载，请稍候...</div>');
    $.ajax({
        url: encodeURI(url),
        type: 'post',
        data: data,
        success: function (data)
        {
            $('#' + target).html(data);
        },
        error: function ()
        {
            alert('pager error');
        }
    });
}

function TimerHide(target, time)
{
    window.setTimeout(function ()
    {
        $('#' + target).hide();
    }, time);
}

function setAccountNavCur()
{
    var menuArr = [{ key: "accindex", accindex: ["/Account", "/Account/Index"] }, { key: "scout", scout: ["/Member", "/Member/Info", "/Member/Index"] }, { key: "horse", horse: ["/SwiftHorse", "/SwiftHorse/Info", "/SwiftHorse/Index"]}];
    var url = document.location.href;
    var route = url.substring(url.indexOf('/', 7));
    ////alert(route);
    var isExit = false;
    var currenMenu = "accindex";
    for (var i = 0; i < menuArr.length; i++)
    {
        var key = menuArr[i]['key'];
        for (var j = 0; j < menuArr[i][key].length; j++)
        {
            if (menuArr[i][key][j].toLowerCase() == route.toLowerCase())
            {
                isExit = true;
                currenMenu = key;
                break;
            }
        }
        if (isExit) { break; }
    }
    if (currenMenu != "null") { $("#" + currenMenu).parent("li").addClass("cur"); }
    ///alert(currenMenu);
}

function _rzgotop()
{
    if ($(window).scrollTop() - 200 > 0)
    {
        $('.gotop').css("visibility", "visible");
    } else
    {
        $('.gotop').css("visibility", "hidden");
    }
}

function setGoTop()
{
    _rzgotop();
    window.onresize = _rzgotop;
    window.onscroll = _rzgotop;
}


jQuery(function ()
{
    setGoTop();
});
