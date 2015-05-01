<%@ Page Title="ContactEdit" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Edit.aspx.cs" Inherits="FrontierAg.Contacts.Edit" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div>
		<p>&nbsp;</p>
        <asp:FormView runat="server"
            ItemType="FrontierAg.Models.Contact" DefaultMode="Edit" DataKeyNames="ContactId"
            UpdateMethod="UpdateItem" SelectMethod="GetItem"
            OnItemCommand="ItemCommand" RenderOuterTable="false">
            <EmptyDataTemplate>
                Cannot find the Contact with ContactId <%: Request.QueryString["ContactId"] %>
            </EmptyDataTemplate>
            <EditItemTemplate>
                <fieldset class="form-horizontal">
                    <legend>Edit Contact</legend>
					<asp:ValidationSummary runat="server" CssClass="alert alert-danger"  />                 
						    <asp:DynamicControl Mode="Edit" DataField="Contact_Identification" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="Company" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="LName" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="FName" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="Address1" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="Address2" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="City" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="State" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="PostalCode" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="Country" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="PPhone" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="PPType" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="SPhone" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="SPType" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="Fax" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="EMail" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="WebSite" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="Comment" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="Type" runat="server" />
						    <asp:DynamicControl Mode="Edit" DataField="DateCreated" runat="server" />
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

