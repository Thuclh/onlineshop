using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ProductCategoryController : Controller
    {
        private OnlineShopDbContext _context;
        public ProductCategoryController()
        {
            _context = new OnlineShopDbContext();
        }
        // GET: Admin/ProductCatgrry
        public ActionResult Index()
        {
            var dao = new ProductCategoryDao();
            var productCategoryList = dao.ListAll();
            return View(productCategoryList);
        }

        [HttpPost]
        public JsonResult CreateUpdate(string strProductCategory)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ProductCategory productCategory = serializer.Deserialize<ProductCategory>(strProductCategory);
            bool status = false;
            string message = string.Empty;
            if (productCategory.ID == 0)
            {
                productCategory.CreatedDate = DateTime.Now;
                _context.ProductCategories.Add(productCategory);
                try
                {
                    _context.SaveChanges();
                    status = true;
                }
                catch (Exception ex)
                {
                    status = false;
                    message = ex.Message;
                }
            }
            else
            {
                var entity = _context.ProductCategories.Find(productCategory.ID);
                entity.Name = productCategory.Name;
                entity.MetaTitle = productCategory.MetaTitle;
                entity.Status = productCategory.Status;
                entity.ModifiedDate = DateTime.Now;
                try
                {
                    _context.SaveChanges();
                    status = true;
                }
                catch (Exception ex)
                {
                    status = false;
                    message = ex.Message;
                }
            }
            return Json(new
            {
                status = status,
                message=message
            });
        }
    }
}