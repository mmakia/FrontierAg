<%@ Page Title="PriceInsert" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Insert.aspx.cs" Inherits="FrontierAg.Prices.Insert" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div>
		<p>&nbsp;</p>
        <asp:FormView runat="server"
            ItemType="FrontierAg.Models.Price" DefaultMode="Insert"
            InsertItemPosition="FirstItem" InsertMethod="InsertItem"
            OnItemCommand="ItemCommand" RenderOuterTable="false">
            <InsertItemTemplate>
                <fieldset class="form-horizontal">
				<legend>Insert Price</legend>
		        <asp:ValidationSummary runat="server" CssClass="alert alert-danger" />
						    <asp:DynamicControl Mode="Insert" DataField="From" runat="server" />
						    <asp:DynamicControl Mode="Insert" DataField="To" runat="server" />
						    <asp:DynamicControl Mode="Insert" DataField="Unit" runat="server" />
						    <asp:DynamicControl Mode="Insert" DataField="PriceNumber" runat="server" />
						    <asp:DynamicControl Mode="Insert" DataField="DateCreated" runat="server" />
							<asp:DynamicControl Mode="Insert" 
								DataField="ProductId" 
								DataTypeName="FrontierAg.Models.Product" 
								DataTextField="ProductNo" 
								DataValueField="ProductId" 
								UIHint="ForeignKey" runat="server" />
                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            <asp:Button runat="server" ID="InsertButton" CommandName="Insert" Text="Insert" CssClass="btn btn-primary" />
                            <asp:Button runat="server" ID="CancelButton" CommandName="Cancel" Text="Cancel" CausesValidation="false" CssClass="btn btn-default" />
                        </div>
					</div>
                </fieldset>
            </InsertItemTemplate>
        </asp:FormView>
    </div>
</asp:Content>
