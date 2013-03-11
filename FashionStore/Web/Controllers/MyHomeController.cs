using Domain;
using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class MyHomeController : Controller
    {
        private IOrders orderRepos;
        private IOrderStatus orderStatus;

        public MyHomeController(IOrders order,IOrderStatus status)
        {
            orderRepos = order;
            orderStatus = status;
        }

        public ActionResult Index(Customers customer)
        {
            List<Orders> orders = orderRepos.Orders.Where(order => order.Shipping1.CustomerID == customer.ID).ToList();
            return View(orders);
        }

        [HttpGet]
        public ViewResult OrderPay(int id)
        {
            Orders order = orderRepos.Orders.Where(x => x.ID == id).FirstOrDefault();
            if (null == order)
                return null;
            ViewBag.total = order.TotalPay;
            return View();
        }

        [HttpPost]
        public ViewResult OrderPay(int id,FormCollection collection)
        {
            Orders order = orderRepos.Orders.Where(x => x.ID == id).FirstOrDefault();
            if (null == order)
                return null;
            OrderStatus status = orderStatus.GetPaidStatus();
            order.Status = status.ID;
            order.Paid = true;
            bool res = orderRepos.SaveOrder(order);
            ViewBag.success = res;
            return View();
        }

        public RedirectToRouteResult OrderCancel(int id)
        {
            Orders order = orderRepos.Orders.Where(x => x.ID == id).FirstOrDefault();
            if (null == order)
                return null;
            OrderStatus status = orderStatus.GetCancelStatus();
            order.Status = status.ID;
            orderRepos.SaveOrder(order);
            return RedirectToAction("index");
        }

        public RedirectToRouteResult OrderDone(int id)
        {
            Orders order = orderRepos.Orders.Where(x => x.ID == id).FirstOrDefault();
            if (null == order)
                return null;
            OrderStatus status = orderStatus.GetDoneStatus();
            order.Status = status.ID;
            orderRepos.SaveOrder(order);
            return RedirectToAction("index");
        }


        public ViewResult ChangePwd(Customers customer)
        {
            return View();
        }

    }
}
