<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SucessPayment.aspx.cs" Inherits="Web_SucessPayment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<style>
    #Box {
        border: 1px solid green;
        width: 400px;
    }

    p {
        width: 200px;
        margin-left: 40%;
        display: block;
    }

    dl dt {
        margin-left: 0;
    }
</style>
<body>
    <div id="Box">
        <p>Your Payment is Successfull !</p>
        <div class="alert alert-success">
            <center><strong>Success</strong></center>
        </div>
        <dl class="dl-horizontal">
            <dt>Transaction Id : </dt>
            <dd>
                <asp:Label ID="lblTxnId" runat="server" Text=""></asp:Label></dd>
            <dt>Date :</dt>
            <dd>
                <asp:Label ID="lblDate" runat="server" Text=""></asp:Label></dd>
        </dl>
    </div>
</body>
</html>
