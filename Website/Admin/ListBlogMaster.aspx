<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ListBlogMaster.aspx.cs" Inherits="Admin_ListBlogMaster" %>

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
                        <a href="AddBlogMaster.aspx" class="btn btn-custon-four btn-success" style="color: white; margin-top: 0%">
                            <asp:Label ID="lblInsert1" runat="server" Text=""></asp:Label>
                            <span class="fa fa-plus-circle"></span></a>

                    </div>
                    <div class="col-md-4"></div>
                   
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
                                        <asp:TemplateField HeaderText="Picture">
                                            <ItemTemplate>
                                                <img src=' <%# "../App_Content/Picture/Blogs/actual/"+ Eval("Picture")%>' height="50" alt="" onerror="this.src='../App_Content/icon/picture-not-available.jpg';" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Title" DataField="Title" SortExpression="Title" />
                                        <asp:BoundField HeaderText="Description" DataField="Description" SortExpression="Description" />
                                        <asp:BoundField HeaderText="Created Date" DataField="Create_Date" SortExpression="Create_Date" />
                                        <asp:BoundField HeaderText="Modified Date" DataField="Modify_Date" SortExpression="Modify_Date" />
                                        <asp:TemplateField HeaderStyle-Width="25px">
                                            <ItemTemplate>
                                                <a href="AddBlogMaster.aspx?id=<%#Eval("ID") %>" title="Edit this record">
                                                    <img src="../App_Content/icon/edit_16x16.png" alt="Edit" />
                                                </a>
                                            </ItemTemplate>
                                            <HeaderStyle Width="25px"></HeaderStyle>
                                        </asp:TemplateField>
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
                                                <asp:ImageButton ID="btnIsActive" runat="server" ImageUrl='<%# Convert.ToBoolean(Eval("IsActive")) == true ? "../App_Content/icon/IsActive.png" : "../App_Content/icon/IsDeactive.png" %>'
                                                    AlternateText="Active/Deactive this record" ToolTip='<%# Convert.ToBoolean(Eval("IsActive")) == true ? "Deactive this record" : "Active this record" %>' CommandName="IsActive"
                                                    CommandArgument='<%#Eval("ID") %>' OnClientClick='return confirm("Are You Sure To Active/Deactive This Record?")' />
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
                <div class="text-left">
                    <a href="AddBlogMaster.aspx" class="btn btn-custon-four btn-success" style="color: white">
                        <asp:Label ID="lblInsert2" runat="server" Text=""></asp:Label>
                        <span class="fa fa-plus-circle"></span></a>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

