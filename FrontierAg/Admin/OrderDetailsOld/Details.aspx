<%@ Page Title="OrderDetail Details" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Details.aspx.cs" Inherits="FrontierAg.OrderDetails.Details" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div>
		<p>&nbsp;</p>
      
        <asp:FormView runat="server"
            ItemType="FrontierAg.Models.OrderDetail" DataKeyNames="OrderDetailId"
            SelectMethod="GetItem"
            OnItemCommand="ItemCommand" RenderOuterTable="false">
            <EmptyDataTemplate>
                Cannot find the OrderDetail with OrderDetailId <%: Request.QueryString["OrderDetailId"] %>
            </EmptyDataTemplate>
            <ItemTemplate>
                <fieldset class="form-horizontal">
                    <legend>OrderDetail Details</legend>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>OrderDetailId</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="OrderDetailId" ID="OrderDetailId" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>OrderId</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="OrderId" ID="OrderId" Mode="ReadOnly" />
								</div>
							</div>
							
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>ProductId</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="ProductId" ID="ProductId" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Quantity</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="Quantity" ID="Quantity" Mode="ReadOnly" />
								</div>
							</div>
                    <div class="row">
								<div class="col-sm-2 text-right">
									<strong>QtyShipped</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="QtyShipped" ID="QtyShipped" Mode="Edit" />
								</div>
							</div>
                    <div class="row">
								<div class="col-sm-2 text-right">
									<strong>QtyCancelled</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="QtyCancelled" ID="QtyCancelled" Mode="Edit" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>UnitPrice</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="UnitPrice" ID="UnitPrice" Mode="ReadOnly" />
								</div>
							</div>
                 	<div class="row">
					  &nbsp;
					</div>
					<div class="form-group">
						<div class="col-sm-offset-2 col-sm-10">
							<asp:button id="backButton" runat="server" text="Back" OnClientClick="JavaScript:window.history.back(1);return false;" CssClass="btn btn-warning" />
						</div>
					</div>
                </fieldset>
            </ItemTemplate>
        </asp:FormView>
    </div>
</asp:Content>

