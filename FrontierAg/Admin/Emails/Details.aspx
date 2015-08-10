<%@ Page Title="Email Details" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Details.aspx.cs" Inherits="FrontierAg.Admin.Emails.Details" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div>
		<p>&nbsp;</p>
      
        <asp:FormView runat="server"
            ItemType="FrontierAg.Models.Email" DataKeyNames="EmailId"
            SelectMethod="GetItem"
            OnItemCommand="ItemCommand" RenderOuterTable="false">
            <EmptyDataTemplate>
                Cannot find the Email with EmailId <%: Request.QueryString["EmailId"] %>
            </EmptyDataTemplate>
            <ItemTemplate>
                <fieldset class="form-horizontal">
                    <legend>Email Details</legend>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>EmailAddress</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="EmailAddress" ID="EmailAddress" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>isForOrder</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="isForOrder" ID="isForOrder" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>isForShipment</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="isForShipment" ID="isForShipment" Mode="ReadOnly" />
								</div>
							</div>
                 	<div class="row">
					  &nbsp;
					</div>
					<div class="form-group">
						<div class="col-sm-offset-2 col-sm-10">
							<asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Back" CssClass="btn btn-default" />
						</div>
					</div>
                </fieldset>
            </ItemTemplate>
        </asp:FormView>
    </div>
</asp:Content>

