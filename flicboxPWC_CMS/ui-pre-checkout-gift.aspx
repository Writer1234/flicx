<%@ Page Title="" Language="C#" MasterPageFile="~/MasterFlicbox.Master" AutoEventWireup="true" CodeBehind="ui-pre-checkout-gift.aspx.cs" Inherits="flicboxPWC_CMS.ui_pre_checkout_gift" %>

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
            <div class="plans">
                <div class="one-third column" data-scrollreveal="enter bottom and move 250px over 1.5s">
                    <div class="plan-single">
                        <div class="plan-icon">&#xf02b;</div>
                        <h5>Plan A</h5>
                        <asp:DropDownList runat="server" ID="ddlplantype" CssClass="form-control">
                            <asp:ListItem Text="1 month" Value="1 month"></asp:ListItem>
                            <asp:ListItem Text="3 month" Value="3 month"></asp:ListItem>
                        </asp:DropDownList>
                        <p>UNLIMITED USERS</p>
                        <div class="sections-link-pages">
                            <div class="cl-effect-11"><a href="#" data-hover="Select">Select</a></div>
                        </div>
                    </div>
                </div>
                <div class="one-third column" data-scrollreveal="enter bottom and move 250px over 1.5s">
                    <div class="plan-single featured">
                        <div class="plan-icon">&#xf02c;</div>
                        <h5>Plan B</h5>
                        <asp:DropDownList runat="server" ID="DropDownList1" CssClass="form-control">
                            <asp:ListItem Text="1 month" Value="1 month"></asp:ListItem>
                            <asp:ListItem Text="3 month" Value="3 month"></asp:ListItem>
                        </asp:DropDownList>
                        <p>UNLIMITED USERS</p>
                        <div class="sections-link-pages">
                            <div class="cl-effect-11"><a href="#" data-hover="Select">Select</a></div>
                        </div>
                    </div>
                </div>
                <div class="one-third column" data-scrollreveal="enter bottom and move 250px over 1.5s">
                    <div class="plan-single">
                        <div class="plan-icon">&#xf02e;</div>
                        <h5>Plan C</h5>
                        <asp:DropDownList runat="server" ID="DropDownList2" CssClass="form-control">
                            <asp:ListItem Text="1 month" Value="1 month"></asp:ListItem>
                            <asp:ListItem Text="3 month" Value="3 month"></asp:ListItem>
                        </asp:DropDownList>
                        <p>UNLIMITED USERS</p>
                        <div class="sections-link-pages">
                            <div class="cl-effect-11"><a href="#" data-hover="Select">Select</a></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="sixteen columns">
                <div class="fifteen columns text-center">
                    OR
                </div>
                <div class="fifteen columns text-center">
                    Whats your Budget ? (<= least price of any plan) <br /><br />
                    <asp:TextBox ID="txtBudget" runat="server" MaxLength="10"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVBudget" runat="server" ControlToValidate="txtBudget" ErrorMessage='Budget is required.' Display="None" ValidationGroup="SAVE"></asp:RequiredFieldValidator>
                </div>

                <div class="fifteen columns text-center">
                    Would you like to upgrade?<br />
                    <asp:RadioButton runat="server" ID="rdbYes" Text="Yes" GroupName="upgrade"/>
                    <asp:RadioButton runat="server" ID="rdbNo" Text="No" GroupName="upgrade"/>
                </div>
                
                <div class="fifteen columns text-center">
                    Whats will you get for your budget <br /><br />
                    <div>
                        Graphical table / img will come here only for representation
                    </div>
                </div>

                <div class="three columns">
                    <asp:Button ID="btnProceed" Text="Proceed" runat="server" CssClass="button" CausesValidation="true" ValidationGroup="SAVE" OnClick="btnProceed_Click" />
                    <%--<asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="SAVE"
                        runat="server" HeaderText="Validation summary" ShowMessageBox="true" DisplayMode="List" ShowSummary="false" />--%>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
