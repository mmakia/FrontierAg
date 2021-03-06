﻿<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
         CodeBehind="ProductList.aspx.cs" Inherits="FrontierAg.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">    
    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>            
            <asp:TextBox ID="TextBox1" runat="server" CSSClass="form-control" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged" EnableViewState="False"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" ClientIDMode="Static" style="display:none"/>
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
                                    <%--<a href="ProductDetails.aspx?productID=<%#:Item.ProductId%>">
                                        <span>
                                            <%#:Item.ProductName%>
                                        </span>
                                    </a>--%>
                                    <br />
                                    <span>
                                        <b>Product#: </b><%#:String.Format("{0:c}", Item.ProductNo)%>
                                    </span>
                                    <br />
                                    <asp:HyperLink runat="server" NavigateUrl='<%# Microsoft.AspNet.FriendlyUrls.FriendlyUrl.Href("~/AddToCart", Item.ProductId) %>' Text="Add To Cart"/> 
                                    <%--<a href="AddToCart.aspx?productID=<%#:Item.ProductId %>">                
                                        <span class="ProductListItem">
                                            <b>Add To Cart<b> 
                                        </span>           
                                    </a>--%>

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
    <script type="text/javascript">
        $(function () {
            var button = document.getElementById("Button1");
            $('.form-control').on('focusout', function () {
                button.click();
            });
            $('.form-control').on('enter', function () {
                button.click();
            });
        });
    </script>
</asp:Content>