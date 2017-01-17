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
    public class CorporateGifting
    {
        static string conStr = WebConfigurationManager.ConnectionStrings["conStr"].ConnectionString.ToString().Trim();
        string strQuery = "", strUpdBy = "", strInsBy = "", strErrMsg = "";
        string strPersonName = "", strCompanyName = "", strCompanyEmail = "", strCompanyMobile = "", strCompanyHeadCount ="",strCompanyDes = "";

        int giftID;

        bool IsError = false;

        DateTime dtInsDate, dtUpdDate;

        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = null;
        //SqlDataAdapter da = null;
        //SqlDataReader dr = null;

        public int GiftID
        {
            get { return giftID; }
            set { giftID = value; }
        }

        public string PersonName
        {
            get { return strPersonName; }
            set { strPersonName = value; }
        }

        public string CompanyName
        {
            get { return strCompanyName; }
            set { strCompanyName = value; }
        }

        public string CompanyEmail
        {
            get { return strCompanyEmail; }
            set { strCompanyEmail = value; }
        }

        public string CompanyMobile
        {
            get { return strCompanyMobile; }
            set { strCompanyMobile = value; }
        }

        public string CompanyHeadcount
        {
            get { return strCompanyHeadCount; }
            set { strCompanyHeadCount = value; }
        }

        public string CompanyDes
        {
            get { return strCompanyDes; }
            set { strCompanyDes = value; }
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

        public void CallProcedureCorporateGiftingDML(int _mode, System.Web.UI.Page _page)
        {
            try
            {
                cmd = new SqlCommand("PROC_CorporateGifting_DML", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@mode", SqlDbType.Int);
                cmd.Parameters["@mode"].Value = _mode;

                cmd.Parameters.Add("@giftID", SqlDbType.Int);
                cmd.Parameters["@giftID"].Value = GiftID;

                cmd.Parameters.Add("@personName", SqlDbType.VarChar, 50);
                cmd.Parameters["@personName"].Value = PersonName;

                cmd.Parameters.Add("@companyName", SqlDbType.VarChar, 100);
                cmd.Parameters["@companyName"].Value = CompanyName;

                cmd.Parameters.Add("@companyEmail", SqlDbType.VarChar, 50);
                cmd.Parameters["@companyEmail"].Value = CompanyEmail;

                cmd.Parameters.Add("@companyMobile", SqlDbType.VarChar, 10);
                cmd.Parameters["@companyMobile"].Value = CompanyMobile;

                cmd.Parameters.Add("@companyHeadCount", SqlDbType.VarChar, 8);
                cmd.Parameters["@companyHeadCount"].Value = CompanyHeadcount;

                cmd.Parameters.Add("@companyDescription", SqlDbType.VarChar, 5000);
                cmd.Parameters["@companyDescription"].Value = CompanyDes;

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
                        ErrorMessage = "Gift ID Required !";
                        HasErrors = true;
                        break;
                    case 102:
                        ErrorMessage = "Person Name Required !";
                        HasErrors = true;
                        break;
                    case 103:
                        ErrorMessage = "Company Name Required !";
                        HasErrors = true;
                        break;
                    case 104:
                        ErrorMessage = "Email ID Required !";
                        HasErrors = true;
                        break;
                    case 105:
                        ErrorMessage = "Mobile Required !";
                        HasErrors = true;
                        break;
                    case 106:
                        ErrorMessage = "Head Count Required !";
                        HasErrors = true;
                        break;
                    case 107:
                        ErrorMessage = "Description Required !";
                        HasErrors = true;
                        break;
                    case 9991:
                        ErrorMessage = "Submission is Successful! We will get in touch with you soon!";
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
                Global.WriteErrorLog(ErrorMessage, ex.StackTrace, ex.TargetSite.ToString(), "CorporateGifting.CallProcedureCorporateGiftingDML()", _page);
            }
            finally { con.Close(); }
        }

        
    }
}