<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="FrontierAg.Admin.Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">    

    <div id="OpenOrderTitle" runat="server" class="ContentHead"><h2>Categories</h2></div>
    <asp:HyperLink NavigateUrl="~/Admin/AddCategory" Text="Add New Category" runat="server" />
    <asp:ValidationSummary ShowModelStateErrors="true" runat="server" />
    <asp:GridView ID="CategoriesList" runat="server" AutoGenerateColumns="False" ItemType="FrontierAg.Models.Category" DataKeyNames="CategoryId" SelectMethod="CategoriesList_GetData" UpdateMethod="CategoriesList_UpdateData"     
    AutoGenerateEditButton="True" CssClass="table table-striped table-bordered" EnableModelValidation="true" >
        <Columns>                  
        <asp:DynamicField DataField="CategoryId" HeaderText="Category ID" ReadOnly="true"/>        
        <asp:DynamicField DataField="CategoryName" HeaderText="Category Name" />
        <asp:DynamicField DataField="DateCreated" HeaderText="Date Created" ReadOnly="true" />                  
             

            
        </Columns>        
    </asp:GridView>
         
    
    

</asp:Content>

