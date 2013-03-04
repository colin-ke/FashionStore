using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Domain.Abstract;

namespace Web.Binders
{
    public class CustomerBinder : IModelBinder
    {
        private const string sessionKey = "user";
        private const string cookieKey = "uid";

        private ICustomers customersRepos;

        public CustomerBinder(ICustomers cus)
        {
            customersRepos = cus;
        }


        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Customers ctmr = (Customers)controllerContext.HttpContext.Session[sessionKey];
            if (null == ctmr)
            {
                Object uid = controllerContext.HttpContext.Request.Cookies[cookieKey];
                if (null == uid)
                    return null;
                ctmr = customersRepos.Customers.Where<Customers>(x => x.ID.ToString() == uid.ToString()).FirstOrDefault<Customers>();
            }
            return ctmr;
        }
    }
}