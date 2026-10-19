<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AddProductMaster.aspx.cs" Inherits="Admin_AddProductMaster" %>
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
                <h3 class="box-title">Add/Update Product</h3>
                <div class="box-tools pull-right">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                </div>
            </div>
            <div class="box-body">
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Product Name</label>
                            <asp:TextBox ID="txtName" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtName" ID="rfvName" runat="server"
                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                ValidationGroup="a">
                        <div class="alert alert-danger alert-mg-b" role="alert">
                                Please Enter Name
                            </div>
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                <div class="col-md-6">
                        <div class="form-group">
                            <label>Picture</label>
                            <asp:FileUpload ID="fuPicture" CssClass="form-control" runat="server" />
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

