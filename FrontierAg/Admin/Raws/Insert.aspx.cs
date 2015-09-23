﻿using System;
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



        public IQueryable GetProducts()
        {
            var _db = new FrontierAg.Models.ProductContext();
            IQueryable query = _db.Products;//.Where(u => (u.CategoryId == 11 || u.CategoryId == 12 || u.CategoryId == 13 || u.CategoryId == 15));
            return query;
        }
        protected void AddRAWButton_Click(object sender, EventArgs e)
        {

        }

        //protected void ItemCommand(object sender, FormViewCommandEventArgs e)
        //{
        //    if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
        //    {
        //        Response.Redirect("Default");
        //    }
        //}
    }
}
