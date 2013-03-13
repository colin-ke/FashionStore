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
        private ICustomers customerRepos;

        public MyHomeController(IOrders order,IOrderStatus status,ICustomers cus)
        {
            orderRepos = order;
            orderStatus = status;
            customerRepos = cus;
        }

        public ActionResult Index(Customers customer)
        {
            if (null == customer)
                return RedirectToAction("login", "main", new { preurl = "/myhome" });
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

        [HttpGet]
        public ActionResult ChangePwd(Customers customer)
        {
            if (null == customer)
                return RedirectToAction("login", "main", new { preurl = "/myhome/changepwd" });
            return View();
        }

        [HttpPost]
        public ActionResult ChangePwd(Customers customer,FormCollection collection)
        {
            if (null == customer)
                return RedirectToAction("login", "main", new { preurl = "/myhome/changepwd" });
            string old, newPwd;
            string msg;
            old = collection["old"];
            newPwd = collection["new"];
            if (old == customer.Password)
            {
                customer.Password = newPwd;
                if (customerRepos.SaveCustomer(customer, out msg))
                    msg = "修改成功";
            }
            else
                msg = "原密码错误！";
            ViewBag.msg = msg;
            return View();
        }

    }
}
