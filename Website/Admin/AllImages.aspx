<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AllImages.aspx.cs" Inherits="Admin_AllImages" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
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
                <h3 class="box-title">Header Images Master</h3>
                <div class="box-tools pull-right">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                </div>
            </div>
            <div class="box-body">
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Contact Us</label>
                            <asp:FileUpload ID="fuContactUs" CssClass="form-control" runat="server" />
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>About Us</label>
                            <asp:FileUpload ID="fuAboutUs" CssClass="form-control" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Our Products</label>
                            <asp:FileUpload ID="fuProducts" CssClass="form-control" runat="server" />
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Client Info</label>
                            <asp:FileUpload ID="fuClientInfo" CssClass="form-control" runat="server" />
                        </div>
                    </div>
                </div>
                 <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Call Us</label>
                            <asp:FileUpload ID="fuCallUs" CssClass="form-control" runat="server" />
                        </div>
                    </div>
                       <div class="col-md-6">
                        <div class="form-group">
                            <label>Certificates</label>
                            <asp:FileUpload ID="fuCertificates" CssClass="form-control" runat="server" />
                        </div>
                    </div>
                </div>
                  <div class="row">
                       <div class="col-md-6">
                        <div class="form-group">
                            <label>Payment</label>
                            <asp:FileUpload ID="fuPayment" CssClass="form-control" runat="server" />
                        </div>
                    </div>
                </div>
                <div>
                    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" ValidationGroup="a" CssClass="btn btn-custon-four btn-success" runat="server" Text="Add" />
                    <asp:Button ID="btnClear" OnClick="btnClear_Click" CssClass="btn btn-custon-four btn-default" runat="server" Text="Clear" />
                    <asp:Button ID="btnBack" OnClick="btnBack_Click" CssClass="btn btn-custon-four btn-primary" runat="server" Text="Back" />
                    <asp:Button ID="btnDelete" OnClick="btnDelete_Click" CssClass="btn btn-custon-four btn-danger" runat="server" Text="Delete" />
                </div>
            </div>
        </div>
    </section>
</asp:Content>

