using FrontierAg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Web.ModelBinding;
using System.Collections.Specialized;


namespace FrontierAg.Admin.OrderDetails
{
    public partial class Default : System.Web.UI.Page
    {
        //private ProductContext _db = new ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        

        public IQueryable<OrderDetail> OpenOrderList_GetData([QueryString] int OrderId) 
        {           
            OrderActions actions = new OrderActions();
            return actions.GetOrderItems(OrderId);            
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            string rawId = Request.QueryString["OrderId"]; 

            UpdateOrderDetail(Convert.ToInt16(rawId));            
        }

        public IQueryable<OrderDetail> UpdateOrderDetail(int OrderId)
        {
            //String cartId = usersShoppingCart.GetCartId();
            using (OrderActions MyOrderActions = new OrderActions())
            {

                OrderActions.OrederDetailUpdates[] ODUpdates = new OrderActions.OrederDetailUpdates[OrderDetailList.Rows.Count];
                for (int i = 0; i < OrderDetailList.Rows.Count; i++)
                {
                    IOrderedDictionary rowValues = new OrderedDictionary();
                    rowValues = GetValues(OrderDetailList.Rows[i]);
                    ODUpdates[i].ProductId = Convert.ToInt32(rowValues["ProductId"]);

                    TextBox QtyShippedTextBox = new TextBox();
                    QtyShippedTextBox = (TextBox)OrderDetailList.Rows[i].FindControl("QtyShippedBx");
                    ODUpdates[i].QtyShipped = Convert.ToInt16(QtyShippedTextBox.Text.ToString());

                    TextBox QtyCancelledTextBox = new TextBox();
                    QtyCancelledTextBox = (TextBox)OrderDetailList.Rows[i].FindControl("QtyCancelledBx");
                    ODUpdates[i].QtyCancelled = Convert.ToInt16(QtyCancelledTextBox.Text.ToString());

                    TextBox CommentBox = new TextBox();
                    CommentBox = (TextBox)OrderDetailList.Rows[i].FindControl("CommentBx");
                    ODUpdates[i].Comment = CommentBox.Text.ToString();

                }

                MyOrderActions.UpdateOrderDetailDatabase(OrderId, ODUpdates);
                OrderDetailList.DataBind();
                return MyOrderActions.GetOrderDetailsItems(OrderId);
            }
        }

        

        public static IOrderedDictionary GetValues(GridViewRow row)
        {
            IOrderedDictionary values = new OrderedDictionary();
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.Visible)
                {
                    // Extract values from the cell.
                    cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, true);
                }
            }
            return values;
        }

               

    }
}