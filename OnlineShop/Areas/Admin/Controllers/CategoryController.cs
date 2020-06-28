using Model.EF;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        private OnlineShopDbContext _context;

        public CategoryController()
        {
            _context = new OnlineShopDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Category
        [HttpGet]
        public JsonResult LoadData()
        {
            var model = _context.Categories.ToList();
            return Json(new
            {
                data = model,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetDetail(int id)
        {
            var category = _context.Categories.Find(id);
            return Json(new
            {
                data = category,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveData(string strCategory)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Category category = serializer.Deserialize<Category>(strCategory);
            bool status = false;
            string message = string.Empty;

            if (category.ID == 0)
            {
                category.CreatedDate = DateTime.Now;
                _context.Categories.Add(category);
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
                var entity = _context.Categories.Find(category.ID);
                entity.Name = category.Name;
                entity.MetaTitle = category.MetaTitle;
                entity.Status = category.Status;
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
                message = message
            });
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var entity = _context.Categories.Find(id);
            _context.Categories.Remove(entity);
            try
            {
                _context.SaveChanges();
                return Json(new
                {
                    status = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    status = false,
                    message = ex.Message
                });
            }
        }
    }
}