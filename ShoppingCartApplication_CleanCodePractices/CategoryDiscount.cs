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

        //public int CalculateDiscountOnBill(int cost, IProduct product)
        //{
        //    int costWithDiscount = cost * (100 - (int)product.category) / 100;
        //    return costWithDiscount;
        //}
    }
}
