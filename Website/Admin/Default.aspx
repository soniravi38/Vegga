<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Root_Admin_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title id="title" runat="server">Admin Login</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
      <link rel="stylesheet" type="text/css" href="../App_Content/Login/app-assets/css/bootstrap.css" />
      <link rel="shortcut icon" type="image/x-icon" id="LogoIcon" runat="server" />
     <link rel="stylesheet" type="text/css" href="../App_Content/Login/app-assets/fonts/icomoon.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous" />
      <link rel="stylesheet" type="text/css" href="../App_Content/Login/app-assets/fonts/flag-icon-css/css/flag-icon.min.css" />
      <link rel="stylesheet" type="text/css" href="../App_Content/Login/app-assets/vendors/css/extensions/pace.css" />
     <link rel="stylesheet" type="text/css" href="../App_Content/Login/app-assets/css/bootstrap-extended.css" />
      <link rel="stylesheet" type="text/css" href="../App_Content/Login/app-assets/css/app.css" />
      <link rel="stylesheet" type="text/css" href="../App_Content/Login/app-assets/css/colors.css" />
    <link rel="stylesheet" type="text/css" href="../App_Content/Login/app-assets/css/core/menu/menu-types/vertical-menu.css" />
      <link rel="stylesheet" type="text/css" href="../App_Content/Login/app-assets/css/core/menu/menu-types/vertical-overlay-menu.css" />
      <link rel="stylesheet" type="text/css" href="../App_Content/Login/app-assets/css/pages/login-register.css" />
    <link rel="stylesheet" type="text/css" href="../App_Content/Login/assets/css/style.css" />
    <link href="../App_Content/Login/css/admin.css" rel="stylesheet" />
</head>
<body data-open="click" data-menu="vertical-menu" data-col="1-column" class="vertical-layout vertical-menu 1-column  blank-page blank-page" style="background:url('../App_Content/icon/Colorful-Diamonds-Wallpaper-HD.jpg')">
    <form id="form1" runat="server">
    <div class="app-content content container-fluid">
      <div class="content-wrapper">
        <div class="content-header row">
        </div>
        <div class="content-body"><section class="flexbox-container">
    <div class="col-md-4 offset-md-4 col-xs-10 offset-xs-1  box-shadow-2 p-0">
        <div class="card border-grey border-lighten-3 m-0" style="box-shadow:0px 0px 20px 2px white">
            <div class="card-header no-border">
                <div class="card-title text-xs-center">
                    <div class="p-1" >
                <asp:Image ID="imgCompanyLogo" onerror="this.src='../App_Content/icon/picture-not-available.jpg';" runat="server"  width="100%" alt="branding logo" />
                    
                </div>
                <h6 class="card-subtitle line-on-side text-muted text-xs-center font-small-3 pt-2"><span>
                    <asp:Label ID="lblHeading" runat="server" Text=""></asp:Label></span></h6>
            </div>
            <div class="card-body collapse in">
                <div class="card-block">
                   
                        <fieldset class="form-group position-relative has-icon-left mb-0">
                            <asp:TextBox ID="txtloginid" CssClass="form-control form-control-lg input-lg" placeholder="Username" autocomplete="off" runat="server"></asp:TextBox>
                            <div style="margin-top:-7%;position:absolute;padding-left:3%">
                                <i class="fa fa-user"></i>
                            </div>
                        </fieldset>
                         <fieldset class="form-group position-relative has-icon-left mb-0">
                            <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control form-control-lg input-lg" placeholder="Password" runat="server"></asp:TextBox>
                            <div style="margin-top:-7%;position:absolute;padding-left:3%">
                                <i class="fa fa-key"></i>
                            </div>
                        </fieldset>
                        <fieldset class="form-group position-relative has-icon-left mb-0">
                            <asp:TextBox ID="txtCaptcha" CssClass="form-control form-control-lg input-lg" placeholder="Captcha" runat="server" autocomplete="off"></asp:TextBox>
                            <div style="margin-top:-7%;position:absolute;padding-left:3%">
                                <i class="fa fa-keyboard " ></i>
                            </div>
                            <asp:Image ID="Image1Captcha" runat="server"  />
                        </fieldset>

                       <asp:Button ID="btnSubmit" runat="server" Text="Login" class="btn btnsubmit btn-lg btn-block" OnClick="btnSubmit_Click" style="margin-top:2%" />
                        
                   
                </div>
            </div>
            <div class="card-footer">
                <div class="">
                    <p class="float-sm-right text-xs-center m-0">Back to <a href="../Default.aspx" class="card-link">Main Site</a></p>
                </div>
            </div>
        
        </div>
    </div>
</section>

        </div>
      </div>
    </div>
    </form>
    <script src="../App_Content/Login/app-assets/js/core/libraries/jquery.min.js" type="text/javascript"></script>
      <script src="../App_Content/Login/app-assets/vendors/js/ui/tether.min.js" type="text/javascript"></script>
      <script src="../App_Content/Login/app-assets/js/core/libraries/bootstrap.min.js" type="text/javascript"></script>
      <script src="../App_Content/Login/app-assets/vendors/js/ui/perfect-scrollbar.jquery.min.js" type="text/javascript"></script>
      <script src="../App_Content/Login/app-assets/vendors/js/ui/unison.min.js" type="text/javascript"></script>
      <script src="../App_Content/Login/app-assets/vendors/js/ui/blockUI.min.js" type="text/javascript"></script>
      <script src="../App_Content/Login/app-assets/vendors/js/ui/jquery.matchHeight-min.js" type="text/javascript"></script>
      <script src="../App_Content/Login/app-assets/vendors/js/ui/screenfull.min.js" type="text/javascript"></script>
      <script src="../App_Content/Login/app-assets/vendors/js/extensions/pace.min.js" type="text/javascript"></script>
      <script src="../App_Content/Login/app-assets/js/core/app-menu.js" type="text/javascript"></script>
      <script src="../App_Content/Login/app-assets/js/core/app.js" type="text/javascript"></script>
</body>
</html>
