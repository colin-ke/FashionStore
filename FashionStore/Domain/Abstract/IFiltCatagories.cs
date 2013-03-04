using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Abstract
{
    public interface IFiltCatagories
    {
        IQueryable<FiltCatagories> Catagories { get; }
    }
}
