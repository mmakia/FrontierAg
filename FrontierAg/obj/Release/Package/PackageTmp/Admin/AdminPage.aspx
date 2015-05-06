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
                <asp:Button ID="ContactsBtn" runat="server" Text="Contacts" OnClick="ContactsBtn_Click" Width="200px" />
            </td>
            <td>
                <asp:Button ID="ShippingsBtn" runat="server" Text="Shippings" OnClick="ShippingsBtn_Click" Width="200px" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="PosBtn" runat="server" Text="Pos" OnClick="PosBtn_Click" Width="200px" />
            </td>
        
            <td>
                <asp:Button ID="CategoriesBtn" runat="server" Text="Categories" OnClick="CategoriesBtn_Click" Width="200px" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="ProductsBtn" runat="server" Text="Products" OnClick="ProductsBtn_Click" Width="200px" />
            </td>
            <td>
                <asp:Button ID="PricesBtn" runat="server" Text="Prices" OnClick="PricesBtn_Click" Width="200px" />
            </td>
        </tr>
            <tr>
            <td>
                <asp:Button ID="OrderBtn" runat="server" Text="Orders" OnClick="OrderBtn_Click" Width="200px" />
            </td>
            <td>
                <asp:Button ID="OrderDetails" runat="server" Text="OrderDetails" OnClick="OrderDetails_Click" Width="200px" />
            </td>
        </tr>
            </tbody>
    </table>

    
       
</asp:Content>
