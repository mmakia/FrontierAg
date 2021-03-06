﻿<%@ Page Title="ProductList" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Default.aspx.cs" Inherits="FrontierAg.Admin.Shippings.Default" %>
<%@ Register TagPrefix="FriendlyUrls" Namespace="Microsoft.AspNet.FriendlyUrls" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <h3>Addresses List</h3>
    <p>
        <asp:HyperLink runat="server" NavigateUrl="~/Admin/Shippings/AddShipping" Text="Create new" />
       <%-- <asp:LinkButton runat="server" Onclick="Unnamed_Click" Text="Create new" />        --%>
    </p>
    <div>
        <asp:ValidationSummary ShowModelStateErrors="true" runat="server" />
        <asp:GridView runat="server" ID="ShippingsGrid"
        ItemType="FrontierAg.Models.Shipping" DataKeyNames="ShippingId" AutoGenerateEditButton="true" UpdateMethod="ShippingsGrid_UpdateItem" 
        SelectMethod="ShippingsGrid_GetData"  CssClass="table table-striped table-bordered" EnableModelValidation="true" DeleteMethod="ShippingsGrid_DeleteItem"
        AutoGenerateColumns="false" >
        <Columns>
            <asp:TemplateField HeaderText="Contact ID">
              <ItemTemplate>
                <asp:Label Text="<%# Item.Contact.ContactId %>" 
                    runat="server" />
              </ItemTemplate>
            </asp:TemplateField>  
            <asp:DynamicField DataField="ShippingId" ReadOnly="true" />
            <asp:DynamicField DataField="Company"  />
            <asp:DynamicField DataField="FName"  />
            <asp:DynamicField DataField="LName"  />
            <asp:DynamicField DataField="Other1"  />
            <asp:DynamicField DataField="Other2"  />
            <asp:DynamicField DataField="Address1"  />
            <asp:DynamicField DataField="Address2" />
            <asp:DynamicField DataField="City" />
            <asp:DynamicField DataField="State" />                 
            <asp:DynamicField DataField="PostalCode" />                 
            <asp:DynamicField DataField="Country" />  
            <asp:DynamicField DataField="PPhone"  />   
            <asp:DynamicField DataField="SType" />                                
        </Columns>
        </asp:GridView>
        <div class="row">
					  &nbsp;
					</div>
					<div class="form-group">
						<div>
							<asp:button id="backButton" runat="server" text="Back" OnClientClick="JavaScript:window.history.back(1);return false;" CssClass="btn btn-warning" />	
					</div>
		</div>
    </div>
</asp:Content>

