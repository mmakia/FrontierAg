<%@ Page Title="CustomerInsert" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Insert.aspx.cs" Inherits="FrontierAg.Admin.Customers.Insert" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <p>&nbsp;</p>
        <asp:FormView runat="server"
            ItemType="FrontierAg.Models.Customer" DefaultMode="Insert"
            InsertItemPosition="FirstItem" InsertMethod="InsertItem"
            OnItemCommand="ItemCommand" RenderOuterTable="false">
            <InsertItemTemplate>
                <fieldset class="form-horizontal">
                    <legend>Insert Customer</legend>
                    <asp:ValidationSummary runat="server" CssClass="alert alert-danger" />
                    <asp:DynamicControl Mode="Insert" DataField="Company" runat="server" />
                    <asp:DynamicControl Mode="Insert" DataField="FName" runat="server" />
                    <asp:DynamicControl Mode="Insert" DataField="LName" runat="server" />
                    <asp:DynamicControl Mode="Insert" DataField="Address1" runat="server" />
                    <asp:DynamicControl Mode="Insert" DataField="Address2" runat="server" />
                    <asp:DynamicControl Mode="Insert" DataField="City" runat="server" />
                    <asp:DynamicControl Mode="Insert" DataField="State" runat="server" />
                    <asp:DynamicControl Mode="Insert" DataField="PostalCode" runat="server" />
                    <asp:DynamicControl Mode="Insert" DataField="Country" runat="server" />
                    <asp:DynamicControl Mode="Insert" DataField="PPhone" runat="server" />
                    <asp:DynamicControl Mode="Insert" DataField="PPType" runat="server" />
                    <asp:DynamicControl Mode="Insert" DataField="SPhone" runat="server" />
                    <asp:DynamicControl Mode="Insert" DataField="SPType" runat="server" />
                    <asp:DynamicControl Mode="Insert" DataField="Fax" runat="server" />
                    <asp:DynamicControl Mode="Insert" DataField="EMail" runat="server" />
                    <asp:DynamicControl Mode="Insert" DataField="WebSite" runat="server" />
                    <asp:DynamicControl Mode="Insert" DataField="Comment" runat="server" />
                    <asp:DynamicControl Mode="Insert" DataField="DateCreated" runat="server" />
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
