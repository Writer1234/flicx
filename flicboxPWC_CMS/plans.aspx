<%@ Page Title="" Language="C#" MasterPageFile="~/MasterFlicbox.Master" AutoEventWireup="true" CodeBehind="plans.aspx.cs" Inherits="flicboxPWC_CMS.plans" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="plan">
        
        <div class="parallax-section">
            <div class="parallax-services"></div>
            <div class="just_pattern"></div>
            <div class="container z-index-pages">
                <div class="sixteen columns" data-scrollreveal="enter top and move 250px over 3s">
                    <h1>Subscription Plans</h1>
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

        <div class="plans" id="pric-scroll">
            <div class="container">
                <div class="sixteen columns" data-scrollreveal="enter top and move 250px over 1.5s">
                    <h4>OUR Subscription PLANS</h4>
                    <div class="uper-text">
                        <p>Subscribe for 1 month / 3 months / 6 months</p>
                    </div>
                </div>
                <%--<div id="divPlansData" runat="server"></div>--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <asp:ListView ID="rptProducts" runat="server" DataKeyNames="intProductID">
                            <ItemTemplate>
                                <div class="one-third column" data-scrollreveal="enter bottom and move 250px over 1.5s">
                                    <div class="plan-single">
                                        <asp:Image ID="ImgProduct" runat="server" ImageUrl='<%# Eval("varcharProductImg1") %>' Width="100%" AlternateText='<%# Eval("varcharProductName")%>' />

                                        <h5>
                                            <asp:Label ID="lblProductName" runat="server" Text='<%#Eval("varcharProductName") %>'></asp:Label>
                                        </h5>
                                        <asp:DropDownList ID="ddlSubscriptionType" runat="server" AutoPostBack="true" DataSourceID="sqlDataSource2"
                                            DataValueField="ID"
                                            DataTextField="VALUE" OnSelectedIndexChanged="ddlSubscriptionType_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="sqlDataSource2" runat="server"
                                            ConnectionString="<%$ ConnectionStrings:conStr %>"
                                            SelectCommand="select distinct intProductID ID,varcharSubscriptionType VALUE from ProductMaster where varcharProductName=@varcharProductName;"
                                            CancelSelectOnNullParameter="true">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="lblProductName" Name="varcharProductName" Type="String" Size="100" ConvertEmptyStringToNull="false" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <h5>&#x20b9;<asp:Label ID="lblPrice" runat="server" Text='<%#Eval("intProductPrice") %>'></asp:Label>
                                            
                                        </h5>
                                        <div class="sections-link-pages">
                                            <div class="cl-effect-11">
                                                <asp:LinkButton ID="btnAddCart"  runat="server" data-hover="Add to Cart" OnClick="btnAddCart_Click">Add to Cart</asp:LinkButton>
                                            </div>
                                            &nbsp
                                    <div class="cl-effect-11">
                                        <a href='<%# string.Format("cart.aspx?action=add&Plan={0}", Eval("intProductID")) %>' id="btnLittleSub" runat="server" data-hover="Subscribe">Subscribe</a>
                                    </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                            <%--<FooterTemplate>
                        
                    </FooterTemplate>--%>
                        </asp:ListView>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
        </div>

    </div>
</asp:Content>
