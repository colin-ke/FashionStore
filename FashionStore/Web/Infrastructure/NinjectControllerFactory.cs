using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Concrete;

namespace Web.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            //return base.GetControllerInstance(requestContext, controllerType);
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IFiltCatagories>().To<EFFiltCatagories>();
            ninjectKernel.Bind<INavCatagories>().To<EFNavCatagories>();
            ninjectKernel.Bind<IAttrs>().To<EFAttrs>();
            ninjectKernel.Bind<IProducts>().To<EFProducts>();
        }
    }
}