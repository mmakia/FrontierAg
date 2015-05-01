<%@ Page Title="ProductList" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="FrontierAg.Products.Default" %>
<%@ Register TagPrefix="FriendlyUrls" Namespace="Microsoft.AspNet.FriendlyUrls" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h2>Products List</h2>
    <p>
        <asp:HyperLink runat="server" NavigateUrl="~/Admin/Products/AddProduct" Text="Create new" />
    </p>
    <div>
        <asp:ValidationSummary ShowModelStateErrors="true" runat="server" />
        <asp:GridView runat="server" ID="ProductsGrid"
        ItemType="FrontierAg.Models.Product" DataKeyNames="ProductId" 
        SelectMethod="ProductsGrid_GetData" UpdateMethod="ProductsGrid_UpdateItem" CssClass="table table-striped table-bordered" EnableModelValidation="true"
        AutoGenerateColumns="false">
        <Columns>
            <asp:DynamicField DataField="ProductId" ReadOnly="true"/>
            <asp:DynamicField DataField="ProductNo" />
            <asp:DynamicField DataField="ProductName" />
            <asp:DynamicField DataField="Description" />          
            <asp:TemplateField HeaderText="Category name">
              <ItemTemplate>
                <asp:Label Text="<%# Item.Category.CategoryName %>" 
                    runat="server" />
              </ItemTemplate>
            </asp:TemplateField>    
            <asp:DynamicField DataField="DateCreated" ReadOnly="false"/>     
            <asp:HyperLinkField Text="Prices" DataNavigateUrlFormatString="~/Admin/Prices/Default.aspx?ProductId={0}" DataNavigateUrlFields="ProductId" />      
        </Columns>
    </asp:GridView>
        <div class="row">
					  &nbsp;
					</div>
					<div class="form-group">
						<div>
							<asp:button id="backButton" runat="server" text="Back" OnClientClick="JavaScript:window.history.back(1);return false;" CssClass="btn btn-warning" />
						</div>
					</div>
    </div>
</asp:Content>

