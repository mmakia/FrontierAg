<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="FrontierAg.Admin.AdminPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<script type="text/javascript">
        $(function () {
            $(alert = "Hi")
        });
    </script>--%>
    <table class="SCTable">
        <tbody>
            <tr>
                <td>
                    <asp:Button ID="CategoriesBtn" runat="server" Text="Categories" OnClick="CategoriesBtn_Click" Width="300px" CssClass="btn btn-warning" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ProductsBtn" runat="server" Text="Products Pricing Packaging " OnClick="ProductsBtn_Click" Width="300px" CssClass="btn btn-warning" />
                </td>

            </tr>
            <tr>

                <td>
                    <asp:Button ID="ContactsBtn" runat="server" Text="Companies Addresses Orders Shipments" OnClick="ContactsBtn_Click" Width="300px" CssClass="btn btn-warning" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="AllOrderBtn" runat="server" Text="All Orders" OnClick="AllOrderBtn_Click" Width="300px" CssClass="btn btn-warning" />
                </td>
            </tr>
            <tr>

                <td>
                    <asp:Button ID="ToProcessOrdersBtn" runat="server" Text="ToProcess Orders" OnClick="ToProcessOrdersBtn_Click" Width="300px" CssClass="btn btn-warning" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="AllShipments" runat="server" Text="All Shipments" OnClick="AllShipments_Click" Width="300px" CssClass="btn btn-warning" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Emails" runat="server" Text="Notification Emails" OnClick="Emails_Click" Width="300px" CssClass="btn btn-warning" />
                </td>
            </tr>
        </tbody>
    </table>



</asp:Content>
