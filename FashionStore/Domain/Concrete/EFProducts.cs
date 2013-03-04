using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Concrete
{
    public class EFProducts : Domain.Abstract.IProducts
    {
        private Domain.EFDBContext context = new EFDBContext();

        IQueryable<Products> Abstract.IProducts.Products
        {
            get { return context.Products; }
        }
    }
}
