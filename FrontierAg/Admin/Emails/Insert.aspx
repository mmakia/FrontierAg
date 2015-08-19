<%@ Page Title="EmailInsert" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Insert.aspx.cs" Inherits="FrontierAg.Admin.Emails.Insert" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">    
    <h3>Add Email Address</h3>
    <p>&nbsp;</p>
    <asp:FormView runat="server" ItemType="FrontierAg.Models.Email" DefaultMode="Insert" InsertItemPosition="FirstItem" InsertMethod="InsertItem"
        OnItemCommand="ItemCommand" RenderOuterTable="True" CssClass="table table-striped table-bordered">
        <InsertItemTemplate>
            <fieldset>
                <ol>
                    <asp:ValidationSummary runat="server" />
                    <asp:DynamicEntity Mode="Insert" runat="server" />                    
                </ol>
                <asp:Button runat="server" ID="InsertButton" CommandName="Insert" Text="Insert" CssClass="btn btn-warning"/>
                <asp:Button runat="server" ID="CancelButton" CommandName="Cancel" Text="Cancel" CausesValidation="false" CssClass="btn btn-warning"/>
            </fieldset>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>



