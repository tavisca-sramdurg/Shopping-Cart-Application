using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartApplication_CleanCodePractices
{
    public interface ICartItem
    {
        Product product { get; set; }

        int Quantity { get; set; }

        int TotalCostOfCartItem();
    }
}
