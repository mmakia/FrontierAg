﻿<%@ Page Title="EmailList" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="FrontierAg.Admin.Emails.Default" %>

<%@ Register TagPrefix="FriendlyUrls" Namespace="Microsoft.AspNet.FriendlyUrls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Emails List</h2>
    <p>
        <asp:HyperLink runat="server" NavigateUrl="Insert" Text="Create new" />
    </p>

    <asp:GridView runat="server" ID="EmailsGrid" CssClass="table table-striped table-bordered"
        ItemType="FrontierAg.Models.Email" DataKeyNames="EmailId" AutoGenerateEditButton="true" AutoGenerateDeleteButton="true"
        SelectMethod="GetData" UpdateMethod="EmailsGrid_UpdateItem" DeleteMethod="EmailsGrid_DeleteItem"
        AutoGenerateColumns="false">
        <Columns>
            <%--<asp:DynamicField DataField="StudentID" />--%>
            <asp:DynamicField DataField="EmailAddress" />
            <asp:DynamicField DataField="isForOrder"  />
            <asp:DynamicField DataField="isForShipment"  />

        </Columns>
    </asp:GridView>
    <div class="row">
        &nbsp;
    </div>
    <div class="form-group">
        <div>
            <asp:Button ID="backButton" runat="server" Text="Back" OnClientClick="JavaScript:window.history.back(1);return false;" CssClass="btn btn-warning" />
        </div>
    </div>
    </div>
</asp:Content>