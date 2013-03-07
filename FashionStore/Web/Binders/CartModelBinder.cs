using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;
using System.Web.Mvc;
using Web.Infrastructure;

namespace Web.Binders
{
    public class CartModelBinder : IModelBinder
    {
        SessionCart cart = new SessionCart();
        private const string sessionKey = Utility.CART_SESSIONKEY;

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            SessionCart cart = (SessionCart)controllerContext.HttpContext.Session[sessionKey];
            if (cart == null)
            {
                cart = new SessionCart();
                controllerContext.HttpContext.Session[sessionKey] = cart;
            }
            return cart;
        } 
    }
}