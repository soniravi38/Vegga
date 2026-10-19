<%@ Page Title="" Language="C#" MasterPageFile="~/Web/MasterPage.master" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="Web_Reports" %>

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
                   <div class="col-md-8 ContactUs1" style="max-width: 605px; margin-left: 0px; width: 48%; padding-left: 30px">
                        <div class="fieldset">
                            <h2 class="legend">Report Verification</h2>
                            <ul class="form-list">
                                <li class="fields">
                                    <div class="field">
                                        <label for="CertificateNo" class="required"><em>*</em>Certificate No.</label>
                                        <div class="input-box">
                                            <asp:TextBox ID="txtCertificateNo" autocomplete="off" CssClass="input-text required-entry validate-alpha" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtCertificateNo" ID="rfvCertificateNo" runat="server"
                                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                                ValidationGroup="Contact">
                                            Please Enter Certificate No.
                                            </asp:RequiredFieldValidator>
                                        <cc1:FilteredTextBoxExtender TargetControlID="txtCertificateNo" ID="txtCertificateNo_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers"></cc1:FilteredTextBoxExtender>
                                        </div>
                                    </div>
                                    <div class="field">
                                        <label for="Weight" class="required"><em>*</em>Weight</label>
                                        <div class="input-box">
                                            <asp:TextBox ID="txtWeight" autocomplete="off" CssClass="input-text required-entry validate-alpha" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ControlToValidate="txtWeight" ID="rfvWeight" runat="server"
                                                Display="Dynamic" ErrorMessage="Please Enter Name !" SetFocusOnError="True"
                                                ValidationGroup="Contact">
                                             Please Enter Weight
                                            </asp:RequiredFieldValidator>
                                           <%--<cc1:FilteredTextBoxExtender TargetControlID="txtWeight" ID="txtWeight_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers"></cc1:FilteredTextBoxExtender>--%>
                                        </div>
                                    </div>
                                </li>                              
                            </ul>
                            <div class="buttons-set" style="float: left">
                                <asp:Button ID="btnQuerySubmit" CssClass="button" OnClick="btnQuerySubmit_Click" ValidationGroup="Contact" runat="server" Text="Submit" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

