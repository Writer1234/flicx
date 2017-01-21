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
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <div class="plans">
                        <asp:ListView ID="rptProducts" runat="server">
                            <ItemTemplate>
                                <div class="one-third column" data-scrollreveal="enter bottom and move 250px over 1.5s">
                                    <div class="plan-single">
                                        <%--<asp:Image ID="ImgProduct" runat="server" ImageUrl='<%# Eval("varcharProductImg1") %>' Width="100%" AlternateText='<%# Eval("varcharProductName")%>' />--%>
                                        <div class="plan-icon">&#xf02b;</div>
                                        <h5>
                                            <asp:Label ID="lblProductName" runat="server" Text='<%#Eval("CategoryName") %>'></asp:Label>
                                        </h5>
                                        <asp:DropDownList ID="ddlSubscriptionType" runat="server" AutoPostBack="true" DataSourceID="sqlDataSource2"
                                            DataValueField="ID" CssClass="form-control"
                                            DataTextField="VALUE" OnSelectedIndexChanged="ddlSubscriptionType_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="sqlDataSource2" runat="server"
                                            ConnectionString="<%$ ConnectionStrings:conStr %>"
                                            SelectCommand="exec [dbo].[GetSubscriptionTypeCombo] @SP_TYPE='ByProductName', @SP_Searchstring=@varcharProductName"
                                            CancelSelectOnNullParameter="true">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="lblProductName" Name="varcharProductName" Type="String" Size="100" ConvertEmptyStringToNull="false" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <h5><asp:Label ID="lblPrice" runat="server" Text=" " ></asp:Label>

                                        </h5>
                                        <p>UNLIMITED USERS</p>
                                        <div class="sections-link-pages">
                                            <div class="cl-effect-11">
                                                <asp:LinkButton ID="btnAddCart" runat="server" data-hover="Select" OnClick="btnAddCart_Click">Select</asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                            <%--<FooterTemplate>
                        
                    </FooterTemplate>--%>
                        </asp:ListView>
                        <!-- new added-->
                    </div>
                    <div class="sixteen columns">
                        <div class="fifteen columns text-center">
                            OR
                        </div>
                        <div class="fifteen columns text-center">
                            Whats your Budget ? (<= least price of any plan)
                            <br />
                            <br />
                            <asp:TextBox ID="txtBudget" runat="server" MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVBudget" runat="server" ControlToValidate="txtBudget" ErrorMessage='Budget is required.' Display="None" ValidationGroup="SAVE"></asp:RequiredFieldValidator>
                        </div>

                        <div class="fifteen columns text-center">
                            Would you like to upgrade?<br />
                            <asp:RadioButton runat="server" ID="rdbYes" Text="Yes" GroupName="upgrade" AutoPostBack="true" OnCheckedChanged="rdbYes_CheckedChanged" />
                            <asp:RadioButton runat="server" ID="rdbNo" Text="No" GroupName="upgrade" />
                        </div>

                        <div class="fifteen columns text-center">
                            Whats will you get for your budget
                            <br />
                            <br />
                            <div>
                                Graphical table / img will come here only for representation
                                <asp:ListView ID="DTlstInBudget" runat="server" DataKeyNames="intProductID">
                                    <ItemTemplate>
                                        <div class="one-third column" data-scrollreveal="enter bottom and move 250px over 1.5s">
                                            <div class="plan-single">
                                                <%--<asp:Image ID="ImgProduct" runat="server" ImageUrl='<%# Eval("varcharProductImg1") %>' Width="100%" AlternateText='<%# Eval("varcharProductName")%>' />--%>
                                                <div class="plan-icon">&#xf02b;</div>
                                                <h5>
                                                    
                                                    <asp:Label ID="lblProductName" runat="server" Text='<%#Eval("varcharProductName") %>'></asp:Label>
                                                </h5>
                                               <h5><asp:Label ID="lblSubscriptionType" runat="server" Text='<%#Eval("SubscriptionName") %>'></asp:Label>
                                                <h5>&#x20b9;<asp:Label ID="lblPrice" runat="server" Text='<%#Eval("intProductPrice") %>'></asp:Label>
                                                </h5>
                                                <div>
                                                    <asp:Label ID="lblShortDescription" runat="server" Text='<%#Eval("varcharProductShortDescription") %>'></asp:Label>
                                                </div>                
                                                <div class="sections-link-pages">
                                                    <div class="cl-effect-11">
                                                        <asp:LinkButton ID="btnBudgetProductAdd" runat="server" data-hover="Select" OnClick="btnBudgetProductAdd_Click">Select</asp:LinkButton>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <%--<FooterTemplate>
                        
                    </FooterTemplate>--%>
                                </asp:ListView>

                            </div>
                        </div>

                        <div class="three columns">
                            <asp:Button ID="btnProceed" Text="Proceed" runat="server" CssClass="button" CausesValidation="true" ValidationGroup="SAVE" OnClick="btnProceed_Click" />
                            <%--<asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="SAVE"
                        runat="server" HeaderText="Validation summary" ShowMessageBox="true" DisplayMode="List" ShowSummary="false" />--%>
                        </div>
                    </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
</asp:Content>
