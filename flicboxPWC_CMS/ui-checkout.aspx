<%@ Page Title="" Language="C#" MasterPageFile="~/MasterFlicbox.Master" AutoEventWireup="true" CodeBehind="ui-checkout.aspx.cs" Inherits="flicboxPWC_CMS.ui_checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function ShowHideDiv(chkPassport) {
            var dvPassport = document.getElementById("Panellogin");
            dvPassport.style.display = "block";
        }

        $(function () {
            GetTotal();
        });

        function GetTotal() {
            var grandTotal = 0;
            $("[id*=ProductTotal]").each(function () {
                var value = $(this).html();
                if (value != "")
                    grandTotal = grandTotal + parseFloat(value);
            });
            $("[id*=lblCartTotal]").html(grandTotal.toString());
            $("[id*=lblOrderTotal]").html(grandTotal.toString());
        }
    </script>

    <div id="about">
        <div class="parallax-section">
            <div class="parallax-services"></div>
            <div class="just_pattern"></div>
            <div class="container z-index-pages">
                <div class="sixteen columns" data-scrollreveal="enter top and move 250px over 3s">
                    <h1>Checkout</h1>
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
            <div class="ten columns">
                <div class="two columns text-left">
                    Name: *
                </div>
                <div class="seven columns">
                    <asp:TextBox ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
                </div>

                <div class="two columns text-left">
                    Email: *
                </div>
                <div class="seven columns">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </div>

                <div class="two columns text-left">
                    Phone: *
                </div>
                <div class="seven columns">
                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                </div>

                <div class="two columns text-left">
                    Address: *
                </div>
                <div class="seven columns">
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                </div>

                <div class="two columns text-left">
                    City: *
                </div>
                <div class="seven columns">
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                </div>

                <div class="two columns text-left">
                    State: *
                </div>
                <div class="seven columns">
                    <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
                </div>
                <div class="two columns text-left">
                    Pincode: *
                </div>
                <div class="seven columns">
                    <asp:TextBox ID="txtPincode" runat="server"></asp:TextBox>
                </div>
                <div id="divpassword" runat="server">
                    <div class="two columns text-left">
                        Password: *
                    </div>
                    <div class="seven columns">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="three columns">
                    <asp:Button ID="btnPurchase" Text="Pay" runat="server" CssClass="button" CausesValidation="true" OnClick="btnPurchase_Click"  />
                </div>
            </div>
            <div class="six columns">
                <h3>Order Summery</h3>
                <asp:Repeater ID="rptOrderItems" runat="server">
                    <HeaderTemplate>
                        <table class="shop_table woocommerce-checkout-review-order-table order_table">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <<tbody>
                            <tr class="cart_item">
                                <td class="product-name" colspan="3">
                                    <span><%#Eval("ProductName") %></span>
                                    <strong class="product-quantity"><%#Eval("SubscriptionName") %></strong>
                                    <span><%#Eval("Quanity") %></span>
                                    <span><%#Eval("ProductPrice") %></span>
                                </td>
                                <td class="product-total">
                                    <span class="woocommerce-Price-amount amount"><span class="woocommerce-Price-currencySymbol">₹</span>
                                        <asp:Label ID="lblProductTotal" runat="server" Text='<%#Eval("ProductTotal") %>' />
                                    </span></td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                    <FooterTemplate>
                        <tfoot>
                            <tr class="cart-subtotal">
                                <th colspan="3">Cart Subtotal</th>
                                <td class="product-subtotal"><span class="woocommerce-Price-amount amount"><span class="woocommerce-Price-currencySymbol">₹</span>
                                    <asp:Label ID="lblCartTotal" runat="server"></asp:Label>
                                </span></td>
                            </tr>
                            <tr class="shipping">
                                <th colspan="3">Shipping</th>
                                <td data-title="Shipping">
                                    <p>There are no shipping methods available. Please double check your address, or contact us if you need any help.</p>
                                </td>
                            </tr>
                            <tr class="order-total">
                                <th colspan="3">Order Total</th>
                                <td><strong><span class="woocommerce-Price-amount amount"><span class="woocommerce-Price-currencySymbol">₹</span>
                                    <asp:Label ID="lblOrderTotal" runat="server"></asp:Label>
                                </span></strong></td>
                            </tr>

                        </tfoot>

                        </table>
           
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>

</asp:Content>
