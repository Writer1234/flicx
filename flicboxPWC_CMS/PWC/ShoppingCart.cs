using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace flicboxPWC_CMS.PWC
{
    public class ShoppingCart
    {
        #region Properties

        public List<CartItem> Items { get; private set; }
        


        #endregion

        #region Singleton Implementation



        // Readonly properties can only be set in initialization or in a constructor
        private static readonly ShoppingCart instance = new ShoppingCart();


        public static ShoppingCart Instance
        {
            get
            {
                return instance;
            }
        }


        // The static constructor is called as soon as the class is loaded into memory
        static ShoppingCart()
        {
            try
            {
                // If the cart is not in the session, create one and put it there
                // Otherwise, get it from the session
                if (HttpContext.Current.Request.Cookies["Cart"] == null)
                {
                    //Instance = new ShoppingCart();
                    Instance.Items = new List<CartItem>();
                    //HttpContext.Current.Session["Cart"] = Instance;
                    string myObjectJson = new JavaScriptSerializer().Serialize(Instance);
                    var cookie = new HttpCookie("Cart", myObjectJson)
                    {
                        Expires = DateTime.Now.AddMinutes(3)
                    };
                    HttpContext.Current.Response.Cookies.Add(cookie);

                }
                else
                {
                    HttpCookie oCookie = (HttpCookie)HttpContext.Current.Request.Cookies["Cart"];
                    var json = oCookie.Value;
                    oCookie.Expires = DateTime.Now.AddMinutes(3);
                    HttpContext.Current.Response.Cookies.Add(oCookie);
                    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    var result = serializer.Deserialize<List<CartItem>>(json);
                    Instance.Items = result;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        // A protected constructor ensures that an object can't be created from outside
        private ShoppingCart() { }

        #endregion

        #region Item Modification Methods
        /**
         * AddItem() - Adds an item to the shopping 
         */
        public void AddItem(int productId)
        {
            // Create a new item to add to the cart
            CartItem newItem = new CartItem(productId);

            // If this item already exists in our list of items, increase the quantity
            // Otherwise, add the new item to the list
            if (Items.Contains(newItem))
            {
                foreach (CartItem item in Items)
                {
                    if (item.Equals(newItem))
                    {
                        item.Quantity++;
                        return;
                    }
                }
            }
            else
            {
                newItem.Quantity = 1;
                Items.Add(newItem);
            }
        }

        /**
         * SetItemQuantity() - Changes the quantity of an item in the cart
         */
        public void SetItemQuantity(int productId, int quantity)
        {
            // If we are setting the quantity to 0, remove the item entirely
            if (quantity == 0)
            {
                RemoveItem(productId);
                return;
            }

            // Find the item and update the quantity
            CartItem updatedItem = new CartItem(productId);

            foreach (CartItem item in Items)
            {
                if (item.Equals(updatedItem))
                {
                    item.Quantity = quantity;
                    return;
                }
            }
        }

        /**
         * RemoveItem() - Removes an item from the shopping cart
         */
        public void RemoveItem(int productId)
        {
            CartItem removedItem = new CartItem(productId);
            Items.Remove(removedItem);
        }
        #endregion

        #region Reporting Methods
        /**
         * GetSubTotal() - returns the total price of all of the items
         *                 before tax, shipping, etc.
         */
        public decimal GetSubTotal()
        {
            decimal subTotal = 0;
            foreach (CartItem item in Items)
            {
                ProductMaster obj = new ProductMaster();
                subTotal += (item.Quantity * Convert.ToDecimal(obj.GetPrice(new System.Web.UI.Page(), item.ProductId.ToString())));
                //subTotal += item.TotalPrice;
            }

            return subTotal;
        }


        public int GetTotalQuantity()
        {
            int TotalQuantity = 0;
            foreach (CartItem item in Items)
                TotalQuantity += item.Quantity;

            //CartCount = TotalQuantity;

            return TotalQuantity;
        }

        #endregion


    }




}