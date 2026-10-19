<%@ Page Title="" Language="C#" MasterPageFile="~/Web/MasterPage.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Web_Products" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="blog-wrapper f-fix" style="margin-top: 1%">
        <div class="container">
            <div class="">
                <section class="block-news areaBox">
                    <p>
                         <asp:Image ID="imgHeader" style="width: 1150px; height: 200px; border: 2px solid #ad7a21" runat="server" CssClass="HeaderImage img-responsive" />
                    </p>
                    <div id="messages_product_view"></div>
                </section>
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
            </div>
        </div>
    </div>
</asp:Content>

