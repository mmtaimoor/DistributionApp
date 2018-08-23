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
    public class SearchProductViewModel : BaseViewModel
    {
        #region [private variables]

        private ObservableCollection<Product> _productList;
        private ProductBL objBL;

        #endregion

        #region [public properties]

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

        #region [Commands]

        public ICommand AddNewProduct { get; set; }
        public ICommand EditProduct { get; set; }
        #endregion


        public SearchProductViewModel()
        {
            AddNewProduct = new RelayCommand(AddNewProductCommand);
            EditProduct = new RelayCommand(EditProductCommand);

            objBL = new ProductBL();
            ProductList = new ObservableCollection<Product>(objBL.GetProductList());
        }

        #region [private methods]

        private void AddNewProductCommand(object commandparameter)
        {
            SaveProductView view = new SaveProductView()
            {
                DataContext = new SaveProductViewModel()
            };
            view.ShowDialog();
            ProductList = new ObservableCollection<Product>(objBL.GetProductList());
        }

        private void EditProductCommand(object commandparameter)
        {
            int productId = int.Parse(commandparameter.ToString());
            SaveProductViewModel model = new SaveProductViewModel();
            model.LoadProduct(productId);
            SaveProductView view = new SaveProductView()
            {
                DataContext = model,
                Title = "Edit Product"
            };
            view.ShowDialog();
            ProductList = new ObservableCollection<Product>(objBL.GetProductList());
        }

        #endregion

    }
}
