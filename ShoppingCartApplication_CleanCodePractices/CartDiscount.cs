using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartApplication_CleanCodePractices
{
    public class CartDiscount : IDiscount
    {
        public int DiscountPercentage { get; set; }

        public CartDiscount()
        {
            DiscountPercentage = 10;
        }
    }
}
