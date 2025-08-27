using System.ComponentModel.DataAnnotations;

namespace ecommerce_shop.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [EmailAddress(ErrorMessage = "Định dạng Email không đúng")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập lại Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật khẩu không khớp")]
        public string ConfirmPassword { get; set; }

        // Chứa thông báo lỗi (nếu có) khi đăng ký
        public string RegisterErrorMessage { get; set; }
    }
}
