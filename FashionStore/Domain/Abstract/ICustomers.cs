using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Abstract
{
    public interface ICustomers
    {
        IQueryable<Customers> Customers { get; }

        bool SaveCustomer(Customers customer, out string err);
        Customers GetCustomerById(int id);

    }
}
