<%@ Page Title="Po Details" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Details.aspx.cs" Inherits="FrontierAg.Pos.Details" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div>
		<p>&nbsp;</p>
      
        <asp:FormView runat="server"
            ItemType="FrontierAg.Models.Po" DataKeyNames="PoId"
            SelectMethod="GetItem"
            OnItemCommand="ItemCommand" RenderOuterTable="false">
            <EmptyDataTemplate>
                Cannot find the Po with PoId <%: Request.QueryString["PoId"] %>
            </EmptyDataTemplate>
            <ItemTemplate>
                <fieldset class="form-horizontal">
                    <legend>Po Details</legend>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>PoId</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="PoId" ID="PoId" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>PO Number</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="PoNumber" ID="PoNumber" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Company</strong>
								</div>
								<div class="col-sm-4">
									<%#: Item.Contact != null ? Item.Contact.Company : "" %>
								</div>
                             </div>
                             <div class="row">
								<div class="col-sm-2 text-right">
									<strong>LName</strong>
								</div>
                                <div class="col-sm-4">
									<%#: Item.Contact != null ? Item.Contact.LName : "" %>
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

