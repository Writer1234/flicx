using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using flicboxPWC_CMS.PWC;

namespace flicboxPWC_CMS
{
    public partial class plans : System.Web.UI.Page
    {
        private ProductMaster _objProdMaster;

        Page _page = HttpContext.Current.CurrentHandler as Page;
        public  ProductMaster objProdMaster
        {
            get{

                if (_objProdMaster==null)
	                {
		                _objProdMaster=new  ProductMaster();
	                }

                return _objProdMaster;
            }

        }

        public string _CartCount="0";

        public string CartCount
        {

            get
            {
                if (Session["Count"] != null)
                {

                    _CartCount = Convert.ToString(Session["Count"]); 
                }

                return _CartCount;
            }

            set {

                Session["Count"] = value;
            }

        }  



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //divPlansData.InnerHtml = objProdMaster.FillPlansData(this);
                rptProducts.DataSource = objProdMaster.FillPlansDataGrid(this);
                rptProducts.DataBind();
            }
        }

        protected void btnAddCart_Click(object sender, EventArgs e)
        {
            try 
	        {

                LinkButton ddl = (LinkButton)sender;
                ListViewItem listView = (ListViewItem)ddl.NamingContainer;
                ListViewDataItem DataItem = (ListViewDataItem)listView.DataItem;
                string ProductID = rptProducts.DataKeys[0]["intProductID"].ToString();

                
                if (Request.Cookies["ShoppingCart"] == null)
                {

                    HttpCookie oCookie = new HttpCookie("ShoppingCart");

                    //Set Cookie to expire in 3 hours

                    oCookie.Expires = DateTime.Now.AddDays(1);
                    oCookie.Value = ProductID;

                    Response.Cookies.Add(oCookie);
                    CartCount = "1";
                }
                else
                {

                    bool bExists = false;

                    char[] sep = { ',' };

                    HttpCookie oCookie = (HttpCookie)Request.Cookies["ShoppingCart"];

                    //Set Cookie to expire in 3 hours

                    oCookie.Expires = DateTime.Now.AddDays(1);

                    //Check if Cookie already contain same item

                    string sProdID = oCookie.Value.ToString();

                    string[] arrCookie = sProdID.Split(sep);
                    for (int i = 0; i < arrCookie.Length; i++)
                    {
                        if (arrCookie[i].Trim() == ProductID.Trim())
                        {
                            bExists = true;
                        }
                    }
                    if (!bExists)
                    {
                        if (oCookie.Value.Length == 0)
                        {
                            oCookie.Value = ProductID;
                        }

                        else
                        {
                            oCookie.Value = oCookie.Value + "," + ProductID;
                        }
                    }


                    CartCount = arrCookie.Count().ToString();
                    ((MasterFlicbox)this.Page.Master).UpdateCartCount(CartCount);
                    //Add back into  the Response Objects.
                    Response.Cookies.Add(oCookie);

                }


	        }
	        catch (Exception ex)
	        {

                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace, ex.TargetSite.ToString(), "plan.btnAddCart_Click()", _page);
	        }
        }

        protected void ddlSubscriptionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddl=(DropDownList)sender;
                ListViewItem listView = (ListViewItem)ddl.NamingContainer;
                Label lblprice = (Label)listView.FindControl("lblPrice");
                lblprice.Text = objProdMaster.GetPrice(this, ddl.SelectedValue.ToString());
            }
            catch (Exception ex)
            {

                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace, ex.TargetSite.ToString(), "plan.ddlSubscriptionType_SelectedIndexChanged()", _page);
            }
        }

        

  

   

    }
}