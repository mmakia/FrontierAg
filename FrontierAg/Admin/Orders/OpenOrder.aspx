<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OpenOrder.aspx.cs" Inherits="FrontierAg.Admin.Orders.OpenOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="OpenOrderTitle" runat="server" class="ContentHead"><h2>Open Orders</h2></div>
    <asp:GridView ID="OpenOrdersList2" runat="server" AutoGenerateColumns="False" ItemType="FrontierAg.Models.Order" DataKeyNames="OrderId" SelectMethod="OpenOrdersList_GetData" UpdateMethod="OpenOrders_UpdateItem"     
    AutoGenerateEditButton="True" CssClass="table table-striped table-bordered" EnableModelValidation="true" >
        <Columns>            

        <asp:DynamicField DataField="OrderId" HeaderText="OrderId" ReadOnly="true"/>        
        <asp:DynamicField DataField="OrderDate" HeaderText="Order Date" ReadOnly="true"/>
        <asp:DynamicField DataField="Total" HeaderText="Total" ReadOnly="true"/>      
                     
        <asp:TemplateField HeaderText="Customer">
            <ItemTemplate>
                <asp:HyperLink runat="server" NavigateUrl='<%# Microsoft.AspNet.FriendlyUrls.FriendlyUrl.Href("~/Admin/Contacts/Details", Item.ContactId) %>' Text="<%#: Item.Contact.Company %>" />
            </ItemTemplate>
        </asp:TemplateField>        

        <asp:TemplateField HeaderText="Shipping To">
            <ItemTemplate>
                <asp:HyperLink runat="server" NavigateUrl='<%# Microsoft.AspNet.FriendlyUrls.FriendlyUrl.Href("~/Admin/Shippings/Details", Item.ShippingId) %>' Text="<%#: Item.Shipping.City %>" />
            </ItemTemplate>
        </asp:TemplateField>

            <asp:DynamicField DataField="Payment" HeaderText="Payment" />
            <asp:DynamicField DataField="PaymentDate" HeaderText="Payment Date" />  
            <asp:DynamicField DataField="Comment" HeaderText="Comment" />          
            <asp:DynamicField DataField="Closed" HeaderText="Closed?" />                   
        </Columns>        
    </asp:GridView>
</asp:Content>

