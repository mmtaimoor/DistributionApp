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

        public void SaveCustomer(Customer _customer)
        {
            using (DistributionDbEntities context = new DistributionDbEntities())
            {
                var cust = context.Customers.FirstOrDefault(x => x.CustomerId == _customer.CustomerId);
                if (cust == null)
                {
                    context.Customers.Add(_customer);
                    context.SaveChanges();
                }
                else
                {
                    context.Entry(cust).CurrentValues.SetValues(_customer);
                    context.SaveChanges();
                }
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
