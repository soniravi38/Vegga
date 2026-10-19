<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ListCustomers.aspx.cs" Inherits="Admin_ListCustomers" %>

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
                <h3 class="box-title">Total Number of Records :
                    <asp:Literal ID="litrecordcount" runat="server" Text="0" /></h3>
                <div class="box-tools pull-right">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                    <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                </div>
            </div>
            <div class="box-body">
                <div class="row">
                    <div class="col-md-4">
                        <div style="display: none">
                            <a href="AddMainSlider.aspx" class="btn btn-custon-four btn-success" style="color: white; margin-top: 0%">
                                <asp:Label ID="lblInsert1" runat="server" Text=""></asp:Label>
                                <span class="fa fa-plus-circle"></span></a>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <asp:DropDownList ID="ddlVerfiy" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlVerfiy_SelectedIndexChanged">
                            <asp:ListItem Value="2">All Queries</asp:ListItem>
                            <asp:ListItem Value="1">Only Verified</asp:ListItem>
                            <asp:ListItem Value="0">Only Un-Verified</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlPageSize" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                            <asp:ListItem Value="10">10 Record(s)</asp:ListItem>
                            <asp:ListItem Value="25">25 Record(s)</asp:ListItem>
                            <asp:ListItem Value="50">50 Record(s)</asp:ListItem>
                            <asp:ListItem Value="100">100 Record(s)</asp:ListItem>
                            <asp:ListItem Value="200">200 Record(s)</asp:ListItem>
                            <asp:ListItem Value="500">500 Record(s)</asp:ListItem>
                            <asp:ListItem Value="1000">1000 Record(s)</asp:ListItem>
                            <asp:ListItem Value="2000">2000 Record(s)</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div style="overflow-x: scroll; margin-top: 1%">
                    <table class="ListPageArea">
                        <tr>
                            <td valign="top" colspan="2">
                                <asp:GridView ID="gvReport" runat="server" CssClass="GridViewStyle" AutoGenerateColumns="False"
                                    AllowPaging="True" DataKeyNames="ID" OnPageIndexChanging="gvReport_PageIndexChanging" Width="100%" OnRowCommand="gvReport_RowCommand" OnSorting="gvReport_Sorting"
                                    AllowSorting="True" RowStyle-CssClass="rowHover" ShowHeaderWhenEmpty="True" CellPadding="3" ForeColor="Black" GridLines="Both" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S.No." HeaderStyle-Width="35px">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>

                                            <HeaderStyle Width="35px"></HeaderStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField Visible="false" HeaderText="ID" DataField="ID" SortExpression="ID" />
                                        <asp:BoundField HeaderText="Name" DataField="name" SortExpression="name" />
                                        <asp:BoundField HeaderText="E-Mail" DataField="email" SortExpression="email" />
                                        <asp:BoundField HeaderText="Mobile" DataField="Mobile" SortExpression="Mobile" />
                                         <asp:BoundField HeaderText="Product Check?" DataField="ProductCheck" SortExpression="ProductCheck" />
                                        <asp:BoundField HeaderText="IP" DataField="IP" SortExpression="IP" />
                                        <asp:BoundField HeaderText="Created Date" DataField="Create_Date" SortExpression="Create_Date" />
                                        <asp:TemplateField HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="../App_Content/icon/icn_trash.png"
                                                    AlternateText="Delete" ToolTip="Delete this record" CommandName="IsDelete" CommandArgument='<%#Eval("ID") %>'
                                                    OnClientClick='return confirm("Are You Sure To Delete This Record?")' />
                                            </ItemTemplate>
                                            <HeaderStyle Width="25px"></HeaderStyle>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnIsActive" runat="server" ImageUrl='<%# Convert.ToBoolean(Eval("IsVerified")) == true ? "../App_Content/icon/verify.png" : "../App_Content/icon/unverify.png" %>'
                                                    AlternateText="Verify/UnVerify this record" ToolTip='<%# Convert.ToBoolean(Eval("IsVerified")) == true ? "UnVerfiy this record" : "Verfiy this record" %>' CommandName="IsActive"
                                                    CommandArgument='<%#Eval("ID") %>' OnClientClick='return confirm("Are You Sure To Verify/UnVerify This Record?")' />
                                            </ItemTemplate>
                                            <HeaderStyle Width="25px"></HeaderStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div class="EmptyDataTemplate">
                                            No Record Found !
                                        </div>
                                    </EmptyDataTemplate>
                                    <RowStyle CssClass="RowStyle" />
                                    <PagerStyle CssClass="PagerStyle" ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <HeaderStyle CssClass="HeaderStyle" BackColor="#333" Font-Bold="True" ForeColor="White" />
                                    <AlternatingRowStyle CssClass="AltRowStyle" BackColor="#CCCCCC" />
                                    <PagerSettings Position="Bottom" />
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#808080" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#383838" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="text-left" style="display: none">
                    <a href="AddMainSlider.aspx" class="btn btn-custon-four btn-success" style="color: white">
                        <asp:Label ID="lblInsert2" runat="server" Text=""></asp:Label>
                        <span class="fa fa-plus-circle"></span></a>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

