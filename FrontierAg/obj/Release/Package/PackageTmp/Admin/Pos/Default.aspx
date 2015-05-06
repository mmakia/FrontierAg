<%@ Page Title="PoList" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="FrontierAg.Pos.Default" %>
<%@ Register TagPrefix="FriendlyUrls" Namespace="Microsoft.AspNet.FriendlyUrls" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h2>Pos List</h2>
    <p>
        <asp:HyperLink runat="server" NavigateUrl="Insert" Text="Create new" />
    </p>
    <div>
        <asp:ListView id="ListView1" runat="server"
            DataKeyNames="PoId" 
			ItemType="FrontierAg.Models.Po"
            SelectMethod="GetData">
            <EmptyDataTemplate>
                There are no entries found for Pos
            </EmptyDataTemplate>
            <LayoutTemplate>
                <table class="table">
                    <thead>
                        <tr>
                            <%--<th>
								<asp:LinkButton Text="PoId" CommandName="Sort" CommandArgument="PoId" runat="Server" />
							</th>--%>
                            <th>
								<asp:LinkButton Text="PO Number" CommandName="Sort" CommandArgument="PoNumber" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="Company" CommandName="Sort" CommandArgument="ContactId" runat="Server" />
							</th>
                            <th>
								<asp:LinkButton Text="LName" CommandName="Sort" CommandArgument="ContactId" runat="Server" />
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
							<%--<td>
								<asp:DynamicControl runat="server" DataField="PoId" ID="PoId" Mode="ReadOnly" />
							</td>--%>
							<td>
								<asp:DynamicControl runat="server" DataField="PoNumber" ID="PoNumber" Mode="ReadOnly" />
							</td>
							<td>
								<%#: Item.Contact != null ? Item.Contact.Company : "" %>
							</td>
                             <td>
								<%#: Item.Contact != null ? Item.Contact.LName : "" %>
							</td>
                    <td>
					    <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/Pos/Details", Item.PoId) %>' Text="Details" /> | 
					    <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/Pos/Edit", Item.PoId) %>' Text="Edit" /> | 
                        <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/Pos/Delete", Item.PoId) %>' Text="Delete" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>

