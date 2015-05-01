using FrontierAg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontierAg
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Product> GetProduct([QueryString("productID")] int? productId)
        {
            var _db = new FrontierAg.Models.ProductContext();
            IQueryable<Product> query = _db.Products;
            if (productId.HasValue && productId > 0)
            {
                query = query.Where(p => p.ProductId == productId);
            }
            else
            {
                query = null;
            }
            return query;
        }

        public IQueryable<Price> GetPrice([QueryString("productID")] int? productId)
        {
            var _db = new FrontierAg.Models.ProductContext();
            IQueryable<Price> query = _db.Prices;
            if (productId.HasValue && productId > 0)
            {
                query = query.Where(p => p.ProductId == productId);
            }
            else
            {
                query = null;
            }
            return query;
        }

        

    }
}