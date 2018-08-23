using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DistributionApp.DataLayer;

namespace DistributionApp.BusinessLayer
{
    public class CustomerBL
    {
        public CustomerBL()
        {
        }

        public List<Customer> GetCustomerList()
        {
            using (DistributionDbEntities context = new DistributionDbEntities())
            {
                return  context.Customers.ToList();
            }
        }

        public void AddCustomer(Customer _customer)
        {
            using (DistributionDbEntities context = new DistributionDbEntities())
            {
                context.Customers.Add(_customer);
                context.SaveChanges();
            }
        }

        public Customer FindCustomerById(int customerId)
        {
            using (DistributionDbEntities context = new DistributionDbEntities())
            {
                return context.Customers.FirstOrDefault(x => x.CustomerId == customerId);
            }
        }

    }
}
