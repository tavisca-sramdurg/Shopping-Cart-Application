using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartApplication_CleanCodePractices
{
    public class CategoryDiscount : IDiscount
    {
        public int DiscountPercentage { get; set; }
        public CategoryDiscount(int discountPercentage)
        {
            DiscountPercentage = discountPercentage;
        }
    }
}
