<%@ Page Title="Raw Details" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Details.aspx.cs" Inherits="FrontierAg.Admin.Raws.Details" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <script type="text/javascript">
        $(function () {
            if ($('p:contains("AG_")').length) {
            $('p:contains("AG_")').html($('p:contains("AG_")').html().replace("AG_", ""))}        

            if ($('p:contains("12:00:00 AM")').length) {
                $('p:contains("12:00:00 AM")').html($('p:contains("12:00:00 AM")').html().replace("12:00:00 AM", ""))
            }
            window.print()
            setTimeout("window.history.back(1)", 100);
        });
    </script>    
    <asp:FormView runat="server"
        ItemType="FrontierAg.Models.Raw" DataKeyNames="RawId"
        SelectMethod="GetItem"
        OnItemCommand="ItemCommand" RenderOuterTable="false">

        <ItemTemplate>
            <fieldset class="form-horizontal">
                <div id="myPrintForm">
                    <div class="row">
                        <div class="col-sm-6 ">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/fssi_logo.png" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-6 ">
                            <div>
                                <p><strong><%#:Item.Product.ProductNo %></strong></p>
                            </div>
                            </asp>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-6 ">
                            <div>
                                <p><strong><%#:Item.Product.ProductName %></strong></p>
                            </div>
                            </asp>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-6 ">
                            <p>
                                <asp:DynamicControl runat="server" DataField="LotNumber" ID="LotNumber" Mode="ReadOnly" />
                            </p>
                        </div>
                    </div>

                    <div class="row">

                        <div class="col-sm-6 ">
                            <p>Exp:
                                <%#:Item.ExpDate == null ? "N/A" : Item.ExpDate.ToString() %>                                
                            </p>
                        </div>
                    </div>
                </div>                
            </fieldset>
        </ItemTemplate>
    </asp:FormView>

</asp:Content>

