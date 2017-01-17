using flicboxPWC_CMS.PWC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace flicboxPWC_CMS
{
    public partial class checkout : System.Web.UI.Page
    {
        BusinessDataBinding objDatabinder = new BusinessDataBinding();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["customerUsername"]!=null)
                {

                    if(!string.IsNullOrWhiteSpace(Convert.ToString(Session["customerUsername"])))
                            LoginDiv.Attributes.Add("style", "display:none");
                    else
                    {
                        LoginDiv.Attributes.Add("style", "display:block");
                    }
                }
                else
                {
                    LoginDiv.Attributes.Add("style", "display:block");
                }


                if (Request.Cookies["ShoppingCart"]!=null)
                {
                    HttpCookie oCookie = (HttpCookie)Request.Cookies["ShoppingCart"];
                    if (oCookie.Value.Length != 0)
                    {
                        
                        //Set Cookie to expire in 3 hours
                        char[] sep = { ',' };
                        string sProdID = oCookie.Value.ToString();
                        string[] arrCookie = sProdID.Split(sep);
                        if (arrCookie.Count() > 0)
                        {
                          string  strQuery = string.Format("Select * FROM ProductMaster WHERE varcharProductType = 'Subscription' and intproductid in({0})", sProdID);
                            objDatabinder.BindRepeater(rptEmployees, strQuery, this);
                            callJavascript();
                        }
                    }
                    else
                    {
                        Response.Redirect("~/index.aspx");
                    }
                }
                


            }
        }

        private void callJavascript()
        {
            try
            {
                ClientScript.RegisterStartupScript(GetType(), "id", "GetTotal()", true);
            }
            catch (Exception)
            {

            }

        }

        MyAccountLogin objMyAccount = new MyAccountLogin();
        protected void login_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    objMyAccount.EmailID = username.Text.ToString().Trim();
                    objMyAccount.Password = password.Text.ToString().Trim();
                    objMyAccount.InsertedDate = objMyAccount.UpdatedDate = DateTime.Now;
                    objMyAccount.CallProcedureUserDetailsDML(4, this);
                    if (objMyAccount.HasErrors == false)
                    {
                        Session["customerUsername"] = username.Text.ToString().Trim();
                        Response.Redirect("~/checkout.aspx", true);
                    }
                }
            }
            catch (Exception)
            {
                
            }
            
        }
    }
}