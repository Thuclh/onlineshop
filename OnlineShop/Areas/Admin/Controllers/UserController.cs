using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1, int pageSize = 4)
        {
            var dao = new UserDao();
            var model = dao.listAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                
                long user = dao.Inser(entity);
                if (user > 0)
                {
                    SetAlert("Thêm người dùng thành công.", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("","Thêm người dùng không thành công.");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new UserDao().GetById(id);
            
            return View(dao);
        }

        [HttpPost]
        public ActionResult Edit(User entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                bool user = dao.Update(entity);
                if (user)
                {
                    SetAlert("Cập nhật người dùng thành công.", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật người dùng không thành công.");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new UserDao();
            new UserDao().Delete(id);
            SetAlert("Xóa người dùng thành công.", "error");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}