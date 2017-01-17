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
    public class MyAccountLogin
    {
        static string conStr = WebConfigurationManager.ConnectionStrings["conStr"].ConnectionString.ToString().Trim();
        string strQuery = "", strUpdBy = "", strInsBy = "", strErrMsg = "";
        string strFirstName = "", strLastName = "", strUsername = "", strEmail = "", strPassword = "", strBillingAdd1 = "", strBillingAdd2 = "";
        string strCity = "", strState = "", strPostCode = "", strBirthDay = "", strAllergies = "", strPreference = "", strShippingAdd1 = "", strShippingAdd2 = "";
        int userID;

        bool IsError = false;

        DateTime dtInsDate, dtUpdDate;

        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        SqlDataReader dr = null;

        public MyAccountLogin()
        {

        }

        public MyAccountLogin(int userID)
        {
            try
            {
                DataTable dt = new DataTable();
                da = new SqlDataAdapter(string.Format("[dbo].[GetUserDetails] @SP_UserID={0}",Convert.ToString(userID)), con);
                da.Fill(dt);

                if (dt!=null && dt.Rows.Count>0)
                {
                    FullName= Convert.ToString(dt.Rows[0]["Name"]);
                    FirstName = Convert.ToString(dt.Rows[0]["varcharFirstName"]);
                    LastName = Convert.ToString(dt.Rows[0]["varcharLastName"]);
                    EmailID = Convert.ToString(dt.Rows[0]["varcharEmailID"]);
                    Phone= Convert.ToString(dt.Rows[0]["varcharPhone"]);
                    BillingAddress = Convert.ToString(dt.Rows[0]["BillingAddress"]);
                    BillingAdd1 = Convert.ToString(dt.Rows[0]["varcharBillingAddressLine1"]);
                    BillingAdd2 = Convert.ToString(dt.Rows[0]["varcharBillingAddressLine2"]);
                    City = Convert.ToString(dt.Rows[0]["varcharCity"]);
                    State = Convert.ToString(dt.Rows[0]["varcharState"]);
                    PostCode = Convert.ToString(dt.Rows[0]["varcharPostCode"]);
                    Allergies = Convert.ToString(dt.Rows[0]["varcharAllergies"]);
                    Preference = Convert.ToString(dt.Rows[0]["varcharPreference"]);
                    BirthDay = Convert.ToString(dt.Rows[0]["varcharBirthday"]);
                    ShippingAddress = Convert.ToString(dt.Rows[0]["shippingAddress"]);
                    strShippingAdd1 = Convert.ToString(dt.Rows[0]["varcharShippingAddressLine1"]);
                    strShippingAdd2 = Convert.ToString(dt.Rows[0]["varcharShippingAddressLine2"]);
                    Password= Convert.ToString(dt.Rows[0]["varcharPassword"]); 

                }



            }
            catch (System.Threading.ThreadInterruptedException)
            {

            }
            catch (Exception)
            {

                throw;
            }

        }

        

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string FirstName
        {
            get { return strFirstName; }
            set { strFirstName = value; }
        }

        public string LastName
        {
            get { return strLastName; }
            set { strLastName = value; }
        }

        public string UserName
        {
            get { return strUsername; }
            set { strUsername = value; }
        }

        public string Phone { get; set; }

        public string FullName { get; set; }

        public string BillingAddress { get; set; }

        public string ShippingAddress { get; set; }
        public string EmailID
        {
            get { return strEmail; }
            set { strEmail = value; }
        }

        public string Password
        {
            get { return strPassword; }
            set { strPassword = value; }
        }

        public string BillingAdd1
        {
            get { return strBillingAdd1; }
            set { strBillingAdd1 = value; }
        }

        public string BillingAdd2
        {
            get { return strBillingAdd2; }
            set { strBillingAdd2 = value; }
        }

        public string City
        {
            get { return strCity; }
            set { strCity = value; }
        }

        public string State 
        {
            get { return strState; }
            set { strState = value; }
        }

        public string PostCode
        {
            get { return strPostCode; }
            set { strPostCode = value; }
        }

        public string BirthDay
        {
            get { return strBirthDay; }
            set { strBirthDay = value; }
        }
        
        public string Allergies 
        {
            get { return strAllergies; }
            set { strAllergies = value; }
        }

        public string Preference
        {
            get { return strPreference; }
            set { strPreference = value; }
        }
        
        public string ShippingAdd1
        {
            get { return strShippingAdd1; }
            set { strShippingAdd1 = value; }
        }

        public string ShippingAdd2
        {
            get { return strShippingAdd2; }
            set { strShippingAdd2 = value; }
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

        public void CallProcedureUserDetailsDML(int _mode, System.Web.UI.Page _page)
        {
            try
            {
                cmd = new SqlCommand("PROC_UserDetails_DML", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@mode", SqlDbType.Int);
                cmd.Parameters["@mode"].Value = _mode;

                cmd.Parameters.Add("@userID", SqlDbType.Int);
                cmd.Parameters["@userID"].Value = UserID;
                cmd.Parameters["@userID"].Direction = ParameterDirection.InputOutput;

                cmd.Parameters.Add("@firstName", SqlDbType.VarChar, 50);
                cmd.Parameters["@firstName"].Value = FirstName;

                cmd.Parameters.Add("@lastName", SqlDbType.VarChar, 50);
                cmd.Parameters["@lastName"].Value = LastName;

                cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 15);
                cmd.Parameters["@Phone"].Value = Phone;

                cmd.Parameters.Add("@username", SqlDbType.VarChar, 50);
                cmd.Parameters["@username"].Value = UserName;

                cmd.Parameters.Add("@emailID", SqlDbType.VarChar, 50);
                cmd.Parameters["@emailID"].Value = EmailID;

                cmd.Parameters.Add("@password", SqlDbType.VarChar, 50);
                cmd.Parameters["@password"].Value = Password;

                cmd.Parameters.Add("@billingAddress1", SqlDbType.VarChar, 100);
                cmd.Parameters["@billingAddress1"].Value = BillingAdd1;

                cmd.Parameters.Add("@billingAddress2", SqlDbType.VarChar, 100);
                cmd.Parameters["@billingAddress2"].Value = BillingAdd2;

                cmd.Parameters.Add("@city", SqlDbType.VarChar, 50);
                cmd.Parameters["@city"].Value = City;

                cmd.Parameters.Add("@state", SqlDbType.VarChar, 50);
                cmd.Parameters["@state"].Value = State;

                cmd.Parameters.Add("@postCode", SqlDbType.VarChar, 6);
                cmd.Parameters["@postCode"].Value = PostCode;

                cmd.Parameters.Add("@birthDay", SqlDbType.VarChar, 12);
                cmd.Parameters["@birthDay"].Value = BirthDay;

                cmd.Parameters.Add("@allergies", SqlDbType.VarChar, 100);
                cmd.Parameters["@allergies"].Value = Allergies;

                cmd.Parameters.Add("@preference", SqlDbType.VarChar, 30);
                cmd.Parameters["@preference"].Value = Preference;

                cmd.Parameters.Add("@shippingAddress1", SqlDbType.VarChar, 100);
                cmd.Parameters["@shippingAddress1"].Value = ShippingAdd1;

                cmd.Parameters.Add("@shippingAddress2", SqlDbType.VarChar, 100);
                cmd.Parameters["@shippingAddress2"].Value = ShippingAdd2;

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
                UserID= Convert.ToInt32(cmd.Parameters["@userID"].Value.ToString());

                switch (errCode)
                {
                    case 101:
                        ErrorMessage = "Contact ID Required !";
                        HasErrors = true;
                        break;
                    case 102:
                        ErrorMessage = "User Already Exists !";
                        HasErrors = true;
                        break;
                    case 103:
                        ErrorMessage = "Login Successful !";
                        HasErrors = false;
                        break;
                    case 104:
                        ErrorMessage = "Invalid Username or Password !";
                        HasErrors = true;
                        break;
                    case 105:
                        ErrorMessage = "Password has been sent Successfully to Registerd Email ID.";
                        HasErrors = false;
                        break;
                    case 106:
                        ErrorMessage = "User does not Exists. Please Register Now !";
                        HasErrors = true;
                        break;
                    case 9991:
                        ErrorMessage = "Registration Done Successfully";
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
                Global.WriteErrorLog(ErrorMessage, ex.StackTrace, ex.TargetSite.ToString(), "MyAccountLogin.CallProcedureUserDetailsDML()", _page);
            }
            finally { con.Close(); }
        }

        
    }
}