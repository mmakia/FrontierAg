using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using FrontierAg.Models;
using System.Web.DynamicData;
using System.Globalization;

namespace FrontierAg.Admin.Raws
{
    public partial class Insert : System.Web.UI.Page
    {
        protected FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable GetProducts()
        {
            var _db = new FrontierAg.Models.ProductContext();
            IQueryable query = _db.Products.Where(u => (u.CategoryId == 11 || u.CategoryId == 12 || u.CategoryId == 13 || u.CategoryId == 15));
            return query;
        }
        protected void AddRAWButton_Click(object sender, EventArgs e)
        {
            using (_db)
            {
                var item = new FrontierAg.Models.Raw();


                if (_db.Raws.FirstOrDefault() != null)//.OrderByDescending(x => x.RawId).First() != null) NEED TO FIX
                {
                    // getting Last Raw                                   
                    var myLastRaw = _db.Raws.OrderByDescending(x => x.RawId).First();
                    var lastLotNumber = myLastRaw.LotNumber;

                    string lastLotNumberString = lastLotNumber.ToString();
                    string myDateSubString = lastLotNumberString.Substring(3, 6);
                    DateTime StoredDate = DateTime.ParseExact(myDateSubString, "MMddyy", CultureInfo.InvariantCulture);

                    //string temp = lastLotNumber.ToString();
                    string mySequenceSubstring = "9998";
                    if (lastLotNumberString.Length >= 12)
                    {
                        mySequenceSubstring = lastLotNumberString.Substring(10);
                    }
                    int mySequenceAsInt = 0;
                    Int32.TryParse(mySequenceSubstring, out mySequenceAsInt);

                    //if todays date is different than last saved date, then record todays date
                    if (DateTime.Now.Date != StoredDate.Date)
                    {
                        item.LotNumber = "RM - " + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("yy") + " - 01";
                    }
                    //else,we are still adding sequences to today
                    else
                    {
                        if (mySequenceAsInt < 9)
                        {
                            item.LotNumber = "RM-" + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("yy") + "-0" + (mySequenceAsInt + 1).ToString();
                        }
                        else
                        {
                            item.LotNumber = "RM-" + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("yy") + "-" + (mySequenceAsInt + 1).ToString();
                        }

                    }
                }
                else
                {
                    item.LotNumber = item.LotNumber = "RM-" + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("yy") + "-01";
                }

                item.Manufacturer = TXTBXManufacturer.Text;
                item.ManLotNumber = TXTBXManufacturerLot.Text;
                item.ManPartNumber = TXTBXManufacturerPart.Text;



                item.DateRecived = DateTime.ParseExact(TXTBXDateReceived.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                if (TXTBXExpirationDate.Text != "")
                item.ExpDate = Convert.ToDateTime(TXTBXExpirationDate.Text);

                //var selectedProductId = _db.Products.Where(er => er.ProductId == Convert.ToInt16(DDLSelectProduct.SelectedValue)).FirstOrDefault();
                item.ProductId = Convert.ToInt16(DDLSelectProduct.SelectedValue);// selectedProductId.ProductId;

                _db.Raws.Add(item);
                _db.SaveChanges();

                Response.Redirect("Default");

            }
        }

        //public bool AddRaw(string lotNumber, string ProductDesc, string ProductPrice, string ProductCategory, string ProductImagePath)
        //{
        //    u
        //    var myProduct = new Product();
        //    myProduct.ProductName = ProductName;
        //    myProduct.Description = ProductDesc;
        //    myProduct.UnitPrice = Convert.ToDouble(ProductPrice);
        //    myProduct.ImagePath = ProductImagePath;
        //    myProduct.CategoryID = Convert.ToInt32(ProductCategory);

        //    using (ProductContext _db = new ProductContext())
        //    {
        //        // Add product to DB.
        //        _db.Products.Add(myProduct);
        //        _db.SaveChanges();
        //    }
        //    // Success.
        //    return true;
        //}
        //protected void Page_Init()
        //{
        //    MetaTable table = MetaTable.GetTable(typeof(Raw));
        //    addRawForm.SetMetaTable(table);
        //}

        // This is the Insert method to insert the entered Raw item
        // USAGE: <asp:FormView InsertMethod="InsertItem">
        public void InsertItem()
        {
            using (_db)
            {
                var item = new FrontierAg.Models.Raw();

                TryUpdateModel(item);

                if (ModelState.IsValid & _db.Raws.FirstOrDefault() != null)//.OrderByDescending(x => x.RawId).First() != null) NEED TO FIX
                {
                    // getting Last Raw                                   
                    var myLastRaw = _db.Raws.OrderByDescending(x => x.RawId).First();
                    var lastLotNumber = myLastRaw.LotNumber;

                    string lastLotNumberString = lastLotNumber.ToString();
                    string myDateSubString = lastLotNumberString.Substring(3, 6);
                    DateTime StoredDate = DateTime.ParseExact(myDateSubString, "MMddyy", CultureInfo.InvariantCulture);

                    //string temp = lastLotNumber.ToString();
                    string mySequenceSubstring = "9998";
                    if (lastLotNumberString.Length >= 12)
                    {
                        mySequenceSubstring = lastLotNumberString.Substring(10);
                    }
                    int mySequenceAsInt = 0;
                    Int32.TryParse(mySequenceSubstring, out mySequenceAsInt);

                    //if todays date is different than last saved date, then record todays date
                    if (DateTime.Now.Date != StoredDate.Date)
                    {
                        item.LotNumber = "RM - " + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("yy") + " - 01";
                    }
                    //else,we are still adding sequences to today
                    else
                    {
                        if (mySequenceAsInt < 9)
                        {
                            item.LotNumber = "RM-" + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("yy") + "-0" + (mySequenceAsInt + 1).ToString();
                        }
                        else
                        {
                            item.LotNumber = "RM-" + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("yy") + "-" + (mySequenceAsInt + 1).ToString();
                        }

                    }

                    _db.Raws.Add(item);
                    _db.SaveChanges();

                    Response.Redirect("Default");
                }
            }
        }

        protected void ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("Default");
            }
        }
    }
}
