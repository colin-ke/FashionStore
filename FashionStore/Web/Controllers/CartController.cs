using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Web.Models;
using Domain.Abstract;
using Web.Infrastructure;

namespace Web.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/

        private IShippingMethods sMethodsRepos;
        private IPaymentMethods pMethodsRepos;
        private IOrders orderRepos;
        private IShipping shippingRepos;
        private IOrderStatus orderStatus;

        public CartController(IShippingMethods sm,IPaymentMethods pm,IOrders order,IShipping shipping,IOrderStatus status)
        {
            sMethodsRepos = sm;
            pMethodsRepos = pm;
            orderRepos = order;
            shippingRepos = shipping;
            orderStatus = status;
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
        public RedirectToRouteResult CheckOut(CheckoutInfo info,Customers customer,SessionCart cart)
        {
            if (info.Shipping.ID == 0)
            {
                info.Shipping.CustomerID = customer.ID;
                info.Shipping.Customers = customer;
                shippingRepos.Add(info.Shipping);
                info.Shipping = shippingRepos.Shippings.Where(x => x.ToString() == info.Shipping.ToString()).FirstOrDefault();
            }

            List<OrderProducts> oPdts = cart.Items.Select<CartItem, OrderProducts>(item => new OrderProducts { ProductID = item.Products.ID,Quantity = item.Quantity }).ToList();

            Orders order = new Orders() 
            {
                Date = DateTime.Now,
                Shipping = info.Shipping.ID,
                PaymentMethod = info.PaymentMethod.ID,
                ShippingMethod = info.ShippingMethod.ID,
                OrderProducts = oPdts
            };

            //order.Shipping1 = shippingRepos.Shippings.Where(x => x.ID == info.Shipping.ID).FirstOrDefault();
            //order.ShippingMethods = sMethodsRepos.ShippingMethods.Where(x => x.ID == info.ShippingMethod.ID).First();
            //order.PaymentMethods = pMethodsRepos.PaymentMethods.Where(x => x.ID == info.PaymentMethod.ID).First();
            orderRepos.Add(order);
            cart.Clear();
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
