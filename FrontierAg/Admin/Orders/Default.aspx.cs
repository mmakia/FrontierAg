using FrontierAg.Models;
using Microsoft.AspNet.FriendlyUrls;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Web.ModelBinding;

namespace FrontierAg.Admin.Orders
{
    public partial class ToProcess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ErrorLbl.Text = "";
                Session["CategoryCondition"] = null;
                //Session["StatsCondition"] = null;                
            }

            string catCondition = string.Empty;
            foreach (ListItem item in CheckBoxSelectCategory.Items)
                if (item.Selected)
                    catCondition += item.Value + " ";
            catCondition = catCondition.Trim();
            Session["CategoryCondition"] = catCondition;

            //string statCondition = string.Empty;
            //foreach (ListItem item in Status2.Items)
            //    if (item.Selected)
            //        statCondition += item.Value + " ";
            //statCondition = statCondition.Trim();
            //Session["StatsCondition"] = statCondition; 
        }

        public IQueryable GetCategories()
        {
            var _db = new FrontierAg.Models.ProductContext();
            IQueryable query = _db.Categories;

            return query;
        }

        protected void CheckBoxListDivision_DataBound(object sender, EventArgs e)
        {
            foreach (ListItem item in CheckBoxSelectCategory.Items)
            {
                item.Selected = true;
            }
        }

        //protected void GoToOrdersBtn_Click(object sender, EventArgs e)//stay
        //{
        //    string condition = string.Empty;
        //    foreach (ListItem item in CheckBoxSelectCategory.Items)
        //        if(item.Selected)
        //         condition += item.Value + " ";

        //    condition = condition.Trim();
        //    Session["CategoryCondition"] = condition;            
        //}

        public IQueryable<Order> OrdersList_GetData([FriendlyUrlSegmentsAttribute(0)]int? ContactId, [FriendlyUrlSegmentsAttribute(1)]int? OrderId, [Session("CategoryCondition")] string mySession, [Control("Status2")] Status? myStatus)
        {
            ProductContext db = new ProductContext();
            IQueryable<Order> Result = null;

            if (mySession != null)
            {                
                var myOrders = db.Orders.AsQueryable();
                foreach (string ss in mySession.Split(' '))
                {
                    int categoryNumber = Int32.Parse(ss);
                    myOrders = db.OrderDetails.Where(r => r.Product.Category.CategoryId == categoryNumber).Select(t => t.Order);

                    if (Result != null)
                    {
                        Result = Result.Union(myOrders);
                    }
                    else
                    {
                        Result = myOrders;
                    }
                }
                if (myStatus != null)
                {
                    Result = Result.Where(y => y.Status == myStatus);
                }


                Session["CategoryCondition"] = null;

                if (OrderId != null)
                {
                    return Result.Where(en => en.OrderId == OrderId).OrderByDescending(en => en.OrderDate);
                }

                if (ContactId != null)
                {
                    return Result.Where(en => en.ContactId == ContactId).OrderByDescending(en => en.OrderDate);
                }
                
                return Result.OrderByDescending(en => en.OrderDate);
            }

            Result = db.Orders;//.Include(en => en.OrderShippings.Select(em => em.Shipping.Contact)).OrderByDescending(en => en.OrderDate);

            if (myStatus != null)
            {
                Result = Result.Where(e => e.Status == myStatus);
            }

            if (OrderId != null)
            {
                return Result.Where(en => en.OrderId == OrderId).OrderByDescending(en => en.OrderDate);
            }

            if(ContactId != null)
            {
                return Result.Where(i => i.ContactId == ContactId);
            }
            
            return Result;//db.Orders.Where(n => (n.OrderDate <= System.DateTime.Now)).Include(en => en.OrderShippings.Select(em => em.Shipping.Contact)).OrderByDescending(en => en.OrderDate);
        }


        public void Orders_UpdateItem(Order order)
        {
            if (order != null)
            {
                using (ProductContext db = new ProductContext())
                {

                    //grab original order
                    var originalOrder = db.Orders.Find(order.OrderId);
                    //Total fee without  charges
                    //PreTotal = originalOrder.Total;// -(originalOrder.OtherCharge - originalOrder.Discount);
                    if (order.Status == FrontierAg.Models.Status.Cancelled && originalOrder.Status != FrontierAg.Models.Status.New)
                    {
                        ErrorLbl.Text = "**** This Order can not be cancelled directly, Please Cancel each shipment related to this order first, then this order will be cancelled Automatically ****";
                        return;
                    }
                    //originalOrder.OtherCharge = order.OtherCharge;                                       
                    //originalOrder.Discount = order.Discount;

                    //originalOrder.Total = PreTotal + order.OtherCharge - order.Discount;

                    //originalOrder.Payment = order.Payment;
                    //originalOrder.PaymentDate = order.PaymentDate;
                    originalOrder.Tracking = order.Tracking;
                    originalOrder.Comment = order.Comment;
                    originalOrder.Status = order.Status;
                    db.SaveChanges();
                }
            }

        }

        protected void Unnamed_Click0(object sender, EventArgs e)//stay
        {
            LinkButton btn = (LinkButton)(sender);
            string yourValue = btn.CommandArgument;

            int myOrderId = Int32.Parse(yourValue);
            using (ProductContext db = new ProductContext())
            {
                var myShippingId = db.OrderShippings.Where(en => en.OrderId == myOrderId && en.SType == SType.Ordering).Select(en => en.ShippingId).FirstOrDefault();
                Response.Redirect(FriendlyUrl.Href("~/Admin/Shippings/Details", 0, myShippingId));
            }
        }

        protected void Unnamed_Click1(object sender, EventArgs e)//stay
        {
            LinkButton btn = (LinkButton)(sender);
            string yourValue = btn.CommandArgument;

            int myOrderId = Int32.Parse(yourValue);
            using (ProductContext db = new ProductContext())
            {
                var myShippingId = db.OrderShippings.Where(en => en.OrderId == myOrderId && en.SType == SType.Billing).Select(en => en.ShippingId).FirstOrDefault();
                Response.Redirect(FriendlyUrl.Href("~/Admin/Shippings/Details", 0, myShippingId));
            }
        }
    }
}