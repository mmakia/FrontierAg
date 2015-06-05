<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShipmentDetail.aspx.cs" Inherits="FrontierAg.Admin.Shipments.ShipmentDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#CategoryMenu').hide();
        });
    </script>
    <div id="PackingSliptitle" runat="server" class="ContentHead"><h3>Frontier Agricultural Sciences</h3></div>    
    <div id="ShipmentsTitle" runat="server" class="ContentHead"><h3>Packing Slip</h3></div>    
    <asp:GridView ID="ShipmentsList" runat="server" AutoGenerateColumns="False" ItemType="FrontierAg.Models.Shipment" DataKeyNames="ShipmentId" SelectMethod="ShipmentList_GetData" UpdateMethod="ShipmentList_UpdateItem"     
    AutoGenerateEditButton="False" CssClass="table table-striped table-bordered" EnableModelValidation="true">
        <Columns>
            <%--<asp:DynamicField DataField="ShipmentId" HeaderText="ID" ReadOnly="true"/>  --%>
            <asp:BoundField DataField="OrderId" HeaderText="OrderID" ReadOnly="true"/>             
            <asp:TemplateField HeaderText="Order Date">            
                <ItemTemplate>                    
                    <%#: Item.Order.OrderDate%>
                </ItemTemplate>        
            </asp:TemplateField>               
            <asp:BoundField DataField="Comment" HeaderText="Note" />            
            </Columns>
        </asp:GridView>     

    <div id="Div1" runat="server" class="ContentHead"><h4>Shipping To</h4></div>
    <asp:GridView runat="server" ID="ShippingsGrid"
        ItemType="FrontierAg.Models.Shipping" DataKeyNames="ShippingId" AutoGenerateEditButton="false" UpdateMethod="ShippingsGrid_UpdateItem" 
        SelectMethod="ShippingsGrid_GetData"  CssClass="table table-striped table-bordered" EnableModelValidation="true"
        AutoGenerateColumns="false" >
        <Columns>
            <%--<asp:TemplateField HeaderText="Contact ID">
              <ItemTemplate>
                <asp:Label Text="<%# Item.Contact.ContactId %>" 
                    runat="server" />
              </ItemTemplate>
            </asp:TemplateField>--%>  
            <%--<asp:DynamicField DataField="ShippingId" ReadOnly="true" />--%>
            <asp:BoundField DataField="Company" HeaderText ="Company"/>
            <asp:BoundField DataField="FName"  HeaderText="FName"/>
            <asp:BoundField DataField="LName" HeaderText ="LName"/>
            <%--<asp:BoundField DataField="Other1"  HeaderText="Other1"/>
            <asp:BoundField DataField="Other2"  HeaderText="Other2"/>--%>
            <asp:BoundField DataField="Address1" HeaderText="Address1" />
            <asp:BoundField DataField="Address2" HeaderText="Address2"/>
            <asp:BoundField DataField="City" HeaderText="City"/>
            <asp:BoundField DataField="State" HeaderText="State"/>                 
            <asp:BoundField DataField="PostalCode" HeaderText="PostalCode"/>            
        </Columns>
    </asp:GridView>

    <div id="ShipmentDetailsTitle" runat="server" class="ContentHead"><h4>Shipment Details</h4></div>
    <asp:GridView ID="ShipmentDetailsList" runat="server" AutoGenerateColumns="False" ItemType="FrontierAg.Models.ShipmentDetail" DataKeyNames="ShipmentDetailId" SelectMethod="ShipmentDetailsList_GetData"    
     CssClass="table table-striped table-bordered" EnableModelValidation="true" >
        <Columns>            
            <asp:BoundField DataField="ProductNo" HeaderText="Product#" ReadOnly="true"/>  
            <asp:BoundField DataField="ProductName" HeaderText="ProductName"  ReadOnly="true"/>  
            <asp:BoundField DataField="Qty" HeaderText="Ordered" ReadOnly="true"/>  
            <asp:BoundField DataField="UnitString" HeaderText="Unit" ReadOnly="true"/>              
            <asp:BoundField DataField="QtyShipped" HeaderText="Shipped" ReadOnly="true"/> 
            <asp:BoundField DataField="QtyShipping" HeaderText="Shipping" ReadOnly="true"/>            
            <asp:BoundField DataField="QtyCancelled" HeaderText="Cancelled" ReadOnly="true"/> 
             <asp:BoundField DataField="Comment" HeaderText="Note" /> 
            </Columns>
        </asp:GridView>   
	
</asp:Content>
