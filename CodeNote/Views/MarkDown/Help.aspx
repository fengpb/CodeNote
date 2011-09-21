<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Pop.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    MarkDown - Help
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="PopTitle" ContentPlaceHolderID="PopTitle" runat="server">
    <li><a href="/" title="Home">首页</a></li>
    <li class="cur"><a>MarkDown 语法</a> </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="maincontent">
        <div id="leftwrap">
            <div class="leftbox">
                <div class="magtlf10 mgt10">
                    <h4>
                        <span title="Header Tag"><a id="tagHeader">Header标记</a></span>
                    </h4>
                    <div>
                        <h5>
                            <label title="Code">
                                代码：</label></h5>
                        <div class="code">
                            <code># 这是 h1 标签<br />
                                ......<br />
                                ### 这是 h3 标签<br />
                                ......<br />
                                ###### 这是 h6 标签 </code>
                        </div>
                        <h5>
                            <label title="Output">
                                输出：</label></h5>
                        <div class="output">
                            <code>&lt;h1&gt;这是 h1 标签&lt;/h1&gt;<br />
                                ......<br />
                                &lt;h3&gt;这是 h3 标签&lt;/h3&gt;<br />
                                ......<br />
                                &lt;h6&gt;这是 h6 标签&lt;/h6&gt;<br />
                            </code>
                        </div>
                    </div>
                    <h4>
                        <span title="UL Tag"><a id="tagLi">列表标记</a></span>
                    </h4>
                    <div>
                        <h5>
                            <label title="Code">
                                代码：</label></h5>
                        <div class="code">
                            <code>+ 这是列表1<br />
                                + 这是列表2<br />
                                <br />
                                # and<br />
                                <br />
                                - 这是列表3<br />
                                - 这是列表4<br />
                                <br />
                                # or<br />
                                <br />
                                1. 这是标签1<br />
                                2. 这是标签2 </code>
                        </div>
                        <h5>
                            <label title="Output">
                                输出：</label></h5>
                        <div class="output">
                            <code>&lt;ul&gt;<br />
                                &nbsp;&nbsp;&lt;li&gt;这是列表1&lt;/li&gt;<br />
                                &nbsp;&nbsp;&lt;li&gt;这是列表2&lt;/li&gt;<br />
                                &lt;/ul&gt;<br />
                                <br />
                                &lt;h1&gt;and&lt;/h1&gt;<br />
                                <br />
                                &lt;ul&gt;<br />
                                &nbsp;&nbsp;&lt;li&gt;这是列表3&lt;/li&gt;<br />
                                &nbsp;&nbsp;&lt;li&gt;这是列表4&lt;/li&gt;<br />
                                &lt;/ul&gt;<br />
                                <br />
                                &lt;h1&gt;or&lt;/h1&gt;<br />
                                <br />
                                &lt;ol&gt;<br />
                                &nbsp;&nbsp;&lt;li&gt;这是列表1&lt;/li&gt;<br />
                                &nbsp;&nbsp;&lt;li&gt;这是列表2&lt;/li&gt;<br />
                                &lt;/ol&gt;<br />
                            </code>
                        </div>
                    </div>
                    <h4>
                        <span title="With multiple"><a id="A1">组合标记</a></span></h4>
                    <div>
                        <h5>
                            <label title="Code">
                                代码：</label></h5>
                        <div class="code">
                            <code>* &nbsp;&nbsp;A list item.<br />
                                <br />
                                &nbsp;&nbsp;&nbsp; With multiple paragraphs.<br />
                                <br />
                                * &nbsp;&nbsp;Another item in the list. </code>
                        </div>
                        <h5>
                            <label title="Output">
                                输出：</label></h5>
                        <div class="output">
                            <code>&lt;ul&gt;<br />
                                &nbsp;&nbsp;&lt;li&gt;<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;A list item.&lt;/p&gt;<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;With multiple paragraphs.&lt;/p&gt;<br />
                                &nbsp;&nbsp;&lt;/li&gt;<br />
                                &nbsp;&nbsp;&lt;li&gt;<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;Another item in the list.&lt;/p&gt;<br />
                                &nbsp;&nbsp;&lt;/li&gt;<br />
                                &lt;/ul&gt; </code>
                        </div>
                    </div>
                </div>
                <!-- end content -->
            </div>
            <div class="clearfix">
            </div>
        </div>
        <div id="rightwrap">
            <div class="rightbox">
                <ul>
                    <li><a href="#tagHeader">Hearder 标签</a></li>
                    <li><a href="#tagLi">列表标签</a> </li>
                </ul>
            </div>
            <div class="clearfix">
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BodyBottomContent" runat="server">
</asp:Content>
