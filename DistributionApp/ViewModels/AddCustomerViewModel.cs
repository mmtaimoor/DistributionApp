using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DistributionApp.BusinessLayer;
using DistributionApp.DataLayer;
using DistributionApp.Utilities;

namespace DistributionApp.ViewModels
{
    public class AddCustomerViewModel : BaseViewModel
    {
        #region [private variables]
        private Customer _customer;
        private CustomerBL objBL;
        #endregion

        #region [public properties]

        public Customer Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region [commands]

        public ICommand SaveCustomer { get; set; }

        #endregion


        public AddCustomerViewModel()
        {
            SaveCustomer = new RelayCommand(SaveCustomerCommand);
            Customer = new Customer();
            objBL = new CustomerBL();
        }

        private void SaveCustomerCommand(object commandParameter)
        {
            if (_customer != null)
            {
                objBL.AddCustomer(Customer);
            }
        }

    }
}
