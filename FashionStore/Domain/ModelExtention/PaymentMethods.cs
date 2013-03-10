using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public partial class PaymentMethods
    {
        public bool NeedtoPayFirst()
        {
            return !Name.Contains("货到付款");
        }
    }
}
