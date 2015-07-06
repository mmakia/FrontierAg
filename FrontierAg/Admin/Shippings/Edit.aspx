<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="FrontierAg.Admin.Shippings.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
		<p>&nbsp;</p>
        <asp:ValidationSummary runat="server" ShowModelStateErrors="true" />
        <asp:FormView runat="server"
            ItemType="FrontierAg.Models.Shipping" DefaultMode="Edit" DataKeyNames="ShippingId"
            UpdateMethod="Unnamed_UpdateItem" SelectMethod="GetItem"
            OnItemCommand="ItemCommand" RenderOuterTable="false">
            <EmptyDataTemplate>
                Cannot find the Contact with ContactId <%: Request.QueryString["ShippingId"] %>
            </EmptyDataTemplate>
            <EditItemTemplate>
                <fieldset>
            <ol>
                <asp:DynamicEntity runat="server" Mode="Insert" />
            </ol>
            <asp:Button runat="server" Text="Update" CommandName="Update" CssClass="btn btn-warning" />            
			<asp:button id="backButton" runat="server" text="Cancel" OnClientClick="JavaScript:window.history.back(1);return false;" CssClass="btn btn-warning" />						
        </fieldset>
            </EditItemTemplate>
        </asp:FormView>
    </div>
    <script type="text/javascript">
        $(function () {
            $("[id*=ctl14_Label1]").hide();
            $("[id*=DateCreated_TextBox1]").hide();            
        });
    </script>
</asp:Content>
