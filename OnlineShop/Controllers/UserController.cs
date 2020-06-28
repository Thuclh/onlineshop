using Model.Dao;
using Model.EF;
using OnlineShop.Common;
using OnlineShop.Models;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại.");
                }
                else if (dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại.");
                }
                else
                {
                    var user = new User();
                    user.UserName = model.UserName;
                    user.Password = Encryptor.MD5Hash(model.Password);
                    user.Name = model.Name;
                    user.Email = model.Email;
                    user.Address = model.Address;
                    user.Phone = model.Phone;
                    user.Status = true;
                    var result = dao.Inser(user);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng kí thành công.";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng kí không thành công.");
                    }
                }
            }
            return View(model);
        }
    }
}