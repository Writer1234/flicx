using flicboxPWC_CMS.PWC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace flicboxPWC_CMS
{
    public partial class MasterFlicbox : System.Web.UI.MasterPage
    {
        private plans _objplansMaster;

        Page _page = HttpContext.Current.CurrentHandler as Page;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    int qty = ShoppingCart.Instance.GetTotalQuantity();

                    if (qty > 0)
                    {
                        UpdateCartCount(Convert.ToString(qty));
                    }
                }
            }
            catch (Exception ex)
            {
                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace, ex.TargetSite.ToString(), "MasterFlicbox.Page_Load()", _page);
            }
        }

        public void UpdateCartCount(string count="0")
        {
            try
            {
                lblCartCount.Text = count;
            }
            catch (Exception ex)
            {
                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace, ex.TargetSite.ToString(), "MasterFlicbox.UpdateCartCount()", _page);
            }
            
        }
    }
}