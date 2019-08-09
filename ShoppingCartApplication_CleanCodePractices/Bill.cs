using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartApplication_CleanCodePractices
{
    public class Bill
    {
        public static int CalculateBill(List<CartItem> cartItemList, IDiscount discount)
        {
            int bill = 0;
            Type receivedType = discount.GetType();
            CategoryDiscount categoryDiscount = new CategoryDiscount(10);
            ConfigurableDiscount configurableDiscount = new ConfigurableDiscount();
            Type categoryDiscountType = categoryDiscount.GetType();
            Type configurableDiscountType = configurableDiscount.GetType();

            if (receivedType.Equals(categoryDiscountType))
            {
                foreach (var cartItem in cartItemList)
                {
                    bill = bill + cartItem.CostOfCartItemWithCategoryDiscount();
                }
                return bill;
            }
            else if (receivedType.Equals(configurableDiscountType))
            {
                foreach (var cartItem in cartItemList)
                {
                    bill = bill + cartItem.CostOfCartItemWithoutCategoryDiscount();
                }

                int costOfCartItemWithConfigurableDiscount = bill * (100 - discount.DiscountPercentage) / 100;
                return costOfCartItemWithConfigurableDiscount;
            }
            else
            {
                foreach (var cartItem in cartItemList)
                {
                    bill = bill + cartItem.CostOfCartItemWithoutCategoryDiscount();
                }

                int costOfCartItemWithCartDiscount = bill * (100 - discount.DiscountPercentage) / 100;
                return costOfCartItemWithCartDiscount;
            }
        }
    }
}
