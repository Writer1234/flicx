using flicboxPWC_CMS.PWC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace flicboxPWC_CMS
{
    public partial class ui_checkout : System.Web.UI.Page
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

        private UrlEncode _objURL;
        public UrlEncode objURL
        {
            get
            {

                if (_objURL == null)
                {
                    _objURL = new UrlEncode();
                }

                return _objURL;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["CustLoginID"] != null)
                    {
                        int ID = Int32.Parse(Convert.ToString(Session["CustLoginID"]));
                        MyAccountLogin objCust=new MyAccountLogin(ID);
                        txtName.Text = objCust.FullName;
                        txtEmail.Text = objCust.EmailID;
                        txtPhone.Text = objCust.Phone;
                        txtAddress.Text = objCust.BillingAddress;
                        txtCity.Text= objCust.City;
                        txtState.Text = objCust.State;
                        txtPincode.Text = objCust.PostCode;

                        divpassword.Style["display"] = "none";
                    }
                    else
                    {
                        divpassword.Style["display"] = "block";
                    }

                    bindgrid();
                }

            }
            catch (System.Threading.ThreadInterruptedException) { }
            catch (Exception)
            {

                throw;
            }
        }

        private void bindgrid()
        {
            if (ShoppingCart.Instance.Items.Count > 0)
            {
                rptOrderItems.DataSource = ObjOrder.GetCartProduct();
                rptOrderItems.DataBind();
            }
            else
            {
                btnPurchase.Enabled = false;
            }


        }

        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            try
            {
                Precheckout obj = OrderDetails._instance._OrderMaster.Precheckout;
                OrderDetails._instance._OrderMaster.Name = txtName.Text;
                OrderDetails._instance._OrderMaster.Phone = txtPhone.Text;
                OrderDetails._instance._OrderMaster.Email = txtEmail.Text;
                OrderDetails._instance._OrderMaster.Address = txtAddress.Text;
                OrderDetails._instance._OrderMaster.City = txtCity.Text;
                OrderDetails._instance._OrderMaster.State = txtState.Text;
                OrderDetails._instance._OrderMaster.PinCode =txtPincode.Text;
                OrderDetails._instance._OrderMaster.Precheckout = obj;
                float total= (float)(ShoppingCart.Instance.GetSubTotal());
                OrderDetails._instance._OrderMaster.TotalAmount = total;
                OrderDetails._instance._OrderMaster.SubTotalAmount = total;
                OrderDetails._instance._OrderMaster.TotalQty = ShoppingCart.Instance.GetTotalQuantity();
                
                OrderDetails._instance.AddOrderDetails(OrderDetails._instance._OrderMaster);

                Int64 OrderID;
                bool IsError;
                string message=ObjOrder.AddOrder(OrderDetails._instance._OrderMaster,ShoppingCart.Instance.Items,out OrderID,out IsError);
                if (!IsError)
                {
                    Response.Redirect(string.Format("OrderConfirmation.aspx?orm={0}", objURL.encrytedText(Convert.ToString(OrderID))), true);
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