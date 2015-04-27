<%@ Page Title="PriceList" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="FrontierAg.Prices.Default" %>
<%@ Register TagPrefix="FriendlyUrls" Namespace="Microsoft.AspNet.FriendlyUrls" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h2>Prices List</h2>
    <p>
        <asp:HyperLink runat="server" NavigateUrl="Insert" Text="Create new" />
    </p>
    <div>
        <asp:ListView id="ListView1" runat="server"
            DataKeyNames="PriceId" 
			ItemType="FrontierAg.Models.Price"
            SelectMethod="GetData">
            <EmptyDataTemplate>
                There are no entries found for Prices
            </EmptyDataTemplate>
            <LayoutTemplate>
                <table class="table">
                    <thead>
                        <tr>
                            <th>
								<asp:LinkButton Text="From" CommandName="Sort" CommandArgument="From" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="To" CommandName="Sort" CommandArgument="To" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="Unit" CommandName="Sort" CommandArgument="Unit" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="PriceNumber" CommandName="Sort" CommandArgument="PriceNumber" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="DateCreated" CommandName="Sort" CommandArgument="DateCreated" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="Product" CommandName="Sort" CommandArgument="ProductId" runat="Server" />
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
								<asp:DynamicControl runat="server" DataField="From" ID="From" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="To" ID="To" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="Unit" ID="Unit" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="PriceNumber" ID="PriceNumber" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="DateCreated" ID="DateCreated" Mode="ReadOnly" />
							</td>
							<td>
								<%#: Item.Product != null ? Item.Product.ProductNo : "" %>
							</td>
                    <td>
					    <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/Prices/Details", Item.PriceId) %>' Text="Details" /> | 
					    <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/Prices/Edit", Item.PriceId) %>' Text="Edit" /> | 
                        <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/Prices/Delete", Item.PriceId) %>' Text="Delete" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <div class="row">
					  &nbsp;
					</div>
					<div class="form-group">
						<div>
							<asp:button id="backButton" runat="server" text="Back" OnClientClick="JavaScript:window.history.back(1);return false;" CssClass="btn btn-default" />
						</div>
					</div>
    </div>
</asp:Content>

