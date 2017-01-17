<%@ Page Title="" Language="C#" MasterPageFile="~/MasterFlicbox.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="flicboxPWC_CMS.contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="contact">
        <div class="parallax-section">
            <div class="parallax-work"></div>
            <div class="just_pattern"></div>
            <div class="container z-index-pages">
                <div class="sixteen columns" data-scrollreveal="enter top and move 250px over 3s">
                    <h1>Contact Us</h1>
                </div>
                <div class="sixteen columns">
                    <div class="text-line-pages"></div>
                </div>
                <div class="sixteen columns" data-scrollreveal="enter bottom and move 250px over 3s">
                    <ul class="flippy">
                        <li>
                            <div class="small-text-pages">We would love to hear from you!</div>
                        </li>
                        <li>
                            <div class="small-text-pages">We would love to hear from you!</div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>

    </div>
    <div class="send-mess top-padding">
        <div class="container">
            <div class="sixteen columns" data-scrollreveal="enter top and move 250px over 1.5s">
                <h4>We would love to hear from you!</h4>
                <div class="uper-text">
                    <p>If you have any questions, comments or feedback regarding our products or the website please don’t hesitate to get in touch with us.</p>
                </div>
            </div>
            <div id="divStatus" runat="server"></div>
            <div class="sixteen columns">
                <div class="three columns text-left">
                    Name: *
                </div>
                <div class="twelve columns">
                    <asp:TextBox ID="txtContactName" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Name Required !"
                        ControlToValidate="txtContactName" Display="Dynamic" CssClass="asperror" runat="server"
                        SetFocusOnError="true" />
                </div>

                <div class="three columns text-left">
                    Email: *
                </div>
                <div class="twelve columns">
                    <asp:TextBox ID="txtContactEmail" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Email Id Required !"
                        ControlToValidate="txtContactEmail" Display="Dynamic" CssClass="asperror" runat="server"
                        SetFocusOnError="true" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ErrorMessage="Invalid Email Id!" ControlToValidate="txtContactEmail"
                        Display="Dynamic" runat="server" SetFocusOnError="true" CssClass="asperror" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                </div>

                <div class="three columns text-left">
                    Phone Number: *
                </div>
                <div class="twelve columns">
                    <asp:TextBox ID="txtContactPhone" runat="server" MaxLength="10" onkeypress="return numbersonly(event)"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="Contact No. Required !"
                        ControlToValidate="txtContactPhone" Display="Dynamic" CssClass="asperror" runat="server"
                        SetFocusOnError="true" />
                </div>

                <div class="three columns text-left">
                    Your Message: *
                </div>
                <div class="twelve columns">
                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ErrorMessage="Description Required !"
                        ControlToValidate="txtDescription" Display="Dynamic" CssClass="asperror" runat="server"
                        SetFocusOnError="true" />
                </div>

                <div class="three columns">
                    <asp:Button ID="btnSubmit" Text="Submit" runat="server" CssClass="button" CausesValidation="true" OnClick="btnSubmit_Click"/>
                </div>
                <div class="three columns">
                    <asp:Button ID="btnReset" Text="Reset" runat="server" CssClass="button" CausesValidation="false"
                        OnClientClick="javascript:return Reset();" />
                </div>
            </div>
        </div>
    </div>
    
    <script type="text/javascript">
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

        function Reset() {
            document.getElementById("<%=txtContactName.ClientID %>").value = "";
            document.getElementById("<%=txtContactEmail.ClientID %>").value = "";
            document.getElementById("<%=txtContactPhone.ClientID %>").value = "";
            document.getElementById("<%=txtDescription.ClientID %>").value = "";
            document.getElementById("<%=txtContactName.ClientID %>").focus();
            return false;
        }
    </script>
</asp:Content>
