<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FrontierAg.Admin.Orders.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">    

    <div id="OrdersTitle" runat="server" class="ContentHead"><h2>Open Orders</h2></div>
    <asp:GridView ID="OpenOrdersList2" runat="server" AutoGenerateColumns="False" ItemType="FrontierAg.Models.Order" DataKeyNames="OrderId" SelectMethod="OrdersList_GetData" UpdateMethod="Orders_UpdateItem"     
    AutoGenerateEditButton="True" CssClass="table table-striped table-bordered" EnableModelValidation="true" >
        <Columns>                  
        <asp:DynamicField DataField="OrderId" HeaderText="OrderId" ReadOnly="true"/>        
        <asp:DynamicField DataField="OrderDate" HeaderText="Order Date" ReadOnly="true"/>
        <asp:DynamicField DataField="Total" HeaderText="Total" ReadOnly="true"/>      
                     
        <asp:TemplateField HeaderText="Customer">
            <ItemTemplate>
                <asp:HyperLink runat="server" NavigateUrl='<%# Microsoft.AspNet.FriendlyUrls.FriendlyUrl.Href("~/Admin/Contacts/Details", Item.Shipping.ContactId) %>' Text="<%#: Item.Shipping.Contact.Company %>" />
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
            <asp:DynamicField DataField="Status" HeaderText="Status" />               

            <asp:HyperLinkField Text="Order Details" DataNavigateUrlFormatString="~/Admin/OrderDetails/Default.aspx?OrderId={0}" DataNavigateUrlFields="OrderId" />      

            
        </Columns>        
    </asp:GridView>
         
    
    

</asp:Content>

