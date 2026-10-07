using System.ComponentModel.DataAnnotations;

namespace LQThangLesson15.Models;

public class LqtProduct
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Category { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string? ImageUrl { get; set; }

    public string? Description { get; set; }
}
