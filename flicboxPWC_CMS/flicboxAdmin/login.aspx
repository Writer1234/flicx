<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="flicboxPWC_CMS.flicboxAdmin.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Flicbox Admin Login</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="padding-top: 10%">
            <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <div class="login-panel panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Please Sign In</h3>
                        </div>
                        <div class="panel-body">
                            <div style="text-align: center;">
                                <img src="../images/flicbox.png" style="width: 55%" /><br />
                                <br />
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtLoginUsername" runat="server" CssClass="form-control" MaxLength="20" placeholder="Enter Your Username" /><br />
                                <asp:RequiredFieldValidator ID="reqfldLoginUsername" ErrorMessage="Username Required !"
                                    ControlToValidate="txtLoginUsername" Display="Dynamic" CssClass="asperror" runat="server"
                                    SetFocusOnError="true" />
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtLoginPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter Your Password"
                                    MaxLength="20" />
                                <br />
                                <asp:RequiredFieldValidator ID="reqfldLoginPwd" ErrorMessage="Password Required !"
                                    ControlToValidate="txtLoginPassword" Display="Dynamic" CssClass="asperror" runat="server"
                                    SetFocusOnError="true" />
                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnSubmitLogin" Text="Login" runat="server" CssClass="btn btn-lg btn-success btn-block" OnClick="btnSubmitLogin_Click" />
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblErrMsg" Text="" runat="server" CssClass="text-danger" />
                            </div>
                        </div>
                        <div class="panel-footer">
                            powered by : <a href="http://www.prasadwebcreations.com" target="_blank">Prasad Web Creations</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
