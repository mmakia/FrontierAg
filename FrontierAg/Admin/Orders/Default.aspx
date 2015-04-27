﻿<%@ Page Title="OrderList" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="FrontierAg.Orders.Default" %>
<%@ Register TagPrefix="FriendlyUrls" Namespace="Microsoft.AspNet.FriendlyUrls" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h2>Orders List</h2>
    <p>
        <asp:HyperLink runat="server" NavigateUrl="Insert" Text="Create new" />
    </p>
    <div>
        <asp:ListView id="ListView1" runat="server"
            DataKeyNames="OrderId" 
			ItemType="FrontierAg.Models.Order"
            SelectMethod="GetData">
            <EmptyDataTemplate>
                There are no entries found for Orders
            </EmptyDataTemplate>
            <LayoutTemplate>
                <table class="table">
                    <thead>
                        <tr>
                            <th>
								<asp:LinkButton Text="OrderId" CommandName="Sort" CommandArgument="OrderId" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="OrderDate" CommandName="Sort" CommandArgument="OrderDate" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="Total" CommandName="Sort" CommandArgument="Total" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="ContactId" CommandName="Sort" CommandArgument="ContactId" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="ShippingId" CommandName="Sort" CommandArgument="ShippingId" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="Payment" CommandName="Sort" CommandArgument="Payment" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="PaymentDate" CommandName="Sort" CommandArgument="PaymentDate" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="Comment" CommandName="Sort" CommandArgument="Comment" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="Closed" CommandName="Sort" CommandArgument="Closed" runat="Server" />
							</th>
                            <th>&nbsp;</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr runat="server" id="itemPlaceholder" />
                    </tbody>
                </table>
				<asp:DataPager PageSize="5"  runat="server">
					<Fields>
                        <asp:NextPreviousPagerField ShowLastPageButton="False" ShowNextPageButton="False" ButtonType="Button" ButtonCssClass="btn" />
                        <asp:NumericPagerField ButtonType="Button"  NumericButtonCssClass="btn" CurrentPageLabelCssClass="btn disabled" NextPreviousButtonCssClass="btn" />
                        <asp:NextPreviousPagerField ShowFirstPageButton="False" ShowPreviousPageButton="False" ButtonType="Button" ButtonCssClass="btn" />
                    </Fields>
				</asp:DataPager>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
							<td>
								<asp:DynamicControl runat="server" DataField="OrderId" ID="OrderId" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="OrderDate" ID="OrderDate" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="Total" ID="Total" Mode="ReadOnly" />
							</td>
							<td>
								<%#: Item.Contact != null ? Item.Contact.Contact_Identification : "" %>
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="ShippingId" ID="ShippingId" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="Payment" ID="Payment" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="PaymentDate" ID="PaymentDate" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="Comment" ID="Comment" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="Closed" ID="Closed" Mode="ReadOnly" />
							</td>
                    <td>
					    <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Orders/Details", Item.OrderId) %>' Text="Details" /> | 
					    <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Orders/Edit", Item.OrderId) %>' Text="Edit" /> | 
                        <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Orders/Delete", Item.OrderId) %>' Text="Delete" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>

