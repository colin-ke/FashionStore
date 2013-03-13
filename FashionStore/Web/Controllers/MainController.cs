using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Domain.Abstract;
using Web.Infrastructure;
using Web.Models;

namespace Web.Controllers
{
    public class MainController : Controller
    {
        private IFiltCatagories filtCata;
        private INavCatagories navCata;
        private ICustomers customerRepos;

        public MainController(IFiltCatagories filtCata,INavCatagories nav,ICustomers cus)
        {
            this.filtCata = filtCata;
            this.navCata = nav;
            this.customerRepos = cus;
        }

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult AllFiltCata()
        {
            return PartialView(navCata.Catagories.Where<Domain.NavCatagories>(item=>item.ParentNavCata == null));
        }

        public PartialViewResult TopNavPanel()
        { 
            return PartialView(navCata.Catagories);
        }

        public PartialViewResult NavPanelUserInfo(Customers cus)
        {
            bool login = false;
            if (null != cus)
                login = true;
            ViewBag.login = login;
            return PartialView(cus);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login model)
        {
            if (string.IsNullOrEmpty(model.Email))
                ModelState.AddModelError("Email", "Please enter your email");
            if (string.IsNullOrEmpty(model.Password))
                ModelState.AddModelError("Password", "Please enter your password");
            if (!ModelState.IsValid)
                return View();
            bool access = false;
            Customers cus = customerRepos.Customers.Where<Customers>(x => x.Email == model.Email).FirstOrDefault<Customers>();
            if (null != cus)
                if (cus.Password.Trim() == model.Password.Trim())
                {
                    access = true;
                    Session[Utility.USER_SESSIONKEY] = cus;
                    if (model.IsToRemeber)
                        Response.AppendCookie(new HttpCookie(Utility.USER_COOKIEKEY,cus.ID.ToString()));
                }
            ViewBag.access = access;
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(FormCollection collection)
        {
            if (string.IsNullOrEmpty(collection["Email"]))
                ModelState.AddModelError("Email","Please enter your email");
            if (string.IsNullOrEmpty(collection["Password"]))
                ModelState.AddModelError("Password","Please enter a password");
            if (string.IsNullOrEmpty(collection["Name"]))
                ModelState.AddModelError("Name","Please enter your name");
            if (!ModelState.IsValid)
                return View();
            Customers cus = new Customers() { 
                Email = collection["Email"],
                Password = collection["Password"],
                Name = collection["Name"],
                Gender = collection["Gender"] == "0" ? Genders.Male : Genders.Female
            };
            string msg;
            if (customerRepos.SaveCustomer(cus, out msg))
            {
                msg = "注册成功";
                cus = customerRepos.Customers.Where<Customers>(x => x.Email == cus.Email).FirstOrDefault<Customers>();
                Session[Utility.USER_SESSIONKEY] = cus;
            }
            else
                msg = msg == "" ? "注册失败" : msg;
            ViewBag.msg = msg;
            if(null!=Request.QueryString["preurl"])
                ViewBag.preurl = Request.QueryString["preurl"];
            return View();
        }

        public RedirectResult LogOff(string preUrl)
        {
            Session[Utility.USER_SESSIONKEY] = null;
            Response.Cookies[Utility.USER_COOKIEKEY].Expires = DateTime.Now;
            return Redirect(preUrl);
        }
    }
}
