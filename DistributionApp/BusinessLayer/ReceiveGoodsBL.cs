using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DistributionApp.DataLayer;

namespace DistributionApp.BusinessLayer
{
    public class ReceiveGoodsBL
    {
        private InventoryBL objInventoryBL;

        public ReceiveGoodsBL()
        {
            objInventoryBL = new InventoryBL();
        }

        public void SaveReceiveGoods(ReceiveGood _receiveGood)
        {
            using (DistributionDbEntities context = new DistributionDbEntities())
            {
                var receiveGoods = context.ReceiveGoods.FirstOrDefault(x => x.ReceiveGoodId == _receiveGood.ReceiveGoodId);
                if (receiveGoods == null)
                {
                    context.ReceiveGoods.Add(_receiveGood);
                    context.SaveChanges();
                    objInventoryBL.SaveInventoryFromReceiveGoods(_receiveGood);
                }
                else
                {
                    context.Entry(receiveGoods).CurrentValues.SetValues(_receiveGood);
                    context.SaveChanges();
                }
                
            }
        }

        public List<ReceiveGood> SearchReceiveGoods(DateTime? fromDate, DateTime? toDate)
        {
            using (DistributionDbEntities context = new DistributionDbEntities())
            {
                var receiveGoodList = context.ReceiveGoods.Where(x => x.ReceiveDate >= fromDate && x.ReceiveDate <= toDate).ToList();
                receiveGoodList.ForEach(item => { FillReceiveGoodDetails(item); });
                return receiveGoodList;
            }
        }

        public ReceiveGood GetReceiveGoodById (int _receiveGoodId)
        {
            using (DistributionDbEntities context = new DistributionDbEntities())
            {
                return context.ReceiveGoods.FirstOrDefault(x => x.ReceiveGoodId == _receiveGoodId);
            }
        }

        private void FillReceiveGoodDetails(ReceiveGood item)
        {
            using (DistributionDbEntities context = new DistributionDbEntities())
            {
                ProductBL objProductBL = new ProductBL();

                var receiveGoodsDetails = context.ReceiveGoodDetails.Where(x => x.ReceiveGoodId == item.ReceiveGoodId).ToList();
                receiveGoodsDetails.ForEach(detail => { detail.Product = objProductBL.FindProductById(detail.ProductId); });
                item.ShowReceiveGoodDetails = new ObservableCollection<ReceiveGoodDetail>(receiveGoodsDetails.ToList());

            }
        }

    }
}
