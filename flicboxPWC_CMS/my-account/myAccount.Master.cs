using flicboxPWC_CMS.PWC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace flicboxPWC_CMS.my_account
{
    public partial class myAccount : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    if (Session["CustLoginID"] != null)
                    {
                    }
                    else
                    {
                        Response.Redirect("~/my-account/login.aspx", true);
                    }
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {

                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace, ex.TargetSite.ToString(), "CustOrderView.Page_Load()", this.Page);
            }
        }

        protected void lnkSignOut_Click(object sender, EventArgs e)
        {
            try
            {
                Session["CustLoginID"] = null;
                Session["customerUsername"] = null;
                Session.Abandon();
                Response.Redirect("~/index.aspx",true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {

                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace, ex.TargetSite.ToString(), "CustOrderView.Page_Load()", this.Page);
            }

            

        }
    }
}