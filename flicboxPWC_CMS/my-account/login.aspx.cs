using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using flicboxPWC_CMS.PWC;

namespace flicboxPWC_CMS.my_account
{
    public partial class login : System.Web.UI.Page
    {
        string strErrorMsg = "", strBody = "", strSubject = "", strQuery = "";
        MyAccountLogin objMyAccount = new MyAccountLogin();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmitLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                objMyAccount.EmailID = txtLoginUsername.Text.ToString().Trim();
                objMyAccount.Password = txtLoginPassword.Text.ToString().Trim();
                objMyAccount.InsertedDate = objMyAccount.UpdatedDate = DateTime.Now;
                objMyAccount.CallProcedureUserDetailsDML(4, this);
                DisplayStatusDiv();
                if (objMyAccount.HasErrors == false)
                {
                    Session["CustLoginID"]=objMyAccount.UserID;
                    Session["customerUsername"] = txtLoginUsername.Text.ToString().Trim();
                    Response.Redirect("~/index.aspx");
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                AssignValues(1);
                objMyAccount.CallProcedureUserDetailsDML(1, this);
                DisplayStatusDiv();
                if (objMyAccount.HasErrors == false)
                {

                    Session["CustLoginID"] = objMyAccount.UserID;
                    Session["customerUsername"] = txtRegisterUsername.Text.ToString().Trim();
                    Response.Redirect("~/index.aspx");
                }
            }
        }

        protected void AssignValues(int _mode)
        {
            if (_mode == 2)
                objMyAccount.UserID = Convert.ToInt32(Request.QueryString["user_id"].ToString().Trim());
            else
                objMyAccount.UserID = 0;

            objMyAccount.EmailID = txtRegisterEmail.Text.ToString().Trim();
            objMyAccount.Password = txtRegisterPassword.Text.ToString().Trim();
            objMyAccount.InsertedDate = objMyAccount.UpdatedDate = DateTime.Now;
        }

        protected void DisplayStatusDiv()
        {
            divStatus.InnerHtml = Global.DisplayStatusDivision(objMyAccount.HasErrors, objMyAccount.ErrorMessage.Trim(), this);
            divStatus.Visible = true;
        }
    }
}