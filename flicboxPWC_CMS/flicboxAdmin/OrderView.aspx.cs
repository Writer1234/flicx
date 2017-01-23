using flicboxPWC_CMS.PWC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace flicboxPWC_CMS.flicboxAdmin
{
    public partial class OrderView : System.Web.UI.Page
    {
        BusinessDataBinding objDatabinder = new BusinessDataBinding();

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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if(Session["username"] == null)
                Response.Redirect("~/flicboxAdmin/login.aspx",true);

                if (!IsPostBack)
                {
                    txtFromDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    txtToDate.Text = DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd");
                    txtCustName.Text = string.Empty;
                    divStatus.Visible = false;
                   
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {

                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace, ex.TargetSite.ToString(), "OrderView.Page_Load()", this.Page);
            }

        }

        protected void grdvwOrderMaster_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void grdvwOrderMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdvwOrderMaster.PageIndex = e.NewPageIndex;
                Button1_Click(null, null);
                divStatus.Visible = false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void grdvwOrderMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string strQuery = String.Format("EXEC [dbo].[GetOrderDetailsForGrid] @SP_FROMDATE='{0}',@SP_TODATE='{1}',@sp_USERSTRING='{2}'",
                    txtFromDate.Text.Trim()
                   ,txtToDate.Text.Trim()
                   ,txtCustName.Text.Trim());
                objDatabinder.BindGridView(grdvwOrderMaster, strQuery, this);
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void grdvwOrderMaster_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                 LinkButton hl = (LinkButton)e.Row.FindControl("lnkOrderID");
                string OrderID= DataBinder.Eval(e.Row.DataItem, "intOrderID").ToString();
                hl.PostBackUrl = "OrderMaster.aspx?q=" + objURL.encrytedText(OrderID);
            }
        }
    }
}