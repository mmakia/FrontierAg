﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using FrontierAg.Models;

namespace FrontierAg.Pos
{
    public partial class Default : System.Web.UI.Page
    {
		protected FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // Model binding method to get List of Po entries
        // USAGE: <asp:ListView SelectMethod="GetData">
        public IQueryable<FrontierAg.Models.Po> GetData()
        {
            return _db.Pos.Include(m => m.Contact);
        }
    }
}

