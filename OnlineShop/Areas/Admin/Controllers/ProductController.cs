using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index(string searchString, int page = 1, int pageSize = 4)
        {
            var productList = new ProductDao().ListAll(searchString,page,pageSize);
            ViewBag.SearchString = searchString;
            return View(productList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                SetViewBag();
                var dao = new ProductDao();
                var prod = dao.Insert(product);
                if (prod > 0)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công.");
                }
            }
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            SetViewBag();
            var dao = new ProductDao().GetById(id);
            return View(dao);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            SetViewBag();
            var model = new ProductDao().Update(product);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProductDao().Delete(id);

            return RedirectToAction("Index");
        }

        public void SetViewBag(long? selectedId = null)
        {
            var dao = new ProductCategoryDao().ListAll();
            ViewBag.CategoryId = new SelectList(dao, "ID", "Name", selectedId);
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new ProductDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}