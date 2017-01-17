using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using flicboxPWC_CMS.PWC;

namespace flicboxPWC_CMS.my_account
{
    public partial class lost_password : System.Web.UI.Page
    {
        static string conStr = WebConfigurationManager.ConnectionStrings["conStr"].ConnectionString.ToString().Trim();
        string strErrorMsg = "", strBody = "", strSubject = "", strQuery = "";
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        SqlDataReader dr = null;
        MyAccountLogin objMyAccount = new MyAccountLogin();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLostPassword_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                objMyAccount.EmailID = objMyAccount.UserName = txtLostPasswordEmail.Text.ToString().Trim();
                objMyAccount.InsertedDate = objMyAccount.UpdatedDate = DateTime.Now;
                objMyAccount.CallProcedureUserDetailsDML(5, this);
                DisplayStatusDiv();
                LostPasswordEmail();
            }
        }

        protected void DisplayStatusDiv()
        {
            divStatus.InnerHtml = Global.DisplayStatusDivision(objMyAccount.HasErrors, objMyAccount.ErrorMessage.Trim(), this);
            divStatus.Visible = true;
        }

        public void LostPasswordEmail()
        {
            string emailid1 = "";
            strQuery = "Select varcharPassword, varcharEmailID From UserDetails where varcharEmailID = '" + txtLostPasswordEmail.Text.ToString().Trim() + "'";
            strQuery += " OR varcharUserName = '" + txtLostPasswordEmail.Text.ToString().Trim() + "'";

            con.Open();

            cmd = new SqlCommand(strQuery, con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                emailid1 = Convert.ToString(dr.GetValue(1).ToString().Trim());
                strSubject = "Flicbox : Lost Password";
                strBody += "Dear User, <br/> Your Password is <b>" + dr.GetValue(0).ToString().Trim() + "</b>";
                strErrorMsg = Global.SendMail(Global.strUsername, emailid1, strSubject, strBody, true, this);
            }
        }
    }
}