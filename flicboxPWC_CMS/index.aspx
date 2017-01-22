<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="flicboxPWC_CMS.index" %>

<!DOCTYPE html>
<!--[if IE 8]><html class="no-js lt-ie9" lang="en"> <![endif]-->
<!--[if gt IE 8]>
<!-->
<html xmlns="http://www.w3.org/1999/xhtml" class="no-js" lang="en">
<!--<![endif]-->
<head runat="server">
    <meta charset="utf-8" />
    <title>Flicbox - It's Flicking Sweet</title>
    <meta name="description" content="It's Flicking Sweet" />
    <meta name="author" content="Prasad Web Creations" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link href="css/SkewedCSS.css" rel="stylesheet" />
    <%--<link rel="stylesheet" type="text/css" href="css/jquery.multiscroll.css" />--%>
    <link rel="stylesheet" type="text/css" href="css/style-intro.css" />
    <link rel="stylesheet" href="css/retina.css" />
    

    <link rel="shortcut icon" href="images/favicon.png" />
    <link rel="apple-touch-icon" href="images/favicon.png" />
    <link rel="apple-touch-icon" sizes="72x72" href="images/favicon.png" />
    <link rel="apple-touch-icon" sizes="114x114" href="images/favicon.png" />
    <script type="text/javascript" src="js/modernizr.custom.js"></script>
    <!--[if IE]>
		<script type="text/javascript">
			 var console = { log: function() {} };
		</script>
	<![endif]-->
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', 'https://www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-81211437-1', 'auto');
        ga('send', 'pageview');

    </script>
</head>
<body class="royal_loader">
    <form id="form1" runat="server">
        <header id="header" class="header-main">
            <!-- Begin Navbar -->
            <nav id="main-navbar" class="navbar navbar-default navbar-fixed-top" role="navigation">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed text-right" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                        <span class="sr-only">Tree Ganesha</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand page-scroll" href="index.aspx">
                        <img src="images/flicbox.png" alt="Flicbox" /></a>
                </div>
                <div class="navbar-collapse collapse" id="bs-example-navbar-collapse-1" aria-expanded="false">
                    <div class="col-md-8">
                        <ul class="nav navbar-nav navbar-right">
                            <li class="active"><a href="index.aspx">HOME</a></li>
                            <li><a href="about.aspx">ABOUT US</a></li>
                            <li><a href="shop.aspx">Shop</a></li>
                            <li><a href="corporate-gifting.aspx">Corporate Gifting</a></li>
                            <li><a href="#">Blog</a></li>
                            <li><a href="contact.aspx">Contact us</a></li>
                        </ul>
                    </div>
                    <div class="col-md-4">
                        <div class="loginArea">
                            <a id="btnLogin" runat="server" href="~/my-account/login.aspx" data-hover="Login / Register">Login / Register</a>
                            <br />
                            <a id="btnUser" runat="server" href="~/my-account/dashboard.aspx"></a>
                            <asp:ScriptManager ID="ScriptManager1" runat="server" />
                            <asp:UpdatePanel ID="masterPanel" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div>
                                        <a href="cart.aspx"><span class="glyphicon glyphicon-shopping-cart"></span>
                                            <asp:Label ID="lblCartCount" runat="server" CssClass="badge badge-warning" ForeColor="White" />
                                        </a>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                    </div>

                </div>
            </nav>
        </header>
        <div class="skw-pages">
            <table>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <%--    
                    <asp:Repeater ID="rptProducts" runat="server">
                        <HeaderTemplate>
                            <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="lblProductName" runat="server" Text='<%#Eval("CategoryName") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlSubScription" runat="server" AutoPostBack="false" DataSourceID="sqlDataSource1"
                                        DataValueField="ID"
                                        DataTextField="VALUE">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="sqlDataSource1" runat="server"
                                        ConnectionString="<%$ ConnectionStrings:conStr %>"
                                        SelectCommand=" exec [dbo].[GetSubscriptionTypeCombo] @SP_TYPE='ByProductName', @SP_Searchstring=@varcharProductName"
                                        CancelSelectOnNullParameter="true">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="lblProductName" Name="varcharProductName" Type="String" Size="100" ConvertEmptyStringToNull="false" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                                <td>
                                    <div class="cl-effect-11">
                                        <asp:LinkButton ID="btnSubscribe" runat="server" data-hover="Subscribe" OnClick="btnSubscribe_Click">Subscribe</asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="cl-effect-11">
                                        <asp:LinkButton ID="btnOneTime" runat="server" data-hover="One Time" OnClick="btnOneTime_Click">One Time</asp:LinkButton>
                                    </div>
                                </td>
                                <td>
                                    <div class="cl-effect-11">
                                        <asp:LinkButton ID="btnGift" runat="server" data-hover='Gift' OnClick="btnGift_Click">
                                         Gift
                                        </asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                        <tfoot>
                        </tfoot>
                        </FooterTemplate>
                    </asp:Repeater> 

                        --%>
                        <!--new code added-->
                        <asp:Repeater ID="rptProducts" runat="server" OnItemDataBound="rptProducts_ItemDataBound">
                            <HeaderTemplate>
                                <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr style="width: 100%">
                                    <td style="width: 100%">
                                        <div class='skw-page skw-page-<%# ((Container.ItemIndex + 1) == 1) ? (Container.ItemIndex + 1).ToString() +" active" : (Container.ItemIndex + 1).ToString()   %>'>
                                            <div class="skw-page__half skw-page__half--left">
                                                <div class="skw-page__skewed">
                                                    <asp:PlaceHolder ID="skw_left" runat="server"></asp:PlaceHolder>
                                                </div>
                                            </div>
                                            <div class="skw-page__half skw-page__half--right">
                                                <div class="skw-page__skewed">
                                                    <asp:PlaceHolder ID="skw_right" runat="server"></asp:PlaceHolder>
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                        <tfoot>
                        </tfoot>
                            </FooterTemplate>
                        </asp:Repeater>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </table>
        </div>

    </form>
    <script type="text/javascript" src="js/jquery.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="js/retina-1.1.0.min.js"></script>
    <script type="text/javascript" src="js/royal_preloader.min.js"></script>
    <script type="text/javascript">
        (function ($) {
            "use strict";
            Royal_Preloader.config({
                mode: 'number', // 'number', "text" or "logo"
                timeout: 0,
                showInfo: true,
                showPercentage: true,
                opacity: 1,
                background: ['#000000']
            });
        })(jQuery);
    </script>

    <!--new jquery-->
    <script>
        $(document).ready(function () {

            var curPage = 1;
            var numOfPages = $(".skw-page").length;
            var animTime = 1000;
            var scrolling = false;
            var pgPrefix = ".skw-page-";

            function pagination() {
                scrolling = true;

                $(pgPrefix + curPage).removeClass("inactive").addClass("active");
                $(pgPrefix + (curPage - 1)).addClass("inactive");
                $(pgPrefix + (curPage + 1)).removeClass("active");

                setTimeout(function () {
                    scrolling = false;
                }, animTime);
            };

            function navigateUp() {
                if (curPage === 1) return;
                curPage--;
                pagination();
            };

            function navigateDown() {
                if (curPage === numOfPages) return;
                curPage++;
                pagination();
            };

            $(document).on("mousewheel DOMMouseScroll", function (e) {
                if (scrolling) return;
                if (e.originalEvent.wheelDelta > 0 || e.originalEvent.detail < 0) {
                    navigateUp();
                } else {
                    navigateDown();
                }
            });

            $(document).on("keydown", function (e) {
                if (scrolling) return;
                if (e.which === 38) {
                    navigateUp();
                } else if (e.which === 40) {
                    navigateDown();
                }
            });

        });
    </script>
    <script type="text/javascript">

        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-36251023-1']);
        _gaq.push(['_setDomainName', 'jqueryscript.net']);
        _gaq.push(['_trackPageview']);

        (function () {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();

    </script>

    <script type="text/javascript" src="js/jquery.easings.min.js"></script>
    <%--<script type="text/javascript" src="js/jquery.multiscroll.js"></script>--%>
    <script type="text/javascript" src="js/classie.js"></script>
    <script type="text/javascript" src="js/uiMorphingButton_fixed.js"></script>
    <script type="text/javascript" src="js/flippy.js"></script>
        <script type="text/javascript" src="js/template-intro.js"></script>
</body>
</html>
