using flicboxPWC_CMS.PWC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace flicboxPWC_CMS
{
    public partial class index : System.Web.UI.Page
    {
        BusinessDataBinding objDatabinder = new BusinessDataBinding();
        ProductMaster objProdMaster = new ProductMaster();
        static string conStr = WebConfigurationManager.ConnectionStrings["conStr"].ConnectionString.ToString().Trim();

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
                //else
                //{

                //}
            }
            catch(System.Threading.ThreadAbortException) { }
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
                rptProducts.DataBind();
                Response.Redirect("cart.aspx", true);
                
            }
            catch (System.Threading.ThreadAbortException) { }
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
                RepeaterItem rptProduct = (RepeaterItem)lnkOneTime.NamingContainer;
                DropDownList dllMonthSub = (DropDownList)rptProduct.FindControl("ddlSubScription");
                string ProductID = dllMonthSub.SelectedValue;
                ShoppingCart.Instance.AddItem(Convert.ToInt32(ProductID),ProductType.OneTime);
                Response.Redirect("cart.aspx", true);
            }
            catch (System.Threading.ThreadAbortException) { }
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
                string random =(new Random()).Next().ToString();
                Response.Redirect(string.Format("ui-pre-checkout-gift.aspx?rnd={0}&Type={1}", random, objURL.encrytedText(ProductType.Gift.ToString())), true);

            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception)
            {

                throw;
            }
        }

        protected void rptProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //PlaceHolder skw_left = e.Item.FindControl("skw_left") as PlaceHolder;
                //PlaceHolder skw_right = e.Item.FindControl("skw_right") as PlaceHolder;
                //HtmlGenericControl divContent = new HtmlGenericControl("div");
                DataRowView row = (DataRowView)e.Item.DataItem;
                Label lblName = (Label)item.FindControl("lblProductName");
                //lblName.ID = "lblProductName";
                lblName.Text = row["CategoryName"].ToString();
                string imagePath = row["ImagePath1"].ToString();
                SqlDataSource sqlDataSource1 = new SqlDataSource();
                sqlDataSource1.ConnectionString = conStr;
                sqlDataSource1.CancelSelectOnNullParameter = true;
                sqlDataSource1.SelectCommand = string.Format("exec [dbo].[GetSubscriptionTypeCombo] @SP_TYPE='ByProductName', @SP_Searchstring='{0}'", lblName.Text.Trim().Replace("'", "''"));
                sqlDataSource1.DataBind();
                //divContent.Attributes["class"] = "skw-page__content";
                 Image image = (Image)item.FindControl("example");
                //image.Style["width"] = "100%";
                //image.Style["height"] = "100%";
                DropDownList ddlSubScription = (DropDownList)item.FindControl("ddlSubScription");
                ddlSubScription.DataSource = sqlDataSource1;
                ddlSubScription.DataValueField = "ID";
                ddlSubScription.DataTextField = "VALUE";
                ddlSubScription.AutoPostBack = false;
                ddlSubScription.DataBind();


                if (!string.IsNullOrWhiteSpace(imagePath))
                {
                    image.ImageUrl = imagePath;
                    //INSERT CODE HERE
                }
                //Literal LtH1Start = new Literal();
                //LtH1Start.Text = "<h2 class='skw-page__heading'>";
                //Literal LtH1End = new Literal();
                //LtH1End.Text = "</h2>";
                //Literal LtPStart = new Literal();
                //LtPStart.Text = "<p class='skw-page__description'>";
                //Literal LtPEnd = new Literal();
                //LinkButton btnSubscribe = new LinkButton();
                //btnSubscribe.CssClass = "btn-default";
                //btnSubscribe.ID = "btnSubscribe";
                //btnSubscribe.Text = "Subscribe";
                //btnSubscribe.Click += new System.EventHandler(this.btnSubscribe_Click);
                //LinkButton btnOneTime = new LinkButton();
                //btnOneTime.CssClass = "btn-default";
                //btnOneTime.ID = "btnOneTime";
                //btnOneTime.Text = "OneTime";
                //btnOneTime.Click += new System.EventHandler(this.btnOneTime_Click);
                //LinkButton btnGift = new LinkButton();
                //btnGift.CssClass = "btn-default";
                //btnGift.ID = "btnGift";
                //btnGift.Text = "Gift";
                //btnGift.Click += new System.EventHandler(this.btnGift_Click);
                //LtPEnd.Text = "</p>";

                //divContent.Controls.Add(LtH1Start);
                //divContent.Controls.Add(lblName);
                //divContent.Controls.Add(LtH1End);
                //divContent.Controls.Add(LtPStart);
                //divContent.Controls.Add(ddlSubScription);
                //divContent.Controls.Add(btnSubscribe);
                //divContent.Controls.Add(btnOneTime);
                //divContent.Controls.Add(btnGift);
                //divContent.Controls.Add(LtPEnd);

                //if (e.Item.ItemIndex % 2 == 0)
                //{
                //    skw_right.Controls.Add(divContent);
                //    skw_left.Controls.Add(image);
                //}
                //else
                //{
                //    skw_left.Controls.Add(divContent);
                //    skw_right.Controls.Add(image);

                //}

            }
        }

        protected void rptProducts_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                PlaceHolder skw_left = e.Item.FindControl("skw_left") as PlaceHolder;
                PlaceHolder skw_right = e.Item.FindControl("skw_right") as PlaceHolder;
                HtmlGenericControl divContent = new HtmlGenericControl("div");
                DataRowView row = (DataRowView)e.Item.DataItem;
                Label lblName = new Label();
                lblName.ID = "lblProductName";
                //lblName.Text = row["CategoryName"].ToString();
                //string imagePath = row["ImagePath1"].ToString();
                //SqlDataSource sqlDataSource1 = new SqlDataSource();
                //sqlDataSource1.ConnectionString = conStr;
                //sqlDataSource1.CancelSelectOnNullParameter = true;
                //sqlDataSource1.SelectCommand = string.Format("exec [dbo].[GetSubscriptionTypeCombo] @SP_TYPE='ByProductName', @SP_Searchstring='{0}'", lblName.Text.Trim().Replace("'", "''"));
                //sqlDataSource1.DataBind();

                divContent.Attributes["class"] = "skw-page__content";
                Image image = new Image();
                image.ID = "example";
                image.Style["width"] = "100%";
                image.Style["height"] = "100%";
                DropDownList ddlSubScription = new DropDownList();
                ddlSubScription.ID = "ddlSubScription";
                //ddlSubScription.DataSource = sqlDataSource1;
                //ddlSubScription.DataValueField = "ID";
                //ddlSubScription.DataTextField = "VALUE";
                ddlSubScription.AutoPostBack = false;
                ddlSubScription.DataBind();


                //if (!string.IsNullOrWhiteSpace(imagePath))
                //{
                //    image.ImageUrl = imagePath;
                //    //INSERT CODE HERE
                //}
                Literal LtH1Start = new Literal();
                LtH1Start.Text = "<h2 class='skw-page__heading'>";
                Literal LtH1End = new Literal();
                LtH1End.Text = "</h2>";
                Literal LtPStart = new Literal();
                LtPStart.Text = "<p class='skw-page__description'>";
                Literal LtPEnd = new Literal();
                LinkButton btnSubscribe = new LinkButton();
                btnSubscribe.CssClass = "btn-default";
                btnSubscribe.ID = "btnSubscribe";
                btnSubscribe.Text = "Subscribe";
                btnSubscribe.Click += new System.EventHandler(this.btnSubscribe_Click);
                LinkButton btnOneTime = new LinkButton();
                btnOneTime.CssClass = "btn-default";
                btnOneTime.ID = "btnOneTime";
                btnOneTime.Text = "OneTime";
                btnOneTime.Click += new System.EventHandler(this.btnOneTime_Click);
                LinkButton btnGift = new LinkButton();
                btnGift.CssClass = "btn-default";
                btnGift.ID = "btnGift";
                btnGift.Text = "Gift";
                btnGift.Click += new System.EventHandler(this.btnGift_Click);
                LtPEnd.Text = "</p>";

                divContent.Controls.Add(LtH1Start);
                divContent.Controls.Add(lblName);
                divContent.Controls.Add(LtH1End);
                divContent.Controls.Add(LtPStart);
                divContent.Controls.Add(ddlSubScription);
                divContent.Controls.Add(btnSubscribe);
                divContent.Controls.Add(btnOneTime);
                divContent.Controls.Add(btnGift);
                divContent.Controls.Add(LtPEnd);

                if (e.Item.ItemIndex % 2 == 0)
                {
                    skw_right.Controls.Add(divContent);
                    skw_left.Controls.Add(image);
                }
                else
                {
                    skw_left.Controls.Add(divContent);
                    skw_right.Controls.Add(image);

                }

            }
        }
    }
}