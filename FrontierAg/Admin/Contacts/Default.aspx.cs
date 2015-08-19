using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using FrontierAg.Models;
using Microsoft.AspNet.FriendlyUrls;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using FrontierAg.Logic;

namespace FrontierAg.Contacts
{
    public partial class Default : System.Web.UI.Page
    {
		protected FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // Model binding method to get List of Contact entries
        // USAGE: <asp:ListView SelectMethod="GetData">
        public IQueryable<FrontierAg.Models.Contact> GetData([FriendlyUrlSegmentsAttribute(0)]String searchString)
        {
            if (searchString != null)
            {
                string[] myStrings = GeneralUtilities.LineToStrings(searchString, " ");

                var ResultFContacts = _db.Contacts.AsQueryable();
                var ResultFShippings = _db.Contacts.AsQueryable();
                IQueryable<Contact> Result = null;

                foreach (string qs in myStrings)
                {
                    ResultFShippings = _db.Shippings.Where(em => em.FName.Contains(qs) || em.LName.Contains(qs) || em.Address1.Contains(qs) || em.Address2.Contains(qs)).Select(em => em.Contact).Where(em => em.Type == CType.Customer).Distinct();//.Where(x => x..Contains(qs));
                    ResultFContacts = _db.Contacts.Where(en => en.Type == CType.Customer && en.Company.Contains(qs) || en.Address1.Contains(qs) || en.Address2.Contains(qs));//qContacts.Where(en => en.Company.Contains(qs)) ||
                    if (Result != null)
                    {
                        Result = Result.Union(ResultFContacts.Concat(ResultFShippings));
                    }
                    else
                    {
                        Result = ResultFContacts.Concat(ResultFShippings);
                    }
                }

                return Result;
                //return _db.Contacts.Where(en => en.Type == CType.Customer && (en.Company..Contains(searchString)));  ///////////              
            }
            return _db.Contacts;
        }

        protected void BackBtn_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/AdminPage");
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string yourValue = Server.HtmlEncode(TextBox1.Text.Trim());

            if (yourValue != "")
            {
                Response.Redirect(FriendlyUrl.Href("~/Admin/Contacts/Default/", yourValue));
            }

            Response.Redirect(FriendlyUrl.Href("~/Admin/Contacts/Default/"));
        }
    }
}

