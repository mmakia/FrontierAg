<%@ Page Title="Start Checkout" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="CheckoutStart.aspx.cs" Inherits="FrontierAg.Checkout.CheckoutStart" %>
<%@ Register TagPrefix="FriendlyUrls" Namespace="Microsoft.AspNet.FriendlyUrls" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h2>Please select a contact or create new:</h2>
    <p>
        <asp:HyperLink runat="server" NavigateUrl="~/Admin/Contacts/Insert"  Text="Create new" />
    </p>
    <div>
        <asp:ListView id="ListView1" runat="server"
            DataKeyNames="ContactId" 
			ItemType="FrontierAg.Models.Contact"
            SelectMethod="GetContacts">
            <EmptyDataTemplate>
                There are no entries found for Contacts
            </EmptyDataTemplate>
            <LayoutTemplate>
                <table class="table">
                    <thead>
                        <tr>
                            
                            <th>
								<asp:LinkButton Text="Company" CommandName="Sort" CommandArgument="Company" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="LName" CommandName="Sort" CommandArgument="LName" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="FName" CommandName="Sort" CommandArgument="FName" runat="Server" />
							</th>
                            
                            <th>
								<asp:LinkButton Text="Primary Phone" CommandName="Sort" CommandArgument="PPhone" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="Phone Type" CommandName="Sort" CommandArgument="PPType" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="Comment" CommandName="Sort" CommandArgument="Comment" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="Contact Type" CommandName="Sort" CommandArgument="Type" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="DateCreated" CommandName="Sort" CommandArgument="DateCreated" runat="Server" />
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
								<asp:DynamicControl runat="server" DataField="Company" ID="Company" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="LName" ID="LName" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="FName" ID="FName" Mode="ReadOnly" />
							</td>
							
							<td>
								<asp:DynamicControl runat="server" DataField="PPhone" ID="PPhone" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="PPType" ID="PPType" Mode="ReadOnly" />
							</td>
							
							<td>
								<asp:DynamicControl runat="server" DataField="Comment" ID="Comment" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="Type" ID="Type" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="DateCreated" ID="DateCreated" Mode="ReadOnly" />
							</td>
                    
                    <td>
					    <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/Contacts/Details", Item.ContactId) %>' Text="Details" /> | 
					    <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/Contacts/Edit", Item.ContactId) %>' Text="Edit" /> | 
                        <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Checkout/SelectShipping.aspx", Item.ContactId) %>' Text="Select Shipping Address" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>

