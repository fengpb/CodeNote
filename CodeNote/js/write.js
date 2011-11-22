/*用于输出信息*/
var url = {
    navbar: '/Control/Navigation',
    reply: '/Reply/ReplyList', //文章回复信息
    categorylist: '/Category/CategoryList', //分类列表
    articlerec: '/Article/ArticleRec', //推荐文章
    footer: '/Control/Footer'
};

var write = {
    navbar: function (categoryID)
    {
        document.write('<div id="navbar"></div>');
        jQuery.get(url.navbar, { categoryID: categoryID }, function (data)
        {
            $('#navbar').replaceWith(data);
        });
    },
    reply: function (articleID)
    {
        jQuery.get(url.reply, { articleID: articleID }, function (data)
        {
            $('#replyList').html(data);
        });
    },
    categorylist: function (categoryID)
    {
        document.write('<div id="categorylist"></div>');
        jQuery.get(url.categorylist, { categoryID: categoryID }, function (data)
        {
            $('#categorylist').replaceWith(data);
        });
    },
    articlerec: function (articleID)
    {
        document.write('<div id="articlerec"></div>');
        jQuery.get(url.articlerec, { articleID: articleID }, function (data)
        {
            $('#articlerec').replaceWith(data);
        });
    },
    footer: function ()
    {
        document.write('<div id="footer"></div>');
        jQuery.get(url.footer, function (data)
        {
            $('#footer').replaceWith(data);
        });
    }
};