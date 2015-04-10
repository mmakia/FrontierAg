<%@ Page Title="ContactList" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="FrontierAg.Contacts.Default" %>
<%@ Register TagPrefix="FriendlyUrls" Namespace="Microsoft.AspNet.FriendlyUrls" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h2>Contacts List</h2>
    <p>
        <asp:HyperLink runat="server" NavigateUrl="Insert" Text="Create new" />
    </p>
    <div>
        <asp:ListView id="ListView1" runat="server"
            DataKeyNames="ContactId" 
			ItemType="FrontierAg.Models.Contact"
            SelectMethod="GetData">
            <EmptyDataTemplate>
                There are no entries found for Contacts
            </EmptyDataTemplate>
            <LayoutTemplate>
                <table class="table">
                    <thead>
                        <tr>
                            <th>
								<asp:LinkButton Text="Contact ID" CommandName="Sort" CommandArgument="Contact_Identification" runat="Server" />
							</th>
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
								<asp:LinkButton Text="Primary Phone" CommandName="Sort" CommandArgument="PPhone" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="Phone Type" CommandName="Sort" CommandArgument="PPType" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="Secondary Phone" CommandName="Sort" CommandArgument="SPhone" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="Secondary Phone Type" CommandName="Sort" CommandArgument="SPType" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="Fax" CommandName="Sort" CommandArgument="Fax" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="EMail" CommandName="Sort" CommandArgument="EMail" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="WebSite" CommandName="Sort" CommandArgument="WebSite" runat="Server" />
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
								<asp:DynamicControl runat="server" DataField="Contact_Identification" ID="Contact_Identification" Mode="ReadOnly" />
							</td>
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
								<asp:DynamicControl runat="server" DataField="PPhone" ID="PPhone" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="PPType" ID="PPType" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="SPhone" ID="SPhone" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="SPType" ID="SPType" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="Fax" ID="Fax" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="EMail" ID="EMail" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="WebSite" ID="WebSite" Mode="ReadOnly" />
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
                        <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/Contacts/Delete", Item.ContactId) %>' Text="Delete" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>

