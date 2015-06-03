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
        bool isItemShipping = false;
        int myShipmentId;

        private ProductContext _db = new ProductContext();        

        public IQueryable<OrderDetail> GetOrderItems(int? OrderId)
        {
            if (OrderId != null)
            {
                return _db.OrderDetails.Where(m => m.OrderId == OrderId);//.Include(n => n.Order).Include(o => o.Product).Include(l => l.Order.Shipping.Contact);
            }

            else return _db.OrderDetails.Include(n => n.Order);//.Include(o => o.Product).Include(l => l.Order.Shipping.Contact);
        }

        public void UpdateOrderDetailDatabase(int OrderId, OrederDetailUpdates[] ODetailUpdates)//////////////////5*******************
        {
            
            try
            {
                int ODUpdatesCount = ODetailUpdates.Count();

                // Iterate through all OrderDetail list to see if creating new shipment is needed
                for (int i = 0; i < ODUpdatesCount; i++)
                {
                    if (ODetailUpdates[i].QtyShipping > 0)
                    {
                        isItemShipping = true;
                    }
                }

                //inserting new Shipment & ShipmentDetail
                if (isItemShipping)
                {
                    var myShipment = new Shipment();
                    myShipment.OrderId = OrderId;
                    myShipment.ShipCharge = 0;
                    myShipment.Tracking = "";
                    myShipment.Comment = "";
                    myShipment.DateCreated = System.DateTime.Now;

                    _db.Shipments.Add(myShipment);
                    _db.SaveChanges();

                    myShipmentId = myShipment.ShipmentId;

                    //inserting new ShipmentDetailS                    
                    InsertShipmentDetail(myShipment.ShipmentId, ODetailUpdates);////////////6
                    
                }

                List<OrderDetail> myDetails = GetOrderDetails(OrderId);//getting originals from Db
                foreach (var OrderDetail in myDetails)
                {
                    
                       

                    //updating OrderDetails
                    for (int i = 0; i < ODUpdatesCount; i++)
                    {
                        if (OrderDetail.Product.ProductId == ODetailUpdates[i].ProductId)
                        {

                            UpdateItem(OrderId, OrderDetail.ProductId, ODetailUpdates[i].QtyShipping, ODetailUpdates[i].QtyCancelling, ODetailUpdates[i].Comment);//////////////////8

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
            public string ProductNo;
            public string ProductName;
            public int Quantity;
            public string UnitString;            
            public int QtyShipped;
            public int QtyShipping;
            public int QtyCancelled;
            public int QtyCancelling;
            public Decimal Price;
            public String Comment;
        }

        public List<OrderDetail> GetOrderDetails(int OrderId)
        {

            return _db.OrderDetails.Where(c => c.OrderId == OrderId).ToList();
        }
        
        public void UpdateItem(int OrderID, int updateProductID, int qtyShipping, int qtyCancelling, string comment)//////////////////9
        {
            using (var _db = new FrontierAg.Models.ProductContext())
            {
                try
                {
                    var myDBOrderDetail = (from c in _db.OrderDetails where c.OrderId == OrderID && c.ProductId == updateProductID select c).FirstOrDefault();

                    if (myDBOrderDetail != null)
                    {
                        //do the work.............
                        if (qtyCancelling + qtyShipping <= myDBOrderDetail.Quantity)
                        {                                                 
                            //update OrderDeatils DB
                            myDBOrderDetail.QtyCancelled = myDBOrderDetail.QtyCancelled + qtyCancelling;
                            myDBOrderDetail.QtyShipped = myDBOrderDetail.QtyShipped + qtyShipping;                            
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

        protected void InsertShipmentDetail(int ShipmentId, OrederDetailUpdates[] ODetailUpdates)//////////////////7****************************
        {
            int ODUpdatesCount = ODetailUpdates.Count();
            try
            {
                // Iterate through all OrderDetail list to see if creating new shipment is needed
                for (int i = 0; i < ODUpdatesCount; i++)
                {
                    if (ODetailUpdates[i].QtyShipping > 0)
                    {                        
                        var myShipmentDetail = new ShipmentDetail();

                        myShipmentDetail.ShipmentId = myShipmentId;//1
                        myShipmentDetail.ProductId = ODetailUpdates[i].ProductId;
                        myShipmentDetail.ProductNo = ODetailUpdates[i].ProductNo;
                        myShipmentDetail.ProductName = ODetailUpdates[i].ProductName;
                        myShipmentDetail.Qty = ODetailUpdates[i].Quantity;//2
                        myShipmentDetail.UnitString = ODetailUpdates[i].UnitString;//3
                        myShipmentDetail.Price = ODetailUpdates[i].Price;
                        myShipmentDetail.QtyShipped = ODetailUpdates[i].QtyShipped;
                        myShipmentDetail.QtyShipping = ODetailUpdates[i].QtyShipping;
                        myShipmentDetail.Comment = ODetailUpdates[i].Comment;
                        myShipmentDetail.QtyCancelled = ODetailUpdates[i].QtyCancelled + ODetailUpdates[i].QtyCancelling;
                        myShipmentDetail.DateCreated = System.DateTime.Now;

                        _db.ShipmentDetails.Add(myShipmentDetail);
                        _db.SaveChanges();       
                    }
                }

                         
            }
            catch (Exception exp)
            {
                throw new Exception("ERROR: Unable to add ShipmentDetail - " + exp.Message.ToString(), exp);                
            }          
            
        }

        public IQueryable<OrderDetail> GetOrderDetailsItems(int OrderId)//
        {
            

            return _db.OrderDetails.Where(c => c.OrderId == OrderId);
        }

        public decimal GetChargeFromPackCharges(int productId, int qty)//1-check if exist in packcharge table 2-check if qty is within limit 3- then calculate packCharge for multipule boxes
        {
            var myPackageCharge = _db.PackCharges.Where(en => en.ProductId == productId).FirstOrDefault();//1
            if (myPackageCharge == null)
            {
                return 0;
            }
            else
            {
                var myItem = _db.PackCharges.Where(en => en.ProductId == productId && en.From <= qty && en.To >= qty).FirstOrDefault();//2

                //found the value
                if (myItem != null)
                {
                    return myItem.PackChargeAmt;
                }

                //3-value not found, will pack QTY in multipule boxes
                Decimal totalCharge = 0;

                //max qty fit in a box 
                var maxQtyInBox = _db.PackCharges.Where(en => en.ProductId == productId).Max(m => m.To);

                //the charge for max qty
                var maxQtyInBoxItem = _db.PackCharges.Where(en => en.ProductId == productId && en.To == maxQtyInBox).FirstOrDefault();

                //counting how many boxes needed
                while (qty > maxQtyInBox)
                {
                    totalCharge = totalCharge + maxQtyInBoxItem.PackChargeAmt;
                    qty = qty - maxQtyInBox;
                }
                //getting the charge for the box thats gonna fit the remaining
                var myItem2 = _db.PackCharges.Where(en => en.ProductId == productId && en.From <= qty && en.To >= qty).FirstOrDefault();
                if (myItem2 != null)
                {
                    //calculating total charge
                    return totalCharge + myItem2.PackChargeAmt;//?
                }
                if (totalCharge + maxQtyInBoxItem.PackChargeAmt != null)
                {
                    return totalCharge + maxQtyInBoxItem.PackChargeAmt;
                }
                return 0;
            }
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