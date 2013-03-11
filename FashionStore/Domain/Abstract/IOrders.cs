using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Abstract
{
    public interface IOrders
    {
        IQueryable<Orders> Orders { get; }

        bool SaveOrder(Orders order);
    }
}
