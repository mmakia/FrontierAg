using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using FrontierAg.Models;

namespace FrontierAg.Contacts
{
    public partial class Insert : System.Web.UI.Page
    {
		protected FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // This is the Insert method to insert the entered Contact item
        // USAGE: <asp:FormView InsertMethod="InsertItem">
        public void InsertItem()
        {
            using (_db)
            {
                var item = new FrontierAg.Models.Contact();
                item.DateCreated = DateTime.Now;
                TryUpdateModel(item);

                if (ModelState.IsValid)
                {
                    // Save changes
                    _db.Contacts.Add(item);

                    var item2 = new FrontierAg.Models.Shipping();
                    //FrontierAg.Models.Contact myContact = _db.Contacts.Where(m => m.ContactId == item.ContactId).FirstOrDefault();
                    item2.Address1 = item.Address1;
                    item2.Address2 = item.Address2;
                    item2.City = item.City;
                    item2.State = item.State;
                    item2.PostalCode = item.PostalCode;
                    item2.DateCreated = item.DateCreated;
                    item2.Country = item.Country;
                    item2.ContactId = item.ContactId;

                    _db.Shippings.Add(item2);

                    //InsertShipping(item.ContactId);

                    _db.SaveChanges();

                    Response.Redirect("~/Admin/Shippings/Insert");
                }
            }
        }

        private void InsertShipping(int p)
        {
            //ProductContext _db = new ProductContext();
            


            throw new NotImplementedException();
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
