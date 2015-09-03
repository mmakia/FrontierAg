<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FrontierAg.Admin.Shipments.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3>All Shipment(s)</h3>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged" EnableViewState="False" placeholder="Search by OrderId or SPACE to reset"></asp:TextBox>

    <h4>Filter by Action</h4>
    <asp:DropDownList runat="server" AutoPostBack="true" ID="myAction" class="form-control" Width="150">
        <asp:ListItem Text="All" Value="" />
        <asp:ListItem Text="Cancel" />
        <asp:ListItem Text="New" />
        <asp:ListItem Text="ToInvoice" />
        <asp:ListItem Text="Invoiced" />
        <asp:ListItem Text="Paid" />
    </asp:DropDownList>
    <br />
    <asp:GridView ID="ShipmentsList" runat="server" AutoGenerateColumns="False" ItemType="FrontierAg.Models.Shipment" DataKeyNames="ShipmentId" SelectMethod="ShipmentList_GetData" UpdateMethod="ShipmentList_UpdateItem"
        AutoGenerateEditButton="True" CssClass="table table-striped table-bordered" EnableModelValidation="true" AllowSorting="true" AllowPaging="true" PageSize="40">
        <Columns>
            <%--<asp:DynamicField DataField="ShipmentId" HeaderText="ID" ReadOnly="true" />--%>

            <asp:TemplateField HeaderText="OrderId">
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%# Microsoft.AspNet.FriendlyUrls.FriendlyUrl.Href("~/Admin/Orders/Default", Item.OrderId) %>' Text="<%#: Item.OrderId  %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:DynamicField DataField="PFee" HeaderText="ProcessFee" />
            <asp:DynamicField DataField="ShipCharge" HeaderText="ShipCharge" />
            <asp:DynamicField DataField="PCharges" HeaderText="PackCharges" />
            <asp:DynamicField DataField="OtherCharges" HeaderText="Others (+/-)" />
            <asp:DynamicField DataField="Total" HeaderText="ShipmentTotal" ReadOnly="true" />
            <asp:DynamicField DataField="Tracking" HeaderText="Tracking" />
            <asp:DynamicField DataField="ReadyDate2" HeaderText="ReadyDate" ReadOnly="true" />
            <asp:DynamicField DataField="Comment" HeaderText="NoteOnPackSlip" />
            <asp:DynamicField DataField="Action" HeaderText="Action" />
            <asp:HyperLinkField Text="Packing Slip" DataNavigateUrlFormatString="~/Admin/Shipments/ShipmentDetail/{0}" DataNavigateUrlFields="ShipmentId" />
            <asp:HyperLinkField Text="Invoice" DataNavigateUrlFormatString="~/Admin/Shipments/Invoice/{0}" DataNavigateUrlFields="ShipmentId" />
        </Columns>
    </asp:GridView>


    <div class="form-group">
        <div>
            <asp:Button ID="backButton" runat="server" Text="Back" OnClientClick="JavaScript:window.history.back(1);return false;" CssClass="btn btn-warning" />
        </div>
    </div>
</asp:Content>
