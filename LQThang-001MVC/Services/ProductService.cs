using System.Text.Json;
using LQThang_001MVC.Models;

namespace LQThang_001MVC.Services
{
    public class ProductService
    {
        private readonly string _filePath;

        public ProductService()
        {
            _filePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Data",
                "products.json"
            );

            string? folder = Path.GetDirectoryName(_filePath);

            if (!string.IsNullOrEmpty(folder) && !Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }

        // Lấy toàn bộ sản phẩm
        public List<Product> GetAll()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Product>();
            }

            string json = File.ReadAllText(_filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Product>();
            }

            return JsonSerializer.Deserialize<List<Product>>(json)
                   ?? new List<Product>();
        }

        // Lấy sản phẩm theo ID
        public Product? GetById(int id)
        {
            var products = GetAll();

            return products.FirstOrDefault(p => p.Id == id);
        }

        // Thêm sản phẩm
        public void Add(Product product)
        {
            var products = GetAll();

            if (products.Count == 0)
            {
                product.Id = 1;
            }
            else
            {
                product.Id = products.Max(p => p.Id) + 1;
            }

            products.Add(product);

            Save(products);
        }

        // Sửa sản phẩm
        public void Update(Product product)
        {
            var products = GetAll();

            var oldProduct = products.FirstOrDefault(
                p => p.Id == product.Id
            );

            if (oldProduct != null)
            {
                oldProduct.Name = product.Name;
                oldProduct.Brand = product.Brand;
                oldProduct.Price = product.Price;
                oldProduct.Quantity = product.Quantity;
                oldProduct.Image = product.Image;
                oldProduct.Description = product.Description;

                Save(products);
            }
        }

        // Xóa sản phẩm
        public void Delete(int id)
        {
            var products = GetAll();

            var product = products.FirstOrDefault(
                p => p.Id == id
            );

            if (product != null)
            {
                products.Remove(product);

                Save(products);
            }
        }

        // Lưu dữ liệu
        private void Save(List<Product> products)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(
                products,
                options
            );

            File.WriteAllText(_filePath, json);
        }
    }
}