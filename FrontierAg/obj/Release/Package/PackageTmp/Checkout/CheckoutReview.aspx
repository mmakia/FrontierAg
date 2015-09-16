<%@ Page Title="Checkout Review" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckoutReview.aspx.cs" Inherits="FrontierAg.Checkout.CheckoutReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function () {
            //$(alert("load"))            
            //ModalPopup();                       
            $("#PaymentDateBox").datepicker();
            $("#StartTxb").datepicker();
            $("#EndTxb").datepicker();

            isPayment();
            var input4 = $(".PaymentBox");
            $(input4).on("input", function () {
                //$(alert("1"));
                isPayment();
            });
        });


        //JS code to be executed after partial postback due to updatepanel
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            //$(alert("Post back"))
            $(function () {
                //ModalPopup();
                isPayment();
                $("#PaymentDateBox").datepicker();
                var input4 = $(".PaymentBox");
                $(input4).on("input", function () {
                    //$(alert("1"));
                    isPayment();
                });
            });
        });

        function validate() {
            var txtDate = $("#PaymentDateBox").val();
            if (isPayment() && isDateOptional(txtDate)) {
                //$(alert("3"));
                return true;
            }
            else {
                return false;
            }
        }       

        function isPayment() {
            //$(alert("FillingPaymentNo"));
            var inpVal = $(".PaymentBox").val();
            var input3 = $(".PaymentBox");
            if (jQuery.trim(inpVal).length > 0) {
                $(".error_msg").html("");
                input3.removeClass("invalid").addClass("valid");
                return true;
            }
            else {
                $(".error_msg").html("Please enter Payment Information");
                input3.removeClass("valid").addClass("invalid");
                return false;
            }
        }

        function validate2() {
            var StartTxbVal = $("#StartTxb").val();
            var EndTxbVal = $("#EndTxb").val();

            //var startDate = new Date($('#startDate').val());
            //var endDate = new Date($('#endDate').val());    


        if (isDateMust(StartTxbVal) && isDateMust(EndTxbVal) && StartTxbVal < EndTxbVal) {
                //$(alert("Post back3"));                
                return true;
            }
            else return false;
        }

        function ModalPopup() {
            //$("[id*=isSOCheckBox]").on("click", function () {
            if (isPayment()) {
                 $("#CalendarDialog").dialog({
                    appendTo: "form",
                    modal: true,
                    title: "Standing Order",
                    width: 'auto'
                });
                //dlg.parent().appendTo(jQuery("form:first"));
                return false;
            }
            //});
        }

        function validate3() {
            if ($("#isSOCheckBox").is(':checked')) {                
                $('#EmlOrdrngCstmrChkBx').attr('checked', false);
                $('#EmlShpToCstmrChkBx').attr('checked', false);
                //$(alert("Post back"));                
                ModalPopup();
            }

            //$("#CalendarDialog").dialog('close');
        }

        function isDateMust(txtDate) {
            var currVal = jQuery.trim(txtDate);
            if (currVal == '')
                return false;
            //Declare Regex 
            var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
            var dtArray = currVal.match(rxDatePattern); // is format OK?
            if (dtArray == null)
                return false;
            //Checks for mm/dd/yyyy format.
            dtMonth = dtArray[1];
            dtDay = dtArray[3];
            dtYear = dtArray[5];
            if (dtMonth < 1 || dtMonth > 12)
                return false;
            else if (dtDay < 1 || dtDay > 31)
                return false;
            else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31)
                return false;
            else if (dtMonth == 2) {
                var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
                if (dtDay > 29 || (dtDay == 29 && !isleap))
                    return false;
            }
            return true;
        }

        function isDateOptional(txtDate) {
            var currVal = jQuery.trim(txtDate);
            if (currVal == '')
                return true;
            //Declare Regex 
            var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
            var dtArray = currVal.match(rxDatePattern); // is format OK?
            if (dtArray == null)
                return false;
            //Checks for mm/dd/yyyy format.
            dtMonth = dtArray[1];
            dtDay = dtArray[3];
            dtYear = dtArray[5];
            if (dtMonth < 1 || dtMonth > 12)
                return false;
            else if (dtDay < 1 || dtDay > 31)
                return false;
            else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31)
                return false;
            else if (dtMonth == 2) {
                var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
                if (dtDay > 29 || (dtDay == 29 && !isleap))
                    return false;
            }
            return true;
        }
        function CloseDialog() {
            $("#CalendarDialog").dialog('close');
        }
    </script>
    <asp:UpdatePanel runat="server" ID="UpdatePanel2">
        <ContentTemplate>
            <div id="CheckoutReviewTitle" runat="server" class="ContentHead">
                <h3>Checkout Review</h3>
            </div>

            <div id="CheckoutReviewWrapper">
                <asp:GridView ID="CheckoutReviewList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
                    ItemType="FrontierAg.Models.CartItem" SelectMethod="GetShoppingCartItems"
                    CssClass="table table-striped table-bordered">
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
                            <legend>Ordering Company</legend>

                            <div class="row">
                                <div class="col-sm-2 text-right">
                                    <strong>Company</strong>
                                </div>
                                <div class="col-sm-4">
                                    <asp:DynamicControl runat="server" DataField="Company" ID="Company" Mode="ReadOnly" />
                                </div>
                            </div>
                            <%--<div class="row">
                                <div class="col-sm-2 text-right">
                                    <strong>FName</strong>
                                </div>
                                <div class="col-sm-4">
                                    <asp:DynamicControl runat="server" DataField="FName" ID="FName" Mode="ReadOnly" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-2 text-right">
                                    <strong>LName</strong>
                                </div>
                                <div class="col-sm-4">
                                    <asp:DynamicControl runat="server" DataField="LName" ID="LName" Mode="ReadOnly" />
                                </div>
                            </div>--%>

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
                            <%--<div class="row">
                                <div class="col-sm-2 text-right">
                                    <strong>Phone Type</strong>
                                </div>
                                <div class="col-sm-4">
                                    <asp:DynamicControl runat="server" DataField="PPType" ID="PPType" Mode="ReadOnly" />
                                </div>
                            </div>--%>
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
                                    <strong>Email</strong>
                                </div>
                                <div class="col-sm-4">
                                    <asp:DynamicControl runat="server" DataField="EMail" ID="Email" Mode="ReadOnly" />
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
                    SelectMethod="GetItem1"
                    OnItemCommand="ItemCommand" RenderOuterTable="false">
                    <EmptyDataTemplate>
                        Cannot find the Shipping with ShippingId <%: Request.QueryString["ShippingId"] %>
                    </EmptyDataTemplate>
                    <ItemTemplate>
                        <fieldset class="form-horizontal">
                            <legend>Ordering Customer</legend>
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
                                    <strong>FName</strong>
                                </div>
                                <div class="col-sm-4">
                                    <asp:DynamicControl runat="server" DataField="FName" ID="DynamicControl3" Mode="ReadOnly" />
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
                            <div class="row">
                                <div class="col-sm-2 text-right">
                                    <strong>EMail</strong>
                                </div>
                                <div class="col-sm-4">
                                    <asp:DynamicControl runat="server" DataField="EMail" ID="EMail" Mode="ReadOnly" />
                                </div>
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
                                    <strong>FName</strong>
                                </div>
                                <div class="col-sm-4">
                                    <asp:DynamicControl runat="server" DataField="FName" ID="DynamicControl3" Mode="ReadOnly" />
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
                            <div class="row">
                                <div class="col-sm-2 text-right">
                                    <strong>EMail</strong>
                                </div>
                                <div class="col-sm-4">
                                    <asp:DynamicControl runat="server" DataField="EMail" ID="EMail" Mode="ReadOnly" />
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
                            <legend>Billing To</legend>
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
                                    <strong>FName</strong>
                                </div>
                                <div class="col-sm-4">
                                    <asp:DynamicControl runat="server" DataField="FName" ID="DynamicControl3" Mode="ReadOnly" />
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
                            <div class="row">
                                <div class="col-sm-2 text-right">
                                    <strong>EMail</strong>
                                </div>
                                <div class="col-sm-4">
                                    <asp:DynamicControl runat="server" DataField="EMail" ID="EMail" Mode="ReadOnly" />
                                </div>
                            </div>
                        </fieldset>
                    </ItemTemplate>
                </asp:FormView>
                <br />

                <table>
                    <div class="form-horizontal">
                        <div class="form-group">
                            <legend></legend>
                            <tr>
                                <td>
                                    <asp:Label ID="OTotalLbl" runat="server" for="LblTotal" class="control-label">Order Total: </asp:Label>
                                </td>
                                <td>&nbsp;
                                    <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="PaymentLbl" runat="server" for="PaymentBox" class="control-label">Payment: </asp:Label>
                                </td>
                                <td>&nbsp;<asp:TextBox ID="PaymentBox" runat="server" CssClass="form-control PaymentBox"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="CommentLbl" runat="server" for="CommentBox" class="control-label">Comment: </asp:Label>
                                </td>
                                <td>&nbsp;<asp:TextBox ID="CommentBox" runat="server" TextMode="MultiLine" CssClass="form-control commentBox"></asp:TextBox>
                                </td>
                            </tr>
                            <%--<tr>
                                <td>
                                    <asp:Label ID="PaymentDateLbl" runat="server" for="PaymentDateBox" class="control-label">Date: </asp:Label>&nbsp;
                                </td>

                                <td>&nbsp;
                                    <asp:TextBox ID="PaymentDateBox" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>

                                </td>
                            </tr>--%>
                            
                            <tr>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="isSOLbl" runat="server">Standing Order:</asp:Label>
                                </td>
                                <td>&nbsp;
                                    <asp:CheckBox runat="server" ID="isSOCheckBox" AutoPostBack="false" ClientIDMode="Static" OnClick="javascript:return validate3();" />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server">Email Ordering Customer:</asp:Label>
                                </td>
                                <td>&nbsp;
                                    <asp:CheckBox runat="server" ID="EmlOrdrngCstmrChkBx" AutoPostBack="false" ClientIDMode="Static"  />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" >Email ShipTo Customer:</asp:Label>
                                </td>
                                <td>&nbsp;
                                    <asp:CheckBox runat="server" ID="EmlShpToCstmrChkBx" AutoPostBack="false" ClientIDMode="Static" Checked="True" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;
                                </td>
                            </tr>

                            <tr>
                                <td>&nbsp;
                                </td>
                            </tr>
                        </div>
                    </div>
                </table>

            </div>

            <div id="CalendarDialog" style="display: none">
                <table class="table">
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="StartLbl">Start: </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="StartTxb" ClientIDMode="Static" AutoPostBack="false"></asp:TextBox>                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="EndLbl">End: </asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="EndTxb" ClientIDMode="Static" AutoPostBack="false"></asp:TextBox>                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="RepeatLbl">Repeat: </asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="RepeatDdl" AutoPostBack="false">
                                <asp:ListItem Selected="True" Value="Daily"> Daily </asp:ListItem>
                                <asp:ListItem Value="Weekly"> Weekly </asp:ListItem>                                
                                <asp:ListItem Value="Weekly"> BiWeekly </asp:ListItem>                             
                                <asp:ListItem Value="Monthly"> Monthly </asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button3" runat="server" Text="Close" OnClientClick="CloseDialog();" CssClass="btn btn-warning" />
                        </td>
                        <td>
                            <asp:Button ID="RecurringButton" runat="server" Text="Place Order" CssClass="btn btn-warning " OnClientClick="javascript:return validate2();" OnClick="RecurringButton_Click" />

                        </td>
                    </tr>
                </table>
            </div>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Cancel" OnClick="CancelBtn_Click" CssClass="btn btn-warning" />
                    </td>
                    <td>&nbsp;<asp:Button ID="PlaceOrderBtn" runat="server" Text="Place Order" CssClass="btn btn-warning PlaceOrderButton" OnClientClick="javascript:return validate();" OnClick="PlaceOrderBtn_Click" />                        
                    </td>
                    <td>
                        <span class="error_msg" style="color: red; margin-left: 10px;"></span>
                    </td>
                </tr>
            </table>
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>    
</asp:Content>
