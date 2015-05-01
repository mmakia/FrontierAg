﻿<%@ Page Title="ShippingDelete" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Delete.aspx.cs" Inherits="FrontierAg.Shippings.Delete" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div>
		<p>&nbsp;</p>
        <h3>Are you sure want to delete this Shipping?</h3>
        <asp:FormView runat="server"
            ItemType="FrontierAg.Models.Shipping" DataKeyNames="ShippingId"
            DeleteMethod="DeleteItem" SelectMethod="GetItem"
            OnItemCommand="ItemCommand" RenderOuterTable="false">
            <EmptyDataTemplate>
                Cannot find the Shipping with ShippingId <%: Request.QueryString["ShippingId"] %>
            </EmptyDataTemplate>
            <ItemTemplate>
                <fieldset class="form-horizontal">
                    <legend>Delete Shipping</legend>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>ShippingId</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="ShippingId" ID="ShippingId" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Address1</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="Address1" ID="Address1" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Address2</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="Address2" ID="Address2" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>City</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="City" ID="City" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>State</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="State" ID="State" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>PostalCode</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="PostalCode" ID="PostalCode" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Country</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="Country" ID="Country" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>ContactId</strong>
								</div>
								<div class="col-sm-4">
									<%#: Item.Contact != null ? Item.Contact.Company : "" %>
								</div>
							</div>
                 	<div class="row">
					  &nbsp;
					</div>
					<div class="form-group">
						<div class="col-sm-offset-2 col-sm-10">
							<asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" CssClass="btn btn-danger" />
							<asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-warning" />
						</div>
					</div>
                </fieldset>
            </ItemTemplate>
        </asp:FormView>
    </div>
</asp:Content>

