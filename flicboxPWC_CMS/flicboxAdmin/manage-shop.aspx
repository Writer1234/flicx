<%@ Page Title="Manage Shop" Language="C#" MasterPageFile="~/flicboxAdmin/flicboxAdmin.Master" AutoEventWireup="true" CodeBehind="manage-shop.aspx.cs" Inherits="flicboxPWC_CMS.flicboxAdmin.manage_shop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <!-- Page Heading -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Manage<small> Shop</small>
                </h1>
            </div>
        </div>
        <div id="divStatus" runat="server"></div>
        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="grdvwProductMaster" runat="server" AutoGenerateColumns="False" EmptyDataText="There is No Data to display !"
                    AllowPaging="True" EnableModelValidation="True" GridLines="Vertical" PageSize="10"
                    CssClass="gview" OnPageIndexChanging="grdvwProductMaster_PageIndexChanging" OnRowCommand="grdvwProductMaster_RowCommand"
                    OnRowDeleting="grdvwProductMaster_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="Product Image">
                            <ItemTemplate>
                                <asp:Image ID="imgPhotoPath" Width="100%" ImageUrl='<%# Eval("varcharProductImg1") %>' AlternateText='<%# Eval("varcharProductImg1") %>'
                                    runat="server" CssClass="img-grid-photo" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="varcharProductName" HeaderText="Product Name" ItemStyle-Wrap="true">
                            <ItemStyle Wrap="True" Width="250px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="varcharSubscriptionType" HeaderText="Subscription Type" ItemStyle-Wrap="true">
                            <ItemStyle Wrap="True" Width="250px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="varcharProductShortDescription" HeaderText="Short Desc" ItemStyle-Wrap="true">
                            <ItemStyle Wrap="True" Width="250px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="varcharProductDescription" HeaderText="Long Desc" ItemStyle-Wrap="true">
                            <ItemStyle Wrap="True" Width="250px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="intProductPrice" HeaderText="Price" ItemStyle-Wrap="true">
                            <ItemStyle Wrap="True" Width="250px"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Details">
                            <ItemTemplate>
                                <a class="editlink" href="plans-master.aspx?mode=2&prodID=<%#Eval("intProductID") %>&prodType=<%# Eval("varcharProductType") %>
                                    &subType=<%#Eval("varcharSubscriptionType") %>&prodName=<%#Eval("varcharProductName") %>&shortDesc=<%#Eval("varcharProductShortDescription") %>
                                    &longDesc=<%#Eval("varcharProductDescription") %>&price=<%#Eval("intProductPrice") %>">Edit</a>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Details">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" CssClass="editlink" Text="Delete" runat="server" CommandName="delete"
                                    CommandArgument='<%# Eval("intProductID") %>' OnClientClick="javascript:return confirmation()" />
                            </ItemTemplate>
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
            </div>
        </div>
    </div>
</asp:Content>
