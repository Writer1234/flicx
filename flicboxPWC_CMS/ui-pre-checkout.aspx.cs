using flicboxPWC_CMS.PWC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace flicboxPWC_CMS
{
    public partial class ui_pre_checkout : System.Web.UI.Page
    {
        Order _order;

        public Order ObjOrder
        {
            get
            {

                if (_order == null)
                {
                    _order = new Order();
                }

                return _order;
            }

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsPostBack)
                {
                    if (ShoppingCart.Instance.Items.Count <= 0)
                    {
                        Response.Redirect("index.aspx", true);
                    }
                    else
                    {
                        if (Session["CustLoginID"] != null)
                        {
                            Response.Redirect("ui-checkout.aspx", true);
                        }

                        if (ObjOrder.GetGiftItemExists())
                        {
                            divGiftDetails.Style["display"] = "block";
                        }
                        else
                        {
                            divGiftDetails.Style["display"] = "none";
                        }
                        
                    }
                }
                
            }
            catch (System.Threading.ThreadInterruptedException) { }
            catch (Exception)
            {
                
                throw;
            }

            
            
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    OrderDetails._instance._OrderMaster.Precheckout.allergies = txtAllergies.Text.Trim();
                    OrderDetails._instance._OrderMaster.Precheckout.birthdate = txtBirthdate.Text.Trim();
                    OrderDetails._instance._OrderMaster.Precheckout.preferencesDiet = ddlPreferenceDiet.SelectedValue;
                    OrderDetails._instance._OrderMaster.Precheckout.preferencesTaste = ddlPreferenceTaste.SelectedValue;
                    
                    if(divGiftDetails.Style["display"] == "block")
                    {
                        OrderDetails._instance._OrderMaster.Precheckout.IsGiftExist = true;
                        OrderDetails._instance._OrderMaster.Precheckout.GiftSenderName = txtSenderName.Text;
                        OrderDetails._instance._OrderMaster.Precheckout.GiftSenderEmailID= txtSenderEmailID.Text;
                        OrderDetails._instance._OrderMaster.Precheckout.GiftSenderPhone= txtSenderPhone.Text;
                        OrderDetails._instance._OrderMaster.Precheckout.GiftSenderAddress = txtSenderAddress.Text;
                        OrderDetails._instance._OrderMaster.Precheckout.GiftSenderState = txtSenderState.Text;
                        OrderDetails._instance._OrderMaster.Precheckout.GiftSenderCity = txtSenderCity.Text;
                        OrderDetails._instance._OrderMaster.Precheckout.GiftSenderPincode= txtSenderPincode.Text;
                        OrderDetails._instance._OrderMaster.Precheckout.GiftRecieverName = txtRecieverName.Text;
                        OrderDetails._instance._OrderMaster.Precheckout.GiftRecieverEmailID = txtRecieverEmailID.Text;
                        OrderDetails._instance._OrderMaster.Precheckout.GiftRecieverPhone = txtRecieverPhone.Text;
                        OrderDetails._instance._OrderMaster.Precheckout.GiftRecieverAddress = txtRecieverAddress.Text;
                        OrderDetails._instance._OrderMaster.Precheckout.GiftRecieverCity = txtRecieverCity.Text;
                        OrderDetails._instance._OrderMaster.Precheckout.GiftRecieverState = txtRecieverState.Text;
                        OrderDetails._instance._OrderMaster.Precheckout.GiftRecieverPincode = txtRecieverPincode.Text;
                        OrderDetails._instance._OrderMaster.Precheckout.OccasionDetails = txtOccasionDetails.Text;
                        OrderDetails._instance._OrderMaster.Precheckout.OccasionDate = txtOccasionDate.Text;
                        OrderDetails._instance._OrderMaster.Precheckout.PersonalGiftMsg = txtPersonalGiftMsg.Text;
                    }
                    OrderDetails._instance.AddOrderDetails(OrderDetails._instance._OrderMaster);
                    Response.Redirect("ui-checkout.aspx", true);
                }
                

            }
            catch (System.Threading.ThreadInterruptedException) { }
            catch (Exception)
            {

                throw;
            }

            
        }
    }
}