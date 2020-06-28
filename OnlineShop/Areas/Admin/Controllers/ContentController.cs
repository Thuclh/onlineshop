using Model.Dao;
using Model.EF;
using System;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Collections.Generic;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ContentController : Controller
    {
        private OnlineShopDbContext _context;

        public ContentController()
        {
            _context = new OnlineShopDbContext();
        }

        // GET: Admin/Content
        public ActionResult Index(string searchString, int page = 1, int pageSize = 3)
        {
            var dao = new ContentDao();
            var content = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

            return View(content);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Content content)
        {
            if (ModelState.IsValid)
            {
                content.CreatedDate = DateTime.Now;
                _context.Contents.Add(content);
                _context.SaveChanges();
            }
            SetViewBag();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var content = _context.Contents.Find(id);
            SetViewBag();
            return View(content);
        }

        [HttpPost]
        public ActionResult Edit(Content content)
        {
            SetViewBag();
            var detailContent = _context.Contents.Find(content.ID);

            detailContent.ModifiedDate = DateTime.Now;
            detailContent.Name = content.Name;
            detailContent.MetaTitle = content.MetaTitle;
            detailContent.Description = content.Description;
            detailContent.Detail = content.Detail;
            detailContent.ModifieBy = content.ModifieBy;
            detailContent.Status = content.Status;

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var delContent = _context.Contents.Find(id);
            _context.Contents.Remove(delContent);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public void SetViewBag(long? selectdId = null, string searchString = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryId = new SelectList(dao.ListAll(searchString), "ID", "Name", selectdId);
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var content = _context.Contents.Find(id);
            content.Status = !content.Status;
            _context.SaveChanges();
            return Json(new
            {
                status = content
            });
        }
    }
}