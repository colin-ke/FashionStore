using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Web.Models;
using Domain.Abstract;

namespace Web.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/

        private IShippingMethods sMethodsRepos;
        private IPaymentMethods pMethodsRepos;

        public CartController(IShippingMethods sm,IPaymentMethods pm)
        {
            sMethodsRepos = sm;
            pMethodsRepos = pm;
        }

        public ActionResult Index(SessionCart cart)
        {
            return View(cart);
        }

        [HttpGet]
        public ActionResult CheckOut(SessionCart cart,Customers cus)
        {
            ViewBag.cart = cart;
            ViewBag.customer = cus;
            ViewBag.sMethods = sMethodsRepos.ShippingMethods.ToList<ShippingMethods>();
            ViewBag.pMethods = pMethodsRepos.PaymentMethods.ToList<PaymentMethods>();
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult CheckOut(CheckoutInfo info)
        {
            return RedirectToAction("Finish");
        }

        [HttpPost]
        public string GetExtraPay(int sid, decimal goodTotal)
        {
            ShippingMethods sm = sMethodsRepos.ShippingMethods.Where(x => x.ID == sid).FirstOrDefault();
            if (null == sm)
                return "0";
            else
                return sm.GetExtraPay(goodTotal).ToString();
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
