using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Domain.Abstract;
using Web.Infrastructure;

namespace Web.Binders
{
    public class CustomerBinder : IModelBinder
    {

        private ICustomers customersRepos;

        public CustomerBinder(ICustomers cus)
        {
            customersRepos = cus;
        }


        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //return null;
            Customers ctmr = (Customers)controllerContext.HttpContext.Session[Utility.USER_SESSIONKEY];
            if (null == ctmr)
            {
                Object objUid = controllerContext.HttpContext.Request.Cookies[Utility.USER_COOKIEKEY];
                if (null == objUid)
                    return null;
                try
                {
                    int uid = Convert.ToInt32(((HttpCookie)objUid).Value);
                    ctmr = customersRepos.Customers.Where<Customers>(x => x.ID == uid).FirstOrDefault<Customers>();
                }
                catch
                {
                    return null;
                }
            }
            return ctmr;
        }
    }
}