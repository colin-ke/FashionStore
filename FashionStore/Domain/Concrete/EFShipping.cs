using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Abstract;

namespace Domain.Concrete
{
    public class EFShipping : IShipping
    {
        private EFDBContext context = new EFDBContext();

        public IQueryable<Domain.Shipping> Shippings
        {
            get { return context.Shipping; }
        }

        public bool Add(Domain.Shipping shipping)
        {
            context.Shipping.Add(shipping);
            return context.SaveChanges() > 0 ? true : false;
        }
        
    }
}
