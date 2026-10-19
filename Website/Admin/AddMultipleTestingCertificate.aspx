<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AddMultipleTestingCertificate.aspx.cs" Inherits="Admin_AddMultipleTestingCertificate" %>

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
                <h3 class="box-title">Adding Bulk Testing Certificate</h3>
                <div class="box-tools pull-right">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                </div>
            </div>
            <div class="box-body">
                 <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>CSV File</label>
                            <asp:FileUpload ID="fuCSV" runat="server" />
                        </div>
                    </div>
                </div>
                <div>
                    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" ValidationGroup="a" CssClass="btn btn-custon-four btn-success" runat="server" Text="Export" />
                </div>
            </div>
        </div>
    </section>
</asp:Content>

