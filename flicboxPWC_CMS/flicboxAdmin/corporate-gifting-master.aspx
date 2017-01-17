<%@ Page Title="Corporate Gifting Master" Language="C#" MasterPageFile="~/flicboxAdmin/flicboxAdmin.Master" AutoEventWireup="true" CodeBehind="corporate-gifting-master.aspx.cs" Inherits="flicboxPWC_CMS.flicboxAdmin.corporate_gifting_master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <!-- Page Heading -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Corporate Gifting <small>Overview</small>
                </h1>
            </div>
        </div>
        <div id="divStatus" runat="server"></div>
        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="grdvwCorporateGifting" runat="server" AutoGenerateColumns="False" EmptyDataText="There is No Data to display !"
                    AllowPaging="True" EnableModelValidation="True" GridLines="Vertical" PageSize="10"
                    CssClass="gview" OnPageIndexChanging="grdvwCorporateGifting_PageIndexChanging" OnRowCommand="grdvwCorporateGifting_RowCommand"
                    OnRowDeleting="grdvwCorporateGifting_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="varcharCompanyPerson" HeaderText="Person Name" ItemStyle-Wrap="true">
                            <ItemStyle Wrap="True" Width="250px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="varcharCompanyName" HeaderText="Company Name" ItemStyle-Wrap="true">
                            <ItemStyle Wrap="True" Width="250px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="varcharCompanyEmail" HeaderText="Company Email" ItemStyle-Wrap="true">
                            <ItemStyle Wrap="True" Width="250px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="varcharCompanyMobile" HeaderText="Company Mobile" ItemStyle-Wrap="true">
                            <ItemStyle Wrap="True" Width="250px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="varcharHeadcount" HeaderText="Head Count" ItemStyle-Wrap="true">
                            <ItemStyle Wrap="True" Width="250px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="varcharCompanyDescription" HeaderText="Description" ItemStyle-Wrap="true">
                            <ItemStyle Wrap="True" Width="400px"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Details">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" CssClass="editlink" Text="Delete" runat="server" CommandName="delete"
                                    CommandArgument='<%# Eval("intCorporateID") %>' OnClientClick="javascript:return confirmation()" />
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
    <script type="text/javascript">

        function confirmation() {
            var myvar = confirm('Are you sure you want to delete this record?');

            if (myvar == true)
                return true;
            else
                return false;
        }
    </script>
</asp:Content>
