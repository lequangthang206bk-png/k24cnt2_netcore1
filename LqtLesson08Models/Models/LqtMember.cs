using System.ComponentModel;

namespace LqtLesson08Models.Models
{
    public class LqtMember
    {
        [DisplayName("Mã thành viên")]
        public string LqtMemberId { get; set; } = string.Empty;

        [DisplayName("Tên tài khoản")]
        public string LqtUserName { get; set; } = string.Empty;

        [DisplayName("Mật khẩu")]
        public string LqtPassword { get; set; } = string.Empty;

        [DisplayName("Họ và tên")]
        public string LqtFullName { get; set; } = string.Empty;

        [DisplayName("Email")]
        public string LqtEmail { get; set; } = string.Empty;
    }
}
