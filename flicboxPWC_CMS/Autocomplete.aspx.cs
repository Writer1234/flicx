using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;

namespace flicboxPWC_CMS
{
    public partial class Autocomplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]
        public static string[] GetProduct(string prefix,string subtype)
        {
            List<string> customers = new List<string>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    if (subtype.ToUpper()== "SUBSCRIPTION")
                    {
                        cmd.CommandText = "select CategoryID ID,categoryname NAME from dbo.CategoryMaster with(nolock) where categoryname like @SearchText + '%'";
                    }
                    else
                    {
                        cmd.CommandText = "select intProductID  ID,varcharProductName Name from productmaster with(nolock) where varcharProductName like @SearchText + '%'";
                    }

                    
                    cmd.Parameters.AddWithValue("@SearchText", prefix);
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(string.Format("{0}-{1}", sdr["Name"], sdr["ID"]));
                        }
                    }
                    conn.Close();
                }
            }
            return customers.ToArray();
        }
    }
}