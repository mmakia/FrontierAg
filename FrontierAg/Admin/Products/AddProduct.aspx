<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="FrontierAg.Admin.Products.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ValidationSummary runat="server" ShowModelStateErrors="true" />
<asp:FormView runat="server" ID="addProductForm"
    ItemType="FrontierAg.Models.Product" 
    InsertMethod="addProductForm_InsertItem" DefaultMode="Insert"
    RenderOuterTable="true" OnItemInserted="addProductForm_ItemInserted">
    <InsertItemTemplate>
        <fieldset>
            <ol>
                <asp:DynamicEntity runat="server" Mode="Insert" />
            </ol>
            <asp:Button runat="server" Text="Insert" CommandName="Insert" />
            <asp:Button runat="server" Text="Cancel" CausesValidation="false" OnClick="CancelBtn_Click" />
        </fieldset>
    </InsertItemTemplate>
</asp:FormView>
</asp:Content>
