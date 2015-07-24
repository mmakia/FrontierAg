using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using FrontierAg.Models;
namespace FrontierAg.Contacts
{
    public partial class Edit : System.Web.UI.Page
    {
        protected FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            //string sessionReturnUrl = (string)(Session["ReturnUrl"]);
            if (!IsPostBack)
            {
                MessageLbl.Text = "";
            }
        }

        // This is the Update methd to update the selected Contact item
        // USAGE: <asp:FormView UpdateMethod="UpdateItem">
        public void UpdateItem(int ContactId)
        {
            var item = _db.Contacts.Find(ContactId);

            using (_db)
            {
                    if (item == null)
                    {
                        // The item wasn't found
                        ModelState.AddModelError("", String.Format("Item with id {0} was not found", ContactId));
                        return;
                    }
                    //var AnotherItem = _db.Contacts.Where(m => m.Company == item.Company && m.ContactId != item.ContactId);
                    TryUpdateModel(item);

                    if (ModelState.IsValid)
                    {
                        var Duplicate = _db.Contacts.Any(m => m.Company == item.Company && m.ContactId != item.ContactId);
                        if (!Duplicate)
                        {
                            // Save changes here
                            _db.SaveChanges();

                            if ((string)(Session["ReturnUrlEditContact"]) != "")
                            {
                                Response.Redirect((string)(Session["ReturnUrlEditContact"]));
                            }
                            else
                            {
                                Response.Redirect("~/Admin/Contacts/Default");
                            }
                        }
                        else
                        {
                            MessageLbl.Text = "* Make sure Company name is unique!";
                        }
                    }               
                
            }
        }

        // This is the Select method to selects a single Contact item with the id
        // USAGE: <asp:FormView SelectMethod="GetItem">
        public FrontierAg.Models.Contact GetItem([FriendlyUrlSegmentsAttribute(0)]int? ContactId)
        {
            FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

            if (ContactId == null)
            {
                return null;
            }

            using (_db)
            {
                return _db.Contacts.Find(ContactId);
            }
        }

        protected void ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("../Default");
            }
        }
    }
}
