<%@ Page Title="ContactList" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="FrontierAg.Contacts.Default" %>

<%@ Register TagPrefix="FriendlyUrls" Namespace="Microsoft.AspNet.FriendlyUrls" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <table>
        <tr>
            <td>
                <h3>Companies List</h3>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink runat="server" NavigateUrl="Insert" Text="Create new" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged" EnableViewState="False" placeholder="Search"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div>
        <asp:ListView ID="ListView1" runat="server"
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
                                <asp:LinkButton Text="ID" CommandName="Sort" CommandArgument="ContactId" runat="Server" />
                            </th>
                            <th>
                                <asp:LinkButton Text="Company" CommandName="Sort" CommandArgument="Company" runat="Server" />
                            </th>
                            <%--<th>
                                <asp:LinkButton Text="FName" CommandName="Sort" CommandArgument="FName" runat="Server" />
                            </th>
                            <th>
                                <asp:LinkButton Text="LName" CommandName="Sort" CommandArgument="LName" runat="Server" />
                            </th>--%>


                            <%--<th>
                                <asp:LinkButton Text="Primary Phone" CommandName="Sort" CommandArgument="PPhone" runat="Server" />
                            </th>--%>
                            <%--<th>
								<asp:LinkButton Text="Phone Type" CommandName="Sort" CommandArgument="PPType" runat="Server" />
							</th>--%>

                            <%--<th>
                                <asp:LinkButton Text="EMail" CommandName="Sort" CommandArgument="EMail" runat="Server" />
                            </th>--%>

                            <th>
                                <asp:LinkButton Text="Comment" CommandName="Sort" CommandArgument="Comment" runat="Server" />
                            </th>
                            <th>
                                <asp:LinkButton Text="Contact Type" CommandName="Sort" CommandArgument="Type" runat="Server" />
                            </th>

                            <th>&nbsp;</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr runat="server" id="itemPlaceholder" />
                    </tbody>
                </table>
                <asp:DataPager PageSize="9" runat="server">
                    <Fields>
                        <asp:NextPreviousPagerField ShowLastPageButton="False" ShowNextPageButton="False" ButtonType="Button" ButtonCssClass="btn" />
                        <asp:NumericPagerField ButtonType="Button" NumericButtonCssClass="btn" CurrentPageLabelCssClass="btn disabled" NextPreviousButtonCssClass="btn" />
                        <asp:NextPreviousPagerField ShowFirstPageButton="False" ShowPreviousPageButton="False" ButtonType="Button" ButtonCssClass="btn" />
                    </Fields>
                </asp:DataPager>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:DynamicControl runat="server" DataField="ContactId" ID="ContactId" Mode="ReadOnly" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="Company" ID="Company" Mode="ReadOnly" />
                    </td>
                    <%--<td>
                        <asp:DynamicControl runat="server" DataField="FName" ID="FName" Mode="ReadOnly" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="LName" ID="LName" Mode="ReadOnly" />
                    </td>--%>

                    <%--<td>
                        <asp:DynamicControl runat="server" DataField="PPhone" ID="PPhone" Mode="ReadOnly" />
                    </td>--%>
                    <%--<td>
								<asp:DynamicControl runat="server" DataField="PPType" ID="PPType" Mode="ReadOnly" />
							</td>--%>

                    <%--<td>
                        <asp:DynamicControl runat="server" DataField="EMail" ID="EMail" Mode="ReadOnly" />
                    </td>--%>

                    <td>
                        <asp:DynamicControl runat="server" DataField="Comment" ID="Comment" Mode="ReadOnly" />
                    </td>
                    <td>
                        <asp:DynamicControl runat="server" DataField="Type" ID="Type" Mode="ReadOnly" />
                    </td>

                    <td>
                        <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/Contacts/Details", Item.ContactId) %>' Text="Details" />
                        | 
					    <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/Contacts/Edit", Item.ContactId) %>' Text="Edit" />
                        |
					    <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/Shippings/Default", Item.ContactId) %>' Text="Addresses" />
                        | 
                        <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/Orders/Default", Item.ContactId) %>' Text="Orders" />
                        | 
                        <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/OrderDetails/AllDetails", Item.ContactId) %>' Text="Products" />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>

        <div class="row">
            &nbsp;
        </div>
        <div class="form-group">
            <div>
                <asp:Button ID="backButton" runat="server" Text="Back" OnClick="BackBtn_OnClick" CssClass="btn btn-warning" />
            </div>
        </div>
    </div>
</asp:Content>

