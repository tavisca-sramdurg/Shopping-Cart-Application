using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartApplication_CleanCodePractices
{
    //Shopping Cart Application
    public class Cart
    {
        public List<CartItem> cartItemList { get; private set;}
        public IDiscount discount;

        public Cart(IDiscount discount)
        {
            this.discount = discount;
            cartItemList = new List<CartItem>();
        }


        public void AddItemToCart(List<CartItem> cartItemList, Product product, int quantity)
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

        public void RemoveItemFromCart(List<CartItem> cartItemList, Product product, int quantity)
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

            int bill = Bill.CalculateBill(cartItemList, discount);
            return bill;
        }

        public int GetItemPriceByName(string name)
        {
            foreach (var item in cartItemList)
            {
                if (item.product.Name.Equals(name))
                {
                    //product = item;
                    return item.product.Price;
                }
            }
            return -1;
        }

    }
}
