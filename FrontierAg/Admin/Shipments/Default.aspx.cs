using FrontierAg.Models;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontierAg.Admin.Shipments
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<FrontierAg.Models.Shipment> ShipmentList_GetData([FriendlyUrlSegmentsAttribute(0)]int? OrderId)
        {
            if (OrderId != null)
            {
                ProductContext db = new ProductContext();
                return db.Shipments.Where(en => en.OrderId == OrderId);//.Include(en => en.OrderShippings.Select(m => m.Shipping))
            }
            else return null;            
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ShipmentList_UpdateItem(int id)
        {
            FrontierAg.Models.Shipment item = null;
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();

            }
        }
    }
}