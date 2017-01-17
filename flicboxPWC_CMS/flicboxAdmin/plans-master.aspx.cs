using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using flicboxPWC_CMS.PWC;
using System.Data;

namespace flicboxPWC_CMS.flicboxAdmin
{
    public partial class plans_master : System.Web.UI.Page
    {
        string strErrorMsg = "", strBody = "", strSubject = "", strQuery = "", strMode = "";
        ProductMaster objProductMaster = new ProductMaster();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"] == null)
                {
                    Response.Redirect("~/flicboxAdmin/login.aspx");
                }
                else
                {
                    if (Request.QueryString["mode"] != null && !string.IsNullOrWhiteSpace(Request.QueryString["mode"].ToString()))
                    {
                        strMode = Request.QueryString["mode"].ToString();
                        if (strMode == "1")
                        {
                            btnUpdate.Visible = false;
                            btnInsert.Visible = true;
                        }
                        if (strMode == "2")
                        {
                            btnInsert.Visible = false;
                            btnUpdate.Visible = true;

                            if (Request.QueryString["ProductID"] != null && !string.IsNullOrWhiteSpace(Request.QueryString["ProductID"].ToString()))
                            {
                                int productID = Int32.Parse(Request.QueryString["ProductID"]);
                                DataTable Productdt = objProductMaster.GetProductDetails(productID, this.Page);

                                if (Productdt != null && Productdt.Rows.Count > 0)
                                {
                                    ddlProductType.SelectedValue = Productdt.Rows[0]["varcharProductType"].ToString();
                                    ddlSubscriptionType.SelectedValue = Productdt.Rows[0]["intSubscriptionType"].ToString();
                                    txtProductName.Text = Productdt.Rows[0]["varcharProductName"].ToString();
                                    txtShortDesc.Text = Productdt.Rows[0]["varcharProductShortDescription"].ToString();
                                    txtLongDesc.Text = Productdt.Rows[0]["varcharProductDescription"].ToString();
                                    txtPrice.Text = Productdt.Rows[0]["intProductPrice"].ToString();
                                }
                            }
                        }
                    }
                }
            }
            catch (System.Threading.ThreadInterruptedException) { }
            catch (Exception ex)
            {
                objProductMaster.HasErrors = true;
                objProductMaster.ErrorMessage = ex.ToString();
                DisplayStatusDiv();
            }

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    divStatus.Visible = false;

                    //Gallary_M objPhotos = new Gallary_M();
                    //ArrayList arrSqlInsertStm = new ArrayList();

                    string query = string.Empty;
                    int count = 0;

                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        HttpPostedFile objPostedFile = Request.Files[i];

                        string strFileName = System.IO.Path.GetFileName(objPostedFile.FileName);
                        string strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1);

                        count = count + objPostedFile.ContentLength;

                        if (objPostedFile.ContentLength > 0 && !objProductMaster.CheckUploadedFileExtension(strFileExt))
                        {
                            objProductMaster.HasErrors = true;
                            strErrorMsg = "Invalid File Extension for Filename : " + strFileName.ToString().Trim();
                            strErrorMsg += "<br/><p class=\"pad-left-1em\">Supported File Extensions are .jpg, .png, .bmp, .jpeg & .gif !</p>";
                            objProductMaster.ErrorMessage = strErrorMsg;
                            divStatus.InnerHtml = Global.DisplayStatusDivision(objProductMaster.HasErrors, objProductMaster.ErrorMessage, this);
                            divStatus.Visible = true;
                            return;
                        }
                    }

                    if (count == 0)
                    {
                        divStatus.InnerHtml = Global.DisplayStatusDivision(true, "Please Choose Files To Upload!", this);
                        divStatus.Visible = true;
                        return;
                    }

                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        HttpPostedFile PostedFile = Request.Files[i];
                        string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);

                        if (PostedFile.ContentLength > 1048576)   //file should be less than 1 MB
                        {
                            objProductMaster.HasErrors = true;
                            strErrorMsg = "Invalid File Size for Filename : " + strFileName.Trim();
                            strErrorMsg += "<br/>     Please Upload File Less Than 1 MB !";
                            objProductMaster.ErrorMessage = strErrorMsg;
                            divStatus.InnerHtml = Global.DisplayStatusDivision(objProductMaster.HasErrors, objProductMaster.ErrorMessage, this);
                            divStatus.Visible = true;
                            return;
                        }
                    }

                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        HttpPostedFile PostedFile = Request.Files[i];

                        string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                        string strFilePath = "~/images/products/" + strFileName.ToString().Trim();

                        if (PostedFile.ContentLength > 0 && PostedFile.ContentLength < 1048576)
                        {
                            objProductMaster.ProductImg1 = strFilePath.ToString().Trim();
                            PostedFile.SaveAs(Server.MapPath(strFilePath));
                        }
                    }


                    AssignValues(1);
                    objProductMaster.CallProcedureProductMasterDML(1, this);
                    DisplayStatusDiv();
                }
            }
            catch (System.Threading.ThreadInterruptedException) { }
            catch (Exception ex)
            {
                objProductMaster.HasErrors = true;
                objProductMaster.ErrorMessage = ex.ToString();
                DisplayStatusDiv();
            }


        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                AssignValues(2);
                objProductMaster.CallProcedureProductMasterDML(2, this);
                DisplayStatusDiv();
            }
        }

        protected void AssignValues(int _mode)
        {
            if (_mode == 2)
                objProductMaster.ProductID = Convert.ToInt32(Request.QueryString["ProductID"]);
            else
                objProductMaster.ProductID = 0;

            objProductMaster.ProductType = ddlProductType.SelectedValue.ToString().Trim();
            objProductMaster.SubscriptionType =  Convert.ToInt32(ddlSubscriptionType.SelectedValue);
            objProductMaster.ProductName = txtProductName.Text.ToString().Trim();
            objProductMaster.ShortDesc = txtShortDesc.Text.ToString().Trim();
            objProductMaster.LongDesc = txtLongDesc.Text.ToString().Trim();
            objProductMaster.ProductPrice = Convert.ToInt32(txtPrice.Text.ToString().Trim());
            objProductMaster.ProductImg2 = "";
            objProductMaster.ProductImg3 = "";
            objProductMaster.ProductImg4 = "";
            objProductMaster.ProductImg5 = "";
            objProductMaster.InsertedBy = objProductMaster.UpdatedBy = Session["username"].ToString().Trim();
            objProductMaster.InsertedDate = objProductMaster.UpdatedDate = DateTime.Now;
        }
        private void ResetAllFields()
        {
            txtProductName.Text = txtShortDesc.Text = txtLongDesc.Text = "";
            txtProductName.Focus();
        }
        protected void DisplayStatusDiv()
        {
            divStatus.InnerHtml = Global.DisplayStatusDivision(objProductMaster.HasErrors, objProductMaster.ErrorMessage.Trim(), this);
            divStatus.Visible = true;
        }
    }
}