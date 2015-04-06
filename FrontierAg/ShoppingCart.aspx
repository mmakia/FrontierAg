<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="FrontierAg.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
                    <asp:TextBox ID="PurchaseQuantity" Width="40" runat="server" Text="<%#: Item.Quantity %>"></asp:TextBox> 
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
        <p></p>
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
        
          <asp:ImageButton ID="CheckoutImageBtn" runat="server" 
                      ImageUrl="http://www.inmotionhosting.com/support/images/stories/icons/ecommerce/checkout-dark.png" 
                      Width="145" AlternateText="Check out with PayPal" 
                      OnClick="CheckoutBtn_Click" 
                      BackColor="Transparent" BorderWidth="0" />

      </td>
    </tr>
    </table>

</asp:Content>