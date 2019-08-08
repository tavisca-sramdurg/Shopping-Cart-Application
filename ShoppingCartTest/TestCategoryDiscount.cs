using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ShoppingCartApplication_CleanCodePractices;

namespace ShoppingCartTest
{
    public class TestCategoryDiscount
    {
        IProduct product1, product2, product3;

        Cart cart;

        [Fact]
        public void Five_percent_discount_should_get_applied_for_sports()
        {
            //Arrange
            product1 = new Product("Football", 100, 101, Category.Sport);

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

            IDiscount discountType = new CategoryDiscount((int)Category.Sport);
            cart = new Cart(discountType);

            //Act
            cart.AddItemToCart(cart.cartItemList, product1, 1);
            int bill = cart.GetTotalBill();
            //Assert
            Assert.Equal(95, bill);
        }

        [Fact]
        public void Ten_percent_discount_should_get_applied_for_Education()
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

            IDiscount discountType = new CategoryDiscount((int)Category.Education);
            cart = new Cart(discountType);

            //Act
            cart.AddItemToCart(cart.cartItemList, product1, 1);
            int bill = cart.GetTotalBill();
            //Assert
            Assert.Equal(90, bill);
        }

        [Fact]
        public void Fifteen_percent_discount_should_get_applied_for_Dairy()
        {
            //Arrange
            product1 = new Product("Tofu", 100, 101, Category.Dairy);

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

            IDiscount discountType = new CategoryDiscount((int)Category.Dairy);
            cart = new Cart(discountType);

            //Act
            cart.AddItemToCart(cart.cartItemList, product1, 1);
            int bill = cart.GetTotalBill();
            //Assert
            Assert.Equal(85, bill);
        }

        [Fact]
        public void Fifty_percent_discount_should_get_applied_for_Clothing()
        {
            //Arrange
            product1 = new Product("Chinos", 100, 101, Category.Clothing);

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
            Assert.Equal(50, bill);
        }

        [Fact]
        public void Fifty_percent_discount_should_get_applied_for_Electronics()
        {
            //Arrange
            product1 = new Product("Chinos", 100, 101, Category.Electronics);

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

            IDiscount discountType = new CategoryDiscount((int)Category.Electronics);
            cart = new Cart(discountType);

            //Act
            cart.AddItemToCart(cart.cartItemList, product1, 1);
            int bill = cart.GetTotalBill();
            //Assert
            Assert.Equal(75, bill);
        }
    }
}
