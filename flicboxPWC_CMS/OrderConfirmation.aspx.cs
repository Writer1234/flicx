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

namespace flicboxPWC_CMS
{
    public partial class OrderConfirmation : System.Web.UI.Page
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

                if(!IsPostBack)
                {

                    if (Session["CustLoginID"]!=null && Request.QueryString["Orm"]!=null)
                    {
                        string OrderID = objURL.DecryptText(Convert.ToString(Request.QueryString["Orm"]));
                        if (!string.IsNullOrWhiteSpace(OrderID))
                        {

                            using (SqlConnection Con = new SqlConnection(conStr))
                            {

                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = Con;
                                cmd.CommandText = string.Format("select 1 from ordersmaster where intorderid={0}", OrderID);
                                cmd.CommandType = System.Data.CommandType.Text;
                                Con.Open();
                                var data = cmd.ExecuteScalar();

                                if (data.ToString()=="1")
                                {
                                    successmsg.Visible = true;
                                    errormsg.Visible = false;
                                    payType.Visible = true;
                                    lblSuccess.Text = "Order has been placed succesfully and Mail has been send to you with details.";
                                }
                                else
                                {
                                    errormsg.Visible = true;
                                    successmsg.Visible = false;
                                    payType.Visible = false;
                                    lblError.Text = "No such Order Exists.";
                                }

                            }

                            

                        }


                    }
                    else
                    {
                        Response.Redirect("index.aspx");
                    }


                }

            }
            catch (System.Threading.ThreadAbortException) { }   
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}