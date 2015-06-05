<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
         CodeBehind="ProductList.aspx.cs" Inherits="FrontierAg.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">    
    <section>
        <div>
            <hgroup>
                <h3><%: Page.Title %></h3>
            </hgroup>                                      
            <asp:TextBox ID="TextBox1" runat="server" CSSClass="form-control" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged" EnableViewState="False"></asp:TextBox>            
            &nbsp;
            <asp:ListView ID="productList" runat="server" 
                DataKeyNames="ProductID" GroupItemCount="4"
                ItemType="FrontierAg.Models.Product" SelectMethod="GetProducts">
                <EmptyDataTemplate>
                    <table >
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td/> 
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">                        
                        <table>                                                 
                            <tr>
                                <td><asp:HyperLink runat="server" NavigateUrl='<%# Microsoft.AspNet.FriendlyUrls.FriendlyUrl.Href("~/ProductDetails", Item.ProductId) %>' Text="<%#:Item.ProductName%>"/>                                     
                                    <br />
                                    <span>
                                        <b>Product#: </b><%#:String.Format("{0:c}", Item.ProductNo)%>
                                    </span>
                                    <br />
                                    <asp:HyperLink runat="server" NavigateUrl='<%# Microsoft.AspNet.FriendlyUrls.FriendlyUrl.Href("~/AddToCart", Item.ProductId) %>' Text="Add To Cart"/> 
                                </td>
                            </tr>                            
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p>
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table style="width:100%;">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width:100%">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>                    
                </div>        
    </section>        
</asp:Content>