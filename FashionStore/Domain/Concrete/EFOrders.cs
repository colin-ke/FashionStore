﻿using System;
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


        public bool Add(Orders order)
        {
            order.OrderStatus = context.OrderStatus.Where(status => status.StatusName.Contains("付款")).FirstOrDefault();
            context.Orders.Add(order);
            return context.SaveChanges() > 0 ? true : false;
        }
    }
}
