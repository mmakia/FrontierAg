<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddPrice.aspx.cs" Inherits="FrontierAg.Admin.Prices.AddPrice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Add Price</h3>
    <asp:ValidationSummary runat="server" ShowModelStateErrors="true" />
<asp:FormView runat="server" ID="addPriceForm"
    ItemType="FrontierAg.Models.Price" 
    InsertMethod="addPriceForm_InsertItem" DefaultMode="Insert"
    RenderOuterTable="True"  CssClass="table table-striped table-bordered">
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
            $("[id*=Product_DropDownList1]").hide();
            //$("[id*=ctl05_Label1]").hide();
            //$("[id*=DateCreated_TextBox1]").hide();
        });
    </script>
</asp:Content>
