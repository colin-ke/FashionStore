using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Concrete
{
    public class EFOrderStatus :IOrderStatus
    {
        EFDBContext context = new EFDBContext();

        public IQueryable<OrderStatus> OrderStatus
        {
            get { return context.OrderStatus; }
        }

        public OrderStatus GetUnPaidStatus()
        {
            return OrderStatus.Where(status => status.StatusName.Contains("付款")).FirstOrDefault();
        }

        public OrderStatus GetPaidStatus()
        {
            return OrderStatus.Where(status => status.StatusName.Contains("发货")).FirstOrDefault();
        }

        public OrderStatus GetDoneStatus()
        {
            return OrderStatus.Where(status => status.StatusName.Contains("成功")).FirstOrDefault();
        }

        public OrderStatus GetCancelStatus()
        {
            return OrderStatus.Where(status => status.StatusName.Contains("取消")).FirstOrDefault();
        }
    }
}
