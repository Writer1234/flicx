using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flicboxPWC_CMS.PWC
{
    public class CartItem:IEquatable<CartItem>
    {
        #region Properties

        // A place to store the quantity in the cart
        // This property has an implicit getter and setter.
        

        private int _productId;
        public int ProductId
        {
            get { return _productId; }
            set
            {
                // To ensure that the Prod object will be re-created
                _product = null;
                _productId = value;
            }
        }
        public int Quantity { get; set; }

        public decimal UnitPrice
        {
            get { return Prod.ProductPrice; }
        }

        public ProductType productType { get; set; }

        private ProductMaster _product = null;
        public ProductMaster Prod
        {
            get
            {
                // Lazy initialization - the object won't be created until it is needed
                if (_product == null)
                {
                    _product = new ProductMaster(ProductId);
                }
                return _product;
            }
        }

        //public decimal TotalPrice
        //{
        //    get { return UnitPrice * Quantity; }
        //}


        #endregion

        // CartItem constructor just needs a productId
        public CartItem(int productId,ProductType productype = ProductType.Subscription)
        {
            this.ProductId = productId;
            this.productType = productype;
        }

        /**
         * Equals() - Needed to implement the IEquatable interface
         *    Tests whether or not this item is equal to the parameter
         *    This method is called by the Contains() method in the List class
         *    We used this Contains() method in the ShoppingCart AddItem() method
         */
        public bool Equals(CartItem item)
        {
            return item.ProductId == this.ProductId && item.productType==this.productType;
        }
    }
}