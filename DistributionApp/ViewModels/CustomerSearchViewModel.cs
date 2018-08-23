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
using DistributionApp.Views;

namespace DistributionApp.ViewModels
{
    public class CustomerSearchViewModel : BaseViewModel
    {
        #region [private variables]
        private ObservableCollection<Customer> _customerList;
        private CustomerBL objBL;
        #endregion
        
        #region [public properties]

        public ObservableCollection<Customer> CustomerList
        {
            get { return _customerList; }
            set
            { _customerList = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region [Commands]

        public ICommand AddNewCustomer { get; set; }
        public ICommand EditCustomer { get; set; }

        #endregion

        public CustomerSearchViewModel()
        {
            AddNewCustomer = new RelayCommand(AddNewCustomerCommand);
            EditCustomer = new RelayCommand(EditCustomerCommand);
            objBL = new CustomerBL();
            CustomerList = new ObservableCollection<Customer>(objBL.GetCustomerList());


        }

        private void AddNewCustomerCommand(object commandParameter)
        {
            AddCustomerView view = new AddCustomerView()
            {
                DataContext = new AddCustomerViewModel()
            };
            view.Show();
        }
        private void EditCustomerCommand(object commandParameter)
        {

        }



    }
}
