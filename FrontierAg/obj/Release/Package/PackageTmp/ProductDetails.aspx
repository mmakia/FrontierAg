<%@ Page Title="Product Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
         CodeBehind="ProductDetails.aspx.cs" Inherits="FrontierAg.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="productDetail" runat="server" ItemType="FrontierAg.Models.Product" SelectMethod ="GetProduct" RenderOuterTable="false">
        <ItemTemplate>
            
            <table>
                <tr>                    
                    <td style="vertical-align: top; text-align:left;">
                        <b>Product Nanme: </b><%#:Item.ProductName %>
                        <br />
                        <b>Description: </b><%#:Item.Description %>
                        <br />
                        <span><b>Product Number: </b>&nbsp;<%#:Item.ProductNo %></span>                                               
                        <br />
                        <a href="/AddToCart.aspx?productID=<%#:Item.ProductId %>">               
                                        <span class="ProductListItem">
                                            <b>Add To Cart<b>
                                        </span>           
                                    </a>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>

    <asp:GridView runat="server" ID="PricesGrid"
        ItemType="FrontierAg.Models.Price" DataKeyNames="PriceId" 
        SelectMethod="GetPrice"
        AutoGenerateColumns="false">
        <Columns>
            <asp:DynamicField DataField="From" />
            <asp:DynamicField DataField="To" />
            <asp:DynamicField DataField="Unit" />
            <asp:DynamicField DataField="PriceNumber" />                   
        </Columns>
    </asp:GridView>

    
</asp:Content>