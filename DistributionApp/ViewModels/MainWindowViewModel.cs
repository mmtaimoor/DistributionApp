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

        #endregion


        public MainWindowViewModel()
        {
            OpenCustomerList = new RelayCommand(OpenCustomerListCommand);

        }


        #region [private methods]

        private void OpenCustomerListCommand(object commandParameter)
        {
            CustomerSearchView customerView = new CustomerSearchView();
            customerView.DataContext = new CustomerSearchViewModel();
            //customerView.Owner = Utils.Instance.GetMainWindowView();
            customerView.Show();
        }

        #endregion

    }
}
