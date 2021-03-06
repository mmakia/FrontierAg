﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FrontierAg.Admin.Categories.Default"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">    

    <div id="OpenOrderTitle" runat="server" class="ContentHead"><h3>Categories</h3></div>
    <asp:HyperLink NavigateUrl="~/Admin/Categories/AddCategory" Text="Add New Category" runat="server" />
    <asp:ValidationSummary ShowModelStateErrors="true" runat="server" />
    <asp:GridView ID="CategoriesList" runat="server" AutoGenerateColumns="False" ItemType="FrontierAg.Models.Category" DataKeyNames="CategoryId" SelectMethod="CategoriesList_GetData" UpdateMethod="CategoriesList_UpdateData"     
    AutoGenerateEditButton="True" CssClass="table table-striped table-bordered" EnableModelValidation="true" DeleteMethod="CategoriesList_DeleteItem" >
        <Columns>                  
        <asp:DynamicField DataField="CategoryId" HeaderText="Category ID" ReadOnly="true"/>        
        <asp:DynamicField DataField="CategoryName" HeaderText="Category Name" />
        <asp:DynamicField DataField="DateCreated" HeaderText="Date Created" ReadOnly="true" />                  
             

            
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
    

</asp:Content>

