<%@ Page Title="" Language="C#" MasterPageFile="~/Web/MasterPage.master" AutoEventWireup="true" CodeFile="TestingCertificate.aspx.cs" Inherits="Web_Reports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        td, th {
            padding: 4px !important;
        }
    </style>

    <div class="blog-wrapper f-fix" style="margin-top: 1%">
        <div class="container">
            <div class="">
                <div class="featuredCat f-fix areaBox" style="text-align: center">
                    <div class="col-md-3"></div>
                    <div class="col-md-8" style="max-width: 605px; margin-left: 0px; width: 48%; padding-left: 30px">
                        <h2 class="legend">Serach Result for
                            <br />
                            <span style="color: red">Certificate No. :
                                <asp:Label ID="lblCertificateNo1" runat="server" Text=""></asp:Label>
                                and Weight :
                                <asp:Label ID="lblWeight1" runat="server" Text=""></asp:Label></span></h2>
                        <ul class="form-list">
                            <table width="100%" border="2" cellpadding="5pt" cellspacing="0" bordercolor="#F1F1F1" style="font-weight: bold !important; font-size: 11pt">
                                <tbody>
                                    <tr></tr>
                                    <tr>
                                        <td align="center">
                                            <table cellspacing="5pt" border="0" id="FormView1" style="width: 100%;">
                                                <tbody>
                                                    <tr>
                                                        <td colspan="2">
                                                            <table width="100%" border="1" cellpadding="8" cellspacing="5" bordercolor="#F5F5F5" style="font-weight: bold;">
                                                                <tbody>
                                                                    <tr>
                                                                        <td colspan="3" style="text-align: center">
                                                                            <asp:Image Height="180px" ID="imgCertificatePhoto" runat="server" alt="" onerror="this.src='../App_Content/icon/picture-not-available.jpg';" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="25%" align="right">Certificate No</td>
                                                                        <td width="10">:
                                                                        </td>
                                                                        <td align="left">
                                                                            <span id="FormView1_Label1">
                                                                                <asp:Label ID="lblCertificateNo2" runat="server" Text=""></asp:Label></span>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td width="25%" align="right">Weight</td>
                                                                        <td width="10">:
                                                                        </td>
                                                                        <td align="left">
                                                                            <span id="FormView1_Label1">
                                                                                <asp:Label ID="lblWeight2" runat="server" Text=""></asp:Label></span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="25%" align="right">Unit</td>
                                                                        <td width="10">:
                                                                        </td>
                                                                        <td align="left">
                                                                            <span id="FormView1_Label1">
                                                                                <asp:Label ID="lblUnit" runat="server" Text=""></asp:Label></span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="25%" align="right">Shape & Cut</td>
                                                                        <td width="10">:
                                                                        </td>
                                                                        <td align="left">
                                                                            <span id="FormView1_Label1">
                                                                                <asp:Label ID="lblShapeNCut" runat="server" Text=""></asp:Label></span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="25%" align="right">Dimension</td>
                                                                        <td width="10">:
                                                                        </td>
                                                                        <td align="left">
                                                                            <span id="FormView1_Label1">
                                                                                <asp:Label ID="lblDimension" runat="server" Text=""></asp:Label></span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="25%" align="right">Color</td>
                                                                        <td width="10">:
                                                                        </td>
                                                                        <td align="left">
                                                                            <span id="FormView1_Label1">
                                                                                <asp:Label ID="lblColor" runat="server" Text=""></asp:Label></span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="25%" align="right">R.I.</td>
                                                                        <td width="10">:
                                                                        </td>
                                                                        <td align="left">
                                                                            <span id="FormView1_Label1">
                                                                                <asp:Label ID="lblRI" runat="server" Text=""></asp:Label></span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="25%" align="right">Stone Name</td>
                                                                        <td width="10">:
                                                                        </td>
                                                                        <td align="left">
                                                                            <span id="FormView1_Label1">
                                                                                <asp:Label ID="lblStoneName" runat="server" Text=""></asp:Label></span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="25%" align="right">Comments</td>
                                                                        <td width="10">:
                                                                        </td>
                                                                        <td align="left">
                                                                            <span id="FormView1_Label1">
                                                                                <asp:Label ID="lblComments" runat="server" Text=""></asp:Label></span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="25%" align="right">Variety</td>
                                                                        <td width="10">:
                                                                        </td>
                                                                        <td align="left">
                                                                            <span id="FormView1_Label1">
                                                                                <asp:Label ID="lblVariety" runat="server" Text=""></asp:Label></span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="25%" align="right">Origin</td>
                                                                        <td width="10">:
                                                                        </td>
                                                                        <td align="left">
                                                                            <span id="FormView1_Label1">
                                                                                <asp:Label ID="lblOrigin" runat="server" Text=""></asp:Label></span>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <br />
                            <asp:Button ID="btnBack" CssClass="button" OnClick="btnBack_Click" ValidationGroup="Contact" runat="server" Text="Back" />
                        </ul>
                    </div>
                    <div class="col-md-1"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

