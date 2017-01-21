<%@ Page Title="" Language="C#" MasterPageFile="~/MasterFlicbox.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="flicboxPWC_CMS.cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="about">
        <script type="text/javascript">
            $(function () {
                GetTotal();

                //var previous;
                //$("select").on('focus', function () {
                //    // Store the current value on focus and on change
                //    previous = this.value;
                //    $("[id*=HFVProductIDold]").val(previous);

                //}).change(function () {
                //    // Do something with the previous value after the change
                //    //alert(previous);

                //    // Make sure the previous value is updated


                //    //$("[id*=HFVProductIDold]").val(previous);
                //    previous = this.value;
                //});


            });

            function GetTotal() {
                var grandTotal = 0;
                $("[id*=lblProductTotal]").each(function () {
                    var value = $(this).html();
                    if (value != "")
                        grandTotal = grandTotal + parseFloat(value);
                });
                $("[id*=lblGrandTotal]").html('Grand Total:  ' + grandTotal.toString());
            }

            function isNumberKey(evt) {
                var charCode = (evt.which) ? evt.which : evt.keyCode;
                if (charCode > 31 && (charCode < 48 || charCode > 57))
                    return false;
                return true;
            }

        </script>
        <div class="parallax-section">
            <div class="parallax-services"></div>
            <div class="just_pattern"></div>
            <div class="container z-index-pages">
                <div class="sixteen columns" data-scrollreveal="enter top and move 250px over 3s">
                    <h1>Cart</h1>
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
                <asp:UpdatePanel ID="CartPanel" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="divStatus" runat="server"></div>

                        <div class="twelve columns" data-scrollreveal="enter top and move 250px over 3s">
                            <asp:GridView ID="grdvwCart" runat="server" AutoGenerateColumns="False" EmptyDataText="There is No Data to display !"
                                AllowPaging="True" EnableModelValidation="True" GridLines="Vertical" PageSize="10" DataKeyNames="ProductId"
                                CssClass="gview" OnPageIndexChanging="grdvwCart_PageIndexChanging" OnRowCommand="grdvwCart_RowCommand" 
                                OnRowDeleting="grdvwCart_RowDeleting" OnRowDataBound="grdvwCart_RowDataBound" OnRowEditing="grdvwCart_RowEditing" OnRowUpdating="grdvwCart_RowUpdating"
                                OnRowCancelingEdit="grdvwCart_RowCancelingEdit">
                                <Columns>
                                    <asp:TemplateField HeaderText="Product Image" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Image ID="imgPhotoPath" Width="100%" ImageUrl='<%# Eval("ProductImg1") %>' AlternateText='<%# Eval("ProductName") %>'
                                                runat="server" CssClass="img-grid-photo" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product Name" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProductName" runat="server" Text='<%#Eval("ProductName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblEditProductName" runat="server" Text='<%#Eval("ProductName")%>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemStyle Wrap="True" Width="250px"></ItemStyle>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Product Type" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProductType" runat="server" Text='<%#Eval("productTypeName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblEditProductType" runat="server" Text='<%#Eval("productTypeName")%>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemStyle Wrap="True" Width="250px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Subscription Type" ItemStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSubscription" runat="server" Text='<%# Eval("SubscriptionName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlSubscriptionType" runat="server" style="border:1px solid;"  DataTextField="NAME" DataValueField="ID" AutoPostBack="true"  OnSelectedIndexChanged="ddlSubscriptionType_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="sqlDataSource2" runat="server"
                                                ConnectionString="<%$ ConnectionStrings:conStr %>"
                                                SelectCommand="EXEC [dbo].[GetSubscriptionTypeCombo] @SP_TYPE='ByProductWithPrice',@SP_Searchstring=Searchstring"
                                                CancelSelectOnNullParameter="true">
                                                <SelectParameters>
                                                    <asp:ControlParameter ControlID="lblEditProductName" Name="Searchstring" Type="String" Size="100" ConvertEmptyStringToNull="false" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </EditItemTemplate>
                                        <ItemStyle Wrap="True" Width="250px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quanity" ItemStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQty" runat="server" Text='<%# Eval("Quanity") %>'></asp:Label>
                                            <asp:HiddenField ID="HFVProductID" runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEditQty" runat="server" Text='<%# Eval("Quanity") %>' BorderStyle="Solid" BorderWidth="1"  onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemStyle Wrap="True" Width="250px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Price" ItemStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("ProductPrice") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblEditPrice" runat="server" Text='<%# Eval("ProductPrice") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemStyle Wrap="True" Width="250px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" ItemStyle-Wrap="true" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProductTotal" runat="server" Text='<%# Eval("ProductTotal") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblEditTotal" runat="server" Text='<%# Eval("ProductTotal") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemStyle Wrap="True" Width="250px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Details" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEdit" runat="server" CssClass="editlink" CausesValidation="false" CommandName="Edit" Text="Edit" />
                                            <asp:LinkButton ID="lnkDelete" CssClass="editlink" Text="Delete" runat="server" CommandName="delete"
                                                CommandArgument='<%# Eval("ProductID") %>' OnClientClick="javascript:return confirm('Are you sure you want to remove?')" OnClick="lnkDelete_Click" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="btnUpdate" runat="server" CssClass="editlink" CommandName="Update" Text="Update" />
                                            <asp:LinkButton ID="btnCancel" runat="server" CssClass="editlink" CausesValidation="false" CommandName="Cancel"
                                                Text="Cancel" />
                                        </EditItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle CssClass="gview_footerstyle" />
                                <HeaderStyle CssClass="gview_headerstyle" />
                                <PagerStyle CssClass="gview_pagerstyle" HorizontalAlign="Center" />
                                <RowStyle CssClass="gview_rowstyle" />
                                <EmptyDataRowStyle CssClass="gview_emptydatarowstyle" />
                                <AlternatingRowStyle CssClass="gview_alternatingrowstyle" />
                                <SelectedRowStyle CssClass="gview_selectedrowstyle" />
                            </asp:GridView>
                            <div id="lblGrandTotal" />
                        </div>
                        <div class="cl-effect-11">
                            <asp:LinkButton ID="btnCheckout" CssClass="editlink" Text="Checkout" runat="server"
                                OnClick="btnCheckout_Click" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
        </div>

    </div>
</asp:Content>
