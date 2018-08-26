using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributionApp.DataLayer
{
    public partial class ReceiveGood
    {
        public ObservableCollection<ReceiveGoodDetail> ShowReceiveGoodDetails { get; set; }
    }
    
    public partial class ReceiveGoodDetail
    {
        public Product ProductReport { get; set; }
    }

    public partial class Inventory
    {
        public Product ProductReport { get; set; }
    }

}
