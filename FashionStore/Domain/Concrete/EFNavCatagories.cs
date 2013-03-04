using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Concrete
{
    public class EFNavCatagories : Domain.Abstract.INavCatagories
    {
        private Domain.EFDBContext efDbConetxt = new EFDBContext();

        public IQueryable<NavCatagories> Catagories
        {
            get { return efDbConetxt.NavCatagories; }
        }
    }
}
