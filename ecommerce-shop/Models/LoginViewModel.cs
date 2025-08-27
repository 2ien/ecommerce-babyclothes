using System.ComponentModel.DataAnnotations;

namespace ecommerce_shop.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập Password")]
        public string Password { get; set; }

        // Thông báo lỗi đăng nhập (nếu sai)
        public string LoginErrorMessage { get; set; }

    }
}
