<%@ Page Title="RawList" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="FrontierAg.Admin.Raws.Default" %>
<%@ Register TagPrefix="FriendlyUrls" Namespace="Microsoft.AspNet.FriendlyUrls" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h2>Raws List</h2>
    <p>
        <asp:HyperLink runat="server" NavigateUrl="Insert" Text="Create new" />
    </p>
    <div>
        <asp:ListView id="ListView1" runat="server"
            DataKeyNames="RawId" 
			ItemType="FrontierAg.Models.Raw"
            SelectMethod="GetData">
            <EmptyDataTemplate>
                There are no entries found for Raws
            </EmptyDataTemplate>
            <LayoutTemplate>
                <table class="table">
                    <thead>
                        <tr>
                            <th>
								<asp:LinkButton Text="RawId" CommandName="Sort" CommandArgument="RawId" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="LotNumber" CommandName="Sort" CommandArgument="LotNumber" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="Manufacturer" CommandName="Sort" CommandArgument="Manufacturer" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="ManLotNumber" CommandName="Sort" CommandArgument="ManLotNumber" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="ManPartNumber" CommandName="Sort" CommandArgument="ManPartNumber" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="DateRecived" CommandName="Sort" CommandArgument="DateRecived" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="ExpDate" CommandName="Sort" CommandArgument="ExpDate" runat="Server" />
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
								<asp:DynamicControl runat="server" DataField="RawId" ID="RawId" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="LotNumber" ID="LotNumber" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="Manufacturer" ID="Manufacturer" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="ManLotNumber" ID="ManLotNumber" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="ManPartNumber" ID="ManPartNumber" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="DateRecived" ID="DateRecived" Mode="ReadOnly" />
							</td>
							<td>
								<asp:DynamicControl runat="server" DataField="ExpDate" ID="ExpDate" Mode="ReadOnly" />
							</td>
                    <td>
					    <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/Raws/Details", Item.RawId) %>' Text="Details" /> | 
					    <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/Raws/Edit", Item.RawId) %>' Text="Edit" /> | 
                        <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/Raws/Delete", Item.RawId) %>' Text="Delete" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>

