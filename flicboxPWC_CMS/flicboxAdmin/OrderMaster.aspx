<%@ Page Title="" Language="C#" MasterPageFile="~/flicboxAdmin/flicboxAdmin.Master" AutoEventWireup="true" CodeBehind="OrderMaster.aspx.cs" Inherits="flicboxPWC_CMS.flicboxAdmin.OrderMaster" %>

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
    <asp:UpdatePanel ID="OrderPanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="success-msg" id="successmsg" runat="server" visible="false">
                <i class="fa fa-check"></i>
                <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label>
            </div>
            <div class="error-msg" id="errormsg" runat="server" visible="false">
                <i class="fa fa-times-circle"></i>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </div>
            <asp:HiddenField ID="HFVOrderID" runat="server"  Visible="false" />
            <div class="container">
                <div class="row">
                    <div class="col-xs-12">
                        <div class="invoice-title">
                            <h2>Order Detail</h2>
                            <h3 class="pull-right">Order
                            <asp:Label ID="lblOrderID" runat="server"></asp:Label></h3>
                            <h3 class="pull-right">Order
                            <asp:Label ID="lblOrderStatus" runat="server" CssClass="alert-info"></asp:Label></h3>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-xs-6">
                                <address></address>
                            </div>
                            <div class="col-xs-6 text-right">
                                <address>
                                    <strong>Billed To:</strong><br />
                                    <asp:Literal ID="lblAddress" runat="server"></asp:Literal>
                                </address>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-6">
                                <address>
                                    <%-- <strong>Payment Method:</strong><br>
                            Visa ending **** 4242<br>
                            jsmith@email.com--%>
                                </address>
                            </div>
                            <div class="col-xs-6 text-right">
                                <address>
                                    <strong>Order Date:</strong><br />
                                    <asp:Label runat="server" ID="lblOrderDate"></asp:Label><br />
                                    <br />
                                </address>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title"><strong>Order summary</strong></h3>
                            </div>
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <asp:GridView ID="grdvwOrderDetails" CssClass="table table-condensed" DataKeyNames="OrderDetailID,ProductID" runat="server" AutoGenerateColumns="false" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Product">
                                                <ItemTemplate>
                                                    <%#Eval("varcharProductName")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Type">
                                                <ItemTemplate><%#Eval("ProductType")%></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SubscriptionType">
                                                <ItemTemplate><%#Eval("SubscriptionName")%></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Quantity">
                                                <ItemTemplate><%#Eval("Qty")%></ItemTemplate>
                                                <FooterTemplate></FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Unit Price">
                                                <ItemTemplate><%#Eval("UnitPrice")%></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total">
                                                <ItemTemplate><%#Eval("TotalAmt")%></ItemTemplate>
                                                <FooterTemplate></FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SubscriptionFrom">
                                                <ItemTemplate><%#Eval("EffectiveFromDate")%></ItemTemplate>
                                                <FooterTemplate></FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SubscriptionTo">
                                                <ItemTemplate><%#Eval("EffectiveToDate")%></ItemTemplate>
                                                <FooterTemplate></FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate><%#Eval("SubscriptionStatus")%></ItemTemplate>
                                                <FooterTemplate></FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="UnsubscribeDate">
                                                <ItemTemplate><%#Eval("UnsubscribeDate")%></ItemTemplate>
                                                <FooterTemplate></FooterTemplate>
                                            </asp:TemplateField>
                                        </Columns>

                                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                        <SortedDescendingHeaderStyle BackColor="#242121" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <asp:Button ID="btnConfirmOrder" runat="server" Text="Confirm Order" CssClass="btn-success" OnClick="btnConfirmOrder_Click" OnClientClick="javascript:return confirm('are you sure you want to Confirm this Order?')" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel Order" CssClass="btn-danger" OnClick="btnCancel_Click" OnClientClick="javascript:return confirm('are you sure you want to Cancel this Order?')" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
