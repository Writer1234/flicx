using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using flicboxPWC_CMS.PWC;
namespace flicboxPWC_CMS.flicboxAdmin
{
    public partial class contact_us_master : System.Web.UI.Page
    {
        string strQuery = "";

        BusinessDataBinding objDatabinder = new BusinessDataBinding();
        ContactUs objContact = new ContactUs();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("~/flicboxAdmin/login.aspx");

            if (!IsPostBack)
            {
                divStatus.Visible = false;

                strQuery = "Select * from FlicboxContact";
                objDatabinder.BindGridView(grdvwContactUs, strQuery, this);
                ViewState["Query"] = strQuery;
            }
        }

        protected void grdvwContactUs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdvwContactUs.PageIndex = e.NewPageIndex;
            strQuery = ViewState["Query"].ToString().Trim();
            objDatabinder.BindGridView(grdvwContactUs, strQuery, this);
            divStatus.Visible = false;
        }

        protected void grdvwContactUs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower().Trim() == "delete")
            {
                int contactID = Convert.ToInt32(e.CommandArgument.ToString().Trim());

                objContact.ContactID = contactID;
                objContact.ContactName = "none";
                objContact.ContactEmail = "none";
                objContact.ContactMobile = "none";
                objContact.ContactMsg = "none";
                objContact.InsertedBy = objContact.UpdatedBy = Session["username"].ToString().Trim();
                objContact.InsertedDate = objContact.UpdatedDate = DateTime.Now;

                objContact.CallProcedureContactUsDML(3, this);

                divStatus.InnerHtml = Global.DisplayStatusDivision(objContact.HasErrors, objContact.ErrorMessage, this);
                divStatus.Visible = true;

                strQuery = ViewState["Query"].ToString().Trim();
                objDatabinder.BindGridView(grdvwContactUs, strQuery, this);
            }
        }

        protected void grdvwContactUs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
        }
    }
}