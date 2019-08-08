using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartApplication_CleanCodePractices
{
    public class Cart 
    {
        public List<ICartItem> cartItemList = new List<ICartItem>();
        public IDiscount discount;

        public Cart(IDiscount discount)
        {
            this.discount = discount;
        }

        public int GetTotalBill()
        {
            int bill = 0;

            foreach(var cartItem in cartItemList)
            {
                bill = bill + cartItem.TotalCostOfCartItem();
            }

            int costOfCartItemWithDiscount = bill * (100 - discount.DiscountPercentage) / 100;
            return costOfCartItemWithDiscount;
        }

    }
}
