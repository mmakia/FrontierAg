<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OpenOrder.aspx.cs" Inherits="FrontierAg.Admin.Orders.OpenOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="OpenOrderTitle" runat="server" class="ContentHead"><h3>Open Order(s)</h3></div> 
    <asp:GridView ID="OpenOrdersList2" runat="server" AutoGenerateColumns="False" ItemType="FrontierAg.Models.Order" DataKeyNames="OrderId" SelectMethod="OpenOrdersList_GetData" UpdateMethod="OpenOrders_UpdateItem"     
    AutoGenerateEditButton="True" CssClass="table table-striped table-bordered" EnableModelValidation="true" AllowSorting="true" AllowPaging="true" PageSize="11">
        <Columns>
            <asp:DynamicField DataField="OrderId" HeaderText="ID" ReadOnly="true"/>        
            <asp:DynamicField DataField="OrderDate" HeaderText="Order Date" ReadOnly="true"/>            
                     
            <asp:TemplateField HeaderText="Ordered By">
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%# Microsoft.AspNet.FriendlyUrls.FriendlyUrl.Href("~/Admin/Customers/Details", Item.CustomerId) %>' Text="<%#: Item.Customer.Company  %>" />
                </ItemTemplate>
            </asp:TemplateField>    

            <asp:TemplateField HeaderText="Person">
            <ItemTemplate>
                <asp:LinkButton runat="server" OnClick="Unnamed_Click0" Text="Person" CommandArgument="<%# Item.OrderId %>"/>                
            </ItemTemplate>
            </asp:TemplateField> 

            <asp:TemplateField HeaderText="Billing">
            <ItemTemplate>
                <asp:LinkButton runat="server" OnClick="Unnamed_Click1" Text="Bill To" CommandArgument="<%# Item.OrderId %>"/>                
            </ItemTemplate>
            </asp:TemplateField>  
            
            <asp:DynamicField DataField="Total" HeaderText="SubTotal" ReadOnly="true"/>  
            <asp:DynamicField DataField="Payment" HeaderText="Payment" />                         
            <asp:DynamicField DataField="Comment" HeaderText="Comment" />          
            <%--<asp:DynamicField DataField="PaymentDate" HeaderText="Date" />  --%>
            <asp:DynamicField DataField="Status" HeaderText="Status" ReadOnly="true"/>                           
            <asp:HyperLinkField Text="Process" DataNavigateUrlFormatString="~/Admin/OrderDetails/Default/{0}" DataNavigateUrlFields="OrderId" />
            <asp:HyperLinkField Text="Shipments" DataNavigateUrlFormatString="~/Admin/Shipments/OpenShipment/{0}" DataNavigateUrlFields="OrderId" />
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

