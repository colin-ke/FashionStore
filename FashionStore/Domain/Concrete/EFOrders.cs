using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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


        public bool SaveOrder(Orders order)
        {
            if (0 == order.ID)
            {
                if (null == order.PaymentMethods)
                    order.PaymentMethods = context.PaymentMethods.Where(x => x.ID == order.PaymentMethod.Value).FirstOrDefault();
                if (order.PaymentMethods.NeedtoPayFirst())
                {
                    order.OrderStatus = context.OrderStatus.Where(status => status.StatusName.Contains("付款")).FirstOrDefault();
                    order.Paid = false;
                }
                else
                {
                    order.OrderStatus = context.OrderStatus.Where(status => status.StatusName.Contains("发货")).FirstOrDefault();
                    order.Paid = true;
                }
                context.Orders.Add(order);
            }
            else
            {
                Orders old = context.Orders.Find(order.ID);
                context.Entry(old).CurrentValues.SetValues(order);
            }
            return context.SaveChanges() > 0 ? true : false;

        }
    }
}
