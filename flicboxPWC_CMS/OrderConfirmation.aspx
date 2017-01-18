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

        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height:40px;width:100%;padding-top:10px">&nbsp&nbsp</div>
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
            <div style="text-align: center;padding-bottom:20px">
                <h4>You can do Cash On Delivery</h4>
            </div>
            <div style="width: 100%; height: 20px; border-bottom: 1px solid black; text-align: center">
                <span style="font-size: 40px; background-color: #e7e7e7; padding: 0 10px;">OR
            <!--Padding is optional-->
                </span>
            </div>
            <br />
            <div style="text-align: center">
                <h4>For Gift item you have to use paytm for Order Confirmation.
            <br />
                    You can pay by Patym using following QR Code</h4>
                <img src="images/J6tFc.png" style="align-content: center" />
            </div>
            <br />
            
        </div>
    </div>
</asp:Content>
