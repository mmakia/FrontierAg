<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddShipping2.aspx.cs" Inherits="FrontierAg.Admin.Shippings.AddShipping2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    <hr />
    <h3>Add Shipping Address:</h3>
    <table>        
        <tr>
            <td><asp:Label ID="LabelAddress1" runat="server">Address1:</asp:Label></td>
            <td>
                <asp:TextBox ID="AddProductName" runat="server"></asp:TextBox>                
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="LabelAddress2" runat="server">Address2:</asp:Label></td>
            <td>
                <asp:TextBox ID="AddProductDescription" runat="server"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="LabelCity" runat="server">City:</asp:Label></td>
            <td>
                <asp:TextBox ID="AddProductPrice" runat="server"></asp:TextBox>
                
            </td>
        </tr>
        <%--<tr>
            <td><asp:Label ID="LabelState" runat="server">State:</asp:Label></td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" 
                    ItemType="WingtipToys.Models.Shipping" 
                    SelectMethod="GetStates" DataTextField="ContactId" 
                    DataValueField="ShippingId" >
                </asp:DropDownList>
            </td>
        </tr>--%>
        <tr>
            <td><asp:Label ID="LabelPostal" runat="server">Postal Code:</asp:Label></td>
            <td>
                <asp:TextBox ID="TextBoxPostal" runat="server"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="LabelCountry" runat="server">Country:</asp:Label></td>
            <td>
                <asp:TextBox ID="TextBoxCountry" runat="server"></asp:TextBox>
                
            </td>
        </tr>
    </table>
    <p></p>
    <p></p>
    <asp:Button ID="AddShippingButton" runat="server" Text="Insert" OnClick="AddShippingButton_Click"  CausesValidation="true" CssClass="btn btn-warning"/>
    <asp:Label ID="LabelAddStatus" runat="server" Text=""></asp:Label>
    <p></p>
    
    <p></p>    
    <asp:Label ID="LabelRemoveStatus" runat="server" Text=""></asp:Label>
</asp:Content>
