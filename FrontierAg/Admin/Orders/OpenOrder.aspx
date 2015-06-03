<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OpenOrder.aspx.cs" Inherits="FrontierAg.Admin.Orders.OpenOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">    

    <div id="OpenOrderTitle" runat="server" class="ContentHead"><h3>Open Orders</h3></div>
    <asp:GridView ID="OpenOrdersList2" runat="server" AutoGenerateColumns="False" ItemType="FrontierAg.Models.Order" DataKeyNames="OrderId" SelectMethod="OpenOrdersList_GetData" UpdateMethod="OpenOrders_UpdateItem"     
    AutoGenerateEditButton="True" CssClass="table table-striped table-bordered" EnableModelValidation="true" AllowSorting="true" AllowPaging="true" PageSize="11">
        <Columns>
            <asp:DynamicField DataField="OrderId" HeaderText="ID" ReadOnly="true"/>        
            <asp:DynamicField DataField="OrderDate" HeaderText="Order Date" ReadOnly="true"/>            
                     
            <asp:TemplateField HeaderText="Ordered By">
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%# Microsoft.AspNet.FriendlyUrls.FriendlyUrl.Href("~/Admin/Contacts/Details", Item.ContactId) %>' Text="<%#: Item.Contact.Company  %>" />
                </ItemTemplate>
            </asp:TemplateField>    

            <asp:TemplateField HeaderText="Billing">
            <ItemTemplate>
                <asp:LinkButton runat="server" OnClick="Unnamed_Click1" Text="Bill To" CommandArgument="<%# Item.OrderId %>"/>
                <%--<asp:HyperLink runat="server" NavigateUrl='<%# Microsoft.AspNet.FriendlyUrls.FriendlyUrl.Href("~/Admin/Shippings/Default", Item.OrderShippings.Select( en => en.Shipping.ShippingId)) %>' Text="<%#: Item.OrderShippings.Select(w => w.Shipping.City) %>" />--%>
            </ItemTemplate>
            </asp:TemplateField>  

            <asp:DynamicField DataField="OtherCharge" HeaderText="Other Charges" />  
            <asp:DynamicField DataField="Discount" HeaderText="Discount" /> 
            <asp:DynamicField DataField="Total" HeaderText="Total" ReadOnly="true"/>  

            <asp:DynamicField DataField="Payment" HeaderText="Payment No." />
            <asp:DynamicField DataField="PaymentDate" HeaderText="Payment Date" />  
             
            <asp:DynamicField DataField="Comment" HeaderText="Comment" />          
            <asp:DynamicField DataField="Status" HeaderText="Status" />                 

                        
            <asp:HyperLinkField Text="Details" DataNavigateUrlFormatString="~/Admin/OrderDetails/Default/{0}" DataNavigateUrlFields="OrderId" />
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

