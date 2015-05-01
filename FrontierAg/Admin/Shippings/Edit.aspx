<%@ Page Title="ShippingEdit" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Edit.aspx.cs" Inherits="FrontierAg.Shippings.Edit" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div>
		<p>&nbsp;</p>
        <asp:FormView runat="server"
            ItemType="FrontierAg.Models.Shipping" DefaultMode="Edit" DataKeyNames="ShippingId"
            UpdateMethod="UpdateItem" SelectMethod="GetItem"
            OnItemCommand="ItemCommand" RenderOuterTable="false">
            <EmptyDataTemplate>
                Cannot find the Shipping with ShippingId <%: Request.QueryString["ShippingId"] %>
            </EmptyDataTemplate>
            <EditItemTemplate>
                <fieldset class="form-horizontal">
                    <legend>Edit Shipping</legend>
					<asp:ValidationSummary runat="server" CssClass="alert alert-danger"  />                 
						    <asp:DynamicControl Mode="Edit" DataField="Address1" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="Address2" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="City" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="State" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="PostalCode" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="Country" runat="server" />
							<asp:DynamicControl Mode="Edit" 
								DataField="ContactId" 
								DataTypeName="FrontierAg.Models.Contact" 
								DataTextField="Company" 
								DataValueField="ContactId" 
								UIHint="ForeignKey" runat="server" />
                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
							<asp:Button runat="server" ID="UpdateButton" CommandName="Update" Text="Update" CssClass="btn btn-warning" />
							<asp:Button runat="server" ID="CancelButton" CommandName="Cancel" Text="Cancel" CausesValidation="false" CssClass="btn btn-warning" />
						</div>
					</div>
                </fieldset>
            </EditItemTemplate>
        </asp:FormView>
    </div>
</asp:Content>

