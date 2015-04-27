<%@ Page Title="OrderInsert" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Insert.aspx.cs" Inherits="FrontierAg.Orders.Insert" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div>
		<p>&nbsp;</p>
        <asp:FormView runat="server"
            ItemType="FrontierAg.Models.Order" DefaultMode="Insert"
            InsertItemPosition="FirstItem" InsertMethod="InsertItem"
            OnItemCommand="ItemCommand" RenderOuterTable="false">
            <InsertItemTemplate>
                <fieldset class="form-horizontal">
				<legend>Insert Order</legend>
		        <asp:ValidationSummary runat="server" CssClass="alert alert-danger" />
						    <asp:DynamicControl Mode="Insert" DataField="OrderDate" runat="server" />
						    <asp:DynamicControl Mode="Insert" DataField="Total" runat="server" />
							<asp:DynamicControl Mode="Insert" 
								DataField="ContactId" 
								DataTypeName="FrontierAg.Models.Contact" 
								DataTextField="Contact_Identification" 
								DataValueField="ContactId" 
								UIHint="ForeignKey" runat="server" />
						    <asp:DynamicControl Mode="Insert" DataField="ShippingId" runat="server" />
						    <asp:DynamicControl Mode="Insert" DataField="Payment" runat="server" />
						    <asp:DynamicControl Mode="Insert" DataField="PaymentDate" runat="server" />
						    <asp:DynamicControl Mode="Insert" DataField="Comment" runat="server" />
						    <asp:DynamicControl Mode="Insert" DataField="Closed" runat="server" />
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
