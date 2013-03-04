using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Abstract
{
    public interface IPaymentMethods
    {
        IQueryable<PaymentMethods> PaymentMethods { get; }
    }
}
