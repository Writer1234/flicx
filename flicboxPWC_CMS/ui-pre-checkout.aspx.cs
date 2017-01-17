using flicboxPWC_CMS.PWC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace flicboxPWC_CMS
{
    public partial class ui_pre_checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsPostBack)
                {
                    //if ( ShoppingCart.Instance.Items.Count<=0 )
                    //{
                    //    Response.Redirect("index.aspx", true);
                    //}
                    //else
                    //{
                    //    if (Session["CustLoginID"] != null)
                    //    {
                    //        Response.Redirect("ui-checkout.aspx", true);
                    //    }
                    //}
                }
                
            }
            catch (System.Threading.ThreadInterruptedException) { }
            catch (Exception)
            {
                
                throw;
            }

            
            
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    OrderDetails._instance._OrderMaster.Precheckout.allergies = txtAllergies.Text.Trim();
                    OrderDetails._instance._OrderMaster.Precheckout.birthdate = txtBirthdate.Text.Trim();
                    OrderDetails._instance._OrderMaster.Precheckout.preferencesDiet = ddlPreferenceDiet.SelectedValue;
                    OrderDetails._instance._OrderMaster.Precheckout.preferencesTaste = ddlPreferenceTaste.SelectedValue;
                    OrderDetails._instance.AddOrderDetails(OrderDetails._instance._OrderMaster);
                    Response.Redirect("ui-checkout.aspx", true);
                }
                

            }
            catch (System.Threading.ThreadInterruptedException) { }
            catch (Exception)
            {

                throw;
            }

            
        }
    }
}