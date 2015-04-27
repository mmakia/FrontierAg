using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontierAg
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         //   new Emailer().SendEmail("mmakia@frontierssi.com", "orders@frontierssi.com", "Test Email", "Test Email body");//("gsilber@cyberdaptive.com", "orders@frontierssi.com", "Test Email", "Test Email body");
            Response.Redirect("ProductList");
        }
    }
}