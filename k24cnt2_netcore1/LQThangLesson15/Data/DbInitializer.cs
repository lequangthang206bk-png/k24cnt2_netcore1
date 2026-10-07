using LQThangLesson15.Models;

namespace LQThangLesson15.Data;

public static class DbInitializer
{
    public static void Seed(LqtLesson15DbContext db)
    {
        if (db.Products.Any())
        {
            return;
        }

        db.Products.AddRange(
            new LqtProduct { Name = "iPhone 15", Category = "Điện thoại", Price = 18990000, ImageUrl = "/images/iphone15.jpg", Description = "Thiết kế hiện đại, hiệu năng ổn định và camera chất lượng." },
            new LqtProduct { Name = "Samsung Galaxy S24", Category = "Điện thoại", Price = 16990000, ImageUrl = "/images/s24.jpg", Description = "Smartphone cao cấp với thiết kế sang trọng và hiệu năng mạnh." },
            new LqtProduct { Name = "Xiaomi 14", Category = "Điện thoại", Price = 14990000, ImageUrl = "/images/xiaomi14.jpg", Description = "Cấu hình mạnh, camera chất lượng và thiết kế nhỏ gọn." },
            new LqtProduct { Name = "AirPods Pro 2", Category = "Phụ kiện", Price = 5990000, ImageUrl = "/images/airpodspro2.jpg", Description = "Tai nghe không dây cao cấp với thiết kế tiện dụng." },
            new LqtProduct { Name = "Anker 737", Category = "Phụ kiện", Price = 1200000, ImageUrl = "/images/anker737.jpg", Description = "Pin sạc dự phòng dung lượng cao và nhiều tính năng." },
            new LqtProduct { Name = "Galaxy Buds 3", Category = "Tai nghe", Price = 1500000, ImageUrl = "/images/galaxybuds3.jpg", Description = "Tai nghe Bluetooth hiện đại với âm thanh rõ ràng." },
            new LqtProduct { Name = "MacBook Air M3", Category = "Laptop", Price = 24990000, ImageUrl = "/images/macbookairm3.jpg", Description = "Laptop mỏng nhẹ, hiệu năng tốt cho học tập và công việc." },
            new LqtProduct { Name = "ROG Strix G16", Category = "Laptop", Price = 32990000, ImageUrl = "/images/rogstrixg16.jpg", Description = "Laptop gaming hiệu năng cao cho học tập và giải trí." }
        );

        db.SaveChanges();
    }
}
