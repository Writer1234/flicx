<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lost-password.aspx.cs" Inherits="flicboxPWC_CMS.my_account.lost_password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Flicbox - Lost Password</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../flicboxAdmin/css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container" style="padding-top: 10%">
            <div class="row">
                <div class="col-md-12">
                    <div style="text-align: center;">
                        <img src="../images/flicbox.png" style="width: 15%" /><br />
                        <br />
                        <div id="divStatus" runat="server"></div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <div class="login-panel panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Lost Password</h3>
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:TextBox ID="txtLostPasswordEmail" runat="server" CssClass="form-control" MaxLength="50" placeholder="Enter Your Registered Username/ EmailID" /><br />
                                <asp:RequiredFieldValidator ID="reqfldLostPassword" ErrorMessage="Username / Email ID Required !"
                                    ControlToValidate="txtLostPasswordEmail" Display="Dynamic" CssClass="asperror" runat="server"
                                    SetFocusOnError="true" />
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnLostPassword" Text="Login" runat="server" CssClass="btn btn-lg btn-success btn-block" OnClick="btnLostPassword_Click" />
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblErrMsg" Text="" runat="server" CssClass="text-danger" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
