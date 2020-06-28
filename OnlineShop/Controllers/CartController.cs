using Model.Dao;
using OnlineShop.Commons;
using OnlineShop.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Linq;

namespace OnlineShop.Controllers
{
    public class CartController : Controller
    {
        //private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        public ActionResult AddItem(long productId, int quantity)
        {
            var product = new ProductDao().ViewDetail(productId);
            var cart = Session[CommonConstants.CartSession];

            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.ID == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                // Gán vào session
                Session[CommonConstants.CartSession] = list;
            }
            else
            {
                // Tạo mới đối tượng CartSession
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);

                // Gán vào session
                Session[CommonConstants.CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        public JsonResult DeleteAll()
        {
            Session[CommonConstants.CartSession] = null;
            return Json(new
            {
                status=true
            });
        }

        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CommonConstants.CartSession];
            sessionCart.RemoveAll(x => x.Product.ID == id);

            Session[CommonConstants.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CommonConstants.CartSession];

            foreach(var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CommonConstants.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
    }
}