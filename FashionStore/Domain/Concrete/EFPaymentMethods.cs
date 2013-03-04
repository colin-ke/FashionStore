using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Concrete
{
    public  class EFPaymentMethods : Domain.Abstract.IPaymentMethods
    {
        Domain.EFDBContext context = new EFDBContext();

        public IQueryable<PaymentMethods> PaymentMethods
        {
            get { return context.PaymentMethods; }
        }
    }
}
