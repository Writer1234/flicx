using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using flicboxPWC_CMS.PWC;

namespace flicboxPWC_CMS
{
    public partial class contact : System.Web.UI.Page
    {
        string strErrorMsg = "", strBody = "", strSubject = "", strQuery = "";
        ContactUs objContact = new ContactUs();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                AssignValues(1);
                objContact.CallProcedureContactUsDML(1, this);
                CGEmail();
                DisplayStatusDiv();
            }
        }

        protected void CGEmail()
        {
            strSubject = "Flicbox : Contact Us".ToUpper();

            strBody += "CONTACT DETAILS : <br/>";
            strBody += "Full Name : " + txtContactName.Text.ToString().Trim() + "<br/>";
            strBody += "Contact : " + txtContactName.Text.ToString().Trim() + "<br/>";
            strBody += "Email : " + txtContactEmail.Text.ToString().Trim() + "<br/>";
            strBody += "Message : " + txtDescription.Text.ToString().Trim() + "<br/>";

            strErrorMsg = Global.SendMail(Global.strUsername, Global.strUsername, strSubject, strBody, true, this);
            if (strErrorMsg != string.Empty)
            {
                //Response.Write("<script type=\"text/javascript\">alert('" + strErrorMsg + "')</script>");
                divStatus.InnerHtml = Global.DisplayStatusDivision(objContact.HasErrors, objContact.ErrorMessage.Trim(), this);
                divStatus.Visible = true;
            }

            ResetAllFields();
        }
        protected void AssignValues(int _mode)
        {
            if (_mode == 2)
                objContact.ContactID = Convert.ToInt32(Request.QueryString[""].ToString().Trim());
            else
                objContact.ContactID = 0;

            objContact.ContactName = txtContactName.Text.ToString().Trim();
            objContact.ContactEmail = txtContactEmail.Text.ToString().Trim();
            objContact.ContactMobile = txtContactPhone.Text.ToString().Trim();
            objContact.ContactMsg = txtDescription.Text.ToString().Trim();
            //objContact.InsertedBy = objContact.UpdatedBy = Session["username"].ToString().Trim();
            objContact.InsertedDate = objContact.UpdatedDate = DateTime.Now;
        }
        private void ResetAllFields()
        {
            txtContactName.Text = txtContactEmail.Text = txtContactPhone.Text = txtDescription.Text = "";
            txtContactName.Focus();
        }
        protected void DisplayStatusDiv()
        {
            divStatus.InnerHtml = Global.DisplayStatusDivision(objContact.HasErrors, objContact.ErrorMessage.Trim(), this);
            divStatus.Visible = true;
        }
    }
}