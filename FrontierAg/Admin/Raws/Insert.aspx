<%@ Page Title="RawInsert" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Insert.aspx.cs" Inherits="FrontierAg.Admin.Raws.Insert" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <script>
        $(function () {
            $("#TXTBXDateReceived").datepicker();
            $("#TXTBXExpirationDate").datepicker();
            $('option:contains("AG_")').each(function () {
                $(this).html($('option:contains("AG_")').html().replace("AG_", ""));
            });
        });
    </script>
    <h3>Insert New Raw Material</h3>
    <div class="table-responsive">
        <table class="table">
            <tr>
                <td>
                    <asp:Label ID="LBLSelectProduct" runat="server" Text="Select Raw Material"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DDLSelectProduct" runat="server"
                        ItemType="FrontierAg.Models.Product"
                        SelectMethod="GetProducts" DataTextField="ProductNo"
                        DataValueField="ProductId" CssClass="form-control MyDropList2">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LBLManufacturer" runat="server" Text="Manufacturer"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TXTBXManufacturer" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="* Manufacturer name required." ControlToValidate="TXTBXManufacturer" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="LBLManufacturerLot" runat="server" Text="Manufacturer Lot#"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TXTBXManufacturerLot" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="* Manufacturer Lot# is required." ControlToValidate="TXTBXManufacturerLot" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LBLManufacturerPart" runat="server" Text="Manufacturer Part#"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TXTBXManufacturerPart" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="* Manufacturer Part # is required." ControlToValidate="TXTBXManufacturerPart" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LBLDateReceived" runat="server" Text="Date Received"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TXTBXDateReceived" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Text="* Date Received is required." ControlToValidate="TXTBXDateReceived" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Text="* Enter A Valid Date." ControlToValidate="TXTBXDateReceived" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td>

                    <asp:Label ID="LBLExpirationDate" runat="server" Text="Expiration Date"></asp:Label>
                </td>
                <td>

                    <asp:TextBox ID="TXTBXExpirationDate" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Text="* Enter A Valid Date" ControlToValidate="TXTBXExpirationDate" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="AddRAWButton" runat="server" Text="Insert" OnClick="AddRAWButton_Click" CssClass="btn btn-warning" />
                    <asp:Button ID="backButton" runat="server" Text="Back" OnClientClick="JavaScript:window.history.back(1);return false;" CssClass="btn btn-warning" />
                </td>
                <td>
                    <asp:Label ID="LabelAddStatus" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
