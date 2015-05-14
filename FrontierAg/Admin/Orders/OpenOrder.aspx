<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OpenOrder.aspx.cs" Inherits="FrontierAg.Admin.Orders.OpenOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">    

    <div id="OpenOrderTitle" runat="server" class="ContentHead"><h3>Open Orders</h3></div>
    <asp:GridView ID="OpenOrdersList2" runat="server" AutoGenerateColumns="False" ItemType="FrontierAg.Models.Order" DataKeyNames="OrderId" SelectMethod="OpenOrdersList_GetData" UpdateMethod="OpenOrders_UpdateItem"     
    AutoGenerateEditButton="True" CssClass="table table-striped table-bordered" EnableModelValidation="true" AllowSorting="true" AllowPaging="true" PageSize="11">
        <Columns>                  
        <asp:DynamicField DataField="OrderId" HeaderText="ID" ReadOnly="true"/>        
        <asp:DynamicField DataField="OrderDate" HeaderText="Order Date" ReadOnly="true"/>            
                     
        <asp:TemplateField HeaderText="Customer">
            <ItemTemplate>
                <asp:HyperLink runat="server" NavigateUrl='<%# Microsoft.AspNet.FriendlyUrls.FriendlyUrl.Href("~/Admin/Contacts/Details", Item.Shipping.ContactId) %>' Text="<%#: Item.Shipping.Contact.Company %>" />
            </ItemTemplate>
        </asp:TemplateField>    

            <asp:DynamicField DataField="OtherCharge" HeaderText="Other Charges" />  
            <asp:DynamicField DataField="Discount" HeaderText="Discount" /> 
            <asp:DynamicField DataField="Total" HeaderText="Total" ReadOnly="true"/>  

            <asp:DynamicField DataField="Payment" HeaderText="Payment No." />
            <asp:DynamicField DataField="PaymentDate" HeaderText="Payment Date" />  
            <asp:DynamicField DataField="Tracking" HeaderText="Tracking #" />  
            <asp:DynamicField DataField="Comment" HeaderText="Comment" />          
            <asp:DynamicField DataField="Status" HeaderText="Status" />                 

                        
            <asp:HyperLinkField Text="Items" DataNavigateUrlFormatString="~/Admin/OrderDetails/Default/{0}" DataNavigateUrlFields="OrderId" />
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

