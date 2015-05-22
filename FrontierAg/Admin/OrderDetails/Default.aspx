<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FrontierAg.Admin.OrderDetails.Default" %>
<%@ Import Namespace = "System.Data.Entity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script type="text/javascript">
        $(function () {            
            validate();            
        });
        
        //JS code to be executed after partial postback due to updatepanel
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            //$(alert("Price Changed"))
            validate();               
        }); 

        function validate() {
            var button = document.getElementById("UpdateBtn");

            $('.form-control.InputInt').on('input', function () {
                var input = $(this);
                var re = /^-?\d\d*$/;
                var is_int = re.test(input.val());
                if (is_int) {
                    $(".error_msg").html("")
                    input.removeClass("invalid").addClass("valid")
                    $('.form-control.InputInt').on('focusout', function () {
                        button.click();
                    });
                }
                else {
                    $(".error_msg").html("Please enter a number")
                    input.removeClass("valid").addClass("invalid");
                }
            });
            
            $('.InputCmt').on('focusout', function () {
                button.click();
            });
        }        
    </script>        
            <div id="OpenOrderTitle" runat="server" class="ContentHead"><h3>Order</h3></div>
            <asp:GridView ID="OpenOrdersList2" runat="server" AutoGenerateColumns="False" ItemType="FrontierAg.Models.Order" DataKeyNames="OrderId" SelectMethod="OpenOrdersList_GetData" UpdateMethod="OpenOrders_UpdateItem"     
    AutoGenerateEditButton="True" CssClass="table table-striped table-bordered mytable" EnableModelValidation="true">
        <Columns>                  
            <%--<asp:DynamicField DataField="OrderId" HeaderText="ID" ReadOnly="true"/>        --%>
            <asp:DynamicField DataField="OrderDate" HeaderText="Order Date" ReadOnly="true"/>            
            <asp:DynamicField DataField="Status" HeaderText="Status" />   
            <asp:DynamicField DataField="Tracking" HeaderText="Tracking #" /> 
            <asp:DynamicField DataField="Comment" HeaderText="Comment" />         
            <asp:DynamicField DataField="ShipCharge" HeaderText="Shipping" /> 
            <asp:DynamicField DataField="Total" HeaderText="Total" ReadOnly="true"/>                      
        </Columns>     
                <EditRowStyle CssClass="GridViewEditRow" />   
    </asp:GridView>
    <div id="Div1" runat="server" class="ContentHead"><h4>Shipping To</h4></div>
    <asp:GridView runat="server" ID="ShippingsGrid"
        ItemType="FrontierAg.Models.Shipping" DataKeyNames="ShippingId" AutoGenerateEditButton="true" UpdateMethod="ShippingsGrid_UpdateItem" 
        SelectMethod="ShippingsGrid_GetData"  CssClass="table table-striped table-bordered" EnableModelValidation="true"
        AutoGenerateColumns="false" >
        <Columns>
            <asp:TemplateField HeaderText="Contact ID">
              <ItemTemplate>
                <asp:Label Text="<%# Item.Contact.ContactId %>" 
                    runat="server" />
              </ItemTemplate>
            </asp:TemplateField>  
            <%--<asp:DynamicField DataField="ShippingId" ReadOnly="true" />--%>
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
            <asp:DynamicField DataField="Country" />  
            <asp:DynamicField DataField="PPhone"  />                        
            <%--<asp:DynamicField DataField="DateCreated" ReadOnly="true"/> --%>           
        </Columns>
    </asp:GridView>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate> 
    <div id="OperOrderTitle" runat="server" class="ContentHead"><h4>Order Items</h4></div>
    <asp:GridView ID="OrderDetailList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        ItemType="FrontierAg.Models.OrderDetail" SelectMethod="OpenOrderList_GetData" DataKeyNames="OrderDetailId" 
        CssClass="table table-striped table-bordered" EnableModelValidation="true" >

        <Columns>      
            <%--<asp:BoundField DataField="ProductId" HeaderText="Product ID" />   --%>

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

        <asp:TemplateField HeaderText="Qty Shipped">
              <ItemTemplate>
                <asp:TextBox id="QtyShippedBx" CSSClass="form-control InputInt" Text="<%# Item.QtyShipped %>" runat="server" width="50"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" ControlToValidate="QtyShippedBx"></asp:RequiredFieldValidator> 
                <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="QtyShippedBx" />                     
              </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Qty Remaining" ItemStyle-CssClass="myGridStyle">
              <ItemTemplate >
                <asp:Label Text="<%# Item.Quantity - Item.QtyShipped - Item.QtyCancelled %>"  runat="server"/>
              </ItemTemplate>
        </asp:TemplateField>              

        <asp:TemplateField HeaderText="Qty Cancelled">
              <ItemTemplate>
                <asp:TextBox id="QtyCancelledBx" CSSClass="form-control InputInt" Text="<%# Item.QtyCancelled %>" runat="server" width="50"/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="" ControlToValidate="QtyCancelledBx"></asp:RequiredFieldValidator> 
                <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="QtyCancelledBx" />                     
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
    <div>        
		<asp:button id="Button1" runat="server" text="Back" OnClientClick="JavaScript:window.history.back(1);return false;" CssClass="btn btn-warning" />						
        <asp:Button ID="UpdateBtn" runat="server" Text="Update" OnClick="UpdateBtn_Click" CssClass="btn btn-warning" ClientIDMode="Static" style="display:none"/>         
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
