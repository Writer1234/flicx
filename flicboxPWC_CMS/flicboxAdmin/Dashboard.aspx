<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/flicboxAdmin/flicboxAdmin.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="flicboxPWC_CMS.flicboxAdmin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <!-- Page Heading -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Flicbox<small> Overview</small>
                </h1>
            </div>
        </div>
        <div id="divStatus" runat="server"></div>
        <div class="row">
            <div class="col-lg-3 col-md-6">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-3">
                                <i class="fa fa-comments fa-5x"></i>
                            </div>
                            <div class="col-xs-9 text-right">
                                <div class="huge">26</div>
                                <div>New Orders!</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
