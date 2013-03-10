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

        public bool SaveProduct(Domain.Shipping shipping)
        {
            if (shipping.ID == 0)
            {
                context.Shipping.Add(shipping);
            }
            else
            {
                Shipping old = context.Shipping.Find(shipping.ID);
                context.Entry(old).CurrentValues.SetValues(shipping);
            }
            return context.SaveChanges() > 0 ? true : false;
        }
        
    }
}
