<%@ Page Title="Checkout Review" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckoutReview.aspx.cs" Inherits="FrontierAg.Checkout.CheckoutReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">   
     <script type="text/javascript">
         $(function () {
             //$(alert("load"))            
                          
             $(function () {
                 $("#PaymentDateBox").datepicker();
             });
         });

         //JS code to be executed after partial postback due to updatepanel
         var prm = Sys.WebForms.PageRequestManager.getInstance();

         prm.add_endRequest(function () {
             //$(alert("Post back"))             
                          
             $(function () {
                 $("#PaymentDateBox").datepicker();
             });
         });

         //function validate() {
         //    var button = document.getElementById("myHiddenBtn");

         //    $('.form-control.PFee').on('input', function () {
         //        var input = $(this);
         //        var re = /^\d+(\.\d\d)?$/;
         //        var is_price = re.test(input.val());
         //        if (is_price) {
         //            $(".error_msg").html("");
         //            input.removeClass("invalid").addClass("valid");
         //            button.click();
         //        }
         //        else {
         //            $(".error_msg").html("Please enter Payment #");
         //            input.removeClass("valid").addClass("invalid");
         //        }
         //    });
         //}

         function FillingPaymentNo() {             
                 var inpVal = $(".PaymentBox").val();
                 var input3 = $(".PaymentBox");
                 if (jQuery.trim(inpVal).length > 0) {                     
                     $(".error_msg").html("");
                     input3.removeClass("invalid").addClass("valid");
                     return true;
                 }
                 else {
                     $(".error_msg").html("Please enter a Payment#");                     
                     input3.removeClass("valid").addClass("invalid");
                     return false;
                 }             
         }         
    </script>    
    <asp:UpdatePanel runat="server" ID="UpdatePanel2">
        <ContentTemplate>
    <div id="CheckoutReviewTitle" runat="server" class="ContentHead"><h3>Checkout Review</h3></div>

    <div id="CheckoutReviewWrapper">
    <asp:GridView ID="CheckoutReviewList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        ItemType="FrontierAg.Models.CartItem" SelectMethod="GetShoppingCartItems" 
        CssClass="table table-striped table-bordered" >   
        <Columns>
        <asp:BoundField DataField="ProductID" HeaderText="ID" SortExpression="ProductID" />         
        <asp:BoundField DataField="Product.ProductNo" HeaderText="Product No." />        
        <asp:BoundField DataField="Product.ProductName" HeaderText="Name" /> 
        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />  
        <asp:BoundField DataField="Unit" HeaderText="Unit" />         
        <asp:BoundField DataField="OriginalPrice" HeaderText="Original Price" />
        <asp:BoundField DataField="ItemPrice" HeaderText="Price Override" />      
        <asp:TemplateField HeaderText="Item Total">            
                <ItemTemplate>                    
                    <%#: Item.Quantity *  Item.ItemPrice  %>
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
                    <legend>Ordering Customer</legend>
							
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
                    <legend>Shipping To</legend>	
                    <div class="row">
							<div class="col-sm-2 text-right">
									<strong>Company</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="Company" ID="DynamicControl2" Mode="ReadOnly" />
								</div>
							</div>
                            <div class="row">
								<div class="col-sm-2 text-right">
									<strong>LName</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="LName" ID="DynamicControl1" Mode="ReadOnly" />
								</div>
							</div>			
                            <div class="row">
								<div class="col-sm-2 text-right">
									<strong>FName</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="FName" ID="DynamicControl3" Mode="ReadOnly" />
								</div>
							</div>	
                             <div class="row">
								<div class="col-sm-2 text-right">
									<strong>Other1</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="Other1" ID="DynamicControl4" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Other2</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="Other2" ID="DynamicControl5" Mode="ReadOnly" />
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
                </fieldset>
            </ItemTemplate>
        </asp:FormView>      

    <asp:FormView runat="server"
            ItemType="FrontierAg.Models.Shipping" DataKeyNames="ShippingId"
            SelectMethod="GetItem3"
            OnItemCommand="ItemCommand" RenderOuterTable="false">
            <EmptyDataTemplate>
                Cannot find the Shipping with ShippingId <%: Request.QueryString["ShippingId"] %>
            </EmptyDataTemplate>
            <ItemTemplate>
                <fieldset class="form-horizontal">
                    <legend>Billing Address</legend>	
                    <div class="row">
							<div class="col-sm-2 text-right">
									<strong>Company</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="Company" ID="DynamicControl2" Mode="ReadOnly" />
								</div>
							</div>
                            <div class="row">
								<div class="col-sm-2 text-right">
									<strong>LName</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="LName" ID="DynamicControl1" Mode="ReadOnly" />
								</div>
							</div>			
                            <div class="row">
								<div class="col-sm-2 text-right">
									<strong>FName</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="FName" ID="DynamicControl3" Mode="ReadOnly" />
								</div>
							</div>		
                    <div class="row">
								<div class="col-sm-2 text-right">
									<strong>Other1</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="Other1" ID="DynamicControl4" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Other2</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="Other2" ID="DynamicControl5" Mode="ReadOnly" />
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
                </fieldset>
            </ItemTemplate>
        </asp:FormView>      
            <br />       
        
    <table>        
        
            
        <legend></legend>
        <tr>
            <td>
                <asp:Label ID="OTotalLbl" runat="server" Text="Total: "></asp:Label>            
            </td>
            <td>
               &nbsp; <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
            </td>
        </tr>                
        
        <tr>
            <td>
                <asp:Label ID="PaymentLbl" runat="server" Text="Payment: " ></asp:Label>  
            </td>
            <td>
                &nbsp;<asp:TextBox ID="PaymentBox" runat="server" CSSClass="form-control PaymentBox"></asp:TextBox>                
            </td>
        </tr>
        <tr>
            <td>    
                <asp:Label ID="PaymentDateLbl" runat="server" Text="Payment Date: "></asp:Label>&nbsp;
            </td>    
             
            <td>                              
                &nbsp; <asp:TextBox ID="PaymentDateBox" runat="server" ClientIDMode="Static" CSSClass="form-control"></asp:TextBox>
                
            </td>
        </tr>        
        <tr>
            <td>    
                <asp:Label ID="CommentLbl" runat="server" Text="Comment: "></asp:Label>
            </td>    
            <td>
                &nbsp;<asp:TextBox ID="CommentBox" runat="server" TextMode="MultiLine" CSSClass="form-control"></asp:TextBox>
            </td>
        </tr>   
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        </table>

        </div>

        <table>            
            <tr>      
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Cancel" OnClick="CancelBtn_Click" CssClass="btn btn-warning"/>
                </td>
                <td>
                    &nbsp;<asp:Button ID="PlaceOrderBtn" runat="server" Text="Place Order"  CssClass="btn btn-warning PlaceOrderButton" onclientclick="javascript:return FillingPaymentNo();" OnClick="PlaceOrderBtn_Click"/> 
                        
                </td>
                <td>
                    <span class="error_msg" style="color: red; margin-left: 10px;" ></span>
                </td>
            </tr>
    </table>            
         <br />               
       </ContentTemplate>
    </asp:UpdatePanel>
 <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
        <ProgressTemplate>
            <div class="PleaseWait">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/PleaseWait.gif"/>
                Processing...
            </div>
        </ProgressTemplate>   
    </asp:UpdateProgress>   --%>   
    <%--<script>
        $(function () {
            $('form').bind('submit', function () {
                if (Page_IsValid) {
                    $('#CheckoutReviewWrapper').slideUp(3000);
                }
            });
        });        
    </script>--%>
   
</asp:Content>