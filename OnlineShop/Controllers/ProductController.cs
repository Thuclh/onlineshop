using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var dao = new ProductCategoryDao();
            var result = dao.ListAll();
            return PartialView(result);
        }

        public ActionResult Category(long cateId)
        {
            var category = new CategoryDao().ViewDetail(cateId);
            ViewBag.Category = category;
            var model = new ProductDao().ListByCategoryId(cateId);
            return View(model);
        }

        public ActionResult Detail(long id)
        {
            var product = new ProductDao().ViewDetail(id);
            ViewBag.Category = new ProductCategoryDao().ViewDetail(product.CategoryId.Value);
            ViewBag.RelateProducts = new ProductDao().ListRelatedProducts(id);
            return View(product);
        }
    }
}