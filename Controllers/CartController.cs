using Microsoft.AspNetCore.Mvc;
using OnlineShoppingApp.Data;
using OnlineShoppingApp.Services;

namespace OnlineShoppingApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICartService _cartService;

        public CartController(ApplicationDbContext context, ICartService cartService)
        {
            _context = context;
            _cartService = cartService;
        }

        public IActionResult Add(int id)
        {
            var product = _context.Products.Find(id);

            if (product != null)
            {
                _cartService.AddToCart(product);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            _cartService.RemoveFromCart(id);
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var items = _cartService.GetCartItems();
            ViewBag.Total = _cartService.GetTotal();
            ViewBag.FinalTotal = _cartService.GetDiscountedTotal();
            ViewBag.Discount = ViewBag.Total - ViewBag.FinalTotal;

            return View(items);
        }
    }
}