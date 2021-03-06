﻿using FrontierAg.Models;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace FrontierAg.Admin.Orders
{
    public partial class ContactOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<Order> OrdersList_GetData([FriendlyUrlSegmentsAttribute(0)]int? ContactId)
        {
            if (ContactId != null)
            {
                FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();                
                return _db.Orders.Include(m => m.OrderShippings.Select(en => en.Shipping)).Where(en => en.ContactId == ContactId);                                             
            }
            return null;
        }
    }
}