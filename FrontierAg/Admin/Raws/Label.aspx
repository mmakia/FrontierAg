<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Label.aspx.cs" Inherits="FrontierAg.Admin.Raws.Label" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/fssi_logo.png" />
   

    <asp:ListView ID="RawList" runat="server" 
                DataKeyNames="RawId" GroupItemCount="5"
                ItemType="FrontierAg.Models.Raw" SelectMethod="GetProducts">
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
                                        <%#:String.Format("{0:c}", Item.Product.ProductNo)%>
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

</asp:Content>
