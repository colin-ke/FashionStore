using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Web.Models;

namespace Web.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/

        public ActionResult Index(SessionCart cart)
        {
            return View(cart);
        }

        public ActionResult CheckOut()
        {
            return View();
        }

        public ActionResult Finish(SessionCart cart)
        {
            string total = cart.ComputeTotalValue().ToString();
            cart.Clear();
            ViewBag.total = total;
            return View();
        }

        [HttpPost]
        public string SetCount(int pdtId, int sizeId, int colorId, int quantity ,SessionCart cart)
        {
            CartItem item = cart.Items.Where<CartItem>(x=>x.Products.ID == pdtId && x.Size.ID == sizeId && x.Color.ID == colorId).FirstOrDefault<CartItem>();
            if (null == item)
                return "";
            item.Quantity = quantity;
            return cart.ComputeTotalValue().ToString();
        }

        [HttpPost]
        public string RemovePdt(int pdtId, SessionCart cart)
        {
            CartItem pdt = cart.Items.Where<CartItem>(item => item.Products.ID == pdtId).FirstOrDefault<CartItem>();
            if (null != pdt)
            {
                cart.RemoveItem(pdt.Products);
                return cart.ComputeTotalValue().ToString();
            }
            else
                return "";
        }

        [HttpPost]
        public void ClearCart(SessionCart cart)
        {
            cart.Clear();
        }

    }
}
