using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Abstract
{
    public interface IShipping
    {
        IQueryable<Shipping> Shippings { get; }

        bool SaveProduct(Shipping shipping);
    }
}
