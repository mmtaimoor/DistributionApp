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
    public class ReceiveGoodsSearchViewModel : BaseViewModel
    {
        #region [private variables]

        private ObservableCollection<ReceiveGood> _receiveGoods;
        private DateTime? _fromDate;
        private DateTime? _toDate;
        private ReceiveGoodsBL objReceiveGoodsBL;

        #endregion

        #region [public variables]

        public ObservableCollection<ReceiveGood> ReceiveGoods
        {
            get { return _receiveGoods; }
            set
            {
                _receiveGoods = value;
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

        public ICommand SearchReceiveGoods { get; set; }
        public ICommand EditReceiveGood { get; set; }

        #endregion

        public ReceiveGoodsSearchViewModel()
        {
            objReceiveGoodsBL = new ReceiveGoodsBL();
            SearchReceiveGoods = new RelayCommand(SearchReceiveGoodsCommand);
            EditReceiveGood = new RelayCommand(EditReceiveGoodCommand);
            FromDate = DateTime.Now.AddDays(-30);
            ToDate = DateTime.Now;
        }

        #region [private methods]

        private void SearchReceiveGoodsCommand(object commandparameter)
        {
            ReceiveGoods = new ObservableCollection<ReceiveGood>(objReceiveGoodsBL.SearchReceiveGoods(FromDate, ToDate));
        }

        private void EditReceiveGoodCommand(object commandparameter)
        {

        }

        #endregion

    }
}
