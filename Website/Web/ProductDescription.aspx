<%@ Page Title="" Language="C#" MasterPageFile="~/Web/MasterPage.master" AutoEventWireup="true" CodeFile="ProductDescription.aspx.cs" Inherits="Web_ProductDescription" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
    <section class="f-fix content-wrapper oneCol">
        <div class="f-block breadcrumbBox ">
            <div class="container">
                <div class="breadcrumbs">
                    <ul>
                        <li class="home">
                            <a href="Default.aspx" title="Go to Home Page" itemprop="url"><span itemprop="title">Home</span></a>
                            <span>>> </span>
                        </li>
                        <li class="category3">
                            <a href="Products.aspx" title="" itemprop="url"><span itemprop="title">Products</span></a>
                            <span>>> </span>
                        </li>
                        <li class="product">
                            <strong>
                                <asp:Label ID="lblProductName" runat="server" Text=""></asp:Label></strong>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </section>

    <div class="blog-wrapper f-fix" style="margin-top: 0.7%">
        <div class="container">
            <div class="">
                <section class="block-news areaBox">

                    <div id="messages_product_view" style="background:#0a1357;height:30px;color:white;font-size:12pt;padding-top:4px;padding-left:4px;padding-right:4px"><marquee> Thank You For Visiting Our Products, we will Contact You Shortly !</marquee></div>
                    <br />
                    <div class="row">
                        <div class="col-md-4">
                            <div id="myCarousel" class="carousel slide" data-ride="carousel">
                                <div class="carousel-inner">
                                    <div class="item active">
                                        <asp:Image Width="100%" Height="300px" ID="imgProductMain" runat="server" />
                                    </div>
                                    <asp:Repeater ID="repProductPictures" runat="server">
                                        <ItemTemplate>
                                            <div class="item">
                                                <asp:Image ID="imgProductPictures" Height="300px" ImageUrl='<%# "../App_Content/Picture/ProductPicture/actual/"+ Eval("Picture")%>' runat="server" />
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                                    <span class="fa fa-arrow-circle-o-left"></span>
                                    <span class="sr-only">Previous</span>
                                </a>
                                <a class="right carousel-control" href="#myCarousel" data-slide="next">
                                    <span class="fa fa-arrow-circle-o-right"></span>
                                    <span class="sr-only">Next</span>
                                </a>
                            </div>
                        </div>
                        <div class="col-md-1"></div>
                        <div class="col-md-7">
                            <div class="product-name">
                                <h1 style="font-weight: bold">
                                    <asp:Label ID="lblProductName1" runat="server" Text=""></asp:Label>
                                </h1>
                            </div>
                            <hr />
                            <div class="product-price">
                                <h1><span class="fa fa-rupee" style="text-transform: none; color: blue">
                                    <asp:Label ID="lblProductPrice" runat="server" Text=""></asp:Label></span></h1>
                            </div>
                            <hr />
                            <div class="product-description">
                                <asp:Label ID="lblProductDescription" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>

</asp:Content>

