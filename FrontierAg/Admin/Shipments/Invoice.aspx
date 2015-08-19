<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="FrontierAg.Admin.Shipments.Invoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $('#CategoryMenu').hide();
        });
    </script>
    <div id="ShipmentsTitle" runat="server" class="ContentHead"><h3>Invoice</h3></div>    
    
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
            <asp:BoundField DataField="Country" HeaderText="Country"/>            
        </Columns>
    </asp:GridView>
    
    <div id="Div2" runat="server" class="ContentHead"><h4>Billing To</h4></div>
    <asp:GridView runat="server" ID="GridView1"
        ItemType="FrontierAg.Models.Shipping" DataKeyNames="ShippingId" AutoGenerateEditButton="false"  
        SelectMethod="GetBilling"  CssClass="table table-striped table-bordered" 
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
            <asp:BoundField DataField="Country" HeaderText="Country"/>            
        </Columns>
    </asp:GridView>
    
    <div id="Div4" runat="server" class="ContentHead"><h4>Order Info</h4></div>
    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" ItemType="FrontierAg.Models.Order" DataKeyNames="OrderId" SelectMethod="Order_GetData" 
         CssClass="table table-striped table-bordered" >
        <Columns>
            <asp:BoundField DataField="OrderId" HeaderText="OrderId"  />
            <asp:BoundField DataField="OrderDate" HeaderText="OrderDate"  />
            <asp:BoundField DataField="Payment" HeaderText="Payment"/>                     
            <asp:BoundField DataField="PaymentDate" HeaderText="PaymentDate" />
            <asp:BoundField DataField="Comment" HeaderText="Comment" />                    
        </Columns>        
    </asp:GridView>
    
    <div id="ShipmentDetailsTitle" runat="server" class="ContentHead"><h4>Shipment Products</h4></div>
    <asp:GridView ID="ShipmentDetailsList" runat="server" AutoGenerateColumns="False" ItemType="FrontierAg.Models.ShipmentDetail" DataKeyNames="ShipmentDetailId" SelectMethod="ShipmentDetailsList_GetData"    
     CssClass="table table-striped table-bordered" EnableModelValidation="true" >
        <Columns>            
            <asp:BoundField DataField="ProductNo" HeaderText="Product#" ReadOnly="true"/>  
            <asp:BoundField DataField="ProductName" HeaderText="ProductName"  ReadOnly="true"/>  
            <asp:BoundField DataField="Qty" HeaderText="Ordered" ReadOnly="true"/>  
            <asp:BoundField DataField="UnitString" HeaderText="Unit" ReadOnly="true"/>              
            <%--<asp:BoundField DataField="QtyShipped" HeaderText="Shipped" ReadOnly="true"/>--%> 
            <asp:BoundField DataField="QtyShipping" HeaderText="Shipping" ReadOnly="true"/>            
            <%--<asp:BoundField DataField="QtyCancelled" HeaderText="Cancelled" ReadOnly="true"/> --%>
            <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="true"/> 
            <asp:TemplateField HeaderText="Amount">
              <ItemTemplate>
                <asp:Label Text="<%# Item.Price * Item.QtyShipping %>" 
                    runat="server" />
              </ItemTemplate>
            </asp:TemplateField> 

             <%--<asp:BoundField DataField="Comment" HeaderText="Note" /> --%>
            </Columns>
        </asp:GridView>   
    
    <div id="Div3" runat="server" class="ContentHead"><h4>Other Details</h4></div>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" ItemType="FrontierAg.Models.Shipment" DataKeyNames="ShipmentId" SelectMethod="ShipmentList_GetData"  
        UpdateMethod="GridView2_UpdateItem" AutoGenerateEditButton="true" CssClass="table table-striped table-bordered" EnableModelValidation="true">
        <Columns>           
            <asp:DynamicField DataField="Action" HeaderText="Action" />
            <asp:BoundField DataField="PFee" HeaderText="ProcessFee" ReadOnly="true"/>
            <asp:BoundField DataField="ShipCharge" HeaderText="ShipCharge" ReadOnly="true"/>
            <asp:BoundField DataField="PCharges" HeaderText="PackCharges" ReadOnly="true"/>
            <asp:BoundField DataField="OtherCharges" HeaderText="Others(+/-)" ReadOnly="true"/>
            <asp:BoundField DataField="Total" HeaderText="ShipmentTotal"  ReadOnly="true"/>
            <asp:BoundField DataField="Tracking" HeaderText="Tracking" ReadOnly="true"/>
            <asp:BoundField DataField="ReadyDate2" HeaderText="ReadyDate" ReadOnly="true" />
            <asp:BoundField DataField="Comment" HeaderText="NoteOnPackSlip" ReadOnly="true"/>
                        
        </Columns>        
    </asp:GridView>
    
</asp:Content>
