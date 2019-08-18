using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ShoppingCartApplication_CleanCodePractices;

namespace ShoppingCartTest
{
    public class TestConfigurableDiscount
    {
        Product product1;
        Cart cart;

        [Fact]
        public void Configurable_discount_should_get_applied_correctly()
        {
            //Arrange
            product1 = new Product("Book", 100, 101, Category.Education);

            /*
             IDiscount discountType;
             string type = Console.ReadLine();
             switch(type)
             {
                case "Category":
                    discountType = new CategoryDiscount();
                    break;
                case "Fixed":
                    discountType = new CartDiscount();
                    break;
            }*/

            IDiscount discountType = new ConfigurableDiscount();
            cart = new Cart(discountType);

            //Act
            cart.AddItemToCart(cart.cartItemList, product1, 1);
            int bill = cart.GetTotalBill();
            //Assert
            Assert.Equal(80, bill);
        }
    }
}
