<%@ Page Title="" Language="C#" MasterPageFile="~/Web/MasterPage.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="Web_ContactUs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        @media only screen and (max-width: 768px) {
            .ContactUs1 .input-text {
                width:200% !important;
            }
        }
    </style>
    <div class="blog-wrapper f-fix" style="margin-top: 1%">
        <div class="container">
            <div class="">
                <section class="block-news areaBox">
                    <p>
                        <asp:Image ID="imgHeader" Style="width: 1150px; height: 200px; border: 2px solid #ad7a21" runat="server" CssClass="HeaderImage img-responsive" />
                    </p>
                    <div id="messages_product_view"></div>
                    <div class="col-md-4 contactUs" style="width: 547px; border-left: 1px solid #896c6cb3; background: #faf4e4 none repeat scroll 0 0; line-height: 27px; border: 1px solid #f3e9cc; padding-right: 15px !important">
                        <div style="margin-left: 11px !important; text-transform: none; color: #936922; font-size: 14px;">
                            <div style="text-align: center">
                                <p>
                                    <asp:Image Style="margin: 9px 0px 4px 0px; height: 112px" ID="imgCompanyLogo" runat="server" alt="" />
                                </p>
                            </div>
                            <div itemprop="address" style="text-align: center">
                                <p>
                                    <asp:Label ID="lblCompanyAddress" runat="server" Text=""></asp:Label><br />
                                    <b>Email :</b>
                                    <asp:Label ID="lblFooterEmail" runat="server" Text=""></asp:Label><br />
                                    <b>Phone :</b>
                                    <asp:Label ID="lblFooterPhone" runat="server" Text=""></asp:Label><br />
                                    <b>Mobile :</b>
                                    <asp:Label ID="lblFooterMobile" runat="server" Text=""></asp:Label>
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-8 ContactUs1" style="max-width: 605px; margin-left: 0px; width: 48%; padding-left: 30px">
                        <div class="fieldset">
                            <h2 class="legend">Query Form</h2>
                            <ul class="form-list">
                                <li class="fields">
                                    <div class="field">
                                        <label for="name" class="required"><em>*</em>Name</label>
                                        <div class="input-box">
                                            <asp:TextBox ID="txtQueryName" autocomplete="off" CssClass="input-text required-entry validate-alpha" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtQueryName" ID="rfvQueryName" runat="server"
                                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                                ValidationGroup="Contact">
                                            Please Enter Name
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="field">
                                        <label for="email" class="required"><em>*</em>Email</label>
                                        <div class="input-box">
                                            <asp:TextBox ID="txtQueryEmail" autocomplete="off" CssClass="input-text required-entry validate-alpha" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtQueryEmail" ID="rfvQueryEmail" runat="server"
                                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                                ValidationGroup="Contact">
                                             Please Enter Email
                                            </asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ControlToValidate="txtQueryEmail" ID="revQueryEmail" runat="server" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                                Display="Dynamic" ValidationGroup="Contact" ErrorMessage="InValid PAN Card" SetFocusOnError="True">
                                             Please Enter Valid Email
                                            </asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                </li>
                                <li class="fields">
                                    <div class="field">
                                        <label for="telephone" class="required"><em>*</em>Mobile</label>
                                        <div class="input-box">
                                            <asp:TextBox ID="txtQueryNumber" autocomplete="off" MaxLength="10" CssClass="input-text required-entry validate-alpha" runat="server"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender TargetControlID="txtQueryNumber" ID="txtQueryNumber_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers"></cc1:FilteredTextBoxExtender>
                                            <asp:RequiredFieldValidator ControlToValidate="txtQueryNumber" ID="rfvQueryNumber" runat="server"
                                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                                ValidationGroup="Contact">
                                               Please Enter Number
                                            </asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ControlToValidate="txtQueryNumber" ID="revQueryNumber" runat="server" ValidationExpression="[0-9]{10}"
                                                Display="Dynamic" ValidationGroup="Contact" ErrorMessage="InValid PAN Card" SetFocusOnError="True">
                                            Please Enter Valid Mobile Number
                                            </asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <div class="field">
                                        <label for="location" class="required"><em>*</em>Location</label>
                                        <div class="input-box">
                                            <asp:TextBox ID="txtQueryLocation" autocomplete="off" CssClass="input-text required-entry validate-alpha" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtQueryLocation" ID="rfvQueryLocation" runat="server"
                                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                                ValidationGroup="Contact">
                                           Please Enter Location
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </li>
                                <li class="wide">
                                    <label for="comment" class="required"><em>*</em>Message</label>
                                    <asp:TextBox ID="txtQueryQuery" autocomplete="off" CssClass="input-text required-entry validate-alpha" TextMode="MultiLine" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ControlToValidate="txtQueryQuery" ID="rfvQueryQuery" runat="server"
                                        Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                        ValidationGroup="Contact">
                                     Please Enter Your Query
                                    </asp:RequiredFieldValidator>
                                </li>
                            </ul>
                            <div class="buttons-set" style="float: left">
                                <asp:Button ID="btnQuerySubmit" CssClass="button" OnClick="btnQuerySubmit_Click" ValidationGroup="Contact" runat="server" Text="Submit" />
                            </div>
                        </div>
                    </div>
                    <iframe id="CompanyMap" runat="server" width="95%" height="280" frameborder="0" style="border: 0; margin-top: 1%" allowfullscreen></iframe>
                </section>
            </div>
        </div>
    </div>
</asp:Content>

