<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FrontierAg.Admin.OrderDetails.Default" %>
<%@ Import Namespace = "System.Data.Entity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script type="text/javascript">         
        $(function () {            
            validate();
            ValidatePFee();
        });
        
        //JS code to be executed after partial postback due to updatepanel
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            //$(alert("Price Changed"))
            validate();
            ValidatePFee();
        }); 

        function validate() {
            //var button = document.getElementById("UpdateBtn");
            //$(alert("running validate"));
            $('.form-control.InputInt').on('input', function () {
                var input = $('.form-control.InputInt');
                var reInt = /^-?\d\d*$/;
                var is_int = reInt.test(input.val());                
                if (is_int) {
                    $(".error_msg").html("");
                    input.removeClass("invalid").addClass("valid");
                    return true;
                    //$('.form-control.InputInt').on('focusout', function () {
                    //    button.click();
                    //});
                }
                else {
                    $(".error_msg").html("Please enter a valid number");
                    input.removeClass("valid").addClass("invalid");
                    //return false;
                }
            });
            
            //$('.InputCmt').on('focusout', function () {
            //    button.click();
            //});
        }
        function ValidatePFee() {
            $('.form-control.PFee').on('input', function () {
                var input = $(this);
                var re = /^\d+(\.\d\d)?$/;
                var is_price = re.test(input.val());
                if (is_price) {
                    $(".error_msg").html("");
                    input.removeClass("invalid").addClass("valid");
                    //button.click();
                }
                else {
                    $(".error_msg").html("Please enter valid dollar amount");
                    input.removeClass("valid").addClass("invalid");
                }
            });
        }
    </script>        
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate> 
            <div id="Div2" runat="server" class="ContentHead"><h3>Order Processing</h3></div>

            <div id="OpenOrderTitle" runat="server" class="ContentHead"><h4>Order</h4></div>

            <asp:GridView ID="OpenOrdersList2" runat="server" AutoGenerateColumns="False" ItemType="FrontierAg.Models.Order" DataKeyNames="OrderId" SelectMethod="OpenOrdersList_GetData" UpdateMethod="OpenOrders_UpdateItem"     
    AutoGenerateEditButton="True" CssClass="table table-striped table-bordered " EnableModelValidation="true">
        <Columns>                  
            <asp:DynamicField DataField="OrderId" HeaderText="ID" ReadOnly="true"/>        
            <asp:DynamicField DataField="OrderDate" HeaderText="Order Date" ReadOnly="true"/>            
            <asp:DynamicField DataField="Status" HeaderText="Status" ReadOnly="true"/>   
            <%--<asp:DynamicField DataField="Tracking" HeaderText="Tracking #" /> --%>
            <asp:DynamicField DataField="Comment" HeaderText="Comment" />         
            <%--<asp:DynamicField DataField="ShipCharge" HeaderText="Shipping Total" /> --%>
            <asp:DynamicField DataField="Total" HeaderText="Total" ReadOnly="true"/>                      
        </Columns>     
                <EditRowStyle CssClass="GridViewEditRow" />  
            </asp:GridView>

    <div id="Div1" runat="server" class="ContentHead"><h4>Shipping To (Editable for multiple shipments, When each shipment is going to a different address)</h4></div>
    <asp:GridView runat="server" ID="ShippingsGrid"
        ItemType="FrontierAg.Models.Shipping" DataKeyNames="ShippingId" AutoGenerateEditButton="true" UpdateMethod="ShippingsGrid_UpdateItem" 
        SelectMethod="ShippingsGrid_GetData"  CssClass="table table-striped table-bordered" EnableModelValidation="true"
        AutoGenerateColumns="false" >
        <Columns>
            <%--<asp:TemplateField HeaderText="Contact ID">
              <ItemTemplate>
                <asp:Label Text="<%# Item.Contact.ContactId %>" 
                    runat="server" />
              </ItemTemplate>
            </asp:TemplateField>  
            <asp:DynamicField DataField="ShippingId" ReadOnly="true" />--%>
            <asp:DynamicField DataField="Company"  />
            <asp:DynamicField DataField="FName"  />
            <asp:DynamicField DataField="LName"  />
            <asp:DynamicField DataField="Other1"  />
            <asp:DynamicField DataField="Other2"  />
            <asp:DynamicField DataField="Address1"  />
            <asp:DynamicField DataField="Address2" />
            <asp:DynamicField DataField="City" />
            <asp:DynamicField DataField="State" />                 
            <asp:DynamicField DataField="PostalCode" />
        </Columns>
    </asp:GridView>
     
    <div id="OperOrderTitle" runat="server" class="ContentHead"><h4>Products</h4></div>
    <asp:GridView ID="OrderDetailList" runat="server" AutoGenerateColumns="False" ShowFooter="False" GridLines="Vertical" CellPadding="4"
        ItemType="FrontierAg.Models.OrderDetail" SelectMethod="OpenOrderList_GetData" DataKeyNames="OrderDetailId" 
        CssClass="table table-striped table-bordered" EnableModelValidation="true" >

        <Columns>      
            <asp:BoundField DataField="ProductId" HeaderText="ID" />   

        <asp:TemplateField HeaderText="Product No">
              <ItemTemplate>
                <asp:Label id="ProductNo" Text="<%# Item.Product.ProductNo %>" runat="server" />
              </ItemTemplate>
        </asp:TemplateField> 

        <asp:TemplateField HeaderText="Product Name">
              <ItemTemplate>
                <asp:Label id="ProductName" Text="<%# Item.Product.ProductName %>" runat="server" />
              </ItemTemplate>
        </asp:TemplateField> 
            
        <asp:BoundField DataField="Quantity" HeaderText="Quantity" ReadOnly="true"/>
        <asp:BoundField DataField="Unit" HeaderText="Unit" ReadOnly="true"/>
        <asp:BoundField DataField="QtyShipped" HeaderText="Shipped" ReadOnly="true"/>

        <asp:TemplateField HeaderText="Remaining" ItemStyle-CssClass="myGridStyle">
              <ItemTemplate >
                <asp:Label Text="<%# Item.Quantity - Item.QtyShipped - Item.QtyCancelled %>"  runat="server"/>
              </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Shipping">
              <ItemTemplate>
                <asp:TextBox id="QtyShippingBx" CSSClass="form-control InputInt" runat="server" width="50" Text="0"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" ControlToValidate="QtyShippingBx"></asp:RequiredFieldValidator> 
                <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="QtyShippingBx" />                     
              </ItemTemplate>
        </asp:TemplateField>
        
        <asp:BoundField DataField="QtyCancelled" HeaderText="Cancelled"/>        

        <asp:TemplateField HeaderText="Cancelling">
              <ItemTemplate>
                <asp:TextBox id="QtyCancellingBx" CSSClass="form-control InputInt" runat="server" width="50" Text="0"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="" ControlToValidate="QtyCancellingBx"></asp:RequiredFieldValidator> 
                <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="QtyCancellingBx" />   
              </ItemTemplate>
        </asp:TemplateField>

        <asp:BoundField DataField="PriceOverride" HeaderText="Price"/>
        <asp:TemplateField HeaderText="Comment">
              <ItemTemplate>
                <asp:TextBox id="CommentBx" Text="<%# Item.Comment %>" runat="server" CSSClass="form-control InputCmt" />                               
              </ItemTemplate>
        </asp:TemplateField>            
       </Columns>        
    </asp:GridView>
            
                <asp:Label ID="Label2" runat="server" Text="Processing Fee: " ></asp:Label>  
            
                <asp:TextBox ID="PFeeBox" runat="server" CSSClass="form-control PFee" Width="100" ClientIDMode="Static"></asp:TextBox>                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" ControlToValidate="PFeeBox"></asp:RequiredFieldValidator> 
                <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Currency" ControlToValidate="PFeeBox" />      
            &nbsp;
                <asp:Button Text="Hidden" ID="myHiddenBtn" runat="server" style="display:none" ClientIDMode="Static"/>       
           
    <div>        
		<asp:button id="Button1" runat="server" text="Back" OnClientClick="JavaScript:window.history.back(1);return false;" CssClass="btn btn-warning" />       
        <asp:Button ID="SvToShipment" runat="server" Text="Save To Shipments" OnClick="SvToShipment_Click" CssClass="btn btn-warning" ClientIDMode="Static" />                 
        <%--<asp:LinkButton ID="ShipmentsBtn" runat="server" Text="Order's Open Shipments" OnClick="ShipmentsBtn_Click" ClientIDMode="Static" />--%>
        <asp:Button ID="ShipmentsBtn" runat="server" Text="Order's Open Shipments" OnClick="ShipmentsBtn_Click" CssClass="btn btn-warning" ClientIDMode="Static" />
        <span><div class="error_msg" style="color: red; margin-left: 10px;" /></span>
    </div>           
      </ContentTemplate>
    </asp:UpdatePanel> 

    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="PleaseWait">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/PleaseWait.gif"/>
                Please Wait...
            </div>
        </ProgressTemplate>   
    </asp:UpdateProgress>  

          
</asp:Content>
