<%@ Page Title="Checkout Review" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckoutReview.aspx.cs" Inherits="FrontierAg.Checkout.CheckoutReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel runat="server" ID="UpdatePanel2">
        <ContentTemplate>

    <div id="CheckoutReviewTitle" runat="server" class="ContentHead"><h2>Checkout Review</h2></div>

    <div id="CheckoutReviewWrapper">

    <asp:GridView ID="CheckoutReviewList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        ItemType="FrontierAg.Models.CartItem" SelectMethod="GetShoppingCartItems" 
        CssClass="table table-striped table-bordered" >   
        <Columns>
        <asp:BoundField DataField="ProductID" HeaderText="ID" SortExpression="ProductID" />        
        <asp:BoundField DataField="Product.ProductName" HeaderText="Name" />        
        
        <asp:TemplateField HeaderText="Price (each)">
              <ItemTemplate>
                <asp:Label Text="<%#:  Item.ItemPrice %>" 
                    runat="server" />
              </ItemTemplate>
            </asp:TemplateField>
        <asp:TemplateField   HeaderText="Quantity">            
                <ItemTemplate>
                    <asp:Label Text="<%#: (Item.Quantity) %>"
                         runat="server" />
                </ItemTemplate>        
        </asp:TemplateField>                     
        </Columns>    
    </asp:GridView>

    <asp:FormView runat="server"
            ItemType="FrontierAg.Models.Contact" DataKeyNames="ContactId"
            SelectMethod="GetItem"
            OnItemCommand="ItemCommand" RenderOuterTable="false">
            <EmptyDataTemplate>
                Cannot find the Contact with ContactId <%: Request.QueryString["ContactId"] %>
            </EmptyDataTemplate>
            <ItemTemplate>
                <fieldset class="form-horizontal">
                    <legend>Contact Details</legend>
							
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Company</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="Company" ID="Company" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>LName</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="LName" ID="LName" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>FName</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="FName" ID="FName" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Address1</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="Address1" ID="Address1" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Address2</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="Address2" ID="Address2" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>City</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="City" ID="City" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>State</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="State" ID="State" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>PostalCode</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="PostalCode" ID="PostalCode" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Country</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="Country" ID="Country" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Primary Phone</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="PPhone" ID="PPhone" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Phone Type</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="PPType" ID="PPType" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Secondary Phone</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="SPhone" ID="SPhone" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Secondary Phone Type</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="SPType" ID="SPType" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Fax</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="Fax" ID="Fax" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>EMail</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="EMail" ID="EMail" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>WebSite</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="WebSite" ID="WebSite" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Comment</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="Comment" ID="Comment" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Contact Type</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="Type" ID="Type" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>DateCreated</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="DateCreated" ID="DateCreated" Mode="ReadOnly" />
								</div>
							</div>
                 	<div class="row">
					  &nbsp;
					</div>					
                </fieldset>
            </ItemTemplate>
        </asp:FormView>

    <asp:FormView runat="server"
            ItemType="FrontierAg.Models.Shipping" DataKeyNames="ShippingId"
            SelectMethod="GetItem2"
            OnItemCommand="ItemCommand" RenderOuterTable="false">
            <EmptyDataTemplate>
                Cannot find the Shipping with ShippingId <%: Request.QueryString["ShippingId"] %>
            </EmptyDataTemplate>
            <ItemTemplate>
                <fieldset class="form-horizontal">
                    <legend>Shipping Details</legend>							
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Address1</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="Address1" ID="Address1" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Address2</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="Address2" ID="Address2" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>City</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="City" ID="City" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>State</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="State" ID="State" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>PostalCode</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="PostalCode" ID="PostalCode" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Country</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="Country" ID="Country" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>ContactId</strong>
								</div>
								<div class="col-sm-4">
									<%#: Item.Contact != null ? Item.Contact.Company : "" %>
								</div>
                                <div class="col-sm-4">
									<%#: Item.Contact != null ? Item.Contact.LName : "" %>
								</div>
							</div>
                 	<div class="row">
					  &nbsp;
					</div>
					
                </fieldset>
            </ItemTemplate>
        </asp:FormView>
    <div>
        <p></p>
        <strong>
            <asp:Label ID="LabelTotalText" runat="server" Text="Order Total: "></asp:Label>
            <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
        </strong> 
    </div>
    <br />
        
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Transaction ID:"></asp:Label>
            </td>
            <td>
                &nbsp;<asp:TextBox ID="PaymentBox" runat="server" ></asp:TextBox>                
            </td>
        </tr>
        <tr>
            <td>    
                <asp:Label ID="Label2" runat="server" Text="Transaction ID Date: "></asp:Label>
            </td>    
            <td>
                &nbsp;<asp:TextBox ID="PaymentDateBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>    
                <asp:Label ID="Label3" runat="server" Text="Comment: "></asp:Label>
            </td>    
            <td>
                &nbsp;<asp:TextBox ID="CommentBox" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
    </table>   
    <br />
    <table> 
     <tr>      
      <td>
        <asp:Button ID="Button1" runat="server" Text="Cancel" OnClick="CancelBtn_Click" CssClass="btn btn-default"/>
      </td>
      <td>
        &nbsp;<asp:Button ID="PlaceOrderBtn" runat="server" Text="Place Order" OnClick="PlaceOrderBtn_Click" CssClass="btn btn-default"/>
      </td>
    </tr>
    </table>
         <br />
        </div>            
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
        <ProgressTemplate>
            <div class="PleaseWait">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/PleaseWait.gif"/>
                Processing...
            </div>
        </ProgressTemplate>   
    </asp:UpdateProgress>
    <script>
        $(function () {
            $('form').bind('submit', function ()
            {
                if(Page_IsValid)
                {
                    $('#CheckoutReviewWrapper').slideUp(3000);
                }
            });
          });
        function pageLoad()
        {
            $('.Attention').animate({ width: '600px' }, 3000).animate({ width: '100px' }, 3000).fadeIn('slow');
            
        }
    </script>
</asp:Content>