﻿using FrontierAg.Models;
using Microsoft.AspNet.FriendlyUrls;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontierAg
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }                

        public IQueryable<Product> GetProducts([FriendlyUrlSegmentsAttribute(0)]int? categoryId, [FriendlyUrlSegmentsAttribute(1)]String searchString)
        {
            var _db = new FrontierAg.Models.ProductContext();

            IQueryable<Product> query = _db.Products.Where(prod => prod.CategoryId != 17);

            if (categoryId.HasValue && categoryId > 0)
            {
                return query = query.Where(p => p.CategoryId == categoryId);
            }
            else if (!String.IsNullOrEmpty(searchString))
            {
                return query = query.Where(s => s.ProductNo.Contains(searchString) || s.ProductName.Contains(searchString)).Where(prod => prod.CategoryId != 17);
            }

            return query;
        }
        

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {            
            string yourValue = Server.HtmlEncode(TextBox1.Text.Trim());

            if (yourValue != "")
            {                
                Response.Redirect(FriendlyUrl.Href("~/ProductList/", 0, yourValue));
            }

            Response.Redirect(FriendlyUrl.Href("~/ProductList/"));
        }

        
    }
}