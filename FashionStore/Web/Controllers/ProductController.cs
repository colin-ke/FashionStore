using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Domain.Abstract;
using Domain.Concrete;
using Web.Models;
using System.Web.Script.Serialization;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        private IProducts products;

        public ProductController(IProducts pdts)
        {
            products = pdts;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductDetail(int id, SessionCart cart)
        {
            Products pdt = null;
            pdt = products.Products.Where<Products>(p => p.ID == id).FirstOrDefault<Products>();
            if (pdt != null)
            {
                if (null == Session["history"])
                    Session["history"] = new List<Products>();
                List<Products> list = (List<Products>)Session["history"];
                if (list.Count >= 5)
                    list.RemoveAt(0);
                if(!list.Any<Products>(x=>x.ID == pdt.ID))
                    list.Add(pdt);
                ViewBag.History = list;
                ViewBag.Cart = cart;
                return View(pdt);
            }
            else
                return null;
        }

        [HttpPost]
        public string Buy(int id,int count,int sizeId,int colorId,SessionCart cart)
        {
            Products pdt = products.Products.Where<Products>(p => p.ID == id).FirstOrDefault<Products>();
            cart.AddItem(pdt, sizeId, colorId, count);
            JsonCart jCart = new JsonCart() { ItemCount = cart.ItemCount, Total = cart.ComputeTotalValue() };
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return  serializer.Serialize(jCart);
        }

        [HttpPost]
        public string RemovePdt(int pdtId,SessionCart cart)
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

    }
}
