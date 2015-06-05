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

        public void UpdateOrderDetailDatabase(int OrderId, OrederDetailUpdates[] ODetailUpdates, Decimal PFee)//////////////////5
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

                    var myShipping = (from my in _db.OrderShippings
                                         where my.OrderId == OrderId && my.Shipping.SType == SType.Shipping
                                         select my.Shipping).FirstOrDefault();
                                   
                    myShipment.ShippingId = InsertNewShipping(myShipping.ShippingId);//originalShippingAddressId
                    myShipment.PFee = PFee;
                    myShipment.ShipCharge = 0;
                    myShipment.Tracking = "";
                    myShipment.Comment = "";
                    myShipment.DateCreated = System.DateTime.Now;

                    _db.Shipments.Add(myShipment);
                    _db.SaveChanges();

                    myShipmentId = myShipment.ShipmentId;

                    //inserting new ShipmentDetailS   
                    Tuple<Decimal, Decimal> myTuple = InsertShipmentDetail(myShipment.ShipmentId, ODetailUpdates);////////////6

                    myShipment.PCharges = myTuple.Item2;
                    myShipment.Total = PFee + myTuple.Item1 + myTuple.Item2;
                    _db.SaveChanges();
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

        private int InsertNewShipping(int ShippingId)
        {            
            //Create new Shipping Address to Link to myOrder
            var myShipping = new Shipping();

            var myExistingShipping = _db.Shippings.Find(ShippingId);

            if (myExistingShipping != null)
            {
                myShipping.Company = myExistingShipping.Company;
                myShipping.LName = myExistingShipping.LName;
                myShipping.FName = myExistingShipping.FName;
                myShipping.Other1 = myExistingShipping.Other1;
                myShipping.Other2 = myExistingShipping.Other2;
                myShipping.Address1 = myExistingShipping.Address1;
                myShipping.Address2 = myExistingShipping.Address2;
                myShipping.City = myExistingShipping.City;
                myShipping.State = myExistingShipping.State;
                myShipping.PostalCode = myExistingShipping.PostalCode;
                myShipping.Country = myExistingShipping.Country;
                myShipping.ContactId = myExistingShipping.ContactId;
                myShipping.PPhone = myExistingShipping.PPhone;
                myShipping.isHistory = true;
                myShipping.SType = SType.Shipping;
                myShipping.DateCreated = System.DateTime.Now;
                _db.Shippings.Add(myShipping);
                _db.SaveChanges();

                return myShipping.ShippingId;
            }
            else return 0;            
        }       

        

        public struct OrederDetailUpdates
        {
            public int ProductId;
            public string ProductNo;
            public string ProductName;
            public int Quantity;
            public string UnitString;
            public Decimal_EditField PFee;
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

        protected Tuple<Decimal, Decimal> InsertShipmentDetail(int ShipmentId, OrederDetailUpdates[] ODetailUpdates)//////////////////7
        {
            Decimal ShipmentTotal = 0;
            Decimal PChargeTotal = 0;
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
                        
                        myShipmentDetail.PCharge = GetChargeFromPackCharges(ODetailUpdates[i].ProductId, ODetailUpdates[i].QtyShipping);

                        myShipmentDetail.QtyCancelled = ODetailUpdates[i].QtyCancelled + ODetailUpdates[i].QtyCancelling;
                        myShipmentDetail.DateCreated = System.DateTime.Now;
                        ShipmentTotal = ShipmentTotal + (ODetailUpdates[i].QtyShipping * ODetailUpdates[i].Price);
                        PChargeTotal = PChargeTotal + myShipmentDetail.PCharge;
                        _db.ShipmentDetails.Add(myShipmentDetail);
                        _db.SaveChanges();                        
                    }
                }

                return Tuple.Create(ShipmentTotal, PChargeTotal);
                //return ShipmentTotal;
                         
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