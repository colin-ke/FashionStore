using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace Web.Models
{
    public class CheckoutInfo
    {
        public Shipping Shipping { get; set; }
        public ShippingMethods ShippingMethod { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
    }
}