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
        #endregion


        public MainWindowViewModel()
        {
            OpenCustomerList = new RelayCommand(OpenCustomerListCommand);
            OpenProductList = new RelayCommand(OpenProductListCommand);
        }


        #region [private methods]

        private void OpenCustomerListCommand(object commandParameter)
        {
            CustomerSearchView customerView = new CustomerSearchView();
            customerView.DataContext = new CustomerSearchViewModel();
            customerView.Owner = Utils.Instance.GetMainWindowView();
            customerView.Show();
        }
        private void OpenProductListCommand(object commandparameter)
        {
            ProductSearchView productView = new ProductSearchView();
            productView.DataContext = new SearchProductViewModel();
            productView.Owner = Utils.Instance.GetMainWindowView();
            productView.Show();
        }

        #endregion

    }
}
