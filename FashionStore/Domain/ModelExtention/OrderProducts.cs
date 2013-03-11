using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public partial class OrderProducts
    {
        public decimal ItemTotal { get { return Products.Price * Quantity; } }
        public string Title
        {
            get 
            {
                return string.Format("{0} {1} {2}", Products.Title, Colors.Name, Sizes.Name);
            }
        }
    }
}
