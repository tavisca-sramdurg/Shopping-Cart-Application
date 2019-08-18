using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartApplication_CleanCodePractices
{
    public class Product /*: IProduct*/
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int ProductID { get; set; }
        public Category category { get; set; }

        public Product(string name, int price, int id, Category category)
        {
            Name = name;
            Price = price;
            ProductID = id;
            this.category = category;
        }
    }
}
