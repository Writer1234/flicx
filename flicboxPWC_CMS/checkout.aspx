<%@ Page Title="" Language="C#" MasterPageFile="~/MasterFlicbox.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="flicboxPWC_CMS.checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="about">
        <style>
            .your-order {
                position: relative;
                float: right;
            }

            .checkout {
                position: relative;
                float: left;
            }
        </style>
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
                $("[id*=lblPrice]").each(function () {
                    var value = $(this).html();
                    if (value != "")
                        grandTotal = grandTotal + parseFloat(value);
                });
                $("[id*=lblCartTotal]").html(grandTotal.toString());
                $("[id*=lblOrderTotal]").html(grandTotal.toString());
            }
        </script>
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

        <div class="top-section">
            <div class="container">
                <div class="twelve columns" data-scrollreveal="enter top and move 250px over 3s">
                    <!-- test -->
                    <div role="main" class="">
                        <asp:UpdatePanel ID="CartPanel" runat="server" ChildrenAsTriggers="true" UpdateMode="Always">
                            <ContentTemplate>
                                <div class="row ">
                                    <div class="wpb_column columns medium-12 small-12">
                                        <div class="woocommerce">
                                            <div class="page-padding">
                                                <div class="row" id="LoginDiv" runat="server">
                                                    <div class="small-12 columns">
                                                        <div class="checkout-quick-login">Returning customer? <a href="#" class="showlogin" onclick="ShowHideDiv(this)">Click here to login</a></div>
                                                        <div class="login" style="display: none;" id="Panellogin">
                                                            <div class="row">
                                                                <div class="small-12 medium-4 large-3 medium-centered columns">

                                                                    <p>If you have shopped with us before, please enter your details in the boxes below.</p>

                                                                    <label for="username">Username or email <span class="required">*</span></label>
                                                                    <asp:TextBox class="input-text full" ID="username" runat="server" ValidationGroup="Login" />
                                                                    <asp:RequiredFieldValidator ID="rfvusername" runat="server" ControlToValidate="username" ErrorMessage="Username required" ValidationGroup="Login"></asp:RequiredFieldValidator>
                                                                    <label for="password">Password <span class="required">*</span></label>
                                                                    <asp:TextBox class="input-text full" TextMode="Password" ID="password" runat="server" ValidationGroup="Login" />
                                                                    <%--<div class="row">
                                                                <div class="columns">
                                                                    <input name="rememberme" type="checkbox" id="rememberme" value="forever" class="custom_check"><label for="rememberme" class="custom_label">Remember me</label>
                                                                    <a href="https://flicbox.com/my-account/lost-password/" class="lost_password">Lost your password?</a>
                                                                </div>
                                                            </div>--%>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="password" ErrorMessage="password required" ValidationGroup="Login"></asp:RequiredFieldValidator>
                                                                    <p>
                                                                        <asp:Button ID="login" runat="server" Text="Login" class="button outline login_button" OnClick="login_Click" ValidationGroup="Login" />
                                                                    </p>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <%--                                        <div class="checkout-quick-coupon">Have a coupon? <a href="#" class="showcoupon">Click here to enter your code</a></div>
                                                <div class="row">
                                                    <div class="small-12 medium-centered medium-6 large-6 xlarge-4 columns text-center">
                                                        <div class="checkout_coupon" method="post" style="display: none;">
                                                            <input type="text" name="coupon_code" class="input-text full" placeholder="Coupon code" value="">
                                                            <input type="submit" class="button outline apply_coupon yellow small" name="apply_coupon" value="Apply">
                                                        </div>
                                                    </div>
                                                </div>--%>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="small-12 columns">
                                                        <div id="checkout" class="checkout">
                                                            <div class="row">
                                                                <div class="small-12 large-8 columns billing_shipping">
                                                                    <div class="woocommerce-billing-fields">

                                                                        <h6>Billing Address</h6>




                                                                        <p class="form-row form-row-first validate-required validate-required " id="billing_first_name_field">
                                                                            <label for="billing_first_name" class="">
                                                                                First Name
                                                                        <abbr class="required" title="required">*</abbr></label>
                                                                            <asp:TextBox class="input-text" ID="billing_first_name" runat="server" placeholder="" autocomplete="given-name" Text="" />
                                                                        </p>

                                                                        <p class="form-row form-row-last validate-required validate-required woocommerce-invalid woocommerce-invalid-required-field" id="billing_last_name_field">
                                                                            <label for="billing_last_name" class="">
                                                                                Last Name
                                                                        <abbr class="required" title="required">*</abbr></label>
                                                                            <asp:TextBox class="input-text" ID="billing_last_name" runat="server" placeholder="" autocomplete="family-name" Text="" />
                                                                        </p>
                                                                        <div class="clear"></div>

                                                                        <p class="form-row form-row-first validate-required validate-email validate-required " id="billing_email_field">
                                                                            <label for="billing_email" class="">
                                                                                Email Address
                                                                        <abbr class="required" title="required">*</abbr></label>
                                                                            <asp:TextBox class="input-text" ID="billing_email" runat="server" placeholder="example@email.com" autocomplete="email" Text="" />
                                                                        </p>

                                                                        <p class="form-row form-row-last validate-required validate-phone validate-required " id="billing_phone_field">
                                                                            <label for="billing_phone" class="">
                                                                                Phone
                                                                        <abbr class="required" title="required">*</abbr></label>
                                                                            <asp:TextBox class="input-text    " ID="billing_phone" runat="server" placeholder="1234567890" autocomplete="tel" Text="" />
                                                                        </p>
                                                                        <div class="clear"></div>

                                                                        <p class="form-row form-row address-field update_totals_on_change form-row-wide validate-required" id="billing_country_field">
                                                                            <label for="billing_country" class="">
                                                                                Country
                                                                        <abbr class="required" title="required">*</abbr></label><strong>India</strong><input type="hidden" name="billing_country" id="billing_country" value="IN" class="country_to_state" />
                                                                        </p>

                                                                        <p class="form-row address-field form-row-wide validate-required" id="billing_address_1_field">
                                                                            <label for="billing_address_1" class="">
                                                                                Address
                                                                        <abbr class="required" title="required">*</abbr></label>
                                                                            <asp:TextBox class="input-text    " ID="billing_address_1" runat="server" placeholder="Street address" autocomplete="address-line1" Text="" />
                                                                        </p>

                                                                        <p class="form-row address-field form-row-wide" id="billing_address_2_field">
                                                                            <label for="billing_address_2" class=""></label>
                                                                            <asp:TextBox class="input-text    " ID="billing_address_2" runat="server" placeholder="Apartment, suite, unit etc. (optional)" autocomplete="address-line2" Text="" />
                                                                        </p>

                                                                        <p class="form-row address-field form-row-wide validate-required" id="billing_city_field" data-o_class="form-row address-field form-row-wide validate-required validate-required ">
                                                                            <label for="billing_city" class="">
                                                                                Town / City
                                                                        <abbr class="required" title="required">*</abbr></label>
                                                                            <asp:TextBox class="input-text    " ID="billing_city" runat="server" placeholder="Ex. Mumbai" autocomplete="address-level2" Text="" />
                                                                        </p>

                                                                        <p class="form-row form-row address-field form-row-wide validate-state woocommerce-invalid woocommerce-invalid-required-field validate-required" id="billing_state_field" data-o_class="form-row form-row address-field form-row-wide validate-required validate-state woocommerce-invalid woocommerce-invalid-required-field">
                                                                            <asp:DropDownList ID="DDLState" runat="server">
                                                                                <asp:ListItem Value="" Selected="True">Select an option…</asp:ListItem>
                                                                                <asp:ListItem Value="AP">Andhra Pradesh</asp:ListItem>
                                                                                <asp:ListItem Value="AR">Arunachal Pradesh</asp:ListItem>
                                                                                <asp:ListItem Value="AS">Assam</asp:ListItem>
                                                                                <asp:ListItem Value="BR">Bihar</asp:ListItem>
                                                                                <asp:ListItem Value="CT">Chhattisgarh</asp:ListItem>
                                                                                <asp:ListItem Value="GA">Goa</asp:ListItem>
                                                                                <asp:ListItem Value="GJ">Gujarat</asp:ListItem>
                                                                                <asp:ListItem Value="HR">Haryana</asp:ListItem>
                                                                                <asp:ListItem Value="HP">Himachal Pradesh</asp:ListItem>
                                                                                <asp:ListItem Value="JK">Jammu and Kashmir</asp:ListItem>
                                                                                <asp:ListItem Value="JH">Jharkhand</asp:ListItem>
                                                                                <asp:ListItem Value="KA">Karnataka</asp:ListItem>
                                                                                <asp:ListItem Value="KL">Kerala</asp:ListItem>
                                                                                <asp:ListItem Value="MP">Madhya Pradesh</asp:ListItem>
                                                                                <asp:ListItem Value="MH">Maharashtra</asp:ListItem>
                                                                                <asp:ListItem Value="MN">Manipur</asp:ListItem>
                                                                                <asp:ListItem Value="ML">Meghalaya</asp:ListItem>
                                                                                <asp:ListItem Value="MZ">Mizoram</asp:ListItem>
                                                                                <asp:ListItem Value="NL">Nagaland</asp:ListItem>
                                                                                <asp:ListItem Value="OR">Orissa</asp:ListItem>
                                                                                <asp:ListItem Value="PB">Punjab</asp:ListItem>
                                                                                <asp:ListItem Value="RJ">Rajasthan</asp:ListItem>
                                                                                <asp:ListItem Value="SK">Sikkim</asp:ListItem>
                                                                                <asp:ListItem Value="TN">Tamil Nadu</asp:ListItem>
                                                                                <asp:ListItem Value="TS">Telangana</asp:ListItem>
                                                                                <asp:ListItem Value="TR">Tripura</asp:ListItem>
                                                                                <asp:ListItem Value="UK">Uttarakhand</asp:ListItem>
                                                                                <asp:ListItem Value="UP">Uttar Pradesh</asp:ListItem>
                                                                                <asp:ListItem Value="WB">West Bengal</asp:ListItem>
                                                                                <asp:ListItem Value="AN">Andaman and Nicobar Islands</asp:ListItem>
                                                                                <asp:ListItem Value="CH">Chandigarh</asp:ListItem>
                                                                                <asp:ListItem Value="DN">Dadar and Nagar Haveli</asp:ListItem>
                                                                                <asp:ListItem Value="DD">Daman and Diu</asp:ListItem>
                                                                                <asp:ListItem Value="DL">Delhi</asp:ListItem>
                                                                                <asp:ListItem Value="LD">Lakshadeep</asp:ListItem>
                                                                                <asp:ListItem Value="PY">Pondicherry (Puducherry)</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </p>
                                                                        <p class="form-row address-field form-row-wide validate-postcode validate-required" id="billing_postcode_field" data-o_class="form-row address-field form-row-wide validate-required validate-postcode validate-required ">
                                                                            <label for="billing_postcode" class="">
                                                                                Postcode / ZIP
                                                                        <abbr class="required" title="required">*</abbr></label>
                                                                            <asp:TextBox class="input-text    " ID="billing_postcode" runat="server" placeholder="Ex. 400001" autocomplete="postal-code" Text="" />
                                                                        </p>



                                                                        <p class="form-row form-row-wide validate-required validate-required " id="billing_field_732_field">
                                                                            <label for="billing_field_732" class="">
                                                                                Birthday
                                                                        <abbr class="required" title="required">*</abbr></label>
                                                                            <asp:TextBox class="input-text    " ID="billing_field_732" runat="server" placeholder="Ex. 01/01/1990" Text="" />
                                                                        </p>

                                                                        <p class="form-row form-row-wide " id="billing_field_911_field">
                                                                            <label for="billing_field_911" class="">Allergies</label>
                                                                            <asp:TextBox class="input-text    " ID="billing_field_911" runat="server" placeholder="Ex. Allergic To Coconuts, Peanuts ETC." Text="" />
                                                                        </p>

                                                                        <div class="create-account">

                                                                            <p>Create an account by entering the information below. If you are a returning customer please login at the top of the page.</p>


                                                                            <p class="form-row validate-required validate-required " id="account_password_field">
                                                                                <label for="account_password" class="">
                                                                                    Account password
                                                                            <abbr class="required" title="required">*</abbr></label>
                                                                                <asp:TextBox class="input-text    " ID="account_password" runat="server" placeholder="Password" Text="" />
                                                                            </p>

                                                                            <div class="clear"></div>

                                                                        </div>



                                                                    </div>
                                                                    <div class="woocommerce-shipping-fields">



                                                                        <div id="ship-to-different-address">
                                                                            <div class="shipping_toggle">
                                                                                <input id="ship-to-different-address-checkbox" class="custom_check" type="checkbox" name="ship_to_different_address" value="1"><label for="ship-to-different-address-checkbox" class="custom_label"> Is this a Gift ?</label>
                                                                            </div>
                                                                            <h6>Gifting Address</h6>
                                                                        </div>

                                                                        <%--        <div class="shipping_address" style="display: none;">



                                                                    <p class="form-row form-row-first validate-required validate-required " id="shipping_first_name_field">
                                                                        <label for="shipping_first_name" class="">First Name of the gift receiver
                                                                            <abbr class="required" title="required">*</abbr></label>
                                                                        <asp:TextBox  class="input-text    " ID="shipping_first_name" runat="server" placeholder="First name of the person you want to gift to" autocomplete="given-name" value=""/>
                                                                    </p>

                                                                    <p class="form-row form-row-last validate-required validate-required " id="shipping_last_name_field">
                                                                        <label for="shipping_last_name" class="">Last Name
                                                                            <abbr class="required" title="required">*</abbr></label>
                                                                        <asp:TextBox  class="input-text    " ID="shipping_last_name" runat="server" placeholder="Last name of the gift receiver" autocomplete="family-name" value=""/>
                                                                    </p>
                                                                    <div class="clear"></div>

                                                                    <p class="form-row address-field form-row-wide validate-required validate-required " id="shipping_address_1_field">
                                                                        <label for="shipping_address_1" class="">Address
                                                                            <abbr class="required" title="required">*</abbr></label>
                                                                        <input type="text" class="input-text    " name="shipping_address_1" id="shipping_address_1" placeholder="Street address" autocomplete="address-line1" value="">
                                                                    </p>

                                                                    <p class="form-row address-field form-row-wide " id="shipping_address_2_field">
                                                                        <label for="shipping_address_2" class=""></label>
                                                                        <input type="text" class="input-text    " name="shipping_address_2" id="shipping_address_2" placeholder="Apartment, suite, unit etc. (optional)" autocomplete="address-line2" value="">
                                                                    </p>

                                                                    <p class="form-row address-field form-row-wide validate-required validate-required " id="shipping_city_field">
                                                                        <label for="shipping_city" class="">Town / City
                                                                            <abbr class="required" title="required">*</abbr></label>
                                                                        <input type="text" class="input-text    " name="shipping_city" id="shipping_city" placeholder="Mumbai" autocomplete="address-level2" value="">
                                                                    </p>

                                                                    <p class="form-row form-row address-field form-row-wide validate-required validate-state" id="shipping_state_field">
                                                                        <label for="shipping_state" class="">State / County
                                                                            <abbr class="required" title="required">*</abbr></label><div class="select2-container state_select" id="s2id_shipping_state" style="width: 100%;"><a href="javascript:void(0)" class="select2-choice select2-default" tabindex="-1"><span class="select2-chosen" id="select2-chosen-3">Ex: Maharashtra</span><abbr class="select2-search-choice-close"></abbr>
                                                                                <span class="select2-arrow" role="presentation"><b role="presentation"></b></span></a>
                                                                                <label for="s2id_autogen3" class="select2-offscreen">State / County *</label><input class="select2-focusser select2-offscreen" type="text" aria-haspopup="true" role="button" aria-labelledby="select2-chosen-3" id="s2id_autogen3"><div class="select2-drop select2-display-none select2-with-searchbox">
                                                                                    <div class="select2-search">
                                                                                        <label for="s2id_autogen3_search" class="select2-offscreen">State / County *</label>
                                                                                        <input type="text" autocomplete="off" autocorrect="off" autocapitalize="off" spellcheck="false" class="select2-input" role="combobox" aria-expanded="true" aria-autocomplete="list" aria-owns="select2-results-3" id="s2id_autogen3_search" placeholder="">
                                                                                    </div>
                                                                                    <ul class="select2-results" role="listbox" id="select2-results-3"></ul>
                                                                                </div>
                                                                            </div>
                                                                        <select name="shipping_state" id="shipping_state" class="state_select " data-placeholder="Ex: Maharashtra" autocomplete="address-level1" tabindex="-1" title="State / County *" style="display: none;">
                                                                            <option value="">Select a state…</option>
                                                                            <option value="AP">Andhra Pradesh</option>
                                                                            <option value="AR">Arunachal Pradesh</option>
                                                                            <option value="AS">Assam</option>
                                                                            <option value="BR">Bihar</option>
                                                                            <option value="CT">Chhattisgarh</option>
                                                                            <option value="GA">Goa</option>
                                                                            <option value="GJ">Gujarat</option>
                                                                            <option value="HR">Haryana</option>
                                                                            <option value="HP">Himachal Pradesh</option>
                                                                            <option value="JK">Jammu and Kashmir</option>
                                                                            <option value="JH">Jharkhand</option>
                                                                            <option value="KA">Karnataka</option>
                                                                            <option value="KL">Kerala</option>
                                                                            <option value="MP">Madhya Pradesh</option>
                                                                            <option value="MH">Maharashtra</option>
                                                                            <option value="MN">Manipur</option>
                                                                            <option value="ML">Meghalaya</option>
                                                                            <option value="MZ">Mizoram</option>
                                                                            <option value="NL">Nagaland</option>
                                                                            <option value="OR">Orissa</option>
                                                                            <option value="PB">Punjab</option>
                                                                            <option value="RJ">Rajasthan</option>
                                                                            <option value="SK">Sikkim</option>
                                                                            <option value="TN">Tamil Nadu</option>
                                                                            <option value="TS">Telangana</option>
                                                                            <option value="TR">Tripura</option>
                                                                            <option value="UK">Uttarakhand</option>
                                                                            <option value="UP">Uttar Pradesh</option>
                                                                            <option value="WB">West Bengal</option>
                                                                            <option value="AN">Andaman and Nicobar Islands</option>
                                                                            <option value="CH">Chandigarh</option>
                                                                            <option value="DN">Dadar and Nagar Haveli</option>
                                                                            <option value="DD">Daman and Diu</option>
                                                                            <option value="DL">Delhi</option>
                                                                            <option value="LD">Lakshadeep</option>
                                                                            <option value="PY">Pondicherry (Puducherry)</option>
                                                                        </select>
                                                                    </p>

                                                                    <p class="form-row address-field form-row-wide validate-required validate-postcode validate-required " id="shipping_postcode_field">
                                                                        <label for="shipping_postcode" class="">Postcode / ZIP
                                                                            <abbr class="required" title="required">*</abbr></label>
                                                                        <input type="text" class="input-text    " name="shipping_postcode" id="shipping_postcode" placeholder="400001" autocomplete="postal-code" value="">
                                                                    </p>
                                                                    <div class="clear"></div>

                                                                    <p class="form-row form-row-wide " id="shipping_field_969_field">
                                                                        <label for="shipping_field_969" class="">Occasion   of   the   gift (Please make sure that the date of occasion is at least a week after the date of placing order. It                                                         will give us enough time for us to fulfill your delivery on time.)</label>
                                                                        <input type="text" class="input-text    " name="shipping_field_969" id="shipping_field_969" placeholder="Ex. Birthday, Anniversary" value="">
                                                                    </p>

                                                                    <p class="form-row form-row-wide " id="shipping_field_315_field">
                                                                        <label for="shipping_field_315" class="">Add a personalized note that you would want our delivery guy to say to the receiver.</label>
                                                                        <input type="text" class="input-text    " name="shipping_field_315" id="shipping_field_315" placeholder="Ex. Happy anniversary to you and your spouse" value="">
                                                                    </p>

                                                                    <p class="form-row form-row-wide " id="shipping_field_85_field">
                                                                        <label for="shipping_field_85" class="">Occasion date</label><input type="text" class="pcfme-datepicker input-text    hasDatepicker" name="shipping_field_85" id="shipping_field_85" placeholder="" value="">
                                                                    </p>

                                                                    <p class="form-row form-row-wide validate-required validate-required " id="shipping_field_156_field">
                                                                        <label for="shipping_field_156" class="">Receiver's Phone number
                                                                            <abbr class="required" title="required">*</abbr></label>
                                                                        <input type="text" class="input-text    " name="shipping_field_156" id="shipping_field_156" placeholder="" value="">
                                                                    </p>


                                                                </div>--%>


                                                                        <p class="form-row notes " id="order_comments_field">
                                                                            <label for="order_comments" class="">Order Notes</label>
                                                                            <textarea name="order_comments" class="input-text    " id="order_comments" placeholder="Notes about your order, e.g. special notes for delivery." rows="2" cols="5"></textarea>
                                                                        </p>


                                                                    </div>
                                                                </div>
                                                                <div class="small-12 large-4 columns your-order">
                                                                    <section class="section woocommerce-checkout-review-order" id="order_review">
                                                                        <h3>Your Order</h3>

                                                                        <asp:Repeater ID="rptEmployees" runat="server">
                                                                            <HeaderTemplate>
                                                                                <table class="shop_table woocommerce-checkout-review-order-table order_table">
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <<tbody>
                                                                                    <tr class="cart_item">
                                                                                        <td class="product-name" colspan="3">
                                                                                            <span><%#Eval("varcharproductname") %></span>
                                                                                            <strong class="product-quantity"><%#Eval("varcharSubscriptionType") %></strong>															</td>
                                                                                        <td class="product-total">
                                                                                            <span class="woocommerce-Price-amount amount"><span class="woocommerce-Price-currencySymbol">₹</span>
                                                                                                <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("intProductPrice") %>' />
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







                                                                        <div id="payment" class="woocommerce-checkout-payment">
                                                                            <ul class="wc_payment_methods payment_methods methods">
                                                                                <li class="payment_method_cod">
                                                                                    <input id="payment_method_cod" type="radio" class="input-radio custom_check" name="payment_method" value="cod" checked="checked" data-order_button_text="" style="display: none;">

                                                                                    <label for="payment_method_cod" class="custom_label">
                                                                                        Cash on Delivery 
                                                                                    </label>
                                                                                    <div class="payment_box payment_method_cod">
                                                                                        <p>Pay with cash upon delivery.</p>
                                                                                    </div>
                                                                                </li>
                                                                            </ul>

                                                                            <div class="form-row place-order">

                                                                                <noscript>
			Since your browser does not support JavaScript, or it is disabled, please ensure you click the &lt;em&gt;Update Totals&lt;/em&gt; button before placing your order. You may be charged more than the amount stated above if you fail to do so.			&lt;br/&gt;&lt;input type="submit" class="button alt" name="woocommerce_checkout_update_totals" value="Update totals" /&gt;
		</noscript>

                                                                                <p class="form-row terms wc-terms-and-conditions">
                                                                                    <input type="checkbox" class="input-checkbox custom_check" name="terms" id="terms">
                                                                                    <label for="terms" class="checkbox custom_label">I’ve read and accept the <a href="https://flicbox.com/terms-and-conditions/" target="_blank">terms &amp; conditions</a> <span class="required">*</span></label>
                                                                                    <input type="hidden" name="terms-field" value="1">
                                                                                </p>


                                                                                <input type="submit" class="button alt" name="woocommerce_checkout_place_order" id="place_order" value="Place order" data-value="Place order">
                                                                                <div class="after-place-order-button">
                                                                                    <br>
                                                                                    If you don't receive an invoice in your inbox, please kindly check your spam.<br>
                                                                                    <br>
                                                                                    Please expect the delivery of your order between 21st and 30th of every month.
                                                                                </div>
                                                                                <input type="hidden" id="_wpnonce" name="_wpnonce" value="b72ca5dfe2"><input type="hidden" name="_wp_http_referer" value="/checkout/?wc-ajax=update_order_review">
                                                                            </div>
                                                                        </div>



                                                                    </section>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>


                    <!--test-->
                </div>
            </div>
        </div>

    </div>
</asp:Content>
