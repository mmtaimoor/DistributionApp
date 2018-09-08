using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DistributionApp.DataLayer;

namespace DistributionApp.BusinessLayer
{
    public class TransactionBL
    {
        public TransactionBL()
        {

        }

        public void SaveTransaction(TransactionDetail _trans)
        {
            using (DistributionDbEntities context = new DistributionDbEntities())
            {
                context.TransactionDetails.Add(_trans);
                context.SaveChanges();
            }
        }

        public List<TransactionType> GetTransactionTypes()
        {
            using (DistributionDbEntities context = new DistributionDbEntities())
            {
                return context.TransactionTypes.Where(x => x.IsActive == true && x.ShowTransaction == true).ToList();
            }
        }

        public bool CheckCreditLimit(Customer customer, decimal invoicePrice )
        {
            using (DistributionDbEntities context = new DistributionDbEntities())
            {
                var transactions = from trans in context.TransactionDetails
                                   select trans.Amount;
            }
            return false;
        }

    }
}
