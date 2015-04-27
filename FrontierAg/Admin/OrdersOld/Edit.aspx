<%@ Page Title="OrderEdit" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Edit.aspx.cs" Inherits="FrontierAg.Orders.Edit" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div>
		<p>&nbsp;</p>
        <asp:FormView runat="server"
            ItemType="FrontierAg.Models.Order" DefaultMode="Edit" DataKeyNames="OrderId"
            UpdateMethod="UpdateItem" SelectMethod="GetItem"
            OnItemCommand="ItemCommand" RenderOuterTable="false">
            <EmptyDataTemplate>
                Cannot find the Order with OrderId <%: Request.QueryString["OrderId"] %>
            </EmptyDataTemplate>
            <EditItemTemplate>
                <fieldset class="form-horizontal">
                    <legend>Edit Order</legend>
                    
					<asp:ValidationSummary runat="server" CssClass="alert alert-danger"  />                 
						    <asp:DynamicControl Mode="Edit" DataField="OrderDate" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="Total" runat="server" />						
							<asp:DynamicControl Mode="Edit" 
								DataField="ContactId" 
								DataTypeName="FrontierAg.Models.Contact" 
								DataTextField="Contact_Identification" 
								DataValueField="ContactId" 
								UIHint="ForeignKey" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="Payment" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="PaymentDate" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="Closed" runat="server" />
                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
							<asp:Button runat="server" ID="UpdateButton" CommandName="Update" Text="Update" CssClass="btn btn-primary" />
							<asp:Button runat="server" ID="CancelButton" CommandName="Cancel" Text="Cancel" CausesValidation="false" CssClass="btn btn-default" />
						</div>
					</div>
                </fieldset>
            </EditItemTemplate>
        </asp:FormView>
    </div>
</asp:Content>

