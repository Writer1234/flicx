<%@ Page Title="" Language="C#" MasterPageFile="~/MasterFlicbox.Master" AutoEventWireup="true" CodeBehind="ui-pre-checkout.aspx.cs" Inherits="flicboxPWC_CMS.ui_pre_checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="about">
        <div class="parallax-section">
            <div class="parallax-services"></div>
            <div class="just_pattern"></div>
            <div class="container z-index-pages">
                <div class="sixteen columns" data-scrollreveal="enter top and move 250px over 3s">
                    <h1>Customer Preference</h1>
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
            <div id="divStatus" runat="server"></div>
            <div class="sixteen columns">
                <div runat="server" id="divCommonDetails">
                    <div class="three columns text-left">
                        Birthday: *
                    </div>
                    <div class="twelve columns">
                        <asp:TextBox ID="txtBirthdate" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVBirthDate" runat="server" ControlToValidate="txtBirthdate" ErrorMessage='Birthday is required.' Display="None" ValidationGroup="SAVE"></asp:RequiredFieldValidator>
                    </div>

                    <div class="three columns text-left">
                        Allergies: *
                    </div>
                    <div class="twelve columns">
                        <asp:TextBox ID="txtAllergies" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVAllergies" runat="server" ControlToValidate="txtAllergies" ErrorMessage='Allergies is required.' Display="None" ValidationGroup="SAVE"></asp:RequiredFieldValidator>
                    </div>

                    <div class="three columns text-left">
                        Preference: *
                    </div>
                    <div class="six columns">
                        <asp:DropDownList ID="ddlPreferenceDiet" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Egg" Value="Egg"></asp:ListItem>
                            <asp:ListItem Text="Eggless" Value="Eggless"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVDiet" runat="server" ControlToValidate="ddlPreferenceDiet" ErrorMessage='Preference Diet is required.' Display="None" ValidationGroup="SAVE"></asp:RequiredFieldValidator>
                    </div>
                    <div class="six columns">
                        <asp:DropDownList ID="ddlPreferenceTaste" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Milk" Value="Milk"></asp:ListItem>
                            <asp:ListItem Text="Dark" Value="Dark"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVTaste" runat="server" ControlToValidate="ddlPreferenceTaste" ErrorMessage='Preference Taste is required.' Display="None" ValidationGroup="SAVE"></asp:RequiredFieldValidator>
                    </div>
                    <div class="three columns">
                        <asp:Button ID="btnProceed" Text="Proceed" runat="server" CssClass="button" CausesValidation="true" ValidationGroup="SAVE" OnClick="btnProceed_Click" />
                        <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="SAVE"
                            runat="server" HeaderText="Validation summary" ShowMessageBox="true" DisplayMode="List" ShowSummary="false" />
                    </div>
                    <div class="twelve columns">
                        <asp:Button ID="Button1" Text="Clear" runat="server" CssClass="button" CausesValidation="true" ValidationGroup="SAVE"  />
                    </div>
                </div>
                <div runat="server" id="divGiftDetails">
                    <div class="eight columns">
                        <h4 class="text-left">Sender's Address</h4><br />
                        <div class="two columns text-left">
                            Name: *
                        </div>
                        <div class="five columns">
                            <asp:TextBox ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
                        </div>

                        <div class="two columns text-left">
                            Email: *
                        </div>
                        <div class="five columns">
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        </div>

                        <div class="two columns text-left">
                            Phone: *
                        </div>
                        <div class="five columns">
                            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                        </div>

                        <div class="two columns text-left">
                            Address: *
                        </div>
                        <div class="five columns">
                            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                        </div>

                        <div class="two columns text-left">
                            City: *
                        </div>
                        <div class="five columns">
                            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                        </div>

                        <div class="two columns text-left">
                            State: *
                        </div>
                        <div class="five columns">
                            <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
                        </div>
                        <div class="two columns text-left">
                            Pincode: *
                        </div>
                        <div class="five columns">
                            <asp:TextBox ID="txtPincode" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="seven columns">
                        <h4 class="text-left">Receiver's Address</h4><br />
                        <div class="two columns text-left">
                            Name: *
                        </div>
                        <div class="four columns">
                            <asp:TextBox ID="TextBox1" runat="server" MaxLength="50"></asp:TextBox>
                        </div>

                        <div class="two columns text-left">
                            Email: *
                        </div>
                        <div class="four columns">
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        </div>

                        <div class="two columns text-left">
                            Phone: *
                        </div>
                        <div class="four columns">
                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        </div>

                        <div class="two columns text-left">
                            Address: *
                        </div>
                        <div class="four columns">
                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                        </div>

                        <div class="two columns text-left">
                            City: *
                        </div>
                        <div class="four columns">
                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                        </div>

                        <div class="two columns text-left">
                            State: *
                        </div>
                        <div class="four columns">
                            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                        </div>
                        <div class="two columns text-left">
                            Pincode: *
                        </div>
                        <div class="four columns">
                            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <hr />
                    <div class="fifteen columns">
                        OCCASION OF THE GIFT (PLEASE MAKE SURE THAT THE DATE OF OCCASION IS AT LEAST A WEEK AFTER THE DATE OF PLACING ORDER. IT WILL GIVE US ENOUGH TIME FOR US TO FULFILL YOUR DELIVERY ON TIME.)<br /><br />
                        <asp:TextBox ID="txtOccasionDetails" runat="server"></asp:TextBox>
                    </div>
                    <div class="fifteen columns">
                        ADD A PERSONALIZED NOTE THAT YOU WOULD WANT OUR DELIVERY GUY TO SAY TO THE RECEIVER.<br /><br />    
                        <asp:TextBox ID="txtPersonalGiftMsg" runat="server"></asp:TextBox>
                    </div>
                    <div class="fifteen columns">
                        OCCASION DATE<br /><br />
                        <asp:TextBox ID="txtOccasionDate" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
