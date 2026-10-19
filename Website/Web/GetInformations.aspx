<%@ Page Title="" Language="C#" MasterPageFile="~/Web/MasterPage.master" AutoEventWireup="true" CodeFile="GetInformations.aspx.cs" Inherits="Web_GetInformations" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <style>
        @media only screen and (max-width: 768px) {
            .CustInfo .input-text,.CustInfo .legend {
                width:200% !important;
            }
            .CustInfo
            {
                padding-top:6% !important;
            }
            .imgCallUs
            {
                width:100% !important;
            }
        }
    </style>
    <div class="blog-wrapper f-fix" style="margin-top: 1%">
        <div class="container">
            <div class="">
                <section class="block-news areaBox">
                    <p>
                         <asp:Image ID="imgHeader" style="width: 1150px; height: 200px; border: 2px solid #ad7a21" runat="server" CssClass="HeaderImage img-responsive" />
                    </p>
                    <div id="messages_product_view"></div>
                    <div class="col-md-4 imgCallUs" style="width: 547px; border-left: 1px solid #896c6cb3; background: #faf4e4 none repeat scroll 0 0; line-height: 27px; border: 1px solid #f3e9cc; padding-right: 15px !important">
                        <asp:Image ID="imgCallUs" runat="server" />
                    </div>
                    <div class="col-md-8 CustInfo" style="max-width: 605px; margin-left: 0px; width: 48%; padding-left: 30px">
                        <div class="fieldset">
                            <h2 class="legend">Please Enter Your Details to Continue...</h2>
                            <ul class="form-list">
                                <li class="fields">
                                    <div class="field">
                                        <label for="name" class="required"><em>*</em>Name</label>
                                        <div class="input-box">
                                            <asp:TextBox ID="txtClientName" autocomplete="off" CssClass="input-text required-entry validate-alpha" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtClientName" ID="rfvClientName" runat="server"
                                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                                ValidationGroup="Client">
                                            Please Enter Name
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="field">
                                        <label for="telephone" class="required"><em>*</em>Mobile</label>
                                        <div class="input-box">
                                            <asp:TextBox ID="txtClientNumber" autocomplete="off" MaxLength="10" CssClass="input-text required-entry validate-alpha" runat="server"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender TargetControlID="txtClientNumber" ID="txtClientNumber_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers"></cc1:FilteredTextBoxExtender>
                                            <asp:RequiredFieldValidator ControlToValidate="txtClientNumber" ID="rfvClientNumber" runat="server"
                                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                                ValidationGroup="Client">
                                               Please Enter Number
                                            </asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ControlToValidate="txtClientNumber" ID="revClientNumber" runat="server" ValidationExpression="[0-9]{10}"
                                                Display="Dynamic" ValidationGroup="Client" ErrorMessage="InValid PAN Card" SetFocusOnError="True">
                                            Please Enter Valid Mobile Number
                                            </asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                </li>
                                <li class="fields">
                                    <div class="field">
                                        <label for="email">Email</label>
                                        <div class="input-box">
                                            <asp:TextBox ID="txtClientEmail" autocomplete="off" CssClass="input-text required-entry validate-alpha" runat="server"></asp:TextBox>
                                            <asp:RegularExpressionValidator ControlToValidate="txtClientEmail" ID="revClientEmail" runat="server" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                                Display="Dynamic" ValidationGroup="Client" ErrorMessage="InValid PAN Card" SetFocusOnError="True">
                                             Please Enter Valid Email
                                            </asp:RegularExpressionValidator>
                                        </div>

                                    </div>
                                </li>
                            </ul>
                            <div class="buttons-set" style="float: left">
                                <asp:Button ID="btnInfoSubmit" OnClick="btnInfoSubmit_Click" CssClass="button" ValidationGroup="Client" runat="server" Text="Submit" />
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
</asp:Content>

