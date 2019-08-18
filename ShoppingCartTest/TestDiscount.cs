using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ShoppingCartApplication_CleanCodePractices;

namespace ShoppingCartTest
{
    public class TestDiscount
    {
        IProduct product1, product2, product3;

        Cart cart;

        [Fact]
        public void Cart_discount_should_get_applied_correctly()
        {
            //Arrange
            product1 = new Product("tshirt", 1000, 101, Category.Clothing);

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

            IDiscount discountType = new CartDiscount();
            cart = new Cart(discountType);

            //Act
            cart.AddItemToCart(cart.cartItemList, product1, 1);
            int bill = cart.GetTotalBill();
            //Assert
            Assert.Equal(900, bill);
        }

        [Fact]
        public void Category_discount_should_get_applied_correctly()
        {
            //Arrange
            product1 = new Product("tshirt", 1000, 101, Category.Clothing);

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

            IDiscount discountType = new CategoryDiscount((int)Category.Clothing);
            cart = new Cart(discountType);

            //Act
            cart.AddItemToCart(cart.cartItemList, product1, 1);
            int bill = cart.GetTotalBill();
            //Assert
            Assert.Equal(500, bill);
        }
    }
}
