using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using flicboxPWC_CMS.PWC;

namespace flicboxPWC_CMS.flicboxAdmin
{
    public partial class corporate_gifting_master : System.Web.UI.Page
    {
        string strQuery = "";

        BusinessDataBinding objDatabinder = new BusinessDataBinding();
        CorporateGifting objGift = new CorporateGifting();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("~/flicboxAdmin/login.aspx");

            if (!IsPostBack)
            {
                divStatus.Visible = false;

                strQuery = "Select * from CorporateGifting";
                objDatabinder.BindGridView(grdvwCorporateGifting, strQuery, this);
                ViewState["Query"] = strQuery;
            }
        }

        protected void grdvwCorporateGifting_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvwCorporateGifting.PageIndex = e.NewPageIndex;
            strQuery = ViewState["Query"].ToString().Trim();
            objDatabinder.BindGridView(grdvwCorporateGifting, strQuery, this);
            divStatus.Visible = false;
        }

        protected void grdvwCorporateGifting_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower().Trim() == "delete")
            {
                int giftID = Convert.ToInt32(e.CommandArgument.ToString().Trim());

                objGift.GiftID = giftID;
                objGift.PersonName = "none";
                objGift.CompanyName = "none";
                objGift.CompanyEmail = "none";
                objGift.CompanyMobile = "none";
                objGift.CompanyHeadcount = "none";
                objGift.CompanyDes = "none";
                objGift.InsertedBy = objGift.UpdatedBy = Session["username"].ToString().Trim();
                objGift.InsertedDate = objGift.UpdatedDate = DateTime.Now;

                objGift.CallProcedureCorporateGiftingDML(3, this);

                divStatus.InnerHtml = Global.DisplayStatusDivision(objGift.HasErrors, objGift.ErrorMessage, this);
                divStatus.Visible = true;

                strQuery = ViewState["Query"].ToString().Trim();
                objDatabinder.BindGridView(grdvwCorporateGifting, strQuery, this);
            }
        }

        protected void grdvwCorporateGifting_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
        }
    }
}