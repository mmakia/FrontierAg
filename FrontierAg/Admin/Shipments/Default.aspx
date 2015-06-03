<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FrontierAg.Admin.Shipments.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ShipmentsTitle" runat="server" class="ContentHead"><h3>Shipments</h3></div>
    <asp:GridView ID="ShipmentsList" runat="server" AutoGenerateColumns="False" ItemType="FrontierAg.Models.Shipment" DataKeyNames="ShipmentId" SelectMethod="ShipmentList_GetData" UpdateMethod="ShipmentList_UpdateItem"     
    AutoGenerateEditButton="True" CssClass="table table-striped table-bordered" EnableModelValidation="true" AllowSorting="true" AllowPaging="true" PageSize="10">
        <Columns>
            <asp:DynamicField DataField="ShipmentId" HeaderText="ID" ReadOnly="true"/>  
            <asp:DynamicField DataField="OrderId" HeaderText="OrderID" ReadOnly="true"/>             
            <asp:DynamicField DataField="Tracking" HeaderText="Tracking" /> 
            <asp:DynamicField DataField="ShipCharge" HeaderText="ShipCharge" /> 
            <asp:DynamicField DataField="Comment" HeaderText="Comment" /> 
            <asp:DynamicField DataField="Total" HeaderText="Total" ReadOnly="true"/>
            <asp:HyperLinkField Text="Details" DataNavigateUrlFormatString="~/Admin/Shipments/ShipmentDetail/{0}" DataNavigateUrlFields="ShipmentId" />
            </Columns>
        </asp:GridView>      
    <div class="row">
					  &nbsp;
					</div>
					<div class="form-group">
						<div >
							<asp:button id="backButton" runat="server" text="Back" OnClientClick="JavaScript:window.history.back(1);return false;" CssClass="btn btn-warning" />
						</div>
	</div
</asp:Content>
