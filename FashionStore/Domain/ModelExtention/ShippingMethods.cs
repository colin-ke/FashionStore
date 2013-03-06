using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public partial class ShippingMethods
    {
        public decimal GetExtraPay(decimal money)
        {
            if (null == Operation || (null != MaxFree && money >= MaxFree.Value))
                return 0;
            switch (Operation)
            {
                case "+":
                    return OpNum.Value;
                case "*":
                    if (null != MinPay && money <= MinPay)
                        return MinPay.Value;
                    else {
                        return money * OpNum.Value;
                    }
                default: return 0;
            }
        }
    }
}
