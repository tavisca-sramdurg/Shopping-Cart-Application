using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartApplication_CleanCodePractices
{
    //Shopping Cart Application
    public class Cart 
    {
        public List<CartItem> cartItemList = new List<CartItem>();
        public IDiscount discount;

        public Cart(IDiscount discount)
        {
            this.discount = discount;
        }


        public void AddItemToCart(List<CartItem> cartItemList, IProduct product, int quantity)
        {
            bool ItemAlreadyExistsInCart = false;

            foreach (CartItem cartItem in cartItemList)
            {
                if (cartItem.product.ProductID == product.ProductID)
                {
                    ItemAlreadyExistsInCart = true;
                    cartItem.Quantity += quantity;
                }
            }

            if (!ItemAlreadyExistsInCart)
            {
                CartItem cartItem = new CartItem(product, quantity);
                cartItemList.Add(cartItem);
            }
        }

        public void RemoveItemFromCart(List<CartItem> cartItemList, IProduct product, int quantity)
        {
            //cartItemList.Remove(cartItem);
            //bool ItemAlreadyExistsInCart = false;

            foreach (CartItem cartItem in cartItemList)
            {
                if (cartItem.product == product)
                {
                    //ItemAlreadyExistsInCart = true;
                    cartItem.Quantity -= quantity;
                    if (cartItem.Quantity <= 0)
                    {
                        cartItem.Quantity = 0;
                        cartItemList.Remove(cartItem);
                    }
                    break;
                }
            }

            //if (!ItemAlreadyExistsInCart)
            //    throw new ItemDoesntExist("Item not found");
        }

        public int GetTotalBill()
        {
            int bill = 0;

            Type receivedType = discount.GetType();
            CategoryDiscount categoryDiscount = new CategoryDiscount(10);
            Type type = categoryDiscount.GetType();

            if (receivedType.Equals(type))
            {
                foreach (var cartItem in cartItemList)
                {
                    bill = bill + cartItem.CostOfCartItemWithCategoryDiscount();
                }
                return bill;
            }
            else
            {
                foreach (var cartItem in cartItemList)
                {
                    bill = bill + cartItem.CostOfCartItemWithoutCategoryDiscount();
                }

                int costOfCartItemWithDiscount = bill * (100 - discount.DiscountPercentage) / 100;
                return costOfCartItemWithDiscount;
            }

           

            
        }

    }
}
