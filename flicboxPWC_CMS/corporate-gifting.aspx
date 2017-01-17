<%@ Page Title="" Language="C#" MasterPageFile="~/MasterFlicbox.Master" AutoEventWireup="true" CodeBehind="corporate-gifting.aspx.cs" Inherits="flicboxPWC_CMS.corporate_gifting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="contact">
        <div class="parallax-section">
            <div class="parallax-contact"></div>
            <div class="just_pattern"></div>
            <div class="container z-index-pages">
                <div class="sixteen columns" data-scrollreveal="enter top and move 250px over 3s">
                    <h1>Corporate Gifting</h1>
                </div>
                <div class="sixteen columns">
                    <div class="text-line-pages"></div>
                </div>
                <div class="sixteen columns" data-scrollreveal="enter bottom and move 250px over 3s">
                    <ul class="flippy">
                        <li>
                            <div class="small-text-pages">Awesome chocolates monthly</div>
                        </li>
                        <li>
                            <div class="small-text-pages">Awesome chocolates monthly</div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>

    </div>
    <div class="send-mess top-padding">
        <div class="container">
            <div class="sixteen columns" data-scrollreveal="enter top and move 250px over 1.5s">
                <h4>Get in Touch with us</h4>
                <div class="uper-text">
                    <p>Please fill up the following form and one our executive will get in touch with you soon</p>
                </div>
            </div>
            <div id="divStatus" runat="server"></div>
            <div class="sixteen columns">
                <div class="three columns text-left">
                    Name: *
                </div>
                <div class="twelve columns">
                    <asp:TextBox ID="txtPersonName" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Name Required !"
                        ControlToValidate="txtPersonName" Display="Dynamic" CssClass="asperror" runat="server"
                        SetFocusOnError="true" />
                </div>

                <div class="three columns text-left ">
                    Company Name: *
                </div>
                <div class="twelve columns">
                    <asp:TextBox ID="txtCompanyName" runat="server" MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Company Name Required !"
                        ControlToValidate="txtCompanyName" Display="Dynamic" CssClass="asperror" runat="server"
                        SetFocusOnError="true" />
                </div>

                <div class="three columns text-left">
                    Email: *
                </div>
                <div class="twelve columns">
                    <asp:TextBox ID="txtCompanyEmail" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Email Id Required !"
                        ControlToValidate="txtCompanyEmail" Display="Dynamic" CssClass="asperror" runat="server"
                        SetFocusOnError="true" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ErrorMessage="Invalid Email Id!" ControlToValidate="txtCompanyEmail"
                        Display="Dynamic" runat="server" SetFocusOnError="true" CssClass="asperror" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                </div>

                <div class="three columns text-left">
                    Phone Number: *
                </div>
                <div class="twelve columns">
                    <asp:TextBox ID="txtCompanyPhone" runat="server" MaxLength="10" onkeypress="return numbersonly(event)"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="Contact No. Required !"
                        ControlToValidate="txtCompanyPhone" Display="Dynamic" CssClass="asperror" runat="server"
                        SetFocusOnError="true" />
                </div>

                <div class="three columns text-left">
                    Headcount: *
                </div>
                <div class="twelve columns">
                    <asp:TextBox ID="txtHeadcount" runat="server" MaxLength="8" onkeypress="return numbersonly(event)"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="Headcount Required !"
                        ControlToValidate="txtCompanyPhone" Display="Dynamic" CssClass="asperror" runat="server"
                        SetFocusOnError="true" />
                </div>

                <div class="three columns text-left">
                    Description: *
                </div>
                <div class="twelve columns">
                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="5" MaxLength="5000"></asp:TextBox>
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
            document.getElementById("<%=txtPersonName.ClientID %>").value = "";
            document.getElementById("<%=txtCompanyName.ClientID %>").value = "";
            document.getElementById("<%=txtCompanyEmail.ClientID %>").value = "";
            document.getElementById("<%=txtCompanyPhone.ClientID %>").value = "";
            document.getElementById("<%=txtHeadcount.ClientID %>").value = "";
            document.getElementById("<%=txtDescription.ClientID %>").value = "";
            document.getElementById("<%=txtPersonName.ClientID %>").focus();
            return false;
        }
    </script>
</asp:Content>
