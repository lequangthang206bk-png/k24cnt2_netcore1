using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeQuangThang2410900071_exam.Models;

[Table("LqtEmployee")]
public class LqtEmployee
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    [Display(Name = "Họ và tên")]
    public string? LqtName { get; set; }

    [StringLength(20)]
    [Display(Name = "Giới tính")]
    public string? LqtGender { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Ngày sinh")]
    public DateTime? LqtBirthDay { get; set; }

    [EmailAddress]
    [StringLength(150)]
    [Display(Name = "Email")]
    public string? LqtEmail { get; set; }

    [StringLength(20)]
    [Display(Name = "Số điện thoại")]
    public string? LqtPhone { get; set; }

    [Display(Name = "Hoạt động")]
    public bool LqtActive { get; set; }
}
