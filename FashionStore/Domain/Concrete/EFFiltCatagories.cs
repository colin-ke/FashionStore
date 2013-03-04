using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Concrete
{
    public class EFFiltCatagories : Domain.Abstract.IFiltCatagories
    {
        private Domain.EFDBContext context = new EFDBContext();

        public IQueryable<FiltCatagories> Catagories
        {
            get { return context.FiltCatagories; }
        }
    }
}
