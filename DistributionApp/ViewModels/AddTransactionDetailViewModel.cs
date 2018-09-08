using DistributionApp.BusinessLayer;
using DistributionApp.DataLayer;
using DistributionApp.Utilities;
using DistributionApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace DistributionApp.ViewModels
{
    public class AddTransactionDetailViewModel : BaseViewModel
    {
        #region [private variables]

        private ObservableCollection<Customer> _customerList;
        private ObservableCollection<TransactionType> _transactionTypeList;
        private CustomerBL objCustomerBL;
        private TransactionBL objTransactionBL;
        private TransactionDetail _transactionDetail;

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

        public ObservableCollection<TransactionType> TransactionTypeList
        {
            get { return _transactionTypeList; }
            set
            {
                _transactionTypeList = value;
                OnPropertyChanged();
            }
        }

        public TransactionDetail TransactionDetail
        {
            get { return _transactionDetail; }
            set
            {
                _transactionDetail = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region [Icommands]

        public ICommand SaveTransaction { get; set; }

        #endregion


        public AddTransactionDetailViewModel()
        {
            objCustomerBL = new CustomerBL();
            objTransactionBL = new TransactionBL();
            TransactionDetail = new TransactionDetail();
            CustomerList = new ObservableCollection<Customer>(objCustomerBL.GetActiveCustomers());
            TransactionTypeList = new ObservableCollection<TransactionType>(objTransactionBL.GetTransactionTypes());
            SaveTransaction = new RelayCommand(SaveTransactionCommand);
        }

        #region [private variables]

        private void SaveTransactionCommand(object commandparameter)
        {
            objTransactionBL.SaveTransaction(TransactionDetail);
        }

        #endregion

    }
}
