<%@ Page Title="PriceDelete" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Delete.aspx.cs" Inherits="FrontierAg.Prices.Delete" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div>
		<p>&nbsp;</p>
        <h3>Are you sure want to delete this Price?</h3>
        <asp:FormView runat="server"
            ItemType="FrontierAg.Models.Price" DataKeyNames="PriceId"
            DeleteMethod="DeleteItem" SelectMethod="GetItem"
            OnItemCommand="ItemCommand" RenderOuterTable="false">
            <EmptyDataTemplate>
                Cannot find the Price with PriceId <%: Request.QueryString["PriceId"] %>
            </EmptyDataTemplate>
            <ItemTemplate>
                <fieldset class="form-horizontal">
                    <legend>Delete Price</legend>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>From</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="From" ID="From" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>To</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="To" ID="To" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Unit</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="Unit" ID="Unit" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>PriceNumber</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="PriceNumber" ID="PriceNumber" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>DateCreated</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="DateCreated" ID="DateCreated" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Product</strong>
								</div>
								<div class="col-sm-4">
									<%#: Item.Product != null ? Item.Product.ProductNo : "" %>
								</div>
							</div>
                 	<div class="row">
					  &nbsp;
					</div>
					<div class="form-group">
						<div class="col-sm-offset-2 col-sm-10">
							<asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" CssClass="btn btn-danger" />
							<asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-default" />
						</div>
					</div>
                </fieldset>
            </ItemTemplate>
        </asp:FormView>
    </div>
</asp:Content>

