<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckoutComplete.aspx.cs" Inherits="FrontierAg.Checkout.CheckoutComplete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Checkout Complete</h2>
    <p></p>
    
    <p></p>
    <h3>Thank You!</h3>
    <p></p>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label> 
    <hr />
    <asp:Button ID="Continue" runat="server" Text="Continue Shopping" OnClick="Continue_Click" CssClass="btn btn-warning"/>    
</asp:Content>
