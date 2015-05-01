<%@ Page Title="Select Shipping" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="SelectShipping.aspx.cs" Inherits="FrontierAg.Checkout.SelectShipping" %>
<%@ Register TagPrefix="FriendlyUrls" Namespace="Microsoft.AspNet.FriendlyUrls" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h2>Select Shipping Address</h2>
    <p>
        <asp:HyperLink runat="server" NavigateUrl="~/Admin/Shippings/Insert" Text="Create new" />
    </p>
    <div>
        <asp:ListView id="ListView1" runat="server"
            DataKeyNames="ShippingId" 
			ItemType="FrontierAg.Models.Shipping"
            SelectMethod="GetData">
            <EmptyDataTemplate>
                There are no entries found for Shippings
            </EmptyDataTemplate>
            <LayoutTemplate>
                <table class="table">
                    <thead>
                        <tr>
                            <th>
								<asp:LinkButton Text="ShippingId" CommandName="Sort" CommandArgument="ShippingId" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="Address1" CommandName="Sort" CommandArgument="Address1" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="Address2" CommandName="Sort" CommandArgument="Address2" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="City" CommandName="Sort" CommandArgument="City" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="State" CommandName="Sort" CommandArgument="State" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="PostalCode" CommandName="Sort" CommandArgument="PostalCode" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="Country" CommandName="Sort" CommandArgument="Country" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="ContactId" CommandName="Sort" CommandArgument="ContactId" runat="Server" />
							</th>
                            <th>&nbsp;</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr runat="server" id="itemPlaceholder" />
                    </tbody>
                </table>
				<asp:DataPager PageSize="15"  runat="server">
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
								<asp:DynamicControl runat="server" DataField="ShippingId" ID="ShippingId" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="Address1" ID="Address1" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="Address2" ID="Address2" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="City" ID="City" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="State" ID="State" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="PostalCode" ID="PostalCode" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="Country" ID="Country" Mode="ReadOnly" />
							</td>
							<td>
								<%#: Item.Contact != null ? Item.Contact.Company : "" %>
							</td>
                    <td>
                        <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Checkout/CheckoutReview.aspx", Item.ContactId , Item.ShippingId) %>' Text="Select" /> | 
					    <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/Shippings/Details", Item.ShippingId) %>' Text="Details" /> | 
					    <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/Shippings/Edit", Item.ShippingId) %>' Text="Edit" />                        
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <div class="row">
					  &nbsp;
					</div>
					<div class="form-group">
						<div >
							<asp:button id="backButton" runat="server" text="Back" OnClientClick="JavaScript:window.history.back(1);return false;" CssClass="btn btn-warning" />
						</div>
					</div>
    </div>
</asp:Content>

