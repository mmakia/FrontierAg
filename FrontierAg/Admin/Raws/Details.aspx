<%@ Page Title="Raw Details" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Details.aspx.cs" Inherits="FrontierAg.Admin.Raws.Details" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">   
      <script type="text/javascript">    
        $(function () {           
            window.print();
            window.history.back(1);
        });
    </script>
    <asp:FormView runat="server"
        ItemType="FrontierAg.Models.Raw" DataKeyNames="RawId"
        SelectMethod="GetItem"
        OnItemCommand="ItemCommand" RenderOuterTable="false">
        
        <ItemTemplate>
            <fieldset class="form-horizontal">

                <div class="row">                    
                    <div class="col-sm-6 ">
                         <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/fssi_logo.png" />
                    </div>
                </div>
                 
                <div class="row">
                    <div class="col-sm-6 ">
                        <div>
                <h4><%#:Item.Product.ProductNo %></h4>
            </div>
                </asp>
                    </div>
                </div>                                                   

                <div class="row">
                    <div class="col-sm-6 ">
                        <div>
                <h4><%#:Item.Product.ProductName %></h4>
            </div>
                </asp>
                    </div>
                </div>      

                <div class="row">
                    <div class="col-sm-6 ">
                       <h4> <asp:DynamicControl runat="server" DataField="LotNumber" ID="LotNumber" Mode="ReadOnly" /></h4>
                    </div>
                </div>

                <div class="row">    
                                    
                    <div class="col-sm-6 ">
                        <h4>Exp: <asp:DynamicControl runat="server" DataField="ExpDate" ID="ExpDate" Mode="ReadOnly" /></h4>
                    </div>
                </div>

                <div class="row">
                    &nbsp;
                </div>
                <div class="form-group">
                    <div class="col-sm-6">
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Back" CssClass="btn btn-warning" />
                        <button id="myPrintButton" onclick="window.print();" Class="btn btn-warning">Print Page</button>
                    </div>
                </div>
            </fieldset>
        </ItemTemplate>
    </asp:FormView>

</asp:Content>

