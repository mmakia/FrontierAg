<%@ Page Title="ProductList" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="FrontierAg.Products.Default" %>
<%@ Register TagPrefix="FriendlyUrls" Namespace="Microsoft.AspNet.FriendlyUrls" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h3>Products List</h3>
    <p>
        <asp:HyperLink runat="server" NavigateUrl="~/Admin/Products/AddProduct" Text="Create new" />
    </p>
    <div>
        <asp:ValidationSummary ShowModelStateErrors="true" runat="server" />
        <asp:GridView runat="server" ID="ProductsGrid"
        ItemType="FrontierAg.Models.Product" DataKeyNames="ProductId" AutoGenerateEditButton="true"
        SelectMethod="ProductsGrid_GetData" UpdateMethod="ProductsGrid_UpdateItem" CssClass="table table-striped table-bordered" EnableModelValidation="true"
        AutoGenerateColumns="false" AllowPaging="true" PageSize="40">
        <Columns>
            <asp:DynamicField DataField="ProductId" HeaderText="ID" ReadOnly="true"/>
            <asp:DynamicField DataField="ProductNo" ReadOnly="true"/>
            <asp:DynamicField DataField="ProductName" />                          
            <asp:DynamicField DataField="Category" HeaderText="Category Name"/>                
            <asp:HyperLinkField Text="Prices" DataNavigateUrlFormatString="~/Admin/Prices/Default/{0}" DataNavigateUrlFields="ProductId" /> 
            <asp:HyperLinkField Text="Packaging Charges" DataNavigateUrlFormatString="~/Admin/PackCharges/Default/{0}" DataNavigateUrlFields="ProductId" />      
        </Columns>
    </asp:GridView>
        <div class="row">
					  &nbsp;
					</div>
					<div class="form-group">
						<div>
							<asp:button id="backButton" runat="server" text="Back"  OnClientClick="JavaScript:window.history.back(1);return false;" CssClass="btn btn-warning" />
						</div>
					</div>
    </div>
</asp:Content>

