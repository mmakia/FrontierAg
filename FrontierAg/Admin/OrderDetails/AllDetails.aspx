<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllDetails.aspx.cs" Inherits="FrontierAg.Admin.OrderDetails.AllDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="AllDetail" runat="server" class="ContentHead"><h3>Items</h3></div>
    <asp:GridView ID="AllDetailsGrid" runat="server" DataKeyNames="OrderDetailId" ItemType="FrontierAg.Models.OrderDetail" SelectMethod="AllDetailsGrid_GetData" AutoGenerateColumns="false" CssClass="table table-striped table-bordered"
        AllowSorting="true" AllowPaging="true" PageSize="17">
        <Columns>      
            <asp:DynamicField DataField="ProductId" HeaderText="Product ID" />
            <asp:DynamicField DataField="OrderId" HeaderText="Order ID" />
           <asp:TemplateField HeaderText="Product Name">
              <ItemTemplate>
                <asp:Label id="ProductNo" Text="<%# Item.Product.ProductNo %>" runat="server" />
              </ItemTemplate>
            </asp:TemplateField> 
            <asp:TemplateField HeaderText="Product Name">
              <ItemTemplate>
                <asp:Label id="ProductName" Text="<%# Item.Product.ProductName %>" runat="server" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:DynamicField DataField="Quantity" HeaderText="Quantity" />
            <asp:DynamicField DataField="QtyShipped" HeaderText="QtyShipped" /> 
            <asp:TemplateField HeaderText="Qty Remaining" ItemStyle-CssClass="myGridStyle">
              <ItemTemplate >
                <asp:Label Text="<%# Item.Quantity - Item.QtyShipped - Item.QtyCancelled %>"  runat="server"/>
              </ItemTemplate>
            </asp:TemplateField>  
            <asp:DynamicField DataField="QtyCancelled" HeaderText="QtyCancelled" />
             
            <asp:DynamicField DataField="UnitPrice" HeaderText="UnitPrice" />
            <asp:DynamicField DataField="PriceOverride" HeaderText="PriceOverride" />                         
            <asp:DynamicField DataField="Comment" HeaderText="Comment" />
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
