<%@ Page Title="Welcome" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FrontierAg._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3><%: Title %>.</h3>
        <p class="lead">Frontier Agricultural Sciences website provide an internal ordering system and is still under construction, for testing purposes, the database have been seeded with sample data<br />
            To test, click on Category name "Diet Ingrediants",click on any product to see Details page, to start ordering, click "Add to cart", update the Quantity in the shoppingcart as desicred and continue shopping and adding more products(Use "Diet Ingrediants" category for testing)<br />
        </p>

</asp:Content>
