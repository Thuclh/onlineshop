using Model.Dao;
using OnlineShop.Commons;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var slide = new SlideDao();
            var result = slide.ListAll();
            ViewBag.Slide = result;
            //
            var productDao = new ProductDao();
            ViewBag.ListNewProducts = productDao.ListNewProducts(4);
            ViewBag.ListFeatureProducts = productDao.ListFeatureProducts(4);
            return View();
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDao();
            var result = model.ListByGroupId(1);
            return PartialView(result);
        }

        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            var model = new MenuDao();
            var result = model.ListByGroupId(2);
            return PartialView(result);
        }

        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return PartialView(list);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = new FooterDao();
            var result = model.GetFooter();
            return PartialView(result);
        }
    }
}