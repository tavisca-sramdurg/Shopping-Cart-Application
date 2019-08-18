using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartApplication_CleanCodePractices
{
    public class CartItem 
    {
        public Product product { get; private set; }
        public int Quantity { get; set; }

        public CartItem(Product product, int quantity)
        {
            this.product = product;
            Quantity = quantity;
        }

        public int CostOfCartItemWithCategoryDiscount()
        {
            int cost = product.Price * Quantity;
            //int costWithDiscount = CalculateDiscountOnBill(cost, product);
            int costWithDiscount = cost * (100 - (int)product.category) / 100;
            return costWithDiscount;
        }

        public int CostOfCartItemWithoutCategoryDiscount()
        {
            int cost = product.Price * Quantity;
            return cost;
        }
    }
}
