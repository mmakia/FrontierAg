<%@ Page Title="ContactDelete" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Delete.aspx.cs" Inherits="FrontierAg.Contacts.Delete" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div>
		<p>&nbsp;</p>
        <h3>Are you sure want to delete this Contact?</h3>
        <asp:FormView runat="server"
            ItemType="FrontierAg.Models.Contact" DataKeyNames="ContactId"
            DeleteMethod="DeleteItem" SelectMethod="GetItem"
            OnItemCommand="ItemCommand" RenderOuterTable="false">
            <EmptyDataTemplate>
                Cannot find the Contact with ContactId <%: Request.QueryString["ContactId"] %>
            </EmptyDataTemplate>
            <ItemTemplate>
                <fieldset class="form-horizontal">
                    <legend>Delete Contact</legend>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Contact ID</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="Contact_Identification" ID="Contact_Identification" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Company</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="Company" ID="Company" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>LName</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="LName" ID="LName" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>FName</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="FName" ID="FName" Mode="ReadOnly" />
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
									<strong>Primary Phone</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="PPhone" ID="PPhone" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Phone Type</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="PPType" ID="PPType" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Secondary Phone</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="SPhone" ID="SPhone" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Secondary Phone Type</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="SPType" ID="SPType" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Fax</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="Fax" ID="Fax" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>EMail</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="EMail" ID="EMail" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>WebSite</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="WebSite" ID="WebSite" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Comment</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="Comment" ID="Comment" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Contact Type</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="Type" ID="Type" Mode="ReadOnly" />
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

