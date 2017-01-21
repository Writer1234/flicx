using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using flicboxPWC_CMS.PWC;

namespace flicboxPWC_CMS
{
    public partial class ui_pre_checkout_gift : System.Web.UI.Page
    {

        private ProductMaster _objProdMaster;

        Page _page = HttpContext.Current.CurrentHandler as Page;
        public ProductMaster objProdMaster
        {
            get
            {

                if (_objProdMaster == null)
                {
                    _objProdMaster = new ProductMaster();
                }

                return _objProdMaster;
            }

        }

        private UrlEncode _objURL;
        public UrlEncode objURL
        {
            get
            {

                if (_objURL == null)
                {
                    _objURL = new UrlEncode();
                }

                return _objURL;
            }

        }

        BusinessDataBinding objDatabinder = new BusinessDataBinding();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    if (Request.QueryString.AllKeys.Contains("Type") && Request.QueryString["Type"] != null)
                    {
                        string ptype = objURL.DecryptText(Request.QueryString["Type"].ToString());
                        ProductType type = (ProductType)Enum.Parse(typeof(ProductType), ptype, true);

                        if (type == ProductType.Gift)
                        {
                            string productquery = string.Format("[dbo].[GetCategoryMasterGrid]");
                            objDatabinder.BindListView(rptProducts, productquery, this.Page);
                            
                        }
                        else
                        {
                            Response.Redirect("index.aspx", true);
                        }
                    }
                    else
                    {
                        Response.Redirect("index.aspx", true);
                    }

                    ((MasterFlicbox)this.Page.Master).UpdateCartCount();
                }

            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace, ex.TargetSite.ToString(), "ui-pre-checkout-gift.Page_Load()", _page);
            }
        }

        protected void btnAddCart_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btnAddCart = (LinkButton)sender;
                ListViewItem listView = (ListViewItem)btnAddCart.NamingContainer;
                DropDownList dllMonthSub = (DropDownList)listView.FindControl("ddlSubscriptionType");
                string ProductID = dllMonthSub.SelectedValue;
                ShoppingCart.Instance.AddItem(Convert.ToInt32(ProductID), ProductType.Gift);
                ((MasterFlicbox)this.Page.Master).UpdateCartCount();
                Response.Redirect("cart.aspx", true);

            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace, ex.TargetSite.ToString(), "ui-pre-checkout-gift.btnAddCart_Click()", _page);
            }
        }



        protected void btnProceed_Click(object sender, EventArgs e)
        {
            try
            {
                if(ShoppingCart.Instance.Items.Count>0)
                {
                    Response.Redirect("cart.aspx", true);

                }
                else
                {
                    Response.Redirect("index.aspx", true);
                }

            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace, ex.TargetSite.ToString(), "ui-pre-checkout-gift.btnProceed_Click()", _page);
            }
        }


        protected void ddlSubscriptionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddl = (DropDownList)sender;
                ListViewItem listView = (ListViewItem)ddl.NamingContainer;
                Label lblprice = (Label)listView.FindControl("lblPrice");
                lblprice.Text = @"&#x20b9;" + objProdMaster.GetPrice(this, ddl.SelectedValue.ToString());
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {

                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace, ex.TargetSite.ToString(), "ui-pre-checkout-gift.ddlSubscriptionType_SelectedIndexChanged()", _page);
            }
        }

        protected void rdbYes_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int price = int.Parse(txtBudget.Text.Trim());
                if (price>0)
                {
                    string query = string.Format("[dbo].[GetProductByPriceBudget] @SP_PRODUCTTYPE={0},@SP_Price={1}","subscription",Convert.ToString(price));
                    objDatabinder.BindListView(DTlstInBudget, query, this.Page);
                }
                else
                {
                    DTlstInBudget.DataSource = null;
                    DTlstInBudget.DataBind();
                }
                
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                DTlstInBudget.DataSource = null;
                DTlstInBudget.DataBind();
                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace, ex.TargetSite.ToString(), "ui-pre-checkout-gift.ddlSubscriptionType_SelectedIndexChanged()", _page);
            }
        }

        protected void btnBudgetProductAdd_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btnAddCart = (LinkButton)sender;
                ListViewItem listView = (ListViewItem)btnAddCart.NamingContainer;
                ListViewDataItem DataItem = (ListViewDataItem)listView.DataItem;
                string ProductID = DTlstInBudget.DataKeys[0]["intProductID"].ToString();
                ShoppingCart.Instance.AddItem(Convert.ToInt32(ProductID), ProductType.Gift);
                ((MasterFlicbox)this.Page.Master).UpdateCartCount();
                Response.Redirect("cart.aspx", true);

            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace, ex.TargetSite.ToString(), "ui-pre-checkout-gift.btnBudgetProductAdd_Click()", _page);
            }
        }
    }
}