<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="flicboxPWC_CMS.my_account.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Flicbox - My Account Login</title>
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
                <div class="col-md-6">
                    <div class="login-panel panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">I'm an existing customer and would like to login.</h3>
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <asp:TextBox ID="txtLoginUsername" runat="server" CssClass="form-control" MaxLength="50" placeholder=" Email ID" /><br />
                                <asp:RequiredFieldValidator ID="reqfldLoginUsername" ErrorMessage="Username Required !"
                                    ControlToValidate="txtLoginUsername" Display="Dynamic" CssClass="asperror" runat="server"
                                    SetFocusOnError="true" />
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtLoginPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password"
                                    MaxLength="50" />
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
                            <a href="lost-password.aspx">Lost Password</a>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="panel-default panel">
                        <div class="panel-heading">
                            <h3 class="panel-title">I'm a new customer and would like to register.</h3>
                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtRegisterUsername" runat="server" CssClass="form-control" MaxLength="50" placeholder="Name" ValidationGroup="register"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Username Required !" ValidationGroup="register"
                                        ControlToValidate="txtRegisterUsername" Display="Dynamic" CssClass="asperror" runat="server"
                                        SetFocusOnError="true" />
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtRegisterEmail" runat="server" CssClass="form-control" MaxLength="50" placeholder="Email ID" ValidationGroup="register" /><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Email ID Required !" ValidationGroup="register"
                                        ControlToValidate="txtRegisterEmail" Display="Dynamic" CssClass="asperror" runat="server"
                                        SetFocusOnError="true" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ErrorMessage="Invalid Email Id!" ControlToValidate="txtRegisterEmail"
                                        Display="Dynamic" runat="server" SetFocusOnError="true" CssClass="asperror" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtContactPhone" runat="server" CssClass="form-control" placeholder="Mobile Number" MaxLength="10" onkeypress="return numbersonly(event)" ValidationGroup="register"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="Contact No. Required !" ValidationGroup="register"
                                        ControlToValidate="txtContactPhone" Display="Dynamic" CssClass="asperror" runat="server"
                                        SetFocusOnError="true" />
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtRegisterPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password" ValidationGroup="register"
                                        MaxLength="50" />
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Password Required !" ValidationGroup="register"
                                        ControlToValidate="txtRegisterPassword" Display="Dynamic" CssClass="asperror" runat="server"
                                        SetFocusOnError="true" />
                                </div>

                            </div>
                            <div class="form-group">
                                <asp:Button ID="btnRegister" Text="Register" runat="server" CssClass="btn btn-lg btn-success btn-block" OnClick="btnRegister_Click" ValidationGroup="register" />
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblStatusRegister" Text="" runat="server" CssClass="text-danger" />
                            </div>
                        </div>
                        <div class="panel-footer">
                            Copyrights 2017 - Flicbox
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
    <script type="text/ecmascript">
        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode;
            if (unicode != 8) {
                if (unicode < 48 || unicode > 57) {
                    return false;
                }
                else {
                    return true;
                }
            }
            else {
                return true;
            }
        }
    </script>
</body>
</html>
