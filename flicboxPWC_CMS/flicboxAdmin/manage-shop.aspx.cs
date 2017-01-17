using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using flicboxPWC_CMS.PWC;

namespace flicboxPWC_CMS.flicboxAdmin
{
    public partial class manage_shop : System.Web.UI.Page
    {
        string strQuery = "";

        BusinessDataBinding objDatabinder = new BusinessDataBinding();
        ProductMaster objProdMaster = new ProductMaster();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("~/flicboxAdmin/login.aspx");

            if (!IsPostBack)
            {
                divStatus.Visible = false;

                strQuery = "Select * FROM ProductMaster WHERE varcharProductType = 'Shop'";
                objDatabinder.BindGridView(grdvwProductMaster, strQuery, this);
                ViewState["Query"] = strQuery;
            }

        }
        protected void grdvwProductMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvwProductMaster.PageIndex = e.NewPageIndex;
            strQuery = ViewState["Query"].ToString().Trim();
            objDatabinder.BindGridView(grdvwProductMaster, strQuery, this);
            divStatus.Visible = false;
        }

        protected void grdvwProductMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower().Trim() == "delete")
            {
                int prodID = Convert.ToInt32(e.CommandArgument.ToString().Trim());

                objProdMaster.ProductID = prodID;
                objProdMaster.ProductType = "none";
                objProdMaster.SubscriptionType = 0;
                objProdMaster.ProductName = "none";
                objProdMaster.ShortDesc = "none";
                objProdMaster.LongDesc = "none";
                objProdMaster.ProductPrice = 0;
                objProdMaster.ProductImg2 = "";
                objProdMaster.ProductImg3 = "";
                objProdMaster.ProductImg4 = "";
                objProdMaster.ProductImg5 = "";
                objProdMaster.InsertedBy = objProdMaster.UpdatedBy = Session["username"].ToString().Trim();
                objProdMaster.InsertedDate = objProdMaster.UpdatedDate = DateTime.Now;

                objProdMaster.CallProcedureProductMasterDML(3, this);

                divStatus.InnerHtml = Global.DisplayStatusDivision(objProdMaster.HasErrors, objProdMaster.ErrorMessage, this);
                divStatus.Visible = true;

                strQuery = ViewState["Query"].ToString().Trim();
                objDatabinder.BindGridView(grdvwProductMaster, strQuery, this);
            }
        }

        protected void grdvwProductMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
        }
    }
}