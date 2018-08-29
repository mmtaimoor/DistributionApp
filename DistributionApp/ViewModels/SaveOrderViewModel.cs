using DistributionApp.BusinessLayer;
using DistributionApp.DataLayer;
using DistributionApp.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DistributionApp.ViewModels
{
    public class SaveOrderViewModel : BaseViewModel
    {
        #region [private variables]

        private CustomerBL objCustomerBL;
        private ProductBL objProductBL;
        private OrderBL objOrderBL;
        private ObservableCollection<Customer> _customerList;
        private Order _order;
        private ObservableCollection<OrderDetail> _orderDetails;
        private ObservableCollection<Product> _productList;

        #endregion

        #region [public properties]

        public ObservableCollection<Customer> CustomerList
        {
            get { return _customerList; }
            set
            {
                _customerList = value;
                OnPropertyChanged();
            }
        }

        public Order Order
        {
            get { return _order; }
            set
            {
                _order = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<OrderDetail> OrderDetails
        {
            get { return _orderDetails; }
            set
            {
                _orderDetails = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Product> ProductList
        {
            get { return _productList; }
            set
            {
                _productList = value;
                OnPropertyChanged();
            }
        }

        #endregion


        #region [command]

        public ICommand AddNewOrderDetail { get; set; }
        public ICommand DeleteOrderDetail { get; set; }
        public ICommand SaveOrder { get; set; }

        #endregion

        public SaveOrderViewModel()
        {
            objCustomerBL = new CustomerBL();
            objProductBL = new ProductBL();
            objOrderBL = new OrderBL();
            Order = new Order();
            OrderDetails = new ObservableCollection<OrderDetail>();
            AddNewOrderDetail = new RelayCommand(AddNewOrderDetailCommand);
            DeleteOrderDetail = new RelayCommand(DeleteOrderDetailCommand);
            SaveOrder = new RelayCommand(SaveOrderCommand);
            CustomerList = new ObservableCollection<Customer>(objCustomerBL.GetActiveCustomers());
            ProductList = new ObservableCollection<Product>(objProductBL.GetActiveProducts());
        }

        private void AddNewOrderDetailCommand(object commandparameter)
        {
            OrderDetails.Add(new OrderDetail { Order = Order });
        }

        private void DeleteOrderDetailCommand(object commandparameter)
        {
            var orderDetail = commandparameter as OrderDetail;
            if (orderDetail != null)
                OrderDetails.Remove(orderDetail);
        }

        private void SaveOrderCommand(object commandparameter)
        {
            OrderDetails.ToList().ForEach(x => x.TotalPrice = x.Quantity * x.ProductReport.PricePerUnit);
            Order.OrderDetails = OrderDetails;
            objOrderBL.SaveOrders(Order);
        }

    }
}
