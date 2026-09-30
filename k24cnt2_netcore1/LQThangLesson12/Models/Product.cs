
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LQThangLesson12.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(150)]
        [Column(TypeName = "nvarchar(150)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Giá sản phẩm không được để trống")]
        public float Price { get; set; }

        public float SalePrice { get; set; }

        public byte Status { get; set; }

        [StringLength(1000)]
        [Column(TypeName = "ntext")]
        public string Descriptions { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public DateTime CreatedDate { get; set; }

        public Category Category { get; set; }
    }
}
