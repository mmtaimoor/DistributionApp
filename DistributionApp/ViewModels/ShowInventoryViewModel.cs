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
    public class ShowInventoryViewModel : BaseViewModel
    {
        #region [private variables]

        private ObservableCollection<Inventory> _inventoryList;
        private InventoryBL objInventoryBL;

        #endregion

        #region [public variables]

        public ObservableCollection<Inventory> InventoryList
        {
            get { return _inventoryList; }
            set
            {
                _inventoryList = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public ShowInventoryViewModel()
        {
            objInventoryBL = new InventoryBL();
            InventoryList = new ObservableCollection<Inventory>(objInventoryBL.GetInventory());
        }


    }
}
