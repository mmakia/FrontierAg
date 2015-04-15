<%@ Page Title="OrderDetailList" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="FrontierAg.OrderDetails.Default" %>
<%@ Register TagPrefix="FriendlyUrls" Namespace="Microsoft.AspNet.FriendlyUrls" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h2>OrderDetails List</h2>
    <%--<p>
        <asp:HyperLink runat="server" NavigateUrl="~/Admin/OrderDetails/Insert" Text="Create new" />
    </p>--%>
    <div>
        <asp:ListView id="ListView1" runat="server"
            DataKeyNames="OrderDetailId" 
			ItemType="FrontierAg.Models.OrderDetail"
            SelectMethod="GetData">
            <EmptyDataTemplate>
                There are no entries found for OrderDetails
            </EmptyDataTemplate>
            <LayoutTemplate>
                <table class="table">
                    <thead>
                        <tr>
                            <th>
								<asp:LinkButton Text="OrderDetailId" CommandName="Sort" CommandArgument="OrderDetailId" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="OrderId" CommandName="Sort" CommandArgument="OrderId" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="ContactId" CommandName="Sort" CommandArgument="ContactId" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="ProductId" CommandName="Sort" CommandArgument="ProductId" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="Quantity" CommandName="Sort" CommandArgument="Quantity" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="UnitPrice" CommandName="Sort" CommandArgument="UnitPrice" runat="Server" />
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
								<asp:DynamicControl runat="server" DataField="OrderDetailId" ID="OrderDetailId" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="OrderId" ID="OrderId" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="ContactId" ID="ContactId" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="ProductId" ID="ProductId" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="Quantity" ID="Quantity" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="UnitPrice" ID="UnitPrice" Mode="ReadOnly" />
							</td>
                    <td>
					    <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/OrderDetails/Details", Item.OrderDetailId) %>' Text="Details" /> | 
					    <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/OrderDetails/Edit", Item.OrderDetailId) %>' Text="Edit" /> | 
                        <%--<asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/OrderDetails/Delete", Item.OrderDetailId) %>' Text="Delete" />--%>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>

