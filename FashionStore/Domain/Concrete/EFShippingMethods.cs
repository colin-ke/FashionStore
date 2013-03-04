using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Concrete
{
    public class EFShippingMethods : Domain.Abstract.IShippingMethods
    {
        Domain.EFDBContext context = new EFDBContext();

        public IQueryable<ShippingMethods> ShippingMethods
        {
            get { return context.ShippingMethods; }
        }
    }
}
