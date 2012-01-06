<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>$entity.Subject$</title>
    <meta name="keywords" content="$entity.Subject$ $keywords$" />
    <link href="/css/base.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="/js/CodeNote.Script.js" type="text/javascript"></script>
    <link href="/css/wmd.css" rel="stylesheet" type="text/css" />
    <script src="/js/CodeNote.Article.js" type="text/javascript"></script>
    <script src="/js/Markdown.Converter.js" type="text/javascript"></script>
    <script src="/js/Markdown.Sanitizer.js" type="text/javascript"></script>
    <script src="/js/Markdown.Editor.js" type="text/javascript"></script>
    <script src="/js/write.js" type="text/javascript"></script>
</head>
<body>
    <script type="text/javascript">
        write.navbar('$entity.CategoryID$');
    </script>
    <!--start content -->
    <div id="content">
        <div id="maincontent" class="clearfix">
            <!--start left-->
            <div class="left colwrap">
                <div class="com">
                    <h2 class="posrl">
                        $entity.Subject$
                    </h2>
                    <dl>
                        <dd class="end">
                            <label title="发布时间">
                                Date：<span>$entity.CreateDate$</span></label></dd>
                        <dd>
                            <label title="作者">
                                By：<a href="/">$entity.CreateName$</a></label></dd>
                        <dd>
                            <label>
                                Notic：<a href="/Topic/$entity.CategoryName$" title="$entity.CategoryTitle$">$entity.CategoryTitle$</a></label>
                        </dd>
                        <dd>
                            <label title="标签">
                                Tag：$taglinks$</label>
                        </dd>
                    </dl>
                </div>
                <div class="content">
$entity.Body$
                </div>
                <!--start reply-->
                <h3 class="title mgt10">
                    <input id="hidArtilceID" type="hidden" value="$entity.ID$" />
                    <label title="Reply">
                        评论</label></h3>
                <div id="replyList" class="replyList">
                </div>
                <script type="text/javascript">
                    write.reply($entity.ID$);
                </script>
                <div class="replay">
                    <dl class="edit">
                        <dd>
                            <label>
                                <input id="replayNick" type="text" class="text" name="nick" value="" />&nbsp; 昵称<b
                                    title="必填">*</b></label>
                        </dd>
                        <dd>
                            <label>
                                <input id="replayEmail" type="text" class="text" name="email" value="" />&nbsp;
                                邮件(不公开)<b title="必填">*</b></label>
                        </dd>
                        <dd>
                            <div class="wmd-panel">
                                <div id="wmd-button-bar">
                                </div>
                                <textarea id="wmd-input" class="wmd-input" name="body" cols="50" rows="5"></textarea>
                            </div>
                            <div id="wmd-preview" class="wmd-panel wmd-preview">
                            </div>
                        </dd>
                        <dd class="btn">
                            <input type="button" onclick="Replay()" value="提交评论" />&nbsp;<span id="replayMessage"
                                class="message"><!--Ctrl+Enter--></span></dd>
                    </dl>
                </div>
                <!--end reply-->
            </div>
            <!--end left-->
            <!--start right-->
            <div class="right colwrap">
                <script type="text/javascript">
                    write.categorylist('$entity.CategoryID$');
                    write.articlerec($entity.ID$);
                </script>
            </div>
            <!--end right-->
			 <a class="gotop" href="#top"><span><em class="sj">&diams;</em><em class="fk">▐</em>返回顶部</span>
            </a>
        </div>
    </div>
    <!--end content-->
    <script type="text/javascript">
        write.footer();
    </script>
    <script src="/js/detail.js" type="text/javascript"></script>
</body>
</html>
<!-- up date: $update$ -->
