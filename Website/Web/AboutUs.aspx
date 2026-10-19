<%@ Page Title="" Language="C#" MasterPageFile="~/Web/MasterPage.master" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="Web_AboutUs" %>

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
                    <div id="messages_product_view"></div><br /><br />
                    <div style="text-align:center" class="aboutUsSection">
                        <p>
                            <h3>About Us</h3>
                        </p>
                        <p style="text-transform:none !important">
                            <asp:Label ID="lblAboutUsText" runat="server" Text="" style="text-transform:none !important"></asp:Label>
                        </p>
                        <p>
                            <h3>Why Us</h3>
                        </p>
                        <p style="text-transform:none !important">
                             <asp:Label ID="lblWhyUsText" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                </section>
            </div>
        </div>
    </div>
</asp:Content>

