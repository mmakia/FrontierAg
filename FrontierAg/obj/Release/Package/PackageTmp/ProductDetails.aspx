<%@ Page Title="Product Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
         CodeBehind="ProductDetails.aspx.cs" Inherits="FrontierAg.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    <asp:FormView ID="productDetail" runat="server" ItemType="FrontierAg.Models.Product" SelectMethod ="GetProduct" >
        <ItemTemplate>            
            <table>
                <tr>                    
                    <td style="vertical-align: top; text-align:left;">
                        <b>Product Nanme: </b><%#:Item.ProductName %>
                        <br />
                        <%--<b>Description: </b><%#:Item.Description %>
                        <br />--%>
                        <b>Product Number: </b>&nbsp;<%#:Item.ProductNo %><br />
                        <br />
                        <asp:HyperLink runat="server" NavigateUrl='<%# Microsoft.AspNet.FriendlyUrls.FriendlyUrl.Href("~/AddToCart", Item.ProductId) %>' Text="Add To Cart"/>    
                        <%--<asp:HyperLink runat="server" NavigateUrl='<%# Microsoft.AspNet.FriendlyUrls.FriendlyUrl.Href("~/ProductList", Item.CategoryId) %>' Text="<%#: Item.CategoryName %>"/>                                           --%>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
    <br />
    <b>Prices</b>
    <asp:GridView runat="server" ID="PricesGrid" ItemType="FrontierAg.Models.Price" DataKeyNames="PriceId"  SelectMethod="GetPrice" AutoGenerateColumns="false" Width="200" CssClass="table table-bordered">
        <EmptyDataTemplate>
                There are no entries found for Prices
            </EmptyDataTemplate>
        <Columns>
            <asp:DynamicField DataField="From" />
            <asp:DynamicField DataField="To" />
            <asp:DynamicField DataField="Unit" />
            <asp:DynamicField DataField="PriceNumber" />                   
        </Columns>        
    </asp:GridView>
    <br /> 
    <b>Packaging Charges</b>
    <asp:GridView runat="server" ID="PackchargeGrid" ItemType="FrontierAg.Models.PackCharge" DataKeyNames="PackChargeId"  SelectMethod="PackchargeGrid_GetData" AutoGenerateColumns="false" Width="200" CssClass="table table-bordered">
        <EmptyDataTemplate>
                There are no entries found for Packaging Charges
            </EmptyDataTemplate>
        <Columns>
            <asp:DynamicField DataField="From" />
            <asp:DynamicField DataField="To" />
            <asp:DynamicField DataField="PackChargeAmt" />                             
        </Columns>        
    </asp:GridView>
    
    

    
</asp:Content>