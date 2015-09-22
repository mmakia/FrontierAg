<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FrontierAg.Admin.Orders.ToProcess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-2">
            <br />
            <br />
            <br />
            <h4>Refine Results by: </h4>
            <h4>Order Status
            </h4>                     
            <asp:DropDownList runat="server" AutoPostBack="true" ID="Status2" class="form-control" Width="150">
                <asp:ListItem Text="All" Value="" />
                <asp:ListItem Text="Cancelled" />
                <asp:ListItem Text="New" />
                <asp:ListItem Text="PartialShipment" />
                <asp:ListItem Text="Shipped" />
                <asp:ListItem Text="Closed" />
            </asp:DropDownList>
            <br />
            <h4>Product Category</h4>
            <asp:CheckBoxList ID="CheckBoxSelectCategory" runat="server" ItemType="FrontierAg.Models.Category" class="checkbox-inline" AutoPostBack="true" OnDataBound="CheckBoxListDivision_DataBound"
                SelectMethod="GetCategories" DataTextField="CategoryName" DataValueField="CategoryID" ViewStateMode="Enabled">
            </asp:CheckBoxList>
        </div>

        <div class="col-md-10">
            <h3>Orders
            </h3>
            <asp:Label ID="ErrorLbl" runat="server" ForeColor="Red" Font-Bold="True" BackColor="#FFCC66"></asp:Label>
            <br />
            <asp:GridView ID="OrdersList2" runat="server" AutoGenerateColumns="False" ItemType="FrontierAg.Models.Order" DataKeyNames="OrderId" SelectMethod="OrdersList_GetData" UpdateMethod="Orders_UpdateItem"
                AutoGenerateEditButton="True" CssClass="table table-striped table-bordered" EnableModelValidation="true" AllowSorting="true" AllowPaging="true" PageSize="35">
                <Columns>
                    <asp:DynamicField DataField="OrderId" HeaderText="ID" ReadOnly="true" />
                    <asp:DynamicField DataField="OrderDate" HeaderText="Order Date" ReadOnly="true" />

                    <asp:TemplateField HeaderText="Ordering Company">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" NavigateUrl='<%# Microsoft.AspNet.FriendlyUrls.FriendlyUrl.Href("~/Admin/Customers/Details", Item.CustomerId) %>' Text="<%#: Item.Customer.Company  %>" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Customer">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" OnClick="Unnamed_Click0" Text="Customer" CommandArgument="<%# Item.OrderId %>" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Billing">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" OnClick="Unnamed_Click1" Text="Bill To" CommandArgument="<%# Item.OrderId %>" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:DynamicField DataField="Total" HeaderText="SubTotal" ReadOnly="true" />
                    <asp:DynamicField DataField="Payment" HeaderText="Payment" ReadOnly="true" />
                    <asp:DynamicField DataField="Comment" HeaderText="Comment" />
                    <asp:DynamicField DataField="Status" HeaderText="Status" />
                    <asp:HyperLinkField Text="Process" DataNavigateUrlFormatString="~/Admin/OrderDetails/Default/{0}" DataNavigateUrlFields="OrderId" />
                    <asp:HyperLinkField Text="Shipments" DataNavigateUrlFormatString="~/Admin/Shipments/OpenShipment/{0}" DataNavigateUrlFields="OrderId" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div class="row">
        &nbsp;
    </div>
    <div class="form-group">
        <div>
            <asp:Button ID="backButton" runat="server" Text="Back" OnClientClick="JavaScript:window.history.back(1);return false;" CssClass="btn btn-warning" />
        </div>
    </div>
</asp:Content>
