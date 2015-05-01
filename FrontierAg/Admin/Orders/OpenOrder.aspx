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
    <div class="row">
					  &nbsp;
					</div>
					<div class="form-group">
						<div >
							<asp:button id="backButton" runat="server" text="Back" OnClientClick="JavaScript:window.history.back(1);return false;" CssClass="btn btn-warning" />
						</div>
					</div>

         
    
    

</asp:Content>

