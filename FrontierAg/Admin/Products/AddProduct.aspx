<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="FrontierAg.Admin.Products.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Add Product</h3>
    <asp:ValidationSummary runat="server" ShowModelStateErrors="true" />
<asp:FormView runat="server" ID="addProductForm"  ItemType="FrontierAg.Models.Product"    InsertMethod="addProductForm_InsertItem" DefaultMode="Insert"
        RenderOuterTable="true" OnItemInserted="addProductForm_ItemInserted" CssClass="table table-striped table-bordered" >
    <InsertItemTemplate>
        <fieldset>
            <ol>

                <asp:DynamicEntity runat="server" Mode="Insert" />
            </ol>
            <asp:Button runat="server" Text="Insert" CommandName="Insert" CssClass="btn btn-warning" />            
			<asp:button id="backButton" runat="server" text="Back" OnClientClick="JavaScript:window.history.back(1);return false;" CssClass="btn btn-warning" />
        </fieldset>
    </InsertItemTemplate>
</asp:FormView>
</asp:Content>
