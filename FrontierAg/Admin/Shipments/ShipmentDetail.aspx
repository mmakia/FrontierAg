<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShipmentDetail.aspx.cs" Inherits="FrontierAg.Admin.Shipments.ShipmentDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ShipmentDetailsTitle" runat="server" class="ContentHead"><h3>Shipment Details</h3></div>
    <asp:GridView ID="ShipmentDetailsList" runat="server" AutoGenerateColumns="False" ItemType="FrontierAg.Models.ShipmentDetail" DataKeyNames="ShipmentDetailId" SelectMethod="ShipmentDetailsList_GetData" UpdateMethod="ShipmentDetailsList_UpdateItem"    
    AutoGenerateEditButton="False" CssClass="table table-striped table-bordered" EnableModelValidation="true" AllowSorting="true" AllowPaging="true" PageSize="10">
        <Columns>
            <asp:DynamicField DataField="ShipmentDetailId" HeaderText="ID" ReadOnly="true"/>  
            <asp:DynamicField DataField="ShipmentId" HeaderText="ShipmentID" ReadOnly="true"/>  
            <asp:DynamicField DataField="ProductId" HeaderText="ProductID" ReadOnly="true"/>  
            <asp:DynamicField DataField="ProductNo" HeaderText="ProductNo" ReadOnly="true"/>  
            <asp:DynamicField DataField="ProductName" HeaderText="ProductName" ReadOnly="true"/>  
            <asp:DynamicField DataField="Qty" HeaderText="QTY" ReadOnly="true"/>  
            <asp:DynamicField DataField="UnitString" HeaderText="Unit" ReadOnly="true"/>              
            <asp:DynamicField DataField="QtyShipped" HeaderText="Shipped" ReadOnly="true"/> 
            <asp:DynamicField DataField="QtyShipping" HeaderText="Shipping" ReadOnly="true"/>            
            <asp:DynamicField DataField="QtyCancelled" HeaderText="Cancelled" ReadOnly="true"/> 
             <asp:DynamicField DataField="Comment" HeaderText="Comment" /> 
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
