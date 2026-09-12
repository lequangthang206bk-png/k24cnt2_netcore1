using System.ComponentModel.DataAnnotations;

namespace LQTLesson07Models.Models.DataModels
{
    public class LQTMember
    {
        [Display(Name = "LQT Member Id")]
        public string LQTMemberId { get; set; } = Guid.NewGuid().ToString();

        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập.")]
        [Display(Name = "LQT User Name")]
        public string LQTUserName { get; set; } = "";

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        [Display(Name = "LQT Password")]
        public string LQTPassword { get; set; } = "";

        [Required(ErrorMessage = "Vui lòng nhập họ và tên.")]
        [Display(Name = "LQT Full Name")]
        public string LQTFullName { get; set; } = "";

        [Required(ErrorMessage = "Vui lòng nhập email.")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
        [Display(Name = "LQT Email")]
        public string LQTEmail { get; set; } = "";
    }
}
