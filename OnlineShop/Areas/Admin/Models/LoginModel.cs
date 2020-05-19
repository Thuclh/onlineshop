using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Nhập tên đăng nhập.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Nhập mật khẩu.")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}