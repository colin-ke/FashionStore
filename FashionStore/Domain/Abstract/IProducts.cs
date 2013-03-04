using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Abstract
{
    public interface IProducts
    {
        IQueryable<Products> Products { get; }
    }
}
