<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Software_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
        <section class="content-header">
            <h1>Dashboard
       
                <small>Admin panel</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                <li class="active">Dashboard</li>
            </ol>
        </section>
        <section class="content">
            <div class="row">
                <div class="col-lg-3 col-xs-6">
                    <div class="small-box bg-aqua">
                        <div class="inner">
                            <h3>
                                <asp:Label ID="lblTotalQueries" runat="server" Text=""></asp:Label></h3>

                            <p>Total Queries</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-document"></i>
                        </div>
                     
                    </div>
                </div>
                <div class="col-lg-3 col-xs-6">
                    <div class="small-box bg-green">
                        <div class="inner">
                            <h3><asp:Label ID="lblVerifiedQueries" runat="server" Text=""></asp:Label></h3>

                            <p>Verified Queries</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-happy"></i>
                        </div>
                       
                    </div>
                </div>
                <div class="col-lg-3 col-xs-6">
                    <div class="small-box bg-yellow">
                        <div class="inner">
                           <h3><asp:Label ID="lblUnverifiedQueries" runat="server" Text=""></asp:Label></h3>

                            <p>Un-Verified Queries</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-sad"></i>
                        </div>
                       
                    </div>
                </div>
                 <div class="col-lg-3 col-xs-6">
                    <div class="small-box bg-fuchsia">
                        <div class="inner">
                          <h3><asp:Label ID="lblSMS" runat="server" Text=""></asp:Label></h3>

                            <p>SMS Remain</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-chatboxes"></i>
                        </div>
                       
                    </div>
                </div>





                 <div class="col-lg-3 col-xs-6">
                    <div class="small-box bg-teal-active">
                        <div class="inner">
                            <h3>
                                <asp:Label ID="lblTotalCustomers" runat="server" Text=""></asp:Label></h3>

                            <p>Total Customers Entry</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-man"></i>
                        </div>
                     
                    </div>
                </div>
                <div class="col-lg-3 col-xs-6">
                    <div class="small-box bg-light-blue-active">
                        <div class="inner">
                            <h3><asp:Label ID="lblVerifiedCustomers" runat="server" Text=""></asp:Label></h3>

                            <p>Verified Customers Entry</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-happy"></i>
                        </div>
                       
                    </div>
                </div>
                <div class="col-lg-3 col-xs-6">
                    <div class="small-box bg-maroon-active">
                        <div class="inner">
                           <h3><asp:Label ID="lblUnVerifiedCustomers" runat="server" Text=""></asp:Label></h3>

                            <p>Un-Verified Customers Entry</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-sad"></i>
                        </div>
                       
                    </div>
                </div>
                <div class="col-lg-3 col-xs-6">
                    <div class="small-box bg-red">
                        <div class="inner">
                          <h3><asp:Label ID="lblCurrentLoginIP" runat="server" Text=""></asp:Label></h3>

                            <p>Current Login IP</p>
                        </div>
                        <div class="icon">
                            <i class="ion ion-monitor"></i>
                        </div>
                       
                    </div>
                </div>
               
            </div>
        </section>
  
</asp:Content>

