<%@ Page Title="" Language="C#" MasterPageFile="~/Web/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Web_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="f-fix content-wrapper oneCol">
        <div class="container zero">
            <div class="oneBox">
                <div class="columnOne areaBox proArea">
                    <div class="std">
                        <p>
                            <div id="slide_parent" style="width: 1920px">
                                <div id="slider1_container" class="slide_container" style="height: 550px; width: 1920px">
                                    <div u="loading" style="position: absolute; top: 0px; left: 0px;">
                                        <div style="filter: alpha(opacity=70); opacity: 0.7; position: absolute; display: block; background-color: #000; top: 0px; left: 0px; width: 100%; height: 100%;">
                                        </div>
                                        <div style="position: absolute; display: block; background: url(img/loading.html) no-repeat center center; top: 0px; left: 0px; width: 100%; height: 100%;">
                                        </div>
                                    </div>
                                    <div u="slides" class="slides-inner" style="height: 550px; width: 1920px">
                                        <asp:Repeater ID="repMainSlider" runat="server">
                                            <ItemTemplate>
                                                <div class="sli slide-1" style="height: 550px; width: 1920px">
                                                    <img src='<%# "../App_Content/Picture/MainSlider/actual/"+ Eval("Picture")%>' alt="" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <div u="navigator" class="jssorb03">
                                        <div u="prototype" style="position: absolute; width: 23px; height: 23px; text-align: center; line-height: 23px; color: White; font-size: 12px;">
                                        </div>
                                    </div>
                                    <span u="arrowleft" class="jssora20l" style="width: 55px; height: 55px; top: 123px; left: 50px;"></span>
                                    <span u="arrowright" class="jssora20r" style="width: 55px; height: 55px; top: 123px; right: 50px"></span>
                                </div>
                            </div>
                        </p>
                        <div>
                            <div class="container zeroNine">
                                <div class="row oneBox">
                                    <ul class="staticBlock row">
                                        <asp:Repeater ID="repMainImages" runat="server">
                                            <ItemTemplate>
                                                <li class="col-sm-4">
                                                    <a class="areaBox" title='<%# Eval("title") %>' href='<%# Eval("href") %>'>
                                                        <img height="230px" alt='<%# Eval("title") %>' src='<%# "../App_Content/Picture/MainImages/actual/"+ Eval("Picture")%>' />
                                                    </a>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>

                                    <div class="featuredCat f-fix areaBox">
                                        <div class="block-title">
                                            <h2><span>Popular Products</span></h2>
                                        </div>
                                        <ul>
                                            <asp:Repeater ID="repProduct" runat="server" OnItemCommand="repProduct_ItemCommand">
                                                <ItemTemplate>
                                                    <li class="catBlock withfc col-sm-4 col-md-2 col-xs-6">
                                                        <div class="featuredInner">
                                                            <span class="thum-block">
                                                                <asp:ImageButton ImageUrl='<%# "../App_Content/Picture/Product/actual/"+ Eval("picture")%>' Height="160px" ID="imgbtnProductImage" runat="server" AlternateText="" />
                                                            </span>
                                                            <div class="fc-content">
                                                                <asp:Button ID="btnProductName" CssClass="btn btn-danger productbtn" Style="width: 100%; background-color: #990100" runat="server" Text='<%# Eval("name") %>' />
                                                            </div>
                                                            <asp:Label ID="lblProductID" runat="server" Text='<%# Eval("id") %>' Style="display: none"></asp:Label><br />
                                                        </div>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </div>
                                    <div class="row">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>



    <div class="blog-wrapper f-fix">
        <div class="container">
            <div class="">
                <section class="block-news areaBox">
                    <div class="page-title">
                        <h2><span>Latest Blogs</span></h2>
                    </div>
                    <div class="jcarousel-wrapper">
                        <div class="jcarousel scrollerBlog">
                            <asp:Repeater ID="repBlogs" runat="server">
                                <ItemTemplate>
                                    <div class="blogItem">
                                        <div class="img-block">
                                            <a class="blog-img" href="blog/choosing-opal-engagement-ring-stones/index.html">
                                                <img width="100%" height="170px" src='<%# "../App_Content/Picture/Blogs/actual/"+ Eval("Picture")%>' alt='<%# Eval("Title") %>' />
                                            </a>
                                        </div>
                                        <h3><%# Eval("Title") %></h3>
                                        <p class="shortdes"></p>
                                        <ul class="f-block bList">
                                            <li>
                                                <span class="Rblog">
                                                    <a class="blog-img" href="#" style="color: #B78524;">Read More
                                                    </a>
                                                </span>
                                                <strong></strong>
                                            </li>
                                        </ul>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>

                    <script type="text/javascript">
                        (function ($) {


                            $('.scrollerBlog').owlCarousel({
                                loop: true,
                                smartSpeed: 500,
                                dots: false,
                                margin: 30,
                                navText: ["Back", "Next"],
                                responsiveClass: true,
                                responsive: {
                                    0: {
                                        items: 1,
                                        nav: true
                                    },
                                    600: {
                                        items: 2,
                                        nav: true
                                    },
                                    1000: {
                                        items: 3,
                                        nav: true,
                                        loop: true
                                    },
                                    1000: {
                                        items: 4,
                                        nav: true
                                    }
                                }
                            })


                        })(jQuery);
				</script>
                </section>
            </div>
        </div>
    </div>
    <section class="f-block">
        <div class="container sepArea">
            <div class="areaBox f-block">
                <div class="col-sm-14">
                    <div style="width: 46%; float: left">
                        <h3>Why Buy from
                            <asp:Label ID="lblCompanyName" runat="server" Text=""></asp:Label></h3>
                        <asp:Label ID="lblWhyUsText" runat="server" Text="" Style="text-transform: none !important"></asp:Label>
                    </div>
                    <div style="float: right; width: 48%;">
                        <h3>About us</h3>
                        <asp:Label ID="lblAboutUsText" runat="server" Text="" Style="text-transform: none !important"></asp:Label>
                        <a href="AboutUs.aspx" style="color: blue">read more...</a>
                    </div>
                </div>
                <div class="blog-wrapper f-fix">
                    <hr />
                    <h3>Customer Ratings</h3>
                    <ul class="staticBlock row">
                        <asp:Repeater ID="repRating" runat="server">
                            <ItemTemplate>
                                <li class="col-sm-4">
                                    <a class="areaBox1" title='<%# Eval("title") %>' href='<%# Eval("href") %>'>
                                        <img title='<%# Eval("title") %>' height="180px" width="100%" alt="Google Plus" src='<%# "../App_Content/Picture/Rating/actual/"+ Eval("Picture")%>' />
                                    </a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
    </section>
    <section class="f-block">
        <div class="container">
            <div class="areaBox">
                <section class="testimonial-wrapper">
                    <div class="page-title">
                        <h2><span>Customer Reviews</span></h2>
                    </div>
                    <div class="jcarousel-wrapper">
                        <div class="jcarousel">
                            <div id="owl-demo5" class="scroller-testimonial">
                                <asp:Repeater ID="repReview" runat="server">
                                    <ItemTemplate>
                                        <div class="testimonialPan">
                                            <img class="testimonialThumb img-circle" style="width: 60px !important; height: 60px !important" src='<%# "../App_Content/Picture/Review/actual/"+ Eval("Picture")%>' alt='<%# Eval("Name") %>'>
                                            <p>
                                                <i class="quote fa fa-quote-left"></i>
                                                <%# Eval("Review") %>
                                                <span class="author" style="font-weight: bold; text-transform: uppercase"><%# Eval("Name") %></span>
                                            </p>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </section>
                <script type="text/javascript">
                    (function ($) {

                        $('.scroller-testimonial').owlCarousel({
                            loop: true,
                            lazyLoad: true,
                            smartSpeed: 500,
                            dots: false,
                            dotsContainer: false,
                            navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
                            responsiveClass: true,
                            autoplay: true,
                            autoplayTimeout: 5000,
                            responsive: {
                                0: {
                                    items: 1,
                                    nav: true
                                },
                                600: {
                                    items: 1,
                                    nav: true
                                },
                                1000: {
                                    items: 1,
                                    nav: true,
                                    loop: true
                                }
                            }
                        })

                    })(jQuery);
	</script>
            </div>
        </div>
    </section>
</asp:Content>

