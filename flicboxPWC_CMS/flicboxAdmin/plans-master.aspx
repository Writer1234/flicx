<%@ Page Title="Subscription Plans Master" Language="C#" MasterPageFile="~/flicboxAdmin/flicboxAdmin.Master" AutoEventWireup="true" CodeBehind="plans-master.aspx.cs" Inherits="flicboxPWC_CMS.flicboxAdmin.plans_master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="http://code.jquery.com/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="../js/ValidationJs.js"></script>
    <script type="text/javascript">
        $(function () {
            $('[id*=txtProductName]').typeahead({
            hint: true,
            highlight: true,
            minLength: 1
            ,source: function (request, response) {
                $.ajax({
                    url: '<%=ResolveUrl("~/Autocomplete.aspx/GetProduct") %>',
                    data: "{ 'prefix': '" + request + "','subtype': '" + $('[id*=ddlProductType]').val() + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        items = [];
                        map = {};
                        $.each(data.d, function (i, item) {
                            var id = item.split('-')[1];
                            var name = item.split('-')[0];
                            map[name] = { id: id, name: name };
                            items.push(name);
                        });
                        response(items);
                        $(".dropdown-menu").css("height", "auto");
                    },
                    error: function (response) {
                        alert(response.responseText);
                    },
                    failure: function (response) {
                        alert(response.responseText);
                    }
                });
            },
            updater: function (item) {
                //$('[id*=hfCustomerId]').val(map[item].id);
                return item;
            }
        });
    });
   
    </script>
    <div class="container-fluid">
        <!-- Page Heading -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Manage<small> Plans</small>
                </h1>
            </div>
        </div>
        <div id="divStatus" runat="server"></div>
        <div class="row">
            <div class="col-md-12">
                <table class="table table-bordered table-hover table-striped">
                    <tr>
                        <th>Product Type</th>
                        <td>
                            <asp:DropDownList ID="ddlProductType" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Subscription" Value="Subscription"></asp:ListItem>
                                <asp:ListItem Text="Shop" Value="Shop"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>Subscription Type</th>
                        <td>
                            <asp:DropDownList ID="ddlSubscriptionType" runat="server" DataSourceID="SqlDataSourceSubscriptionType" DataTextField="NAME" DataValueField="ID" CssClass="form-control">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSourceSubscriptionType" runat="server" ConnectionString="<%$ConnectionStrings:conStr %>"
                                SelectCommand="EXEC [dbo].[GetSubscriptionTypeCombo] @SP_TYPE='allactive'" ></asp:SqlDataSource>

                        </td>
                    </tr>
                    <tr>
                        <th>Product Name</th>
                        <td>
                            <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control"  onkeypress="return IsAlphaNumeric(event,this);"  AutoCompleteType="Disabled" ondrop="return false;" onpaste="return false;" />
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="Product Name Required !"
                                ControlToValidate="txtProductName" Display="Dynamic" CssClass="asperror" runat="server"
                                SetFocusOnError="true" />
                        </td>
                    </tr>
                    <tr>
                        <th>Product Short Description</th>
                        <td>
                            <asp:TextBox ID="txtShortDesc" runat="server" CssClass="form-control" />
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Product Name Required !"
                                ControlToValidate="txtProductName" Display="Dynamic" CssClass="asperror" runat="server"
                                SetFocusOnError="true" />
                        </td>
                    </tr>
                    <tr>
                        <th>Product Long Description</th>
                        <td>
                            <asp:TextBox ID="txtLongDesc" runat="server" CssClass="form-control" />
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Product Name Required !"
                                ControlToValidate="txtProductName" Display="Dynamic" CssClass="asperror" runat="server"
                                SetFocusOnError="true" />
                        </td>
                    </tr>
                    <tr>
                        <th>Price</th>
                        <td>
                            <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" />
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Product Name Required !"
                                ControlToValidate="txtProductName" Display="Dynamic" CssClass="asperror" runat="server"
                                SetFocusOnError="true" />
                        </td>
                    </tr>
                    <tr>
                        <th>Product Image</th>
                        <td>
                            <input id="Button1" type="button" value="Add Image Button" onclick="AddFileUpload()" class="btn-success btn btn-primary" /><hr />
                            <span id="FileUploadContainer">
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnInsert" Text="Insert" runat="server" CssClass="btn-success btn btn-primary" OnClick="btnInsert_Click" />
                            <asp:Button ID="btnUpdate" Text="Update" runat="server" CssClass="btn-success btn btn-primary" OnClick="btnUpdate_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var counter = 0;

        function ReInitializeCounter() {
            counter = 0;
            //            alert(counter);
        }

        function AddFileUpload() {
            if (counter > 1) {
                alert('Cannot Add More Files!\nKindly Upload The Existing Files To Continue Adding More Files!');
                return false;
            }
            var div = document.createElement('div');
            //div.id = "myDiv";
            div.innerHTML = 'Product Image : <input id="file' + counter + '" name = "file' + counter + '" type="file" /> <br/>';
            div.innerHTML += '<input id="Button' + counter + '" type="button" value="Remove" onclick = "RemoveFileUpload(this)" class="btn-danger btn btn-primary" /><hr/>';
            document.getElementById("FileUploadContainer").appendChild(div);
            counter++;
        }

        function RemoveFileUpload(div) {
            document.getElementById("FileUploadContainer").removeChild(div.parentNode);
            counter--;
        }

        function Validate() {
            if (counter == 0) {
                alert('Please Add Some Files To Upload!');
                return false;
            }
        }

    </script>
</asp:Content>
