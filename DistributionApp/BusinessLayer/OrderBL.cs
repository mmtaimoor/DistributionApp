using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DistributionApp.DataLayer;

namespace DistributionApp.BusinessLayer
{
    public class OrderBL
    {
        public OrderBL()
        {

        }

        public void SaveOrders(Order _order)
        {
            using (DistributionDbEntities context = new DistributionDbEntities())
            {

                var order = context.Orders.FirstOrDefault(x => x.OrderId == _order.OrderId);
                if (order == null)
                {
                    context.Orders.Add(_order);
                    context.SaveChanges();
                }
                else
                {
                    context.Entry(order).CurrentValues.SetValues(_order);
                    context.SaveChanges();
                }
            }
        }



    }
}
