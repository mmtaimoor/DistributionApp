using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DistributionApp.DataLayer;

namespace DistributionApp.BusinessLayer
{
    public class OrderBL
    {
        private CustomerBL objCustomerBL;

        public OrderBL()
        {
            objCustomerBL = new CustomerBL();
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


        public List<Order> SearchOrders(DateTime? fromDate, DateTime? toDate)
        {
            using (DistributionDbEntities context = new DistributionDbEntities())
            {
                var orderList = context.Orders.Where(x => x.OrderDate>= fromDate && x.OrderDate <= toDate).ToList();
                orderList.ForEach(item => 
                {
                    FillOrderDetails(item);
                    item.Customer = objCustomerBL.FindCustomerById(item.CustomerId.GetValueOrDefault());
                });
                return orderList;
            }
        }

        private void FillOrderDetails(Order item)
        {
            using (DistributionDbEntities context = new DistributionDbEntities())
            {
                ProductBL objProductBL = new ProductBL();

                var orderDetails = context.OrderDetails.Where(x => x.OrderId == item.OrderId).ToList();
                orderDetails.ForEach(detail => { detail.Product = objProductBL.FindProductById(detail.ProductId); });
                item.ShowOrderDetails = new ObservableCollection<OrderDetail>(orderDetails.ToList());

            }
        }

    }
}
