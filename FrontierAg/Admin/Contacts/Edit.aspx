﻿<%@ Page Title="ContactEdit" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Edit.aspx.cs" Inherits="FrontierAg.Contacts.Edit" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div>
		<p>&nbsp;</p>
        <asp:ValidationSummary runat="server" ShowModelStateErrors="true" />
        <asp:FormView runat="server"
            ItemType="FrontierAg.Models.Contact" DefaultMode="Edit" DataKeyNames="ContactId"
            UpdateMethod="UpdateItem" SelectMethod="GetItem"
            OnItemCommand="ItemCommand" RenderOuterTable="false">
            <EmptyDataTemplate>
                Cannot find the Contact with ContactId <%: Request.QueryString["ContactId"] %>
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
</asp:Content>

