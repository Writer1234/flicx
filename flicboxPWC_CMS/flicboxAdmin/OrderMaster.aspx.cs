using flicboxPWC_CMS.PWC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace flicboxPWC_CMS.flicboxAdmin
{
    public partial class OrderMaster : System.Web.UI.Page
    {
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

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {

                    if (Session["username"] != null && Request.QueryString["q"] != null)
                    {
                        string OrderID = objURL.DecryptText(Convert.ToString(Request.QueryString["q"]));
                        if (!string.IsNullOrWhiteSpace(OrderID))
                        {
                            HFVOrderID.Value = OrderID;

                            OrderDetail(OrderID);
                        }

                    }
                    else
                    {
                        Response.Redirect("~/flicboxAdmin/login.aspx", true);
                    }


                }

            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {

                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace, ex.TargetSite.ToString(), "OrderMaster.Page_Load()", this.Page);
            }
        }

        private void OrderDetail(string OrderID)
        {
            using (SqlConnection Con = new SqlConnection(conStr))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Con;
                cmd.CommandText = string.Format("dbo.GetOrderDetails");
                cmd.Parameters.AddWithValue("@SP_ORDERID", OrderID);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                DataSet data = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(data);

                if (data.Tables.Count == 2)
                {
                    lblOrderID.Text = @"#" + OrderID;
                    lblOrderStatus.Text = data.Tables[0].Rows[0]["OrderStatus"].ToString();
                    lblOrderDate.Text = data.Tables[0].Rows[0]["OrderDate"].ToString();
                    lblAddress.Text = data.Tables[0].Rows[0]["BillAddress"].ToString();
                    grdvwOrderDetails.DataSource = data.Tables[1];
                    grdvwOrderDetails.DataBind();
                }

            }

        }

        protected void btnConfirmOrder_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection Con = new SqlConnection(conStr))
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Con;
                    cmd.CommandText = string.Format("dbo.RenewOrderOfSubscription");

                    cmd.Parameters.AddWithValue("@SP_TYPE", "Manual").Direction = ParameterDirection.Input;
                    cmd.Parameters.Add("@SP_OrderID", SqlDbType.BigInt, 0).Value = HFVOrderID.Value.Trim();
                    cmd.Parameters.AddWithValue("@SP_ISCONFIRMED", true).Direction = ParameterDirection.Input;
                    cmd.Parameters.Add("@SP_MESSAGE", SqlDbType.NVarChar, -1);
                    cmd.Parameters["@SP_MESSAGE"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@RETURNSTATUS", SqlDbType.SmallInt, 0);
                    cmd.Parameters["@RETURNSTATUS"].Direction = ParameterDirection.ReturnValue;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    Con.Open();
                    try
                    {
                        int i = cmd.ExecuteNonQuery();
                        int status = Convert.ToInt32(cmd.Parameters["@RETURNSTATUS"].Value);
                        string msg = Convert.ToString(cmd.Parameters["@SP_MESSAGE"].Value);
                        if (status == 0)
                        {
                            ShowMessage(false, msg);
                        }

                    }
                    catch (Exception ex)
                    {
                        ShowMessage(true, ex.ToString());
                    }
                    Con.Close();
                }

                OrderDetail(HFVOrderID.Value);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {

                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace, ex.TargetSite.ToString(), "OrderMaster.btnConfirmOrder_Click()", this.Page);
            }
        }

        private void ShowMessage(bool IsError, string message)
        {
            if (!IsError)
            {
                successmsg.Visible = true;
                errormsg.Visible = false;
                lblSuccess.Text = message;
            }
            else
            {
                errormsg.Visible = true;
                successmsg.Visible = false;

                lblError.Text = message;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection Con = new SqlConnection(conStr))
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = Con;
                    cmd.CommandText = string.Format("dbo.RenewOrderOfSubscription");

                    cmd.Parameters.Add("@SP_TYPE", SqlDbType.VarChar, 50).Value = "Manual";
                    cmd.Parameters.Add("@SP_OrderID", SqlDbType.BigInt, 0).Value = HFVOrderID.Value.Trim();
                    cmd.Parameters.Add("@SP_ISCONFIRMED", SqlDbType.Bit, 0).Value = false;
                    cmd.Parameters.Add("@SP_MESSAGE", SqlDbType.NVarChar, -1);
                    cmd.Parameters["@SP_MESSAGE"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@RETURNSTATUS", SqlDbType.SmallInt, 0);
                    cmd.Parameters["@RETURNSTATUS"].Direction = ParameterDirection.ReturnValue;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    Con.Open();
                    try
                    {
                        int i = cmd.ExecuteNonQuery();
                        int status = Convert.ToInt32(cmd.Parameters["@RETURNSTATUS"].Value);
                        string msg = Convert.ToString(cmd.Parameters["@SP_MESSAGE"].Value);
                        if (status == 0)
                        {
                            ShowMessage(false, msg);
                        }

                        

                    }
                    catch (Exception ex)
                    {
                        ShowMessage(true, ex.ToString());
                    }
                    Con.Close();
                }

                OrderDetail(HFVOrderID.Value);
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {

                Global.WriteErrorLog(ex.Message.ToString(), ex.StackTrace, ex.TargetSite.ToString(), "OrderMaster.btnCancel_Click()", this.Page);
            }

        }
    }
}