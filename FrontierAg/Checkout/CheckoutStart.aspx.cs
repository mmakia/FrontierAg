using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using FrontierAg.Models;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using Microsoft.AspNet.FriendlyUrls;
using System.Web.ModelBinding;
using System.Web.SessionState;
using FrontierAg.Logic;

namespace FrontierAg.Checkout
{
    public partial class CheckoutStart : System.Web.UI.Page
    {
        protected FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ReturnUrlCreateOrdering"] = "";
            Session["ReturnUrlEditOrdering"] = "";
            Session["ReturnUrlCreateContact"] = "";
            Session["ReturnUrlEditContact"] = "";
            Session["ReturnUrlCreateShipping"] = "";
            Session["ReturnUrlEditShipping"] = "";
            Session["ReturnUrlCreateBilling"] = "";
            Session["ReturnUrlEditBilling"] = "";
        }
        //In the method: Session["BackgroundColor"] = ColorSelector.SelectedValue;

        public IQueryable<FrontierAg.Models.Contact> GetContacts([FriendlyUrlSegmentsAttribute(3)]String searchString)
        {
            if (searchString != null)
            {
                string[] mySearchStrings = GeneralUtilities.LineToStrings(searchString, " ");

                var ResultFContacts = _db.Contacts.AsQueryable();
                var ResultFShippings = _db.Contacts.AsQueryable();
                IQueryable<Contact> Result = null;

                foreach (string qs in mySearchStrings)
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

            else
            {
                return _db.Contacts.Where(en => en.Type == CType.Customer);
            }

            //C
            //Implementing revised search
            //if (searchString != null)
            //{
            //    string[] mySearchStrings = GeneralUtilities.LineToStrings(searchString, " ");

            //    var ResultFromContacts = _db.Contacts.AsQueryable();
            //    var ResultFromShippings = _db.Contacts.AsQueryable();
            //    IQueryable<Contact> Result = null;

            //    for (int i = 0; i < mySearchStrings.Length; i++ )
            //    {
            //        ResultFromShippings = _db.Shippings.Where(em => em.FName.Contains(mySearchStrings[i]) || em.LName.Contains(mySearchStrings[i]) || em.Address1.Contains(mySearchStrings[i]) || em.Address2.Contains(mySearchStrings[i])).Select(em => em.Contact).Where(em => em.Type == CType.Customer).Distinct();//.Where(x => x..Contains(qs));
            //        ResultFromContacts = _db.Contacts.Where(en => en.Type == CType.Customer && en.Company.Contains(mySearchStrings[i]) || en.Address1.Contains(mySearchStrings[i]) || en.Address2.Contains(mySearchStrings[i]));//qContacts.Where(en => en.Company.Contains(qs)) ||
            //        if (Result != null)
            //        {
            //            Result = Result.Union(ResultFromContacts.Concat(ResultFromShippings));
            //        }
            //        else
            //        {
            //            Result = ResultFromContacts.Concat(ResultFromShippings);
            //        }
            //    }

            //    return Result;
            //    //return _db.Contacts.Where(en => en.Type == CType.Customer && (en.Company..Contains(searchString)));  ///////////              
            //}

            //else
            //{
            //    return _db.Contacts.Where(en => en.Type == CType.Customer);
            //}
        }

        

        public IQueryable<FrontierAg.Models.Shipping> GetData1([FriendlyUrlSegmentsAttribute(0)] int? ContactId)
        {
            //if (Session["myContactId"] == null)
            if (ContactId == null || ContactId == 0)
            {
                return null;
            }
            //int x = Convert.ToInt32(Session["myContactId"]);
            return _db.Shippings.Where(n => n.ContactId == ContactId && n.isHistory == false);//_db.Shippings.Where(n => n.ContactId == ContactId && n.SType == SType.Shipping && n.isHistory == false);
        }

        public IQueryable<FrontierAg.Models.Shipping> GetData2([FriendlyUrlSegmentsAttribute(0)] int? ContactId, [FriendlyUrlSegmentsAttribute(1)] int? OrderingId)
        {
            //if (Session["myContactId"] == null)
            if (ContactId == null || ContactId == 0 || OrderingId == null || OrderingId == 0)
            {
                return null;
            }
            //int x = Convert.ToInt32(Session["myContactId"]);
            return _db.Shippings.Where(n => n.ContactId == ContactId && n.isHistory == false);//_db.Shippings.Where(n => n.ContactId == ContactId && n.SType == SType.Shipping && n.isHistory == false);
        }

        public IQueryable<FrontierAg.Models.Shipping> GetData3([FriendlyUrlSegmentsAttribute(0)] int? ContactId, [FriendlyUrlSegmentsAttribute(1)] int? OrderingId, [FriendlyUrlSegmentsAttribute(2)] int? ShippingId)
        {
            //if (Session["Shipping"] == null)
            if (ContactId == null || ShippingId == null || ContactId == 0 || ShippingId == 0)
            {
                return null;
            }
            //int y = Convert.ToInt32(Session["myContactId"]);
            return _db.Shippings.Where(n => n.ContactId == ContactId && n.isHistory == false);
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Checkout/ShoppingCart");
        }

        protected void Unnamed_Click1(object sender, EventArgs e)///1
        {
            LinkButton btn = (LinkButton)(sender);
            string yourValue1 = btn.CommandArgument;
            //Session["Shipping"] = yourValue2;
            //Response.Redirect(Request.RawUrl);
            IList<string> segments = Request.GetFriendlyUrlSegments();

            Response.Redirect(FriendlyUrl.Href("~/Checkout/CheckoutStart/", int.Parse(segments[0]), yourValue1));
        }

        protected void Unnamed_Click2(object sender, EventArgs e)///2
        {
            LinkButton btn = (LinkButton)(sender);
            string yourValue2 = btn.CommandArgument;
            //Session["Shipping"] = yourValue2;
            //Response.Redirect(Request.RawUrl);
            IList<string> segments = Request.GetFriendlyUrlSegments();

            Response.Redirect(FriendlyUrl.Href("~/Checkout/CheckoutStart/", int.Parse(segments[0]), int.Parse(segments[1]), yourValue2));
        }

        protected void Unnamed_Click3(object sender, EventArgs e)//3
        {
            LinkButton btn = (LinkButton)(sender);
            string yourValue3 = btn.CommandArgument;
            //Session["Billing"] = yourValue3;
            IList<string> segments = Request.GetFriendlyUrlSegments();
            //Int32 myContactId = Convert.ToInt32(Session["myContactId"]);
            //Int32 Shipping = Convert.ToInt32(Session["Shipping"]);
            //Int32 Billing = Convert.ToInt32(Session["Billing"]);

            //Session["myContactId"] = null;
            //Session["Shipping"] = null;
            //Session["Billing"] = null; 

            Response.Redirect(FriendlyUrl.Href("~/Checkout/CheckoutReview/", int.Parse(segments[0]), int.Parse(segments[1]), int.Parse(segments[2]), yourValue3));
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string yourValue = Server.HtmlEncode(TextBox1.Text.Trim());

            if (yourValue != "")
            {
                Response.Redirect(FriendlyUrl.Href("~/Checkout/CheckoutStart/", 0, 0, 0, yourValue));
            }

            Response.Redirect(FriendlyUrl.Href("~/Checkout/CheckoutStart/"));
        }

        protected void CreateNewBtn_Click(object sender, EventArgs e)
        {
            Session["ReturnUrlCreateContact"] = "~/Checkout/CheckoutStart";
            Response.Redirect(FriendlyUrl.Href("~/Admin/Contacts/Insert"));

        }

        protected void EditBtn_Click1(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string contactId = btn.CommandArgument;
            Session["ReturnUrlEditContact"] = "~/Checkout/CheckoutStart/" + contactId;
            Response.Redirect(FriendlyUrl.Href("~/Admin/Contacts/Edit", contactId));
        }


        protected void CreateNewOrderingBtn_Click(object sender, EventArgs e)
        {
            IList<string> segments = Request.GetFriendlyUrlSegments();
            Session["ReturnUrlCreateOrdering"] = "~/Checkout/CheckoutStart/" + int.Parse(segments[0]);
            Response.Redirect(FriendlyUrl.Href("~/Admin/Shippings/AddShipping", int.Parse(segments[0])));/////
        }

        protected void CreateNewShippingBtn_Click(object sender, EventArgs e)
        {
            IList<string> segments = Request.GetFriendlyUrlSegments();
            Session["ReturnUrlCreateShipping"] = "~/Checkout/CheckoutStart/" + int.Parse(segments[0]) + "/" + int.Parse(segments[1]);
            Response.Redirect(FriendlyUrl.Href("~/Admin/Shippings/AddShipping", int.Parse(segments[0])));/////
        }


        protected void OrderingList_Edit(object sender, EventArgs e)
        {
            IList<string> segments = Request.GetFriendlyUrlSegments();
            LinkButton btn = (LinkButton)(sender);
            string ShippingId = btn.CommandArgument;

            Session["ReturnUrlEditOrdering"] = "~/Checkout/CheckoutStart/" + int.Parse(segments[0]) + "/" + ShippingId;
            Response.Redirect(FriendlyUrl.Href("~/Admin/Shippings/Edit", ShippingId));
        }

        protected void ShippingList_Edit(object sender, EventArgs e)
        {
            IList<string> segments = Request.GetFriendlyUrlSegments();
            LinkButton btn = (LinkButton)(sender);
            string ShippingId = btn.CommandArgument;

            Session["ReturnUrlEditShipping"] = "~/Checkout/CheckoutStart/" + int.Parse(segments[0]) + "/" + ShippingId;
            Response.Redirect(FriendlyUrl.Href("~/Admin/Shippings/Edit", ShippingId));
        }


        protected void CreateNewBilling_Click(object sender, EventArgs e)
        {
            IList<string> segments = Request.GetFriendlyUrlSegments();
            Session["ReturnUrlCreateBilling"] = "~/Checkout/CheckoutReview/" + int.Parse(segments[0]) + "/" + int.Parse(segments[1]) + "/" + int.Parse(segments[2]);
            Response.Redirect(FriendlyUrl.Href("~/Admin/Shippings/AddShipping", int.Parse(segments[0])));
        }

        protected void BillingList_Edit(object sender, EventArgs e)
        {
            IList<string> segments = Request.GetFriendlyUrlSegments();
            LinkButton btn = (LinkButton)(sender);
            string BillingId = btn.CommandArgument;

            Session["ReturnUrlEditBilling"] = "~/Checkout/CheckoutReview/" + int.Parse(segments[0]) + "/" + int.Parse(segments[1]) + "/" + BillingId;
            Response.Redirect(FriendlyUrl.Href("~/Admin/Shippings/Edit", BillingId));
        }

    }
}

