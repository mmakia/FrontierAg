using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.FriendlyUrls;
using System.Data.Entity;

namespace FrontierAg.Admin.OrderDetails
{
    public partial class AllDetails : System.Web.UI.Page
    {
        int ContactId;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<FrontierAg.Models.OrderDetail> AllDetailsGrid_GetData()
        {            
            IList<string> segments = Request.GetFriendlyUrlSegments();
            ContactId = int.Parse(segments[0]);

            if (ContactId != null)
            {
                FrontierAg.Models.ProductContext _db = new FrontierAg.Models.ProductContext();
                //var my = from r in _db.OrderDetails
                return _db.OrderDetails.Where(mn => mn.Order.ContactId == ContactId);
            }
            return null;
        }
    }
}