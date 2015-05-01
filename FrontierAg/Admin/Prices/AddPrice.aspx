<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPrice.aspx.cs" Inherits="FrontierAg.Admin.Prices.AddPrice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ValidationSummary runat="server" ShowModelStateErrors="true" />
<asp:FormView runat="server" ID="addPriceForm"
    ItemType="FrontierAg.Models.Price" 
    InsertMethod="addPriceForm_InsertItem" DefaultMode="Insert"
    RenderOuterTable="false" OnItemInserted="addPriceForm_ItemInserted">
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
