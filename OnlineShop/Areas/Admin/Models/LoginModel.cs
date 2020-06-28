using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Yêu cầu nhập tên tài khoản.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}