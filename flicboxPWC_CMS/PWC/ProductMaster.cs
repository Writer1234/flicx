using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.IO;

namespace flicboxPWC_CMS.PWC
{
    public class ProductMaster
    {
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        SqlDataReader dr = null;

        public ProductMaster()
        { }
        public ProductMaster(int productID)
        {
            try
            {
                string prd = string.Format("EXEC [dbo].[GetProductDetails] @SP_PRODUCTID={0}", Convert.ToString(productID));
                da = new SqlDataAdapter(prd, con);
                DataTable prddt = new DataTable();
                da.Fill(prddt);

                if (prddt!=null && prddt.Rows.Count>0)
                {
                    ProductID = productID;
                    ProductName = Convert.ToString(prddt.Rows[0]["varcharProductName"]);
                    SubscriptionName= Convert.ToString(prddt.Rows[0]["SubscriptionName"]);
                    SubscriptionType = Convert.ToInt32(prddt.Rows[0]["intSubscriptionType"]);
                    ProductType = Convert.ToString(prddt.Rows[0]["varcharProductType"]);
                    LongDesc = Convert.ToString(prddt.Rows[0]["varcharProductDescription"]);
                    ShortDesc= Convert.ToString(prddt.Rows[0]["varcharProductShortDescription"]);
                    ProductPrice = Convert.ToInt32(prddt.Rows[0]["intProductPrice"]);
                    ProductImg1= Convert.ToString(prddt.Rows[0]["varcharProductImg1"]);
                    ProductImg2 = Convert.ToString(prddt.Rows[0]["varcharProductImg2"]);
                    ProductImg3 = Convert.ToString(prddt.Rows[0]["varcharProductImg3"]);
                    ProductImg4 = Convert.ToString(prddt.Rows[0]["varcharProductImg4"]);
                    ProductImg5 = Convert.ToString(prddt.Rows[0]["varcharProductImg5"]);

                }
                

            }
            catch (Exception)
            {
            }


        }

        static string conStr = WebConfigurationManager.ConnectionStrings["conStr"].ConnectionString.ToString().Trim();
        string strQuery = "", strUpdBy = "", strInsBy = "", strErrMsg = "";
        string strProductType = "",  strProductName = "", strShortDesc = "", strLongDesc = "", strProductImg1 = "", strProductImg2 = "", strProductImg3 = "", strProductImg4 = "", strProductImg5 = "";
        int strSubscriptionType = 0;
        string _SubscriptionTypeName = "";
        int productID, productPrice;

        bool IsError = false;

        DateTime dtInsDate, dtUpdDate;

       

        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        public int ProductPrice
        {
            get { return productPrice; }
            set { productPrice = value; }
        }

        int _quanity;
        public int Quanity
        {
            get { return _quanity; }
            set { _quanity = value; }
        }

        decimal _ProductTotal;
        public decimal ProductTotal
        {
            get { return _ProductTotal; }
            set { _ProductTotal = value; }
        }

        public string ProductType
        {
            get { return strProductType; }
            set { strProductType = value; }
        }

        public int SubscriptionType
        {
            get { return strSubscriptionType; }
            set { strSubscriptionType = value; }
        }

        public ProductType productTypeName { get; set; }

        public string SubscriptionName
        {
            get { return _SubscriptionTypeName; }
            set { _SubscriptionTypeName = value; }
        }

        public string ProductName
        {
            get { return strProductName; }
            set { strProductName = value; }
        }
        public string ShortDesc
        {
            get { return strShortDesc; }
            set { strShortDesc = value; }
        }
        public string LongDesc
        {
            get { return strLongDesc; }
            set { strLongDesc = value; }
        }
        public string ProductImg1
        {
            get { return strProductImg1; }
            set { strProductImg1 = value; }
        }
        public string ProductImg2
        {
            get { return strProductImg2; }
            set { strProductImg2 = value; }
        }
        public string ProductImg3
        {
            get { return strProductImg3; }
            set { strProductImg3 = value; }
        }
        public string ProductImg4
        {
            get { return strProductImg4; }
            set { strProductImg4 = value; }
        }
        public string ProductImg5
        {
            get { return strProductImg5; }
            set { strProductImg5 = value; }
        }
        public string InsertedBy
        {
            get { return strInsBy; }
            set { strInsBy = value; }
        }
        public string UpdatedBy
        {
            get { return strUpdBy; }
            set { strUpdBy = value; }
        }

        public DateTime InsertedDate
        {
            get { return dtInsDate; }
            set { dtInsDate = value; }
        }

        public DateTime UpdatedDate
        {
            get { return dtUpdDate; }
            set { dtUpdDate = value; }
        }

        public bool HasErrors
        {
            get { return IsError; }
            set { IsError = value; }
        }

        public string ErrorMessage
        {
            get { return strErrMsg; }
            set { strErrMsg = value; }
        }

        public void CallProcedureProductMasterDML(int _mode, System.Web.UI.Page _page)
        {
            try
            {
                cmd = new SqlCommand("PROC_ProductMaster_DML", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@mode", SqlDbType.Int);
                cmd.Parameters["@mode"].Value = _mode;

                cmd.Parameters.Add("@productID", SqlDbType.Int);
                cmd.Parameters["@productID"].Value = ProductID;

                cmd.Parameters.Add("@productType", SqlDbType.VarChar, 20);
                cmd.Parameters["@productType"].Value = ProductType;

                cmd.Parameters.Add("@subscriptionType", SqlDbType.Int, 0);
                cmd.Parameters["@subscriptionType"].Value = SubscriptionType;

                cmd.Parameters.Add("@productName", SqlDbType.VarChar, 50);
                cmd.Parameters["@productName"].Value = ProductName;

                cmd.Parameters.Add("@productShortDesc", SqlDbType.VarChar, 100);
                cmd.Parameters["@productShortDesc"].Value = ShortDesc;

                cmd.Parameters.Add("@productLongDesc", SqlDbType.VarChar, 1000);
                cmd.Parameters["@productLongDesc"].Value = LongDesc;

                cmd.Parameters.Add("@productPrice", SqlDbType.Int);
                cmd.Parameters["@productPrice"].Value = ProductPrice;

                cmd.Parameters.Add("@productImg1", SqlDbType.VarChar, 500);
                cmd.Parameters["@productImg1"].Value = ProductImg1;

                cmd.Parameters.Add("@productImg2", SqlDbType.VarChar, 500);
                cmd.Parameters["@productImg2"].Value = ProductImg2;

                cmd.Parameters.Add("@productImg3", SqlDbType.VarChar, 500);
                cmd.Parameters["@productImg3"].Value = ProductImg3;

                cmd.Parameters.Add("@productImg4", SqlDbType.VarChar, 500);
                cmd.Parameters["@productImg4"].Value = ProductImg4;

                cmd.Parameters.Add("@productImg5", SqlDbType.VarChar, 500);
                cmd.Parameters["@productImg5"].Value = ProductImg5;

                cmd.Parameters.Add("@ins_by", SqlDbType.VarChar, 30);
                cmd.Parameters["@ins_by"].Value = InsertedBy.ToString();

                cmd.Parameters.Add("@ins_dat", SqlDbType.DateTime);
                cmd.Parameters["@ins_dat"].Value = InsertedDate;

                cmd.Parameters.Add("@upd_by", SqlDbType.VarChar, 30);
                cmd.Parameters["@upd_by"].Value = UpdatedBy.ToString();

                cmd.Parameters.Add("@upd_dat", SqlDbType.DateTime);
                cmd.Parameters["@upd_dat"].Value = UpdatedDate;

                cmd.Parameters.Add("@out_errcode", SqlDbType.Int);
                cmd.Parameters["@out_errcode"].Direction = ParameterDirection.Output;

                if (con.State == ConnectionState.Open)
                    con.Close();

                con.Open();
                cmd.ExecuteNonQuery();

                int errCode = Convert.ToInt32(cmd.Parameters["@out_errcode"].Value.ToString());

                switch (errCode)
                {
                    case 101:
                        ErrorMessage = "Product ID Required !";
                        HasErrors = true;
                        break;
                    case 9991:
                        ErrorMessage = "Inserted Successfully!";
                        HasErrors = false;
                        break;
                    case 9992:
                        ErrorMessage = "Updated Successfully !";
                        HasErrors = false;
                        break;
                    case 9993:
                        ErrorMessage = "Deleted Successfully !";
                        HasErrors = false;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                HasErrors = true;
                ErrorMessage = ex.Message.ToString();
                Global.WriteErrorLog(ErrorMessage, ex.StackTrace, ex.TargetSite.ToString(), "ProductMaster.CallProcedureProductMasterDML()", _page);
            }
            finally { con.Close(); }
        }

        public bool CheckUploadedFileExtension(string _ext)
        {
            bool isExtValid = false;
            string[] arrValidFileExts = { "jpg", "png", "jpeg", "gif", "bmp" };

            for (int i = 0; i < arrValidFileExts.Length; i++)
            {
                if (_ext.ToLower().Trim() == arrValidFileExts[i].ToLower().Trim())
                {
                    isExtValid = true;
                    break;
                }
            }

            return isExtValid;
        }

        public string FillPlansData(System.Web.UI.Page _page)
        {
            StringWriter stringWriter = new StringWriter();
            string strGeneratedHTML = "";

            try
            {
                strQuery = "SELECT varcharProductImg1, varcharProductName, varcharProductShortDescription, varcharProductDescription FROM ProductMaster WHERE varcharSubscriptionType = '1 Month' AND varcharProductType='Subscription'";

                if (con.State == ConnectionState.Open)
                    con.Close();

                con.Open();

                cmd = new SqlCommand(strQuery, con);
                dr = cmd.ExecuteReader();

                using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
                {
                    //class="one-third column" data-scrollreveal="enter bottom and move 250px over 1.5s"
                    //<div class="plan-single">
                    //    <img src="images/products/little-plan.jpg" alt="Little Plan" width="100%"/>
                    //    <h5><span>LITTLE</span></h5>
                    //    <h5>&#x20b9;599 / month + shipping</h5>
                    //    <p><strong>Includes upto 400 gms of chocolates worth Rs.1200</strong></p>
                    //    <div class="sections-link-pages">
                    //        <div class="cl-effect-11"><a href="#" id="btnLittleSub" runat="server" data-hover="Subscribe">Subscribe</a></div>
                    //    </div>
                    //</div>
                    while (dr.Read())
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "one-third column");
                        writer.AddAttribute("data-scrollreveal", "enter bottom and move 250px over 1.5s");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);

                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "plan-single");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);

                        writer.AddAttribute(HtmlTextWriterAttribute.Width, "100%");
                        writer.AddAttribute(HtmlTextWriterAttribute.Src, dr.GetValue(0).ToString().Remove(0, 2).Trim());
                        writer.AddAttribute(HtmlTextWriterAttribute.Alt, dr.GetValue(0).ToString().Trim());
                        writer.RenderBeginTag(HtmlTextWriterTag.Img);
                        writer.RenderEndTag();

                        writer.RenderBeginTag(HtmlTextWriterTag.H5);
                        writer.RenderBeginTag(HtmlTextWriterTag.Span);
                        writer.Write(dr.GetValue(1).ToString().Trim());
                        writer.RenderEndTag();
                        writer.RenderEndTag();

                        writer.RenderBeginTag(HtmlTextWriterTag.H5);
                        writer.Write("&#x20b9;" + dr.GetValue(2).ToString().Trim());
                        writer.RenderEndTag();

                        writer.RenderBeginTag(HtmlTextWriterTag.P);
                        writer.RenderBeginTag(HtmlTextWriterTag.Strong);
                        writer.Write(dr.GetValue(3).ToString().Trim());
                        writer.RenderEndTag();
                        writer.RenderEndTag();

                        //<div class="sections-link-pages">
                        //     <div class="cl-effect-11"><a href="#" id="btnLittleSub" runat="server" data-hover="Subscribe">Subscribe</a></div>
                        //</div>
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "sections-link-pages");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "cl-effect-11");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);
                        writer.AddAttribute(HtmlTextWriterAttribute.Href, "cart.aspx?plan=" + dr.GetValue(1).ToString().Trim());
                        writer.AddAttribute("data-hover", "Subscribe");
                        writer.RenderBeginTag(HtmlTextWriterTag.A);
                        writer.Write("Subscribe");
                        writer.RenderEndTag();
                        writer.RenderEndTag();
                        writer.RenderEndTag();

                        writer.RenderEndTag();
                        writer.RenderEndTag();
                    }




                    strGeneratedHTML = writer.InnerWriter.ToString().Trim();
                }
                return _page.Server.HtmlDecode(strGeneratedHTML.Trim());
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                dr.Close();
                con.Close();
            }
        }

        public DataTable GetProductDetails(int ProductID, System.Web.UI.Page _page)
        {
            DataTable dt = new DataTable();
            try
            {
                strQuery = string.Format("exec [dbo].[GetProductDetails] @SP_PRODUCTID={0}", Convert.ToString(ProductID));
                using (SqlDataAdapter da = new SqlDataAdapter(strQuery, con))
                {
                    da.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
            {
                HasErrors = true;
                ErrorMessage = ex.Message.ToString();
                Global.WriteErrorLog(ErrorMessage, ex.StackTrace, ex.TargetSite.ToString(), "ProductMaster.GetProductDetails()", _page);
                throw ex;
            }


        }


        public DataTable FillPlansDataGrid(System.Web.UI.Page _page)
        {
            DataTable dt = new DataTable();
            try
            {
                strQuery = "SELECT varcharProductImg1, varcharProductName, varcharProductShortDescription, varcharProductDescription,intProductID,intProductPrice FROM ProductMaster WHERE varcharSubscriptionType = '1 Month' AND varcharProductType='Subscription'";
                using (SqlDataAdapter da = new SqlDataAdapter(strQuery, con))
                {
                    da.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
            {
                HasErrors = true;
                ErrorMessage = ex.Message.ToString();
                Global.WriteErrorLog(ErrorMessage, ex.StackTrace, ex.TargetSite.ToString(), "ProductMaster.FillPlansDataGrid()", _page);
                throw ex;
            }
            
        }

        public string GetPrice(System.Web.UI.Page _page,string ProductID)
        {
            DataTable dt = new DataTable();
            try
            {
                strQuery = string.Format("SELECT intProductPrice FROM ProductMaster WHERE intProductID={0}", ProductID);
                if (con.State == ConnectionState.Open)
                    con.Close();

                con.Open();

                cmd = new SqlCommand(strQuery, con);
                var value =cmd.ExecuteScalar();

                if (value!=null)
                {
                    return value.ToString();
                }
                else
                {
                    return "0";
                }
                
            }
            catch (Exception ex)
            {
                HasErrors = true;
                ErrorMessage = ex.Message.ToString();
                Global.WriteErrorLog(ErrorMessage, ex.StackTrace, ex.TargetSite.ToString(), "ProductMaster.GetPrice()", _page);
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }
    }
}