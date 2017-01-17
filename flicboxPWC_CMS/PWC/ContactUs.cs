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
    public class ContactUs
    {
        static string conStr = WebConfigurationManager.ConnectionStrings["conStr"].ConnectionString.ToString().Trim();
        string strQuery = "", strUpdBy = "", strInsBy = "", strErrMsg = "";
        string strContactName = "", strContactEmail = "", strContactMobile = "", strContactMsg = "";
        int contactID;

        bool IsError = false;

        DateTime dtInsDate, dtUpdDate;

        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = null;
        //SqlDataAdapter da = null;
        //SqlDataReader dr = null;

        public int ContactID
        {
            get { return contactID; }
            set { contactID = value; }
        }

        public string ContactName
        {
            get { return strContactName; }
            set { strContactName = value; }
        }

        public string ContactEmail
        {
            get { return strContactEmail; }
            set { strContactEmail = value; }
        }

        public string ContactMobile
        {
            get { return strContactMobile; }
            set { strContactMobile = value; }
        }

        public string ContactMsg
        {
            get { return strContactMsg; }
            set { strContactMsg = value; }
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

        public void CallProcedureContactUsDML(int _mode, System.Web.UI.Page _page)
        {
            try
            {
                cmd = new SqlCommand("PROC_ContactUS_DML", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@mode", SqlDbType.Int);
                cmd.Parameters["@mode"].Value = _mode;

                cmd.Parameters.Add("@contactID", SqlDbType.Int);
                cmd.Parameters["@contactID"].Value = ContactID;

                cmd.Parameters.Add("@contactName", SqlDbType.VarChar, 50);
                cmd.Parameters["@contactName"].Value = ContactName;

                cmd.Parameters.Add("@contactEmail", SqlDbType.VarChar, 50);
                cmd.Parameters["@contactEmail"].Value = ContactEmail;

                cmd.Parameters.Add("@contactMobile", SqlDbType.VarChar, 10);
                cmd.Parameters["@contactMobile"].Value = ContactMobile;

                cmd.Parameters.Add("@contactMsg", SqlDbType.VarChar, 5000);
                cmd.Parameters["@contactMsg"].Value = ContactMsg;

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
                        ErrorMessage = "Contact ID Required !";
                        HasErrors = true;
                        break;
                    case 102:
                        ErrorMessage = "Contact Name Required !";
                        HasErrors = true;
                        break;
                    case 103:
                        ErrorMessage = "Email ID Required !";
                        HasErrors = true;
                        break;
                    case 104:
                        ErrorMessage = "Mobile Required !";
                        HasErrors = true;
                        break;
                    case 105:
                        ErrorMessage = "Msg Required !";
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
                Global.WriteErrorLog(ErrorMessage, ex.StackTrace, ex.TargetSite.ToString(), "ContactUs.CallProcedureContactUsDML()", _page);
            }
            finally { con.Close(); }
        }
    }
}