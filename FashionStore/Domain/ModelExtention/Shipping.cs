using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public partial class Shipping
    {
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}", Name, Address, Zip, Phone);
        }
    }
}
