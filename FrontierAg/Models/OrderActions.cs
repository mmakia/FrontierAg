using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Data.Entity.Infrastructure;
using System.Data.Entity;
//using System.Web.ModelBinding;
//using System.Collections.Specialized;

namespace FrontierAg.Models
{
    public class OrderActions : IDisposable
    {
        //public int OrderId { get; set; }

        private ProductContext _db = new ProductContext();
        //private int? OrderId1;

        //public OrderActions(int? OrderId1)
        //{
        //    // TODO: Complete member initialization
        //    this.OrderId1 = OrderId1;
        //}

        public IQueryable<OrderDetail> GetOrderItems(int OrderId)///////////
        {
            //if (OrderId != null)
            //{
                return _db.OrderDetails.Where(m => m.OrderId == OrderId).Include(n => n.Order).Include(o => o.Product).Include(l => l.Order.Shipping.Contact);
            //}

            //else return _db.OrderDetails.Include(n => n.Order).Include(o => o.Product).Include(l => l.Order.Shipping.Contact);
        }

        public void UpdateOrderDetailDatabase(int OrderId, OrederDetailUpdates[] ODetailUpdates)
        {
            try
            {
                int ODUpdatesCount = ODetailUpdates.Count();
                List<OrderDetail> myDetails = GetOrderDetails(OrderId);//getting originals from Db
                foreach (var OrderDetail in myDetails)
                {
                    // Iterate through all rows within OrderDetail list
                    for (int i = 0; i < ODUpdatesCount; i++)
                    {
                        if (OrderDetail.Product.ProductId == ODetailUpdates[i].ProductId)
                        {

                            UpdateItem(OrderId, OrderDetail.ProductId, ODetailUpdates[i].QtyShipped, ODetailUpdates[i].QtyCancelled, ODetailUpdates[i].Comment);

                        }
                    }
                }
            }
            catch (Exception exp)
            {
                throw new Exception("ERROR: Unable to Update Cart Database - " + exp.Message.ToString(), exp);  ///error input string was not in correct format                  
            }



        }

        public struct OrederDetailUpdates
        {
            public int ProductId;
            public int QtyShipped;
            public int QtyCancelled;
            public String Comment;
        }

        public List<OrderDetail> GetOrderDetails(int OrderId)
        {

            return _db.OrderDetails.Where(c => c.OrderId == OrderId).ToList();
        }


        public void UpdateItem(int OrderID, int updateProductID, int qtyShipped, int qtyCancelled, string comment)
        {
            using (var _db = new FrontierAg.Models.ProductContext())
            {
                try
                {
                    var myDBOrderDetail = (from c in _db.OrderDetails where c.OrderId == OrderID && c.ProductId == updateProductID select c).FirstOrDefault();

                    if (myDBOrderDetail != null)
                    {
                        //do the work.............
                        if (qtyCancelled + qtyShipped <= myDBOrderDetail.Quantity)
                        {
                            myDBOrderDetail.QtyShipped = qtyShipped;
                            myDBOrderDetail.QtyCancelled = qtyCancelled;
                            myDBOrderDetail.Comment = comment;
                        }                        
                       
                        _db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Update Cart Item - " + exp.Message.ToString(), exp);
                }
            }
        }
        public IQueryable<OrderDetail> GetOrderDetailsItems(int OrderId)//done ------ default/////////++++++++++++++++++++
        {
            

            return _db.OrderDetails.Where(c => c.OrderId == OrderId);
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }
    }
}