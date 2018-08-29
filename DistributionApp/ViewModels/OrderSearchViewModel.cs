using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DistributionApp.BusinessLayer;
using DistributionApp.DataLayer;
using DistributionApp.Utilities;

namespace DistributionApp.ViewModels
{
    public class OrderSearchViewModel : BaseViewModel
    {

        #region [private variables]

        private ObservableCollection<Order> _orderList;
        private OrderBL objOrderBL;
        private DateTime? _fromDate;
        private DateTime? _toDate;

        #endregion

        #region [public properties]

        public ObservableCollection<Order> OrderList
        {
            get { return _orderList; }
            set
            {
                _orderList = value;
                OnPropertyChanged();
            }
        }

        public DateTime? FromDate
        {
            get { return _fromDate; }
            set
            {
                _fromDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime? ToDate
        {
            get { return _toDate; }
            set
            {
                _toDate = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region [commands]

        public ICommand SearchOrders { get; set; }
        public ICommand EditOrder { get; set; }


        #endregion

        public OrderSearchViewModel()
        {
            objOrderBL = new OrderBL();
            SearchOrders = new RelayCommand(SearchOrdersCommand);
            EditOrder = new RelayCommand(EditOrderCommand);
            FromDate = DateTime.Now.AddDays(-30);
            ToDate = DateTime.Now;
        }


        #region [private methods]

        private void SearchOrdersCommand(object commandparameter)
        {
            OrderList = new ObservableCollection<Order>(objOrderBL.SearchOrders(FromDate, ToDate));
        }

        private void EditOrderCommand(object commandparameter)
        {

        }

        #endregion

    }
}
