<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FrontierAg.Admin.Orders.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">    

    <div id="OrdersTitle" runat="server" class="ContentHead"><h3>All Orders</h3></div>

    <h4>Show Status</h4>

<asp:DropDownList runat="server" AutoPostBack="true" ID="Status" class="form-control" Width="150">
    <asp:ListItem Text="All" Value="" />
    <asp:ListItem Text="Cancelled" />
    <asp:ListItem Text="New" />
    <asp:ListItem Text="Processing" />
    <asp:ListItem Text="PartialShipment" />
    <asp:ListItem Text="Shipped" />
    <asp:ListItem Text="Billed" />
    <asp:ListItem Text="Closed" />
</asp:DropDownList>
    <br />

    <asp:GridView ID="OrdersList" runat="server" AutoGenerateColumns="False" ItemType="FrontierAg.Models.Order" DataKeyNames="OrderId" SelectMethod="OrdersList_GetData" UpdateMethod="OpenOrders_UpdateItem"     
    AutoGenerateEditButton="True" CssClass="table table-striped table-bordered" EnableModelValidation="true" AllowSorting="true" AllowPaging="true" PageSize="10">
        <Columns>                  
        <asp:DynamicField DataField="OrderId" HeaderText="ID" ReadOnly="true"/>        
        <asp:DynamicField DataField="OrderDate" HeaderText="Order Date" ReadOnly="true"/>            
                     
        <asp:TemplateField HeaderText="Ordered By">
            <ItemTemplate>
                <asp:HyperLink runat="server" NavigateUrl='<%# Microsoft.AspNet.FriendlyUrls.FriendlyUrl.Href("~/Admin/Contacts/Details", Item.ContactId) %>' Text="<%#: Item.Contact.Company %>" />
            </ItemTemplate>
        </asp:TemplateField>    
                        
            <asp:DynamicField DataField="Total" HeaderText="Total" ReadOnly="true"/>  
            <asp:DynamicField DataField="Payment" HeaderText="Payment No." ReadOnly="true"/>
            <asp:DynamicField DataField="PaymentDate" HeaderText="Payment Date" ReadOnly="true"/>  
            <%--<asp:DynamicField DataField="Tracking" HeaderText="Tracking #" ReadOnly="true"/>  --%>
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

