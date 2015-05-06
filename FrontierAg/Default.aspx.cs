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
            //throw new InvalidOperationException("An InvalidOperationException " + "occurred in the Page_Load handler on the Default.aspx page.");
            Response.Redirect("ProductList");
        }

        private void Page_Error(object sender, EventArgs e)
        {
            // Get last error from the server.
            Exception exc = Server.GetLastError();

            // Handle specific exception.
            if (exc is InvalidOperationException)
            {
                
                // Pass the error on to the error page.
                Server.Transfer("ErrorPage.aspx?handler=Page_Error%20-%20Default.aspx",
                    true);
            }
        }
    }
}