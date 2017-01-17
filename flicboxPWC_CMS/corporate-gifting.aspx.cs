using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using flicboxPWC_CMS.PWC;

namespace flicboxPWC_CMS
{
    public partial class corporate_gifting : System.Web.UI.Page
    {
        string strErrorMsg = "", strBody = "", strSubject = "", strQuery = "";
        CorporateGifting objGift = new CorporateGifting();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                AssignValues(1);
                objGift.CallProcedureCorporateGiftingDML(1, this);
                CGEmail();
                DisplayStatusDiv();
            }
        }
        protected void CGEmail()
        {
            strSubject = "Flicbox : Corporate Gifting".ToUpper();

            strBody += "CONTACT DETAILS : <br/>";
            strBody += "Full Name : " + txtPersonName.Text.ToString().Trim() + "<br/>";
            strBody += "Company Name : " + txtCompanyName.Text.ToString().Trim() + "<br/>";
            strBody += "Contact : " + txtCompanyPhone.Text.ToString().Trim() + "<br/>";
            strBody += "Email : " + txtCompanyEmail.Text.ToString().Trim() + "<br/></p>";

            strErrorMsg = Global.SendMail(Global.strUsername, Global.strUsername, strSubject, strBody, true, this);
            if (strErrorMsg != string.Empty)
            {
                //Response.Write("<script type=\"text/javascript\">alert('" + strErrorMsg + "')</script>");
                divStatus.InnerHtml = Global.DisplayStatusDivision(objGift.HasErrors, objGift.ErrorMessage.Trim(), this);
                divStatus.Visible = true;
            }

            ResetAllFields();
        }

        protected void AssignValues(int _mode)
        {
            if (_mode == 2)
                objGift.GiftID = Convert.ToInt32(Request.QueryString["news_id"].ToString().Trim());
            else
                objGift.GiftID = 0;

            objGift.PersonName = txtPersonName.Text.ToString().Trim();
            objGift.CompanyName = txtCompanyName.Text.ToString().Trim();
            objGift.CompanyEmail = txtCompanyEmail.Text.ToString().Trim();
            objGift.CompanyMobile = txtCompanyPhone.Text.ToString().Trim();
            objGift.CompanyHeadcount = txtHeadcount.Text.ToString().Trim();
            objGift.CompanyDes = txtDescription.Text.ToString().Trim();
            //objGift.InsertedBy = objGift.UpdatedBy = Session["username"].ToString().Trim();
            objGift.InsertedDate = objGift.UpdatedDate = DateTime.Now;
        }
        private void ResetAllFields()
        {
            txtPersonName.Text = txtCompanyName.Text = txtCompanyEmail.Text = txtCompanyPhone.Text = txtHeadcount.Text = txtDescription.Text = "";
            txtPersonName.Focus();
        }
        protected void DisplayStatusDiv()
        {
            divStatus.InnerHtml = Global.DisplayStatusDivision(objGift.HasErrors, objGift.ErrorMessage.Trim(), this);
            divStatus.Visible = true;
        }
    }
}