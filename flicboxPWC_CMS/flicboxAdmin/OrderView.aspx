<%@ Page Title="" Language="C#" MasterPageFile="~/flicboxAdmin/flicboxAdmin.Master" AutoEventWireup="true" CodeBehind="OrderView.aspx.cs" Inherits="flicboxPWC_CMS.flicboxAdmin.OrderView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container-fluid">
        <!-- Page Heading -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Manage<small> Order</small>
                </h1>
            </div>
        </div>
        <div id="divStatus" runat="server"></div>
        <div class="row">
            <div class="col-md-12">
                <table>
                    <tr>
                        <td>From Date *</td>
                        <td>
                            <asp:TextBox ID="txtFromDate" runat="server" MaxLength="11" ValidationGroup="SEARCH"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVFromDate" runat="server" ControlToValidate="txtFromDate"  ErrorMessage="From Date Required." Display="None" ValidationGroup="SEARCH"></asp:RequiredFieldValidator>
                        </td>
                        <td>To Date *</td>
                        <td>
                         <asp:TextBox ID="txtToDate" runat="server" MaxLength="11" ValidationGroup="SEARCH"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVToDate" runat="server"  ControlToValidate="txtToDate"  ErrorMessage="To Date Required." Display="None" ValidationGroup="SEARCH"></asp:RequiredFieldValidator>
                        </td>
                        <td>Customer Name </td>
                        <td>
                            <asp:TextBox ID="txtCustName" runat="server" MaxLength="50" ValidationGroup="SEARCH"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <asp:Button ID="Button1" runat="server" Text="Button"  ValidationGroup="SEARCH" OnClick="Button1_Click" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" HeaderText="Validation Error" ShowMessageBox="true" ShowSummary="false"  ValidationGroup="SEARCH"/>
                        </td>
                        
                        
                    </tr>
                </table>
            </div>
            <div class="col-md-12">
                <asp:GridView ID="grdvwOrderMaster" runat="server" AutoGenerateColumns="False" EmptyDataText="There is No Data to display !"
                    AllowPaging="True" EnableModelValidation="True" GridLines="Vertical" PageSize="10" OnRowDataBound="grdvwOrderMaster_RowDataBound"
                    CssClass="gview" OnPageIndexChanging="grdvwOrderMaster_PageIndexChanging" OnRowCommand="grdvwOrderMaster_RowCommand"
                    OnRowDeleting="grdvwOrderMaster_RowDeleting" DataKeyNames="intOrderID">
                    <Columns>
                        <asp:TemplateField HeaderText="Order No.">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkOrderID" runat="server" Text=' <%#string.Format("#{0}", Eval("intOrderID"))%>'></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="varcharUserName" HeaderText="Cust Name" ItemStyle-Wrap="true">
                            <ItemStyle Wrap="True" Width="250px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="TotalQty" HeaderText="Total Qty" ItemStyle-Wrap="true">
                            <ItemStyle Wrap="True" Width="250px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="SubTotalAmount" HeaderText="SubTotal Amount" ItemStyle-Wrap="true">
                            <ItemStyle Wrap="True" Width="250px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" ItemStyle-Wrap="true">
                            <ItemStyle Wrap="True" Width="250px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="OrderStatus" HeaderText="Order Status" ItemStyle-Wrap="true">
                            <ItemStyle Wrap="True" Width="250px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="OrderDate" HeaderText="Order Date" ItemStyle-Wrap="true">
                            <ItemStyle Wrap="True" Width="250px"></ItemStyle>
                        </asp:BoundField>
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
