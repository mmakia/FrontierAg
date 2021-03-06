﻿<%@ Page Title="PriceList" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="FrontierAg.Admin.Prices.Default" %>
<%@ Register TagPrefix="FriendlyUrls" Namespace="Microsoft.AspNet.FriendlyUrls" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h3>Prices List</h3>
    <p>
        <asp:HyperLink runat="server" NavigateUrl="~/Admin/Prices/AddPrice" Text="Create new" />
    </p>
    <div>
        <asp:ValidationSummary ShowModelStateErrors="true" runat="server" />
        <asp:GridView runat="server" ID="PricesGrid"
        ItemType="FrontierAg.Models.Price" DataKeyNames="PriceId" AutoGenerateEditButton="true"
        SelectMethod="PricesGrid_GetData" UpdateMethod="PricesGrid_UpdateItem" CssClass="table table-striped table-bordered" EnableModelValidation="true"
        AutoGenerateColumns="false" DeleteMethod="PricesGrid_DeleteItem" AutoGenerateDeleteButton="true" AllowSorting="true" AllowPaging="true" PageSize="17">
        <Columns>
            <asp:DynamicField DataField="PriceId" ReadOnly="true"/>
            <asp:TemplateField HeaderText="Product No">
              <ItemTemplate>
                <asp:Label Text="<%# Item.Product.ProductNo %>" 
                    runat="server" />
              </ItemTemplate>
            </asp:TemplateField>            
            <asp:DynamicField DataField="From" />
            <asp:DynamicField DataField="To" />
            <asp:DynamicField DataField="PriceNumber" /> 
            <asp:DynamicField DataField="Unit" />      
            <asp:TemplateField HeaderText="Product Name">
              <ItemTemplate>
                <asp:Label Text="<%# Item.Product.ProductName %>" 
                    runat="server" />
              </ItemTemplate>
            </asp:TemplateField>           
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

