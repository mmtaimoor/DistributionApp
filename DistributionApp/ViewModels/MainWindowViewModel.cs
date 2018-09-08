using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DistributionApp.Utilities;
using DistributionApp.ViewModels;
using DistributionApp.Views;

namespace DistributionApp.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {

        #region [private variables]

        #endregion

        #region [Commands]

        public ICommand OpenCustomerList { get; set; }
        public ICommand OpenProductList { get; set; }
        public ICommand OpenReceiveGoods { get; set; }
        public ICommand SearchReceiveGoods { get; set; }
        public ICommand OpenInventory { get; set; }
        public ICommand SaveOrders { get; set; }
        public ICommand SearchOrders { get; set; }
        public ICommand OpenEmployeeList { get; set; }
        public ICommand SaveTransaction { get; set; }

        #endregion


        public MainWindowViewModel()
        {
            OpenCustomerList = new RelayCommand(OpenCustomerListCommand);
            OpenProductList = new RelayCommand(OpenProductListCommand);
            OpenReceiveGoods = new RelayCommand(OpenReceiveGoodsCommand);
            SearchReceiveGoods = new RelayCommand(SearchReceiveGoodsCommand);
            OpenInventory = new RelayCommand(OpenInventoryCommand);
            SaveOrders = new RelayCommand(SaveOrdersCommand);
            SearchOrders = new RelayCommand(SearchOrdersCommand);
            OpenEmployeeList = new RelayCommand(OpenEmployeeListCommand);
            SaveTransaction = new RelayCommand(SaveTransactionCommand);
        }


        #region [private methods]

        private void OpenCustomerListCommand(object commandParameter)
        {
            CustomerSearchView customerView = new CustomerSearchView();
            customerView.DataContext = new CustomerSearchViewModel();
            customerView.Owner = Utils.Instance.GetMainWindowView();
            customerView.Show();
        }
        private void OpenProductListCommand(object commandParameter)
        {
            ProductSearchView productView = new ProductSearchView();
            productView.DataContext = new SearchProductViewModel();
            productView.Owner = Utils.Instance.GetMainWindowView();
            productView.Show();
        }
        private void OpenReceiveGoodsCommand(object commandParameter)
        {
            SaveReceiveGoods receiveGoodsView = new SaveReceiveGoods();
            receiveGoodsView.DataContext = new SaveReceiveGoodsViewModel();
            receiveGoodsView.Owner = Utils.Instance.GetMainWindowView();
            receiveGoodsView.Show();
        }
        private void SearchReceiveGoodsCommand(object commandparameter)
        {
            ReceiveGoodsSearchView receiveGoodsView = new ReceiveGoodsSearchView();
            receiveGoodsView.DataContext = new ReceiveGoodsSearchViewModel();
            receiveGoodsView.Owner = Utils.Instance.GetMainWindowView();
            receiveGoodsView.Show();
        }
        private void OpenInventoryCommand (object commandparameter)
        {
            ShowInventoryView inventoryView = new ShowInventoryView();
            inventoryView.DataContext = new ShowInventoryViewModel();
            inventoryView.Owner = Utils.Instance.GetMainWindowView();
            inventoryView.Show();
        }
        private void SaveOrdersCommand(object commandparameter)
        {
            SaveOrderView orderView = new SaveOrderView();
            orderView.DataContext = new SaveOrderViewModel();
            orderView.Owner = Utils.Instance.GetMainWindowView();
            orderView.Show();
        }
        private void SearchOrdersCommand (object commandparameter)
        {
            OrderSearchView orderSearchView = new OrderSearchView();
            orderSearchView.DataContext = new OrderSearchViewModel();
            orderSearchView.Owner = Utils.Instance.GetMainWindowView();
            orderSearchView.Show();
        }
        private void OpenEmployeeListCommand (object commandparameter)
        {
            EmployeeSearchView emplopyeeView = new EmployeeSearchView();
            emplopyeeView.DataContext = new SearchEmployeeViewModel();
            emplopyeeView.Owner = Utils.Instance.GetMainWindowView();
            emplopyeeView.Show();
        }
        private void SaveTransactionCommand (object commandparameter)
        {
            AddTransactionDetail transView = new AddTransactionDetail();
            transView.DataContext = new AddTransactionDetailViewModel();
            transView.Owner = Utils.Instance.GetMainWindowView();
            transView.Show();
        }
        #endregion

    }
}
