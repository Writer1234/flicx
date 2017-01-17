using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using flicboxPWC_CMS.PWC;

namespace flicboxPWC_CMS.flicboxAdmin
{
    public partial class login : System.Web.UI.Page
    {
        string strUsername = "", strPassword = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmitLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                strUsername = txtLoginUsername.Text.ToString().Trim();
                strPassword = txtLoginPassword.Text.ToString().Trim();

                PWC.Login objLogin = new PWC.Login();

                if (objLogin.Authenticate(strUsername, strPassword, this))
                {
                    Session["userId"] = objLogin.UserId.ToString().Trim();
                    Session["username"] = objLogin.Username.ToString().Trim();
                    Session["password"] = objLogin.Password.ToString().Trim();
                    Response.Redirect("~/flicboxAdmin/Dashboard.aspx");

                }
                else
                {
                    lblErrMsg.Text = "Invalid Username OR Password !";
                }
            }
        }
    }
}