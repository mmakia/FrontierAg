<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="FrontierAg.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            $('.InputQty').on('input', function () {
                var input = $(this);
                var re = /^-?\d\d*$/;
                var is_int = re.test(input.val());                
                if (is_int) {                     
                    $(".error_msg").html("")
                    input.removeClass("invalid").addClass("valid");                    
                }
                else {
                    $(".error_msg").html("Please enter a number")
                    input.removeClass("valid").addClass("invalid");                    
                }
            });            
        });
    </script>    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>  
    <div id="ShoppingCartTitle" runat="server" class="ContentHead"><h1>Shopping Cart</h1></div>
    <asp:GridView ID="CartList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        ItemType="FrontierAg.Models.CartItem" SelectMethod="GetShoppingCartItems" 
        CssClass="table table-striped table-bordered" >   
        <Columns>
        <asp:BoundField DataField="ProductID" HeaderText="ID" SortExpression="ProductID" />        
        <asp:BoundField DataField="Product.ProductName" HeaderText="Name" />           
        <asp:TemplateField HeaderText="Price (each)">
              <ItemTemplate>
                <asp:Label Text="<%#:  Item.Product.Prices.Where(en => en.From <= Item.Quantity && en.To >= Item.Quantity).FirstOrDefault().PriceNumber %>" 
                    runat="server" />
              </ItemTemplate>
            </asp:TemplateField>

        <asp:TemplateField   HeaderText="Quantity">            
                <ItemTemplate>


                    <asp:TextBox ID="PurchaseQuantity" CSSClass="InputQty" Width="40" runat="server" Text="<%#: Item.Quantity %>" ClientIDMode="Static"></asp:TextBox>
                    <%--<span class="error" style="display: none;">Invalid input</span> --%>                                      
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="" ControlToValidate="PurchaseQuantity"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="" ControlToValidate="PurchaseQuantity" MaximumValue="1000" MinimumValue="1" Type="Integer"></asp:RangeValidator>
               
                    
                     </ItemTemplate>        
        </asp:TemplateField>    

        <asp:TemplateField HeaderText="Item Total">            
                <ItemTemplate>
                    
                    <%#: (Item.Quantity) *  Item.Product.Prices.Where(en => en.From <= Item.Quantity && en.To >= Item.Quantity).FirstOrDefault().PriceNumber%>

                </ItemTemplate>        
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Remove Item">            
                <ItemTemplate>
                    <asp:CheckBox id="Remove" runat="server"></asp:CheckBox>
                </ItemTemplate>        
        </asp:TemplateField>    
        </Columns>        
    </asp:GridView>
    <div>
        <p>&nbsp;</p>
        <strong>
            <asp:Label ID="LabelTotalText" runat="server" Text="Order Total: "></asp:Label>
            <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
        </strong> 
    </div>
    <br />

    <table> 
    <tr>
      <td>
        <asp:Button ID="UpdateBtn" runat="server" Text="Update" OnClick="UpdateBtn_Click" />
      </td>
      <td>
        &nbsp;<asp:Button ID="CheckoutBtn" runat="server" Text="Start Checkout" OnClick="CheckoutBtn_Click"  />
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


