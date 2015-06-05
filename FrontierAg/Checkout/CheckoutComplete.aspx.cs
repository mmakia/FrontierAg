using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontierAg.Checkout
{
    public partial class CheckoutComplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new Emailer().SendEmail("mmakia@frontierssi.com", "orders@frontierssi.com", "FrontierAg New Order ", "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
            new Emailer().SendEmail("snacko@frontierssi.com", "orders@frontierssi.com", "FrontierAg New Order ", "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
            new Emailer().SendEmail("ugatti@frontierssi.com", "orders@frontierssi.com", "FrontierAg New Order ", "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
            new Emailer().SendEmail("rwright@frontierssi.com", "orders@frontierssi.com", "FrontierAg New Order ", "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
            new Emailer().SendEmail("ddavis@fsiag.com", "orders@frontierssi.com", "FrontierAg New Order ", "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
            new Emailer().SendEmail("mvella@fsiag.com ", "orders@frontierssi.com", "FrontierAg New Order ", "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
            new Emailer().SendEmail("mwoolman@frontierssi.com ", "orders@frontierssi.com", "FrontierAg New Order ", "There is a new Order, Please Click on the following link for Details: http://orders2.frontiersci.com/FSIAg/Admin/Orders/OpenOrder");
        }

        protected void Continue_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

    }
}