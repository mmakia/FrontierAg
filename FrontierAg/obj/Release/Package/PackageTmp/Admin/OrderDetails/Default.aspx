<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FrontierAg.Admin.OrderDetails.Default" %>
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
        <asp:DynamicField DataField="OrderId" HeaderText="ID" ReadOnly="true"/>        
        <asp:DynamicField DataField="OrderDate" HeaderText="Order Date" ReadOnly="true"/>              
                     
        <asp:TemplateField HeaderText="Shipping To">
            <ItemTemplate>
                <asp:HyperLink runat="server" NavigateUrl='<%# Microsoft.AspNet.FriendlyUrls.FriendlyUrl.Href("~/Admin/Contacts/Details", Item.ContactId) %>' Text="<%#: Item.Contact.Company %>" />
            </ItemTemplate>
        </asp:TemplateField>        

        <asp:TemplateField HeaderText="Address">
            <ItemTemplate>
                <asp:HyperLink runat="server" NavigateUrl='<%# Microsoft.AspNet.FriendlyUrls.FriendlyUrl.Href("~/Admin/Shippings/Default", Item.ShippingId) %>' Text="<%#: Item.Shipping.City %>" />
            </ItemTemplate>
        </asp:TemplateField>
            <asp:DynamicField DataField="ShipCharge" HeaderText="Shipping Charges" />
            <asp:DynamicField DataField="Total" HeaderText="Total" ReadOnly="true"/>             
            <asp:DynamicField DataField="Comment" HeaderText="Comment" />          
            <asp:DynamicField DataField="Status" HeaderText="Status" />                          
        </Columns>     
                <EditRowStyle CssClass="GridViewEditRow" />   
    </asp:GridView>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate> 
    <div id="OperOrderTitle" runat="server" class="ContentHead"><h3>Order Items</h3></div>
    <asp:GridView ID="OrderDetailList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        ItemType="FrontierAg.Models.OrderDetail" SelectMethod="OpenOrderList_GetData" DataKeyNames="OrderDetailId" 
        CssClass="table table-striped table-bordered" EnableModelValidation="true" >

        <Columns>      
            <asp:BoundField DataField="ProductId" HeaderText="Product ID" />   

        <asp:TemplateField HeaderText="Product Name">
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

        <asp:TemplateField HeaderText="Comment">
              <ItemTemplate>
                <asp:TextBox id="CommentBx" Text="<%# Item.Comment %>" runat="server" CSSClass="form-control InputCmt" />                               
              </ItemTemplate>
        </asp:TemplateField>
            
        <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" />

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
