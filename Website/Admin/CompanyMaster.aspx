<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="CompanyMaster.aspx.cs" Inherits="Admin_CompanyMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <section class="content-header">
        <h1>
            <asp:Label ID="lblHeading" runat="server" Style="text-transform: uppercase" Text=""></asp:Label>
        </h1>
        <ol class="breadcrumb">
        </ol>
    </section>
    <section class="content">
        <div class="box box-default">
            <div class="box-header with-border">
                <h3 class="box-title">Update Company Master</h3>
                <div class="box-tools pull-right">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                </div>
            </div>
            <div class="box-body">
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Company Name</label>
                            <asp:TextBox ID="txtCompanyName" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtCompanyName" ID="rfvCompanyName" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Company Name
                            </div>
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Owner Name</label>
                            <asp:TextBox ID="txtOwnerName" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtOwnerName" ID="rfvOwnerName" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Owner Name
                            </div>
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Company Logo</label>
                            <asp:FileUpload ID="fuCompanyLogo" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Company Short Logo</label>
                            <asp:FileUpload ID="fuCompanyShortLogo" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>GSTIN</label>
                            <asp:TextBox ID="txtGSTIN" MaxLength="15" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtGSTIN" ID="rfvGSTIN" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter GSTIN
                            </div>
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ControlToValidate="txtGSTIN" ID="revGSTIN" runat="server" ValidationExpression="[0-9]{2}[(a-z)(A-Z)]{5}\d{4}[(a-z)(A-Z)]{1}\d{1}Z[(0-9)(a-z)(A-Z)]{1}"
                                Display="Dynamic" ValidationGroup="a" ErrorMessage="InValid PAN Card" SetFocusOnError="True">
                                <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Valid GSTIN
                            </div>
                            </asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>PAN </label>
                            <asp:TextBox ID="txtPAN" MaxLength="10" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtPAN" ID="rfvPAN" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter PAN
                            </div>
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ControlToValidate="txtPAN" ID="revPAN" runat="server" ValidationExpression="[A-Z]{5}\d{4}[A-Z]{1}"
                                Display="Dynamic" ValidationGroup="a" ErrorMessage="InValid PAN Card" SetFocusOnError="True">
                                <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Valid PAN
                            </div>
                            </asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Phone 1</label>
                            <asp:TextBox ID="txtPhone1" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtPhone1" ID="rfvPhone1" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Phone
                            </div>
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Phone 2 </label>
                             <asp:TextBox ID="txtPhone2" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator ControlToValidate="txtMobile2" ID="rfvMobile2" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Mobile2
                            </div>
                            </asp:RequiredFieldValidator>--%>
                            <asp:RegularExpressionValidator ControlToValidate="txtMobile2" ID="RegularExpressionValidator2" runat="server" ValidationExpression="[0-9]{10}"
                                Display="Dynamic" ValidationGroup="a" ErrorMessage="InValid PAN Card" SetFocusOnError="True">
                                <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Valid Mobile Number
                            </div>
                            </asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Mobile 1</label>
                            <asp:TextBox ID="txtMobile1" MaxLength="10" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender TargetControlID="txtMobile1" ID="txtMobile1_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers"></cc1:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ControlToValidate="txtMobile1" ID="rfvMobile1" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Mobile1
                            </div>
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ControlToValidate="txtMobile1" ID="revMobile1" runat="server" ValidationExpression="[0-9]{10}"
                                Display="Dynamic" ValidationGroup="a" ErrorMessage="InValid PAN Card" SetFocusOnError="True">
                                <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Valid Mobile Number
                            </div>
                            </asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Mobile 2 </label>
                            <asp:TextBox ID="txtMobile2" MaxLength="10" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender TargetControlID="txtMobile2" ID="txtMobile2_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers"></cc1:FilteredTextBoxExtender>
                            <%--  <asp:RequiredFieldValidator ControlToValidate="txtMobile2" ID="rfvMobile2" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Mobile2
                            </div>
                            </asp:RequiredFieldValidator>--%>
                            <asp:RegularExpressionValidator ControlToValidate="txtMobile2" ID="revMobile2" runat="server" ValidationExpression="[0-9]{10}"
                                Display="Dynamic" ValidationGroup="a" ErrorMessage="InValid PAN Card" SetFocusOnError="True">
                                <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Valid Mobile Number
                            </div>
                            </asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>E-mail 1</label>
                            <asp:TextBox ID="txtEmail1" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtEmail1" ID="rfvEmail1" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Email1
                            </div>
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ControlToValidate="txtEmail1" ID="revEmail1" runat="server" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                Display="Dynamic" ValidationGroup="a" ErrorMessage="InValid PAN Card" SetFocusOnError="True">
                                <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Valid Email
                            </div>
                            </asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>E-mail 2 </label>
                            <asp:TextBox ID="txtEmail2" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator ControlToValidate="txtEmail2" ID="rfvEmail2" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Email2
                            </div>
                            </asp:RequiredFieldValidator>--%>
                            <asp:RegularExpressionValidator ControlToValidate="txtEmail2" ID="revEmail2" runat="server" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                Display="Dynamic" ValidationGroup="a" ErrorMessage="InValid PAN Card" SetFocusOnError="True">
                                <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Valid Email
                            </div>
                            </asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Website</label>
                            <asp:TextBox ID="txtWebsite" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtWebsite" ID="rfvWebsite" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Website
                            </div>
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Address </label>
                            <asp:TextBox ID="txtAddress" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtAddress" ID="rfvAddress" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Address
                            </div>
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Google Map API</label>
                            <asp:TextBox ID="txtGoogleMapAPI" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtGoogleMapAPI" ID="rfvGoogleMapApi" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Google Map API
                            </div>
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Whatsapp Mobile Number </label>
                            <asp:TextBox ID="txtWhatsappMobile" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender TargetControlID="txtWhatsappMobile" ID="txtWhatsappMobile_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers"></cc1:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ControlToValidate="txtWhatsappMobile" ID="rfvWhatsappMobile" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Whatsapp Mobile Number
                            </div>
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ControlToValidate="txtWhatsappMobile" ID="revWhatsappMobile" runat="server" ValidationExpression="[0-9]{10}"
                                Display="Dynamic" ValidationGroup="a" ErrorMessage="InValid PAN Card" SetFocusOnError="True">
                                <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Valid Mobile Number
                            </div>
                            </asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Mobile Number to Receive SMS</label>
                            <asp:TextBox ID="txtSMSMobile" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender TargetControlID="txtSMSMobile" ID="txtSMSMobile_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers"></cc1:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ControlToValidate="txtSMSMobile" ID="rfvSMSMobile" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Mobile to Receive SMS
                            </div>
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ControlToValidate="txtSMSMobile" ID="revSMSMobile" runat="server" ValidationExpression="[0-9]{10}"
                                Display="Dynamic" ValidationGroup="a" ErrorMessage="InValid PAN Card" SetFocusOnError="True">
                                <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Valid Mobile Number
                            </div>
                            </asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>SMS API </label>
                            <asp:TextBox ID="txtSMSApi" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtSMSApi" ID="rfvSMSApi" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter SMS API
                            </div>
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Facebook</label>
                            <asp:TextBox ID="txtFacebook" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtFacebook" ID="rfvFacebook" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Facebook
                            </div>
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Instagram </label>
                            <asp:TextBox ID="txtInstagram" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtInstagram" ID="rfvInstagram" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Instagram
                            </div>
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Twitter</label>
                            <asp:TextBox ID="txtTwitter" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtTwitter" ID="rfvTwitter" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Twitter
                            </div>
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Google Plus </label>
                            <asp:TextBox ID="txtGooglePlus" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtGooglePlus" ID="rfvGooglePlus" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Google Plus
                            </div>
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Linkdin</label>
                            <asp:TextBox ID="txtLinkdin" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtLinkdin" ID="rfvLinkdin" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Linkdin
                            </div>
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Footer Text </label>
                            <asp:TextBox ID="txtFooter" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtFooter" ID="rfvFooter" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Footer
                            </div>
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div>
                    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" ValidationGroup="a" CssClass="btn btn-custon-four btn-success" runat="server" Text="Add" />
                    <asp:Button ID="btnClear" OnClick="btnClear_Click" CssClass="btn btn-custon-four btn-default" runat="server" Text="Clear" />
                    <asp:Button ID="btnBack" OnClick="btnBack_Click" CssClass="btn btn-custon-four btn-primary" runat="server" Text="Back" />
                    <asp:Button ID="btnDelete" CssClass="btn btn-custon-four btn-danger" runat="server" Text="Delete" />
                </div>
            </div>
        </div>
    </section>
</asp:Content>

