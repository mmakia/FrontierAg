<%@ Page Title="Start Checkout" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="CheckoutStart.aspx.cs" Inherits="FrontierAg.Checkout.CheckoutStart" %>

<%@ Register TagPrefix="FriendlyUrls" Namespace="Microsoft.AspNet.FriendlyUrls" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div id="modal_dialog1" style="display: none">
                <p>
                    <%--<asp:HyperLink runat="server" NavigateUrl="~/Admin/Shippings/AddShipping" Text="Create new" />--%>
                    <asp:LinkButton runat="server" ID="LinkButton1" OnClick="CreateNewOrderingBtn_Click" Text="Create New" />
                </p>
                <asp:ListView ID="ListView4" runat="server" DataKeyNames="ShippingId" ItemType="FrontierAg.Models.Shipping" SelectMethod="GetData1">
                    <EmptyDataTemplate></EmptyDataTemplate>
                    <LayoutTemplate>
                        <table class="table showing1">
                            <thead>
                                <tr>
                                    <%--<th>
								<asp:LinkButton Text="ShippingId" CommandName="Sort" CommandArgument="ShippingId" runat="Server" />
							</th>--%>
                                    <th>
                                        <asp:LinkButton Text="Company" CommandName="Sort" CommandArgument="Company" runat="Server" />
                                    </th>
                                    <th>
                                        <asp:LinkButton Text="FName" CommandName="Sort" CommandArgument="FName" runat="Server" />
                                    </th>
                                    <th>
                                        <asp:LinkButton Text="LName" CommandName="Sort" CommandArgument="LName" runat="Server" />
                                    </th>

                                    <th>
                                        <asp:LinkButton Text="Other1" CommandName="Sort" CommandArgument="Other1" runat="Server" />
                                    </th>
                                    <th>
                                        <asp:LinkButton Text="Other2" CommandName="Sort" CommandArgument="Other2" runat="Server" />
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
                                        <asp:LinkButton Text="email" CommandName="Sort" CommandArgument="Email" runat="Server" />
                                    </th>
                                    <th>&nbsp;</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr runat="server" id="itemPlaceholder" />
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <%--<td>
								<asp:DynamicControl runat="server" DataField="ShippingId" ID="ShippingId" Mode="ReadOnly" />
							</td>--%>
                            <td>
                                <asp:DynamicControl runat="server" DataField="Company" ID="Company" Mode="ReadOnly" />
                            </td>
                            <td>
                                <asp:DynamicControl runat="server" DataField="FName" ID="FName" Mode="ReadOnly" />
                            </td>
                            <td>
                                <asp:DynamicControl runat="server" DataField="LName" ID="LName" Mode="ReadOnly" />
                            </td>

                            <td>
                                <asp:DynamicControl runat="server" DataField="Other1" ID="Other1" Mode="ReadOnly" />
                            </td>
                            <td>
                                <asp:DynamicControl runat="server" DataField="Other2" ID="Other2" Mode="ReadOnly" />
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
                                <asp:DynamicControl runat="server" DataField="Email" ID="Email" Mode="ReadOnly" />
                            </td>
                            <td>
                                <asp:LinkButton runat="server" OnClick="Unnamed_Click1" CommandArgument="<%# Item.ShippingId %>" Text="Select" />
                                | 					     
					    <asp:LinkButton runat="server" OnClick="OrderingList_Edit" ID="ShippingList" CommandArgument="<%# Item.ShippingId %>" Text="Edit" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            <div id="modal_dialog2" style="display: none">
                <p>
                    <%--<asp:HyperLink runat="server" NavigateUrl="~/Admin/Shippings/AddShipping" Text="Create new" />--%>
                    <asp:LinkButton runat="server" ID="CreateNewShippingBtn" OnClick="CreateNewShippingBtn_Click" Text="Create New" />
                </p>
                <asp:ListView ID="ListView2" runat="server" DataKeyNames="ShippingId" ItemType="FrontierAg.Models.Shipping" SelectMethod="GetData2">
                    <EmptyDataTemplate></EmptyDataTemplate>
                    <LayoutTemplate>
                        <table class="table showing2">
                            <thead>
                                <tr>
                                    <%--<th>
								<asp:LinkButton Text="ShippingId" CommandName="Sort" CommandArgument="ShippingId" runat="Server" />
							</th>--%>
                                    <th>
                                        <asp:LinkButton Text="Company" CommandName="Sort" CommandArgument="Company" runat="Server" />
                                    </th>
                                    <th>
                                        <asp:LinkButton Text="FName" CommandName="Sort" CommandArgument="FName" runat="Server" />
                                    </th>
                                    <th>
                                        <asp:LinkButton Text="LName" CommandName="Sort" CommandArgument="LName" runat="Server" />
                                    </th>

                                    <th>
                                        <asp:LinkButton Text="Other1" CommandName="Sort" CommandArgument="Other1" runat="Server" />
                                    </th>
                                    <th>
                                        <asp:LinkButton Text="Other2" CommandName="Sort" CommandArgument="Other2" runat="Server" />
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
                                        <asp:LinkButton Text="Email" CommandName="Sort" CommandArgument="Email" runat="Server" />
                                    </th>
                                    <th>&nbsp;</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr runat="server" id="itemPlaceholder" />
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <%--<td>
								<asp:DynamicControl runat="server" DataField="ShippingId" ID="ShippingId" Mode="ReadOnly" />
							</td>--%>
                            <td>
                                <asp:DynamicControl runat="server" DataField="Company" ID="Company" Mode="ReadOnly" />
                            </td>
                            <td>
                                <asp:DynamicControl runat="server" DataField="FName" ID="FName" Mode="ReadOnly" />
                            </td>
                            <td>
                                <asp:DynamicControl runat="server" DataField="LName" ID="LName" Mode="ReadOnly" />
                            </td>

                            <td>
                                <asp:DynamicControl runat="server" DataField="Other1" ID="Other1" Mode="ReadOnly" />
                            </td>
                            <td>
                                <asp:DynamicControl runat="server" DataField="Other2" ID="Other2" Mode="ReadOnly" />
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
                                <asp:DynamicControl runat="server" DataField="Email" ID="Email" Mode="ReadOnly" />
                            </td>
                            <td>
                                <asp:LinkButton runat="server" OnClick="Unnamed_Click2" CommandArgument="<%# Item.ShippingId %>" Text="Select" />
                                <%--| 					     
					    <asp:LinkButton runat="server" OnClick="ShippingList_Edit" ID="ShippingList" CommandArgument="<%# Item.ShippingId %>" Text="Edit" />--%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>

            <div id="modal_dialog3" style="display: none">
                <p>
                    <%--<asp:HyperLink runat="server" NavigateUrl="~/Admin/Shippings/AddShipping" Text="Create new" />--%>
                    <asp:LinkButton runat="server" ID="CreateNewBilling" OnClick="CreateNewBilling_Click" Text="Create New" />
                </p>
                <asp:ListView ID="ListView3" runat="server" DataKeyNames="ShippingId" ItemType="FrontierAg.Models.Shipping" SelectMethod="GetData3">
                    <EmptyDataTemplate></EmptyDataTemplate>
                    <LayoutTemplate>
                        <table class="table showing3">
                            <thead>
                                <tr>
                                    <%--<th>
								<asp:LinkButton Text="ShippingId" CommandName="Sort" CommandArgument="ShippingId" runat="Server" />
							</th>--%>
                                    <th>
                                        <asp:LinkButton Text="Company" CommandName="Sort" CommandArgument="Company" runat="Server" />
                                    </th>
                                    <th>
                                        <asp:LinkButton Text="FName" CommandName="Sort" CommandArgument="FName" runat="Server" />
                                    </th>
                                    <th>
                                        <asp:LinkButton Text="LName" CommandName="Sort" CommandArgument="LName" runat="Server" />
                                    </th>

                                    <th>
                                        <asp:LinkButton Text="Other1" CommandName="Sort" CommandArgument="Other1" runat="Server" />
                                    </th>
                                    <th>
                                        <asp:LinkButton Text="Other2" CommandName="Sort" CommandArgument="Other2" runat="Server" />
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
                                        <asp:LinkButton Text="Email" CommandName="Sort" CommandArgument="Email" runat="Server" />
                                    </th>
                                    <th>&nbsp;</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr runat="server" id="itemPlaceholder" />
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <%--<td>
							<asp:DynamicControl runat="server" DataField="ShippingId" ID="ShippingId" Mode="ReadOnly" />
						</td>--%>
                            <td>
                                <asp:DynamicControl runat="server" DataField="Company" ID="Company" Mode="ReadOnly" />
                            </td>
                            <td>
                                <asp:DynamicControl runat="server" DataField="FName" ID="FName" Mode="ReadOnly" />
                            </td>
                            <td>
                                <asp:DynamicControl runat="server" DataField="LName" ID="LName" Mode="ReadOnly" />
                            </td>

                            <td>
                                <asp:DynamicControl runat="server" DataField="Other1" ID="Other1" Mode="ReadOnly" />
                            </td>
                            <td>
                                <asp:DynamicControl runat="server" DataField="Other2" ID="Other2" Mode="ReadOnly" />
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
                                <asp:DynamicControl runat="server" DataField="Email" ID="Email" Mode="ReadOnly" />
                            </td>
                            <td>
                                <asp:LinkButton runat="server" OnClick="Unnamed_Click3" CommandArgument="<%# Item.ShippingId %>" Text="Select" />
                                <%--| 		
                        <asp:LinkButton runat="server" OnClick="BillingList_Edit" ID="BillingList" CommandArgument="<%# Item.ShippingId %>" Text="Edit" />--%>
                                
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            <h4>Select Ordering Company or 
        <%--<asp:HyperLink runat="server" NavigateUrl="~/Admin/Contacts/Insert"  Text="Create new" />--%>
                <asp:LinkButton runat="server" ID="CreateNewBtn" OnClick="CreateNewBtn_Click" Text="Create New" />
            </h4>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged" EnableViewState="False" placeholder="Search by Company,Contact or Address"></asp:TextBox>

            <div>
                <asp:ListView ID="ListView1" runat="server"
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
                                        <asp:LinkButton Text="Comment" CommandName="Sort" CommandArgument="Comment" runat="Server" />
                                    </th>
                                    <%--<th>
                                        <asp:LinkButton Text="Contact Type" CommandName="Sort" CommandArgument="Type" runat="Server" />
                                    </th>--%>
                                    <%--<th>
                                        <asp:LinkButton Text="DateCreated" CommandName="Sort" CommandArgument="DateCreated" runat="Server" />
                                    </th>--%>
                                    <th>&nbsp;</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr runat="server" id="itemPlaceholder" />
                            </tbody>
                        </table>
                        <asp:DataPager PageSize="60" runat="server">
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
                                <asp:DynamicControl runat="server" DataField="Company" ID="Company" Mode="ReadOnly" />
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
                                <asp:DynamicControl runat="server" DataField="Comment" ID="Comment" Mode="ReadOnly" />
                            </td>
                            <%--<td>
                                <asp:DynamicControl runat="server" DataField="Type" ID="Type" Mode="ReadOnly" />
                            </td>--%>
                            <%--<td>
								<asp:DynamicControl runat="server" DataField="DateCreated" ID="DateCreated" Mode="ReadOnly" />
							</td>--%>

                            <td>
                                <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Checkout/CheckoutStart", Item.ContactId) %>' Text="Select" />
                                | 
					    <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/Contacts/Details", Item.ContactId) %>' Text="Details" />
                                | 
                        <asp:LinkButton runat="server" ID="SelectBtn" OnClick="EditBtn_Click1" CommandArgument="<%# Item.ContactId %>" Text="Edit" />
                                <%--<asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/Contacts/Edit", Item.ContactId) %>' Text="Edit" /> --%>
                        
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
                <div class="row">
                    &nbsp;
                </div>
                <div class="form-group">
                    <div>
                        <asp:Button ID="backButton" runat="server" Text="Back" OnClick="backButton_Click" CssClass="btn btn-warning" />
                    </div>
                </div>
            </div>
            <script type="text/javascript">
                //$("[id*=btnModalPopup]").on("click", function () {
                $(function () {
                    if ($(".table.showing1").length) {
                        $("#modal_dialog1").dialog({
                            modal: true,
                            title: "Select Ordering Customer",
                            width: 'auto',
                            buttons: {
                                Close: function () {
                                    $(this).dialog('close');
                                }
                            }
                        });
                    }
                    if ($(".table.showing2").length) {
                        $("#modal_dialog2").dialog({
                            modal: true,
                            title: "Select Shipping",
                            width: 'auto',
                            buttons: {
                                Close: function () {
                                    $(this).dialog('close');
                                }
                            }
                        });
                    }
                    if ($(".table.showing3").length) {
                        $("#modal_dialog3").dialog({
                            modal: true,
                            title: "Select Billing",
                            width: 'auto',
                            buttons: {
                                Close: function () {
                                    $(this).dialog('close');
                                }
                            }
                        });
                    }
                });
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

