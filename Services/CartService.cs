using OnlineShoppingApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShoppingApp.Services
{
    public class CartService : ICartService
    {
        private readonly List<CartItem> _cart = new();
        private const decimal DISCOUNT_CAP = 5000;

        public void AddToCart(Product product)
        {
            var existing = _cart.FirstOrDefault(x => x.ProductId == product.Id);

            if (existing != null)
            {
                existing.Quantity++;
            }
            else
            {
                _cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    DiscountPercentage = product.DiscountPercentage,
                    Quantity = 1
                });
            }
        }

        public void RemoveFromCart(int productId)
        {
            var item = _cart.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
            {
                _cart.Remove(item);
            }
        }

        public List<CartItem> GetCartItems() => _cart;

        public decimal GetTotal()
        {
            return _cart.Sum(x => x.TotalPrice);
        }

        public decimal GetDiscountedTotal()
        {
            var total = GetTotal();

            if (total > DISCOUNT_CAP)
            {
                return _cart.Sum(x => x.FinalPrice);
            }

            return total; // No discount if below cap
        }
    }
}