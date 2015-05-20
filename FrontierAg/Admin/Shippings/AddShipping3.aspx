<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddShipping3.aspx.cs" Inherits="FrontierAg.Admin.Shippings.AddShipping3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h3>Add Shipping Address</h3>
    <asp:ValidationSummary runat="server" ShowModelStateErrors="true" />
<asp:FormView runat="server" ID="addShippingForm"
    ItemType="FrontierAg.Models.Shipping" 
    InsertMethod="addShippingForm_InsertItem" DefaultMode="Insert"
    RenderOuterTable="True" OnItemInserted="addShippingForm_ItemInserted" CssClass="table table-striped table-bordered">
    <ItemTemplate>
            <fieldset>
                 <ul>
                     <li>
                         <asp:Label ID="LabelAddress1" runat="server">Address1:</asp:Label>
                     </li>
                     <li>
                         <asp:Label ID="Label1" runat="server">Address2:</asp:Label>
                     </li>
                     <li>
                         <asp:Label ID="Label2" runat="server">City:</asp:Label>
                     </li>
                     <li>
                         <asp:Label ID="Label3" runat="server">State:</asp:Label>
                     </li>
                     <li>
                         <asp:Label ID="Label4" runat="server">Country:</asp:Label>
                     </li>
                 </ul>
            </fieldset>
        </ItemTemplate>
    <InsertItemTemplate>        
            <fieldset>
                <ul>
                    <li>

                    </li>
                </ul>
            
    </InsertItemTemplate>
</asp:FormView>
</asp:Content>
