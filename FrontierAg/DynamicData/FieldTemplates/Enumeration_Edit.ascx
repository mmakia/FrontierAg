<%@ Control Language="C#" CodeBehind="Enumeration_Edit.ascx.cs" Inherits="FrontierAg.Enumeration_EditField" %>

<asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" />

<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" CssClass="DDControl DDValidator" ControlToValidate="DropDownList1" Display="Static" Enabled="false" />
<asp:DynamicValidator runat="server" ID="DynamicValidator1" CssClass="DDControl DDValidator" ControlToValidate="DropDownList1" Display="Static" />

