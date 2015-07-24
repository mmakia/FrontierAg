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
        //protected FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MessageLbl.Text = "";
            }
        }

        // This is the Insert method to insert the entered Contact item
        // USAGE: <asp:FormView InsertMethod="InsertItem">
        public void InsertItem(Contact newContact)
        {
            using (FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext())
            {
                var isDuplicate = _db.Contacts.Any(w => w.Company == newContact.Company);

                if (!isDuplicate)
                {
                    var item = new FrontierAg.Models.Contact();
                    item.DateCreated = DateTime.Now;
                    TryUpdateModel(item);

                    if (ModelState.IsValid)
                    {
                        // Save changes
                        _db.Contacts.Add(item);

                        if (item.Type == CType.Customer)
                        {
                            var item2 = new FrontierAg.Models.Shipping();
                            item2.Company = item.Company;
                            item2.FName = "";
                            item2.LName = "";
                            item2.Other1 = "";
                            item2.Other2 = "";
                            item2.Address1 = item.Address1;
                            item2.Address2 = item.Address2;
                            item2.City = item.City;
                            item2.State = item.State;
                            item2.PostalCode = item.PostalCode;
                            item2.Country = item.Country;
                            item2.PPhone = item.PPhone;
                            item2.EMail = item.EMail;
                            item2.DateCreated = item.DateCreated;
                            item2.ContactId = item.ContactId;
                            _db.Shippings.Add(item2);                            
                        }

                        _db.SaveChanges();

                        if ((string)(Session["ReturnUrlCreateContact"]) != "")//if exist
                        {
                            Response.Redirect((string)(Session["ReturnUrlCreateContact"]) + "/" + item.ContactId);
                        }
                        else
                        {
                            Response.Redirect("~/Admin/Contacts/Default");
                        }
                        
                    }
                }

                MessageLbl.Text = "* Make sure Company name is unique!";
            }
        }

        protected void ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("~/Admin/Contacts/Default");
            }
        }
    }
}
