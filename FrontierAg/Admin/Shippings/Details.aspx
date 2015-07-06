<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="FrontierAg.Admin.Shippings.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Address</h3>    
    <div>
        <asp:ValidationSummary ShowModelStateErrors="true" runat="server" />
        <asp:GridView runat="server" ID="ShippingsGrid2"
        ItemType="FrontierAg.Models.Shipping" DataKeyNames="ShippingId"  
        SelectMethod="ShippingsGrid_GetData"  CssClass="table table-striped table-bordered" EnableModelValidation="true" 
        AutoGenerateColumns="false" >
        <Columns>
            <%--<asp:TemplateField HeaderText="Contact ID">
              <ItemTemplate>
                <asp:Label Text="<%# Item.Contact.ContactId %>" 
                    runat="server" />
              </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:BoundField DataField="ShippingId" HeaderText="Id" ReadOnly="true" />
            <asp:BoundField DataField="Company"  HeaderText="Company"/>
            <asp:BoundField DataField="FName"  HeaderText="FName"/>
            <asp:BoundField DataField="LName" HeaderText="LName" />
            <asp:BoundField DataField="Other1" HeaderText="Other2" />
            <asp:BoundField DataField="Other2" HeaderText="Other2" />
            <asp:BoundField DataField="Address1" HeaderText="Address1" />
            <asp:BoundField DataField="Address2" HeaderText="Address2"/>
            <asp:BoundField DataField="City" HeaderText="City"/>
            <asp:BoundField DataField="State" HeaderText="State"/>                 
            <asp:BoundField DataField="PostalCode" HeaderText="PostalCode"/>                 
            <asp:BoundField DataField="Country" HeaderText="Country"/>  
            <asp:BoundField DataField="PPhone"  HeaderText="Phone"/>   
            <asp:BoundField DataField="EMail" HeaderText="Email"/>                                
            <%--<asp:BoundField DataField="SType" /> --%>   
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
