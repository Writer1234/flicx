using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace flicboxPWC_CMS.PWC
{
    public class Order
    {

        static string conStr = WebConfigurationManager.ConnectionStrings["conStr"].ConnectionString.ToString().Trim();
        public List<ProductMaster> GetCartProduct()
        {
            var items = ShoppingCart.Instance.Items;
            var productlist = new List<ProductMaster>();

            foreach (CartItem item in items)
            {
                ProductMaster obj = new ProductMaster(item.ProductId);
                obj.Quanity = item.Quantity;
                obj.ProductTotal = (obj.Quanity * obj.ProductPrice);
                productlist.Add(obj);
            }


            return productlist;

        }


        private static DataTable CreateDataTable(List<CartItem> items)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ProductId", typeof(long));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("UnitPrice", typeof(float));
            foreach (CartItem id in items)
            {
                table.Rows.Add(id.ProductId, id.Quantity, id.UnitPrice);
            }
            return table;
        }


        public string AddOrder(OrderMater obj, List<CartItem> CartItems, out Int64 OrderID, out bool IsError)
        {
            string message = string.Empty;

            try
            {
                using (SqlConnection Con = new SqlConnection(conStr))
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "[dbo].[OrderMasterAdd]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SP_USERID", SqlDbType.Int);
                    cmd.Parameters["@SP_USERID"].Value = HttpContext.Current.Session["CustLoginID"] == null ? -1 : Convert.ToInt32(HttpContext.Current.Session["CustLoginID"]);
                    cmd.Parameters["@SP_USERID"].Direction = ParameterDirection.InputOutput;

                    cmd.Parameters.Add("@SP_ORDERID", SqlDbType.Int);
                    cmd.Parameters["@SP_ORDERID"].Direction = ParameterDirection.Output;


                    cmd.Parameters.Add("@SP_UID", SqlDbType.NVarChar, -1);
                    cmd.Parameters["@SP_UID"].Value = obj.UID;


                    cmd.Parameters.AddWithValue("@SP_OrdrTbl", CreateDataTable(CartItems));
                    cmd.Parameters["@SP_OrdrTbl"].SqlDbType = SqlDbType.Structured;
                    cmd.Parameters["@SP_OrdrTbl"].TypeName = "dbo.OrderDetailData";

                    cmd.Parameters.Add("@SP_NAME", SqlDbType.VarChar, 100);
                    cmd.Parameters["@SP_NAME"].Value = obj.Name;

                    cmd.Parameters.Add("@SP_Phone", SqlDbType.VarChar, 20);
                    cmd.Parameters["@SP_Phone"].Value = obj.Phone;

                    cmd.Parameters.Add("@SP_EmailID", SqlDbType.VarChar, 100);
                    cmd.Parameters["@SP_EmailID"].Value = obj.Email;

                    cmd.Parameters.Add("@SP_PASSWORD", SqlDbType.VarChar, 50);
                    cmd.Parameters["@SP_PASSWORD"].Value = obj.password;

                    cmd.Parameters.Add("@billingAddress", SqlDbType.NVarChar, 500);
                    cmd.Parameters["@billingAddress"].Value = obj.Address;

                    cmd.Parameters.Add("@SP_City", SqlDbType.VarChar, 100);
                    cmd.Parameters["@SP_City"].Value = obj.City;

                    cmd.Parameters.Add("@SP_State", SqlDbType.VarChar, 100);
                    cmd.Parameters["@SP_State"].Value = obj.State;

                    cmd.Parameters.Add("@sp_pincode", SqlDbType.VarChar, 20);
                    cmd.Parameters["@sp_pincode"].Value = obj.PinCode;

                    cmd.Parameters.Add("@SP_Birthdate", SqlDbType.VarChar, 12);
                    cmd.Parameters["@SP_Birthdate"].Value = obj.Precheckout.birthdate;

                    cmd.Parameters.Add("@SP_Allergies", SqlDbType.VarChar, 100);
                    cmd.Parameters["@SP_Allergies"].Value = obj.Precheckout.allergies;

                    cmd.Parameters.Add("@SP_Preferences", SqlDbType.VarChar, 30);
                    cmd.Parameters["@SP_Preferences"].Value = obj.Precheckout.preferencesDiet;

                    cmd.Parameters.Add("@SP_TotalQty", SqlDbType.Int, 0);
                    cmd.Parameters["@SP_TotalQty"].Value = obj.TotalQty;

                    cmd.Parameters.Add("@SP_SubTotalAmount", SqlDbType.Float, 0);
                    cmd.Parameters["@SP_SubTotalAmount"].Value = obj.SubTotalAmount;

                    cmd.Parameters.Add("@SP_TotalAmount", SqlDbType.Float, 0);
                    cmd.Parameters["@SP_TotalAmount"].Value = obj.TotalAmount;

                    cmd.Parameters.Add("@RETURNSTATUS", SqlDbType.SmallInt, 0);
                    cmd.Parameters["@RETURNSTATUS"].Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add("@SP_MESSAGE", SqlDbType.NVarChar, -1);
                    cmd.Parameters["@SP_MESSAGE"].Direction = ParameterDirection.Output;

                    if (Con.State == ConnectionState.Open)
                        Con.Close();

                    Con.Open();

                    try
                    {
                        cmd.ExecuteNonQuery();

                        string status = (string)cmd.Parameters["@RETURNSTATUS"].Value;
                        string msg = (string)cmd.Parameters["@SP_MESSAGE"].Value;
                        if (status == "0")
                        {
                            OrderID = (Int64)cmd.Parameters["@RETURNSTATUS"].Value;
                            message = msg;
                            IsError = false;
                            return message;
                        }

                    }
                    catch (Exception ex)
                    {
                        OrderID = 0;
                        IsError = true;
                        message = ex.ToString();

                        return message;
                    }

                }

            }
            catch (System.Threading.ThreadInterruptedException) { }
            catch (Exception ex)
            {
                OrderID = 0;
                IsError = true;
                message = ex.Message;
                // throw;
            }
            OrderID = 0;
            IsError = true;
            return message;
        }

    }

    public class OrderMater
    {
        public string Name { get; set; }

        public string UID { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public bool IsGift { get; set; }
        public string ToGiftName { get; set; }
        public string GiftAddress { get; set; }
        public string GiftMessage { get; set; }

        public int TotalQty { get; set; }
        public float TotalAmount { get; set; }

        public float SubTotalAmount { get; set; }

        Precheckout _PrecheckOut;
        public Precheckout Precheckout
        {
            get
            {
                if (_PrecheckOut == null)
                {
                    _PrecheckOut = new Precheckout();
                }
                return _PrecheckOut;
            }

            set { _PrecheckOut = value; }
        }

    }

    public class Precheckout
    {

        public string allergies { get; set; }

        public string preferencesTaste { get; set; }

        public string preferencesDiet { get; set; }
        public string birthdate { get; set; }
    }

    public class OrderDetails
    {
        public static readonly OrderDetails _instance = new OrderDetails();
        public OrderMater _OrderMaster { get; set; }

        static OrderDetails()
        {
            if (HttpContext.Current.Session["OrderMaster"] == null)
            {
                _instance = new OrderDetails();
                _instance._OrderMaster = new OrderMater();
                HttpContext.Current.Session["OrderMaster"] = _instance;
            }
            else
            {
                _instance = (OrderDetails)HttpContext.Current.Session["OrderMaster"];
            }


        }

        protected OrderDetails()
        {
        }

        public void AddOrderDetails(OrderMater OMaster)
        {
            _OrderMaster = _OrderMaster;
        }
    }


}