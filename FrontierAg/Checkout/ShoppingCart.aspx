<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="FrontierAg.ShoppingCart" %>
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

            $('.form-control.InputQty').on('input', function () {
                var input = $(this);
                var re = /^-?\d\d*$/;
                var is_int = re.test(input.val());
                if (is_int) {
                    $(".error_msg").html("")
                    input.removeClass("invalid").addClass("valid")
                    $('.form-control.InputQty').on('focusout', function () {
                        button.click();
                    });
                }
                else {
                    $(".error_msg").html("Please enter a number")
                    input.removeClass("valid").addClass("invalid");
                }
            });

            $('.form-control.InputPrice').on('focusout', function () {
                var input = $(this);
                var re = /^\d+(\.\d\d)?$/;
                var is_price = re.test(input.val());
                if (is_price) {
                    $(".error_msg").html("")
                    input.removeClass("invalid").addClass("valid")

                    //$('#PriceHiddenBox').val(this.value)                    
                    //var x = $(this).closest('tr').children('td:eq(0)').text();
                    //$('#ProductIdHiddenBox').val(x)                    
                    button.click();
                }
                else {
                    $(".error_msg").html("Please enter a price")
                    input.removeClass("valid").addClass("invalid");
                }
            });

            $('.myCheckBox').on('click', function () {
                button.click();
            });
        }        
    </script>    
    

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>                 
    <div id="ShoppingCartTitle" runat="server" class="ContentHead"><h3>Shopping Cart</h3></div>

    <asp:GridView ID="CartList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        ItemType="FrontierAg.Models.CartItem" SelectMethod="GetShoppingCartItems" 
        CssClass="table table-striped table-bordered"  >
        <Columns>
            
        <asp:BoundField DataField="ProductID" HeaderText="ID" />  
               
        <asp:TemplateField HeaderText="Product No.">            
                <ItemTemplate>                    
                    <%#: Item.Product.ProductNo  %>
                </ItemTemplate>        
        </asp:TemplateField>    

        <asp:BoundField DataField="Product.ProductName" HeaderText="Name" />  
            
        <asp:TemplateField   HeaderText="Quantity">             
                <ItemTemplate>
                    <asp:TextBox ID="PurchaseQuantity" CSSClass="form-control InputQty" Width="70" runat="server" Text="<%#: Item.Quantity %>" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" ControlToValidate="PurchaseQuantity"></asp:RequiredFieldValidator> 
                    <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="PurchaseQuantity" />                  
                </ItemTemplate>            
        </asp:TemplateField> 
                  
        <asp:BoundField DataField="Unit" HeaderText="Unit" />   

        <asp:BoundField DataField="OriginalPrice" HeaderText="Price" />        
              
        <asp:TemplateField HeaderText="Price Override">
            <ItemTemplate>
                <asp:TextBox ID="PriceBx" CSSClass="form-control InputPrice" Width="100" runat="server" Text="<%#: Item.ItemPrice %>" ></asp:TextBox>               
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="" ControlToValidate="PriceBx"></asp:RequiredFieldValidator>               
                <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Currency" ControlToValidate="PriceBx" />    
            </ItemTemplate>
        </asp:TemplateField>          

        <%--<asp:BoundField DataField="Charge" HeaderText="Packaging" />--%>

        <asp:TemplateField HeaderText="Item Total">            
                <ItemTemplate>                    
                    <%#: Item.Quantity *  Item.ItemPrice  %>
                </ItemTemplate>        
        </asp:TemplateField> 

        <asp:TemplateField HeaderText="Remove Item">            
                <ItemTemplate>
                    <asp:CheckBox id="Remove" runat="server" CssClass="myCheckBox"></asp:CheckBox>
                </ItemTemplate>        
        </asp:TemplateField>    
            
        </Columns>        
    </asp:GridView>
    <div>
        <p>&nbsp;</p>
        <strong>
            <asp:Label ID="LabelTotalText" runat="server" Text="SubTotal: "></asp:Label>
            <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
        </strong> 
    </div>
    <br />

    <table> 
    <tr>
      <td >
        <asp:Button ID="UpdateBtn" runat="server" Text="Update" OnClick="UpdateBtn_Click" CssClass="btn btn-warning" ClientIDMode="Static" style="display:none"/>          
      </td>
      <td >
        &nbsp;<asp:Button ID="CheckoutBtn" runat="server" Text="Start Checkout" OnClick="CheckoutBtn_Click" CssClass="btn btn-warning" />
      </td>
        <td>
            <span class="error_msg" style="color: red; margin-left: 10px;" ></span>
        </td>
    </tr>
    </table>
            
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


