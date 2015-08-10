<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddShipping.aspx.cs" Inherits="FrontierAg.Admin.Shippings.AddShipping" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Add Address</h3>
    <asp:ValidationSummary runat="server" ShowModelStateErrors="true" />
<asp:FormView runat="server" ID="addShippingForm"
    ItemType="FrontierAg.Models.Shipping" 
    InsertMethod="addShippingForm_InsertItem" DefaultMode="Insert"
    RenderOuterTable="True" OnItemInserted="addShippingForm_ItemInserted" CssClass="table table-striped table-bordered myTableWidth">
    <InsertItemTemplate>
        <fieldset>
            <ol>
                <asp:DynamicEntity runat="server" Mode="Insert" />
            </ol>
            <asp:Button runat="server" Text="Insert" CommandName="Insert" CssClass="btn btn-warning" />            
			<asp:button id="backButton" runat="server" text="Cancel" OnClientClick="JavaScript:window.history.back(1);return false;" CssClass="btn btn-warning" />						
        </fieldset>
    </InsertItemTemplate>
</asp:FormView>
    <script type="text/javascript">
        $(function () {
            $("[id*=ctl00_Label1]").hide();
            $("[id*=Contact_DropDownList1]").hide();
            //$("[id*=ctl14_Label1]").hide(); 
            //$("[id*=DateCreated_TextBox1]").hide();
        });
    </script>

</asp:Content>
