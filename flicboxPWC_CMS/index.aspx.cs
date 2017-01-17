using flicboxPWC_CMS.PWC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace flicboxPWC_CMS
{
    public partial class index : System.Web.UI.Page
    {
        BusinessDataBinding objDatabinder = new BusinessDataBinding();
        ProductMaster objProdMaster = new ProductMaster();


        public void UpdateCartCount()
        {
            try
            {
                int qty = ShoppingCart.Instance.GetTotalQuantity();
                if (ShoppingCart.Instance!=null && qty >  0)
                {
                    lblCartCount.Text=Convert.ToString(qty);
                }
                else
                {
                    lblCartCount.Text = "0";
                }

            }
            catch (Exception ex)
            {
                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace, ex.TargetSite.ToString(), "MasterFlicbox.UpdateCartCount()", this.Page);
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UpdateCartCount();

                if (!IsPostBack)
                {
                    if (Session["customerUsername"] == null)
                    {
                        btnUser.Visible = false;
                    }
                    else
                    {
                        btnLogin.Visible = false;
                        btnUser.Visible = true;
                        btnUser.InnerText = "Hi, " + Session["customerUsername"].ToString();
                    }

                    string productquery = string.Format("[dbo].[GetCategoryMasterGrid]");
                    objDatabinder.BindRepeater(rptProducts, productquery, this.Page);


                }
            }
            catch(System.Threading.ThreadInterruptedException) { }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }

        protected void btnSubscribe_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkSubscribe = (LinkButton)sender;
                RepeaterItem rptProduct = (RepeaterItem)lnkSubscribe.NamingContainer;
                DropDownList dllMonthSub = (DropDownList)rptProduct.FindControl("ddlSubScription");

                string ProductID = dllMonthSub.SelectedValue;
                ShoppingCart.Instance.AddItem(Convert.ToInt32(ProductID));
                Response.Redirect("cart.aspx", true);
                
            }
            catch (System.Threading.ThreadInterruptedException) { }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnOneTime_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkOneTime = (LinkButton)sender;
                string ProductID = lnkOneTime.CommandArgument;
                ShoppingCart.Instance.AddItem(Convert.ToInt32(ProductID));
                Response.Redirect("cart.aspx", true);
            }
            catch (System.Threading.ThreadInterruptedException) { }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnGift_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkOneTime = (LinkButton)sender;
                string ProductID = lnkOneTime.CommandArgument;
                ShoppingCart.Instance.AddItem(Convert.ToInt32(ProductID));
                Response.Redirect("cart.aspx", true);

            }
            catch (System.Threading.ThreadInterruptedException) { }
            catch (Exception)
            {

                throw;
            }
        }
    }
}