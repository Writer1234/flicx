using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using flicboxPWC_CMS.PWC;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace flicboxPWC_CMS
{
    public partial class cart : System.Web.UI.Page
    {
        string strQuery = "";
        public static int PreviousIndex;
        BusinessDataBinding objDatabinder = new BusinessDataBinding();

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

        private plans _objplans;


        public plans objplans
        {
            get
            {

                if (_objplans == null)
                {
                    _objplans = new plans();
                }

                return _objplans;
            }

        }

        Order _order;

        public Order ObjOrder
        {
            get
            {

                if (_order == null)
                {
                    _order = new Order();
                }

                return _order;
            }

        }

        


        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                //#region start cookie end
                //    HttpCookie oCookies = new HttpCookie("ShoppingCart");
                //    oCookies.Value = "";
                //    Response.Cookies.Add(oCookies);
                //#endregion
                if (!IsPostBack)
                {
                    
                    bindgrid();
                    callJavascript();
                }

            }
            catch (System.Threading.ThreadAbortException) { }
            catch(Exception)
            { }   

        }


        private void bindgrid()
        {
            try
            {
                if (ShoppingCart.Instance.Items.Count > 0)
                {
                    grdvwCart.DataSource = ObjOrder.GetCartProduct();
                    grdvwCart.DataBind();
                }
                else
                {
                    Response.Redirect("index.aspx", true);
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception)
            { }

        }


        private void callJavascript()
        {
            try
            {
                ClientScript.RegisterStartupScript(GetType(), "id", "GetTotal()", true);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception)
            {

            }

        }
        protected void grdvwCart_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //grdvwCart.PageIndex = e.NewPageIndex;
            //strQuery = ViewState["Query"].ToString().Trim();
            //objDatabinder.BindGridView(grdvwCart, strQuery, this);
            //divStatus.Visible = false;
        }

        protected void grdvwCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void grdvwCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void ddlSubscriptionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList ddl = (DropDownList)sender;
                GridViewRow listView = (GridViewRow)ddl.NamingContainer;
                Label lblEditPrice = (Label)listView.FindControl("lblEditPrice");
                TextBox txtEditQty = (TextBox)listView.FindControl("txtEditQty");
                Label lblEditTotal = (Label)listView.FindControl("lblEditTotal");
                //HiddenField HFVProductID = (HiddenField)listView.FindControl("HFVProductID");

                lblEditPrice.Text = objProdMaster.GetPrice(this, ddl.SelectedValue.ToString());
                double Total = (Convert.ToInt16(txtEditQty.Text) * Convert.ToDouble(lblEditPrice.Text.Trim()));
                lblEditTotal.Text = Convert.ToString(Total);
                //HFVProductID.Value = ddl.SelectedValue.ToString();

            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace, ex.TargetSite.ToString(), "cart.ddlSubscriptionType_SelectedIndexChanged()", _page);
            }
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkDelete = (LinkButton)sender;

                 ShoppingCart.Instance.RemoveItem(Convert.ToInt32(lnkDelete.CommandArgument));
                 bindgrid();
                callJavascript();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {

                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace, ex.TargetSite.ToString(), "cart.lnkDelete_Click()", _page);
            }
        }

        private DataTable GetData(string query)
        {
            string conString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            SqlCommand cmd = new SqlCommand(query);
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable ds = new DataTable())
                    {
                        sda.Fill(ds);
                        return ds;
                    }
                }
            }
        }

        protected void grdvwCart_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
                {
                    //Find the DropDownList in the Row
                    Label lblEditProductName = (e.Row.FindControl("lblEditProductName") as Label);
                    DropDownList ddlSubscriptionType = (e.Row.FindControl("ddlSubscriptionType") as DropDownList);
                    ddlSubscriptionType.DataSource = GetData(string.Format("EXEC [dbo].[GetSubscriptionTypeCombo] @SP_TYPE='ByProductWithPrice',@SP_Searchstring='{0}'", lblEditProductName.Text.Trim()));
                    ddlSubscriptionType.DataTextField = "VALUE";
                    ddlSubscriptionType.DataValueField = "ID";
                    ddlSubscriptionType.DataBind();
                    //DataRowView rowView = (DataRowView)e.Row.DataItem;
                    GridView childGrid = (GridView)sender;

                    //Select the Country of Customer in DropDownList
                    var ProductId = childGrid.DataKeys[e.Row.RowIndex].Value.ToString();
                    ddlSubscriptionType.Items.FindByValue(ProductId.ToString()).Selected = true;
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    
                }

            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {

                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace, ex.TargetSite.ToString(), "cart.grdvwCart_RowDataBound()", _page);
            }
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            try
            {
                if (ShoppingCart.Instance.Items.Count>0)
                {

                    if (Session["customerUsername"] == null)
                    {
                        Response.Redirect("ui-pre-checkout.aspx", true);
                    }
                    else
                    {
                        Response.Redirect("ui-checkout.aspx", true);
                    }

                   
                }


            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {

                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace, ex.TargetSite.ToString(), "cart.grdvwCart_RowDataBound()", _page);
            }
        }

        protected void grdvwCart_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                grdvwCart.EditIndex = e.NewEditIndex;
                bindgrid();
                callJavascript();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace, ex.TargetSite.ToString(), "cart.grdvwCart_RowEditing()", _page);
            }
        }

        protected void grdvwCart_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = grdvwCart.Rows[e.RowIndex];
                int ProductID = Convert.ToInt32(grdvwCart.DataKeys[e.RowIndex].Value);
                TextBox txtEditQty = row.FindControl("txtEditQty") as TextBox;
                DropDownList ddlSubscriptionType = row.FindControl("ddlSubscriptionType") as DropDownList;

                if (txtEditQty != null && !string.IsNullOrWhiteSpace(txtEditQty.Text))
                {
                    CartItem item = ShoppingCart.Instance.Items.Find(c => c.ProductId == ProductID);
                    CartItem item2 = ShoppingCart.Instance.Items.Find(c => c.ProductId == Convert.ToInt32(ddlSubscriptionType.SelectedValue));
                    int UpdateQty = 0;
                    if (item != null && item2 != null)
                        UpdateQty = (item.Quantity + item2.Quantity);
                    
                    if (item!=null && item2!=null && Convert.ToInt32(ddlSubscriptionType.SelectedValue) == ProductID )
                    {
                         ShoppingCart.Instance.SetItemQuantity(Convert.ToInt32(ddlSubscriptionType.SelectedValue),Convert.ToInt32(txtEditQty.Text.Trim()));
                    }
                    else if(item != null && item2 != null && Convert.ToInt32(ddlSubscriptionType.SelectedValue) != ProductID)
                    {
                        ShoppingCart.Instance.SetItemQuantity(ProductID, 0);
                        if (item2 != null)
                        {
                            ShoppingCart.Instance.SetItemQuantity(Convert.ToInt32(ddlSubscriptionType.SelectedValue), UpdateQty);
                        }
                    }
                    else if(item!=null && item2==null && Convert.ToInt32(ddlSubscriptionType.SelectedValue) != ProductID)
                    {
                        ShoppingCart.Instance.SetItemQuantity(ProductID, 0);
                        if (item2 == null)
                        {
                            ShoppingCart.Instance.AddItem(Convert.ToInt32(ddlSubscriptionType.SelectedValue));
                            ShoppingCart.Instance.SetItemQuantity(Convert.ToInt32(ddlSubscriptionType.SelectedValue), Convert.ToInt32(txtEditQty.Text.Trim()));
                        }
                    } 
                    //else if (item==null &&  item2!=null && Convert.ToInt32(ddlSubscriptionType.SelectedValue) != ProductID)
                    //{
                    //    ShoppingCart.Instance.SetItemQuantity(ProductID, 0);
                    //    if ( item2!= null)
                    //     {
                    //         ShoppingCart.Instance.SetItemQuantity(Convert.ToInt32(ddlSubscriptionType.SelectedValue), Convert.ToInt32(txtEditQty.Text.Trim()));
                    //     }

                    //}
                    else if (item == null && item2==null)
                    {
                        ShoppingCart.Instance.SetItemQuantity(ProductID, 0);
                        ShoppingCart.Instance.AddItem(Convert.ToInt32(ddlSubscriptionType.SelectedValue));
                        ShoppingCart.Instance.SetItemQuantity(Convert.ToInt32(ddlSubscriptionType.SelectedValue), Convert.ToInt32(txtEditQty.Text.Trim()));
                    }
                    //lblMessage.Text = String.Format(
                    //    "Customer '{0} {1}' successfully updated.",
                    //    customer.FirstName,
                    //    customer.LastName);

                    grdvwCart.EditIndex = -1;
                    bindgrid();
                    callJavascript();
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace, ex.TargetSite.ToString(), "cart.grdvwCart_RowUpdating()", _page);
            }
        }

        protected void grdvwCart_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                grdvwCart.EditIndex = -1;
                bindgrid();
                callJavascript();
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace, ex.TargetSite.ToString(), "cart.grdvwCart_RowCancelingEdit()", _page);
            }
        }
    }
}