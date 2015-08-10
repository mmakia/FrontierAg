using FrontierAg.Models;
using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontierAg.Admin.Prices
{
    public partial class AddPrice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //for drop down list
        protected void Page_Init()
        {
            MetaTable table = MetaTable.GetTable(typeof(Price));
            addPriceForm.SetMetaTable(table);
        }

        public void addPriceForm_InsertItem()
        {
            var item = new FrontierAg.Models.Price();
            TryUpdateModel(item);
            if (ModelState.IsValid && HttpContext.Current.Session["TheProductId"] != null)
            {
                // Save changes here
                using (FrontierAg.Models.ProductContext db = new FrontierAg.Models.ProductContext())
                {
                    item.ProductId = (int)HttpContext.Current.Session["TheProductId"];
                    item.DateCreated = System.DateTime.Now;
                    db.Prices.Add(item);
                    db.SaveChanges();
                }
                Response.Redirect(FriendlyUrl.Href("~/Admin/Prices/Default/", HttpContext.Current.Session["TheProductId"]));                
            }
        }

        //protected void addPriceForm_ItemInserted(object sender, FormViewInsertedEventArgs e)
        //{
        //    //LinkButton btn = (LinkButton)(sender);
        //    //string yourValue = btn.CommandArgument;

        //    //int myProductId = Int32.Parse(yourValue);

            
        //    Response.Redirect("~/Admin/Products/Default");
        //}
        
    }
}