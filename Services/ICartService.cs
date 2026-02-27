using OnlineShoppingApp.Models;
using System.Collections.Generic;

namespace OnlineShoppingApp.Services
{
    public interface ICartService
    {
        void AddToCart(Product product);
        void RemoveFromCart(int productId);
        List<CartItem> GetCartItems();
        decimal GetTotal();
        decimal GetDiscountedTotal();
    }
}