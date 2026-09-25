using LQThangShopdochoi.Data;

namespace LQThangShopdochoi.Models
{
    public class ProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAll() =>
            _context.Products.OrderBy(p => p.Id).ToList();

        public Product? GetById(int id) =>
            _context.Products.FirstOrDefault(p => p.Id == id);

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public bool Update(Product product)
        {
            var old = GetById(product.Id);
            if (old == null) return false;

            old.Name = product.Name;
            old.Price = product.Price;
            old.Description = product.Description;
            old.ImageUrl = product.ImageUrl;
            old.Category = product.Category;
            old.Quantity = product.Quantity;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var product = GetById(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }
    }
}
