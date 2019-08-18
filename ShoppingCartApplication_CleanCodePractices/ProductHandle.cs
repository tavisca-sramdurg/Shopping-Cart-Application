using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartApplication_CleanCodePractices
{
    public class ProductHandle
    {
        public void AddItemToCart(List<ICartItem> cartItemList, IProduct product, int quantity)
        {
            bool ItemAlreadyExistsInCart = false;

            foreach (ICartItem cartItem in cartItemList)
            {
                if (cartItem.product.ProductID == product.ProductID)
                {
                    ItemAlreadyExistsInCart = true;
                    cartItem.Quantity += quantity;
                }
            }

            if (!ItemAlreadyExistsInCart)
            {
                ICartItem cartItem = new CartItem(product, quantity);
                cartItemList.Add(cartItem);
            }
        }

        public void RemoveItemFromCart(List<ICartItem> cartItemList, IProduct product ,int quantity)
        {
            //cartItemList.Remove(cartItem);
            //bool ItemAlreadyExistsInCart = false;

            foreach(ICartItem cartItem in cartItemList)
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
    }
}