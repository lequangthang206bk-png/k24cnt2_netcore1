IF DB_ID(N'LQThangLesson15') IS NULL
BEGIN
    CREATE DATABASE LQThangLesson15;
END
GO

USE LQThangLesson15;
GO

IF OBJECT_ID(N'dbo.LqtProduct', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.LqtProduct
    (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Name NVARCHAR(150) NOT NULL,
        Category NVARCHAR(100) NOT NULL,
        Price DECIMAL(18,2) NOT NULL,
        ImageUrl NVARCHAR(300) NULL,
        Description NVARCHAR(500) NULL
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.LqtProduct)
BEGIN
    INSERT INTO dbo.LqtProduct (Name, Category, Price, ImageUrl, Description)
    VALUES
    (N'iPhone 15', N'Điện thoại', 18990000, N'/images/iphone15.jpg', N'Thiết kế hiện đại, hiệu năng ổn định và camera chất lượng.'),
    (N'Samsung Galaxy S24', N'Điện thoại', 16990000, N'/images/s24.jpg', N'Smartphone cao cấp với thiết kế sang trọng và hiệu năng mạnh.'),
    (N'Xiaomi 14', N'Điện thoại', 14990000, N'/images/xiaomi14.jpg', N'Cấu hình mạnh, camera chất lượng và thiết kế nhỏ gọn.'),
    (N'AirPods Pro 2', N'Phụ kiện', 5990000, N'/images/airpodspro2.jpg', N'Tai nghe không dây cao cấp với thiết kế tiện dụng.'),
    (N'Anker 737', N'Phụ kiện', 1200000, N'/images/anker737.jpg', N'Pin sạc dự phòng dung lượng cao và nhiều tính năng.'),
    (N'Galaxy Buds 3', N'Tai nghe', 1500000, N'/images/galaxybuds3.jpg', N'Tai nghe Bluetooth hiện đại với âm thanh rõ ràng.'),
    (N'MacBook Air M3', N'Laptop', 24990000, N'/images/macbookairm3.jpg', N'Laptop mỏng nhẹ, hiệu năng tốt cho học tập và công việc.'),
    (N'ROG Strix G16', N'Laptop', 32990000, N'/images/rogstrixg16.jpg', N'Laptop gaming hiệu năng cao cho học tập và giải trí.');
END
GO
