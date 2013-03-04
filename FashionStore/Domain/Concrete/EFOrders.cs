using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Concrete
{
    public class EFOrders : Domain.Abstract.IOrders
    {
        Domain.EFDBContext context = new EFDBContext();

        public IQueryable<Orders> Orders
        {
            get { return context.Orders; }
        }
    }
}
