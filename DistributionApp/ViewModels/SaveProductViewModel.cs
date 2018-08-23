using DistributionApp.BusinessLayer;
using DistributionApp.DataLayer;
using DistributionApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DistributionApp.ViewModels
{
    public class SaveProductViewModel : BaseViewModel
    {
        #region [private variables]
        private Product _product;
        private ProductBL objBL;
        #endregion

        #region [public properties]

        public Product Product
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region [commands]

        public ICommand SaveProduct { get; set; }

        #endregion


        public SaveProductViewModel()
        {
            SaveProduct = new RelayCommand(SaveProductCommand);
            Product = new Product();
            objBL = new ProductBL();
        }

        private void SaveProductCommand(object commandParameter)
        {
            if (_product != null)
            {
                objBL.SaveProduct(_product);
                var window = commandParameter as Window;
                if (window != null)
                    window.Close();
            }
        }

        public void LoadProduct(int productId)
        {
            Product = objBL.FindProductById(productId);
        }

    }
}
