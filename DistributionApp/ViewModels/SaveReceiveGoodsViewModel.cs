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
    public class SaveReceiveGoodsViewModel: BaseViewModel
    {
        #region [private variables]

        private ReceiveGood _receiveGood;
        private ObservableCollection<ReceiveGoodDetail> _receiveGoodDetail;
        private ProductBL objProductBL;
        private ReceiveGoodsBL objReceiveGoodsBL;
        private ObservableCollection<Product> _productList;
        #endregion


        #region [public properties]

        public ReceiveGood ReceiveGood
        {
            get { return _receiveGood; }
            set
            {
                _receiveGood = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ReceiveGoodDetail> ReceiveGoodDetail
        {
            get { return _receiveGoodDetail; }
            set
            {
                _receiveGoodDetail = value;
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

        #region [Commands]

        public ICommand AddNewInvoiceDetail { get; set; }
        public ICommand DeleteInvoiceDetail { get; set; }
        public ICommand SaveReceiveGoods { get; set; }

        #endregion

        public SaveReceiveGoodsViewModel()
        {
            ReceiveGood = new ReceiveGood();
            objProductBL = new ProductBL();
            objReceiveGoodsBL = new ReceiveGoodsBL();
            AddNewInvoiceDetail = new RelayCommand(AddNewInvoiceDetailCommand);
            DeleteInvoiceDetail = new RelayCommand(DeleteInvoiceDetailCommand);
            SaveReceiveGoods = new RelayCommand(SaveReceiveGoodsCommand);
            ProductList = new ObservableCollection<Product>(objProductBL.GetActiveProducts());
            ReceiveGoodDetail = new ObservableCollection<ReceiveGoodDetail>();
        }


        #region [private methods]

        private void AddNewInvoiceDetailCommand(object commandparameter)
        {
            ReceiveGoodDetail.Add(new ReceiveGoodDetail() { ReceiveGood = ReceiveGood });
        }

        private void DeleteInvoiceDetailCommand(object commandparameter)
        {
            var receiveGoodDetail = commandparameter as ReceiveGoodDetail;
            if (receiveGoodDetail != null)
                ReceiveGoodDetail.Remove(receiveGoodDetail);
        }

        private void SaveReceiveGoodsCommand(object commandparameter)
        {
            ReceiveGoodDetail.ToList().ForEach(x => x.TotalValue = x.Quantity * x.ProductReport.PricePerUnit);
            ReceiveGood.ReceiveGoodDetails = ReceiveGoodDetail;
            objReceiveGoodsBL.SaveReceiveGoods(ReceiveGood);
        }

        #endregion



    }
}
