<%@ Page Title="PriceEdit" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Edit.aspx.cs" Inherits="FrontierAg.Prices.Edit" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div>
		<p>&nbsp;</p>
        <asp:FormView runat="server"
            ItemType="FrontierAg.Models.Price" DefaultMode="Edit" DataKeyNames="PriceId"
            UpdateMethod="UpdateItem" SelectMethod="GetItem"
            OnItemCommand="ItemCommand" RenderOuterTable="false">
            <EmptyDataTemplate>
                Cannot find the Price with PriceId <%: Request.QueryString["PriceId"] %>
            </EmptyDataTemplate>
            <EditItemTemplate>
                <fieldset class="form-horizontal">
                    <legend>Edit Price</legend>
					<asp:ValidationSummary runat="server" CssClass="alert alert-danger"  />                 
						    <asp:DynamicControl Mode="Edit" DataField="From" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="To" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="Unit" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="PriceNumber" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="DateCreated" runat="server" />
							<asp:DynamicControl Mode="Edit" 
								DataField="ProductId" 
								DataTypeName="FrontierAg.Models.Product" 
								DataTextField="ProductNo" 
								DataValueField="ProductId" 
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

