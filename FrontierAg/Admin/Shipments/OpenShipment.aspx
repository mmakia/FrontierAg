<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OpenShipment.aspx.cs" Inherits="FrontierAg.Admin.Shipments.OpenShipment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ShipmentsTitle" runat="server" class="ContentHead">
        <h3>Open Shipment(s)</h3>
    </div>
    <asp:GridView ID="ShipmentsList" runat="server" AutoGenerateColumns="False" ItemType="FrontierAg.Models.Shipment" DataKeyNames="ShipmentId" SelectMethod="ShipmentList_GetData" UpdateMethod="ShipmentList_UpdateItem"
        AutoGenerateEditButton="True" CssClass="table table-striped table-bordered" EnableModelValidation="true" AllowSorting="true" AllowPaging="true" PageSize="40">
        <Columns>
            <%--<asp:DynamicField DataField="ShipmentId" HeaderText="ID" ReadOnly="true" />--%>

            <asp:TemplateField HeaderText="OrderId">
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%# Microsoft.AspNet.FriendlyUrls.FriendlyUrl.Href("~/Admin/Orders/OpenOrder", Item.OrderId) %>' Text="<%#: Item.OrderId  %>" />
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
    
    <div class="row">
        &nbsp;
    </div>
    <div class="form-group">
        <div>
            <asp:Button ID="backButton" runat="server" Text="Back" OnClientClick="JavaScript:window.history.back(1);return false;" CssClass="btn btn-warning" />
        </div>
    </div>
</asp:Content>
