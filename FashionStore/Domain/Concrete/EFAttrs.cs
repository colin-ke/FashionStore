using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Domain.Concrete
{
    public class EFAttrs : Domain.Abstract.IAttrs
    {
        private EFDBContext context = new EFDBContext();

        public IQueryable<AttrTitles> AttrTitles { get { return context.AttrTitles; } }
        public IQueryable<AttrContents> AttrContents { get { return context.AttrContents; } }
    }
}
