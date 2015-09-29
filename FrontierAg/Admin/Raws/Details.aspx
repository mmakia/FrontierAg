<%@ Page Title="Raw Details" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Details.aspx.cs" Inherits="FrontierAg.Admin.Raws.Details" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">   
      <script type="text/javascript">
          $(function () {
              window.print();
              window.history.back(1);
            $('h4:contains("AG_")').html($('h4:contains("AG_")').html().replace("AG_", ""));
            if ($('h4:contains("12:00:00 AM")').length)
            {
                $('h4:contains("12:00:00 AM")').html($('h4:contains("12:00:00 AM")').html().replace("12:00:00 AM", ""));
            } 
            
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
                <p><%#:Item.Product.ProductNo %></p>
            </div>
                </asp>
                    </div>
                </div>                                                   

                <div class="row">
                    <div class="col-sm-6 ">
                        <div>
                <p><%#:Item.Product.ProductName %></p>
            </div>
                </asp>
                    </div>
                </div>      

                <div class="row">
                    <div class="col-sm-6 ">
                       <p> <asp:DynamicControl runat="server" DataField="LotNumber" ID="LotNumber" Mode="ReadOnly" /></p>
                    </div>
                </div>

                <div class="row">    
                                    
                    <div class="col-sm-6 ">
                        <p>Exp: <asp:DynamicControl runat="server" DataField="ExpDate" ID="ExpDate" Mode="ReadOnly" /></p>
                    </div>
                </div>
</div>
                <%--<%--<div class="row">
                    &nbsp;
                </div>
                <div class="form-group">
                    <div class="col-sm-6">
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Back" CssClass="btn btn-warning" />
                        <button id="myPrintButton" onclick="window.print();" Class="btn btn-warning">Print Page</button>
                    </div>
                </div>--%>
            </fieldset>
        </ItemTemplate>
    </asp:FormView>
        
</asp:Content>

