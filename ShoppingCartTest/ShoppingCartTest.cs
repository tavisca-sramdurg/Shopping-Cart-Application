using System;
using Xunit;
using ShoppingCartApplication_CleanCodePractices;

namespace ShoppingCartTest
{
    public class ShoppingCartTest
    {
        Product product1, product2;

        Cart cart;

        public ShoppingCartTest()
        {
           
        }

        [Fact]
        public void Test_if_item_is_getting_added_to_cart()
        {
            //Arrange
            product1 = new Product("Mobile", 15000, 101, Category.Electronics);
            
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

            //Assert
            Assert.Equal(1, cart.cartItemList.Count);
        }

        [Fact]
        public void Test_if_item_is_getting_removed_from_cart()
        {
            //Arrange
            product1 = new Product("Mobile", 15000, 101, Category.Electronics);

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
            cart.RemoveItemFromCart(cart.cartItemList, product1, 1);

            //Assert
            Assert.Equal(0, cart.cartItemList.Count);
        }

        [Fact]
        public void Cart_item_quantity_should_get_updated_if_item_already_exists_while_adding()
        {
            //Arrange
            product1 = new Product("Mobile", 15000, 101, Category.Electronics);

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
            cart.AddItemToCart(cart.cartItemList, product1, 1);

            //Assert
            Assert.Equal(1, cart.cartItemList.Count);
        }

        public void Cart_item_quantity_should_get_updated_if_item_already_exists_while_removing()
        {
            //Arrange
            product1 = new Product("Mobile", 15000, 101, Category.Electronics);
            product1 = new Product("NCERT", 500, 102, Category.Education);

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
            cart.AddItemToCart(cart.cartItemList, product1, 2);
            cart.AddItemToCart(cart.cartItemList, product2, 1);
            cart.RemoveItemFromCart(cart.cartItemList, product1, 1);

            //Assert
            Assert.Equal(2, cart.cartItemList.Count);
        }
    }
}
