<%@ Page Title="ContactInsert" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Insert.aspx.cs" Inherits="FrontierAg.Contacts.Insert" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h3>Insert Unique Company Name:</h3>
    <div>
        <p>&nbsp;</p>
        <asp:ValidationSummary runat="server" ShowModelStateErrors="true" />
        <asp:Label runat="server" ID="MessageLbl"></asp:Label>
        <asp:FormView runat="server" ItemType="FrontierAg.Models.Contact" DefaultMode="Insert"
            InsertItemPosition="FirstItem" InsertMethod="InsertItem"
            OnItemCommand="ItemCommand" RenderOuterTable="True" CssClass="table table-striped table-bordered">
            <InsertItemTemplate>
                <fieldset>
                    <ol>
                        <asp:DynamicEntity runat="server" Mode="Insert" />
                    </ol>
                    <asp:Button runat="server" Text="Insert" CommandName="Insert" CssClass="btn btn-warning" />
                    <asp:Button ID="backButton" runat="server" Text="Cancel" OnClientClick="JavaScript:window.history.back(1);return false;" CssClass="btn btn-warning" />
                </fieldset>
            </InsertItemTemplate>
        </asp:FormView>
        <asp:Label ID="Label1" runat="server" Text="Label">For customers, Default Shipping Address will be created automatically</asp:Label>
    </div>
    <%--<div id="dialog" style="display: none">
    This is a simple popup
</div>
    <script type="text/javascript">
    $("[id*=btnPopup]").on("click", function () {
        $("#dialog").dialog({
            title: "jQuery Dialog Popup",
            buttons: {
                Close: function () {
                    $(this).dialog('close');
                }
            }
        });
        return false;
    });
</script>--%>
</asp:Content>
