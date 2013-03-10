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
        IOrders orderRepos;

        public MyHomeController(IOrders order)
        {
            orderRepos = order;
        }

        public ActionResult Index(Customers customer)
        {
            List<Orders> orders = orderRepos.Orders.Where(order => order.Shipping1.CustomerID == customer.ID).ToList();
            return View(orders);
        }

    }
}
