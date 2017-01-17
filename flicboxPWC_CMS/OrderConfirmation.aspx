<%@ Page Title="" Language="C#" MasterPageFile="~/MasterFlicbox.Master" AutoEventWireup="true" CodeBehind="OrderConfirmation.aspx.cs" Inherits="flicboxPWC_CMS.OrderConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @import url('//maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css');

        .info-msg,
        .success-msg,
        .warning-msg,
        .error-msg {
            margin: 10px 0;
            padding: 10px;
            border-radius: 3px 3px 3px 3px;
        }

        .info-msg {
            color: #059;
            background-color: #BEF;
        }

        .success-msg {
            color: #270;
            background-color: #DFF2BF;
        }

        .warning-msg {
            color: #9F6000;
            background-color: #FEEFB3;
        }

        .error-msg {
            color: #D8000C;
            background-color: #FFBABA;
        }

        /* Just for CodePen styling - don't include if you copy paste */
        html {
            font-family: "HelveticaNeue-Light", "Helvetica Neue Light", "Helvetica Neue", Helvetica, Arial, "Lucida Grande", sans-serif;
            font-weight: 300;
            margin: 25px;
        }

        body {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="ContentPage" runat="server">
        <div class="success-msg" id="successmsg" runat="server" visible="false">
            <i class="fa fa-check"></i>
            <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label>
        </div>

        <div class="warning-msg" id="warningmsg" runat="server" visible="false">
            <i class="fa fa-warning"></i>
            <asp:Label ID="lblWarning" runat="server" Text=""></asp:Label>
        </div>
        <div class="error-msg" id="errormsg" runat="server" visible="false">
            <i class="fa fa-times-circle"></i>
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        </div>
        <div id="payType" runat="server" visible="false">
            <div style="text-align: center">
                <h1>You can do Cash On Delivery</h1>
            </div>
            <div style="width: 100%; height: 50px; border-bottom: 1px solid black; text-align: center">
                <span style="font-size: 100px; background-color: #F3F5F6; padding: 0 10px;">OR
            <!--Padding is optional-->
                </span>
            </div>
            <br />
            <div style="text-align: center">
                <h1>For Gift item you have to use paytm for Order Confirmation.
            <br />
                    You can pay by Patym using following QR Code</h1>
            </div>
            <br />
            <img src="images/J6tFc.png" style="align-content: center" />
        </div>
    </div>
</asp:Content>
