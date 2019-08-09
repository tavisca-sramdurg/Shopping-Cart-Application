using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ShoppingCartApplication_CleanCodePractices
{
    public class ConfigurableDiscount : IDiscount
    {
        public int DiscountPercentage { get; set; }

        public ConfigurableDiscount()
        {
            int sampleInteger = 0;
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            int.TryParse(configuration.GetConnectionString("discount"), out sampleInteger);
            DiscountPercentage = sampleInteger;
        }

        //public int CalulcateDiscount(List<CartItem> items)
        //{
        //    int discount = 0;
        //    int totalPrice = 0;
        //    Cart cart = new Cart();

        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        //    IConfigurationRoot configuration = builder.Build();

        //    int.TryParse(configuration.GetConnectionString("discount"), out discount);
        //    for (int i = 0; i < items.Count; i++)
        //    {
        //        var item = items.ElementAt(i);
        //        totalPrice = totalPrice + (cart.GetItemPriceByName(item.Key) * item.Value);
        //    }
        //    return totalPrice * discount / 100;
        //}

    }
}
