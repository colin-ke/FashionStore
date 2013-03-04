using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Web.Controllers
{
    public class MainController : Controller
    {
        private Domain.Abstract.IFiltCatagories filtCata;
        private Domain.Abstract.INavCatagories navCata;

        public MainController(Domain.Abstract.IFiltCatagories filtCata,Domain.Abstract.INavCatagories nav)
        {
            this.filtCata = filtCata;
            this.navCata = nav;
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

        public ActionResult Login()
        {
            return View();
        }

        

    }
}
