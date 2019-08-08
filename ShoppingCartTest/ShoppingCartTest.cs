using System;
using Xunit;
using ShoppingCartApplication_CleanCodePractices;

namespace ShoppingCartTest
{
    public class ShoppingCartTest
    {
        IProduct product1, product2, product3;

        Cart cart;

        public ShoppingCartTest()
        {
           
        }

        [Fact]
        public void Test_if_item_is_getting_added_to_cart()
        {
            //Arrange
            product1 = new Product("Mobile", 15000, 101, Category.Electronics);
            ProductHandle productHandle = new ProductHandle();
            IDiscount discountType = new CartDiscount();
            cart = new Cart(discountType);

            //Act
            productHandle.AddItemToCart(cart.cartItemList, product1, 1);

            //Assert
            Assert.Equal(1, cart.cartItemList.Count);
        }

        [Fact]
        public void Test_if_item_is_getting_removed_from_cart()
        {
            //Arrange
            product1 = new Product("Mobile", 15000, 101, Category.Electronics);
            ProductHandle productHandle = new ProductHandle();
            IDiscount discountType = new CartDiscount();
            cart = new Cart(discountType);

            //Act
            productHandle.AddItemToCart(cart.cartItemList, product1, 1);
            productHandle.RemoveItemFromCart(cart.cartItemList, product1, 1);

            //Assert
            Assert.Equal(0, cart.cartItemList.Count);
        }

        [Fact]
        public void Cart_item_quantity_should_get_updated_if_item_already_exists_while_adding()
        {
            //Arrange
            product1 = new Product("Mobile", 15000, 101, Category.Electronics);
            ProductHandle productHandle = new ProductHandle();
            IDiscount discountType = new CartDiscount();
            cart = new Cart(discountType);

            //Act
            productHandle.AddItemToCart(cart.cartItemList, product1, 1);
            productHandle.AddItemToCart(cart.cartItemList, product1, 1);

            //Assert
            Assert.Equal(1, cart.cartItemList.Count);
        }

        public void Cart_item_quantity_should_get_updated_if_item_already_exists_while_removing()
        {
            //Arrange
            product1 = new Product("Mobile", 15000, 101, Category.Electronics);
            product1 = new Product("NCERT", 500, 102, Category.Education);
            ProductHandle productHandle = new ProductHandle();
            IDiscount discountType = new CartDiscount();
            cart = new Cart(discountType);

            //Act
            productHandle.AddItemToCart(cart.cartItemList, product1, 2);
            productHandle.AddItemToCart(cart.cartItemList, product2, 1);
            productHandle.RemoveItemFromCart(cart.cartItemList, product1, 1);

            //Assert
            Assert.Equal(2, cart.cartItemList.Count);
        }

        [Fact]
        public void Cart_discount_should_get_applied_correctly()
        {
            //Arrange
            product1 = new Product("tshirt", 1000, 101, Category.Clothing);
            ProductHandle productHandle = new ProductHandle();
            IDiscount discountType = new CartDiscount();
            cart = new Cart(discountType);

            //Act
            productHandle.AddItemToCart(cart.cartItemList, product1, 2);
            int bill = cart.GetTotalBill();
            //Assert
            Assert.Equal(900, bill);
        }

        [Fact]
        public void Category_discount_should_get_applied_correctly()
        {
            //Arrange
            product1 = new Product("tshirt", 1000, 101, Category.Clothing);
            ProductHandle productHandle = new ProductHandle();
            IDiscount discountType = new CategoryDiscount((int)Category.Clothing);
            cart = new Cart(discountType);

            //Act
            productHandle.AddItemToCart(cart.cartItemList, product1, 2);
            int bill = cart.GetTotalBill();
            //Assert
            Assert.Equal(500, bill);
        }
    }
}
