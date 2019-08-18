using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartApplication_CleanCodePractices
{
    public interface IProduct
    {
        string Name { get; set; }
        int Price { get; set; }
        int ProductID { get; set; }
        Category category { get; set; }
    }
}
