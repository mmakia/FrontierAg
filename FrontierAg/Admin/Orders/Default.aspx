<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FrontierAg.Admin.Orders.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">    

    <div id="OrdersTitle" runat="server" class="ContentHead"><h3>All Orders</h3></div>
    <asp:GridView ID="OrdersList" runat="server" AutoGenerateColumns="False" ItemType="FrontierAg.Models.Order" DataKeyNames="OrderId" SelectMethod="OrdersList_GetData" UpdateMethod="OpenOrders_UpdateItem"     
    AutoGenerateEditButton="True" CssClass="table table-striped table-bordered" EnableModelValidation="true" AllowSorting="true" AllowPaging="true" PageSize="10">
        <Columns>                  
        <asp:DynamicField DataField="OrderId" HeaderText="ID" ReadOnly="true"/>        
        <asp:DynamicField DataField="OrderDate" HeaderText="Order Date" ReadOnly="true"/>            
                     
        <asp:TemplateField HeaderText="Customer">
            <ItemTemplate>
                <asp:HyperLink runat="server" NavigateUrl='<%# Microsoft.AspNet.FriendlyUrls.FriendlyUrl.Href("~/Admin/Contacts/Details", Item.Shipping.ContactId) %>' Text="<%#: Item.Shipping.Contact.Company %>" />
            </ItemTemplate>
        </asp:TemplateField>    

            <asp:DynamicField DataField="OtherCharge" HeaderText="Other Charges" ReadOnly="true"/>  
            <asp:DynamicField DataField="Discount" HeaderText="Discount" ReadOnly="true"/> 
            <asp:DynamicField DataField="Total" HeaderText="Total" ReadOnly="true"/>  

            <asp:DynamicField DataField="Payment" HeaderText="Payment No." ReadOnly="true"/>
            <asp:DynamicField DataField="PaymentDate" HeaderText="Payment Date" ReadOnly="true"/>  
            <asp:DynamicField DataField="Tracking" HeaderText="Tracking #" ReadOnly="true"/>  
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

