using Microsoft.AspNetCore.Mvc;
using LQThangShopdochoi.Models;
using LQThangShopdochoi.Extensions;

namespace LQThangShopdochoi.Controllers
{
    public class CartController : Controller
    {
        private const string CartKey = "SHOP_CART";
        private readonly ProductRepository _repository;

        public CartController(ProductRepository repository)
        {
            _repository = repository;
        }

        private List<CartItem> GetCart()
        {
            return HttpContext.Session.GetObject<List<CartItem>>(CartKey) ?? new List<CartItem>();
        }

        private void SaveCart(List<CartItem> cart)
        {
            HttpContext.Session.SetObject(CartKey, cart);
        }

        public IActionResult Index()
        {
            return View(GetCart());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(int id)
        {
            var product = _repository.GetById(id);
            if (product == null) return NotFound();

            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.Product.Id == id);

            if (item == null && product.Quantity > 0)
                cart.Add(new CartItem { Product = product, Quantity = 1 });
            else if (item != null && item.Quantity < product.Quantity)
                item.Quantity++;

            SaveCart(cart);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Increase(int id)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.Product.Id == id);
            var product = _repository.GetById(id);

            if (item != null && product != null && item.Quantity < product.Quantity)
                item.Quantity++;

            SaveCart(cart);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Decrease(int id)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(x => x.Product.Id == id);

            if (item != null)
            {
                item.Quantity--;
                if (item.Quantity <= 0)
                    cart.Remove(item);
            }

            SaveCart(cart);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            var cart = GetCart();
            cart.RemoveAll(x => x.Product.Id == id);
            SaveCart(cart);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Clear()
        {
            SaveCart(new List<CartItem>());
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Checkout()
        {
            var cart = GetCart();
            if (!cart.Any()) return RedirectToAction(nameof(Index));

            ViewBag.Total = cart.Sum(x => x.Total);
            return View(new CheckoutViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout(CheckoutViewModel model)
        {
            var cart = GetCart();
            if (!cart.Any()) return RedirectToAction(nameof(Index));

            if (!ModelState.IsValid)
            {
                ViewBag.Total = cart.Sum(x => x.Total);
                return View(model);
            }

            foreach (var item in cart)
            {
                var product = _repository.GetById(item.Product.Id);
                if (product == null || item.Quantity > product.Quantity)
                {
                    ModelState.AddModelError("", $"Sản phẩm {item.Product.Name} không đủ số lượng trong kho.");
                    ViewBag.Total = cart.Sum(x => x.Total);
                    return View(model);
                }
            }

            foreach (var item in cart)
            {
                var product = _repository.GetById(item.Product.Id);
                if (product != null)
                {
                    product.Quantity -= item.Quantity;
                    _repository.Update(product);
                }
            }

            var orderCode = $"DH{DateTime.Now:yyyyMMddHHmmss}";
            var total = cart.Sum(x => x.Total);
            SaveCart(new List<CartItem>());

            ViewBag.OrderCode = orderCode;
            ViewBag.Total = total;
            ViewBag.CustomerName = model.FullName;
            ViewBag.PaymentMethod = model.PaymentMethod == "COD" ? "Thanh toán khi nhận hàng" : "Chuyển khoản ngân hàng";
            return View("Success");
        }
    }
}
