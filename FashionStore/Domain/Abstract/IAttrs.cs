using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace Domain.Abstract
{
    public interface IAttrs
    {
        IQueryable<AttrTitles> AttrTitles { get; }
        IQueryable<AttrContents> AttrContents { get; }
    }
}
