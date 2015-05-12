<%@ Page Title="Start Checkout" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="CheckoutStart.aspx.cs" Inherits="FrontierAg.Checkout.CheckoutStart" %>
<%@ Register TagPrefix="FriendlyUrls" Namespace="Microsoft.AspNet.FriendlyUrls" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">    
<div id="modal_dialog" style="display: none" >
<asp:ListView id="ListView2" runat="server"  DataKeyNames="ShippingId" ItemType="FrontierAg.Models.Shipping"  SelectMethod="GetData">
            <EmptyDataTemplate></EmptyDataTemplate>
            <LayoutTemplate>
                <table class="table showing">
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
					    <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/Shippings/Edit", Item.ShippingId) %>' Text="Edit" />                        
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        </div>
    <h3>Please select a customer or create new:</h3>
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
                        <asp:HyperLink  runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Checkout/CheckoutStart.aspx", Item.ContactId) %>' Text="Select" /> | 
					    <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/Contacts/Details", Item.ContactId) %>' Text="Details" /> | 
					    <asp:HyperLink runat="server" NavigateUrl='<%# FriendlyUrl.Href("~/Admin/Contacts/Edit", Item.ContactId) %>' Text="Edit" /> 
                        
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <div class="row">
					  &nbsp;
					</div>
					<div class="form-group">
						<div >
							<asp:button id="backButton" runat="server" text="Back" OnClick="backButton_Click" CssClass="btn btn-warning" />
						</div>
					</div>
    </div>  
    <script type="text/javascript">        
        //$("[id*=btnModalPopup]").on("click", function () {
        $(function () {
            if ($(".table.showing").length) {
                $("#modal_dialog").dialog({
                    modal: true,
                    title: "Select Shipping Address",
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
</asp:Content>

