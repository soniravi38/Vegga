<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="PaymentConstant.aspx.cs" Inherits="Admin_PaymentConstant" %>

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
                            <label>Merchant Key</label>
                            <asp:TextBox ID="txtMerchantKey" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtMerchantKey" ID="rfvMerchantKey" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Merchant Key
                            </div>
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>SaltKey</label>
                            <asp:TextBox ID="txtSaltKey" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtSaltKey" ID="rfvSaltKey" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Salt Key
                            </div>
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Product Info</label>
                            <asp:TextBox ID="txtProductInfo" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtProductInfo" ID="RequiredFieldValidator1" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter txtProduct Info
                            </div>
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>udf5</label>
                            <asp:TextBox ID="txtudf5" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator ControlToValidate="txtudf5" ID="RequiredFieldValidator2" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter txtudf5
                            </div>
                            </asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>sucess url</label>
                            <asp:TextBox ID="txtsurl" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtsurl" ID="RequiredFieldValidator2" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter sucess url
                            </div>
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Failure URL</label>
                            <asp:TextBox ID="txtfurl" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtfurl" ID="RequiredFieldValidator3" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Failure url
                            </div>
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Payment URL</label>
                            <asp:TextBox ID="txtPaymentURL" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtPaymentURL" ID="RequiredFieldValidator4" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter txtPayment UR
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

