using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using FrontierAg.Models;
using System.Web.DynamicData;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using Microsoft.AspNet.FriendlyUrls;

namespace FrontierAg.Admin.Shippings
{
    public partial class Default : System.Web.UI.Page
    {
		protected FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //to force browser to reload when using back button inorder to display updated info on page
                Response.Buffer = true;
                Response.CacheControl = "no-cache";
                Response.AddHeader("Pragma", "no-cache");
                Response.Expires = -1441;
            }
        }

        //protected void Page_Init()
        //{
        //    MetaTable table = MetaTable.GetTable(typeof(Product));
        //    ShippingsGrid.SetMetaTable(table);
        //}

        
        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Contacts/Default");
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<FrontierAg.Models.Shipping> ShippingsGrid_GetData([FriendlyUrlSegmentsAttribute(0)]int? ContactId, [FriendlyUrlSegmentsAttribute(1)]int? ShippingId) 
        {
            if( ContactId == 0 && ShippingId != null)
            {
                return _db.Shippings.Where(n => n.ShippingId == ShippingId);//.Include(m => m.Contact);//////////
            }

            if (ContactId == null)
            {
                return _db.Shippings.Include(m => m.Contact);
            }              


            else return _db.Shippings.Where(n => n.ContactId == ContactId && n.isHistory == false).Include(m => m.Contact);//////////
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ShippingsGrid_UpdateItem(int ShippingId)
        {
            FrontierAg.Models.Shipping item = null;
            item = _db.Shippings.Find(ShippingId);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", ShippingId));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                _db.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ShippingsGrid_DeleteItem(int ShippingId)
        {
            using (ProductContext db = new ProductContext())
            {
                var item = new Shipping { ShippingId = ShippingId };
                db.Entry(item).State = EntityState.Deleted;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("",
                      String.Format("Item with id {0} no longer exists in the database.", ShippingId));
                }
            }
        }  

        protected void CreateAddress_Click(object sender, EventArgs e)
        {
            IList<string> segments = Request.GetFriendlyUrlSegments();
            Response.Redirect(FriendlyUrl.Href("~/Admin/Shippings/AddShipping/", int.Parse(segments[0])));            
        }  
        
    }
}

