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

        protected void Page_Init()
        {
            MetaTable table = MetaTable.GetTable(typeof(Raw));
            addRawForm.SetMetaTable(table);
        }

        // This is the Insert method to insert the entered Raw item
        // USAGE: <asp:FormView InsertMethod="InsertItem">
        public void InsertItem()
        {
            using (_db)
            {
                var item = new FrontierAg.Models.Raw();

                TryUpdateModel(item);

                if (ModelState.IsValid)
                {
                    // Save changes                                   
                    var myLastRaw = _db.Raws.OrderByDescending(x => x.RawId).First();
                    var lastLotNumber = myLastRaw.LotNumber;
                    
                    string  temp = lastLotNumber.ToString();
                    string myDateSubString = temp.Substring(5,6);
                    DateTime StoredDate = DateTime.ParseExact(myDateSubString, "MMddyy", CultureInfo.InvariantCulture);

                    //string temp = lastLotNumber.ToString();
                    string temp3 = "9999";
                    if (temp.Length == 16)
                    {
                        temp3 = temp.Substring(14);
                    }
                    int myNumberSubString = 0;
                    Int32.TryParse(temp3, out myNumberSubString);

                    if (DateTime.Now.Date != StoredDate.Date)
                    {                        
                        item.LotNumber = "RM - " + myDateSubString + " - 01";                       
                    }
                    else
                    {
                        if (myNumberSubString < 10)
                        {
                            item.LotNumber = "RM - " + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("yy") + " - 0" + (myNumberSubString + 1).ToString();
                        }
                        else
                        {
                            item.LotNumber = "RM - " + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("yy") + " - " + (myNumberSubString + 1).ToString();
                        }
                        
                    }
                    
                    //item.ExpDate = datetime2;
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
