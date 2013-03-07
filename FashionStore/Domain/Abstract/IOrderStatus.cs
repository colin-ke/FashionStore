using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Abstract
{
    public interface IOrderStatus
    {
        IQueryable<OrderStatus> OrderStatus { get; }

        OrderStatus GetUnPaidStatus();
        OrderStatus GetPaidStatus();
        OrderStatus GetDoneStatus();
        OrderStatus GetCancelStatus();
    }
}
