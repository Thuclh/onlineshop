using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ContentController : Controller
    {
        // GET: Admin/Content
        public ActionResult Index()
        {
            return View();
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

            }
            SetViewBag();
            return View();
        }

        public void SetViewBag(long? selectdId = null, string searchString=null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryId = new SelectList(dao.ListAll(searchString), "ID", "Name", selectdId);
        }
    }
}