using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartApplication_CleanCodePractices
{
    public class CartItem : ICartItem
    {
        public IProduct product { get; set; }
        public int Quantity { get; set; }

        public CartItem(IProduct product, int quantity)
        {
            this.product = product;
            Quantity = quantity;
        }

        public int TotalCostOfCartItem()
        {
            int totalBill = product.Price * Quantity;
            int totalBillWithDiscount = totalBill * (100 - (int)product.category) / 100;
            return totalBillWithDiscount;
        }
    }
}
