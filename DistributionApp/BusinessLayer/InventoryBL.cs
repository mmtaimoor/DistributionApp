using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DistributionApp.DataLayer;


namespace DistributionApp.BusinessLayer
{
    public class InventoryBL
    {
        private ProductBL objProductBL;


        public InventoryBL()
        {
            objProductBL = new ProductBL();
        }

        public List<Inventory> GetInventory()
        {
            using (DistributionDbEntities context = new DistributionDbEntities())
            {
                var inventory = context.Inventories.Where(x => x.Qty > 0).ToList();
                inventory.ForEach(item => item.ProductReport = objProductBL.FindProductById(item.ProductId));
                return inventory;
            }
        }

        public void SaveInventoryFromReceiveGoods(ReceiveGood _receive)
        {
            List<Inventory> inventoryList = new List<Inventory>();
            _receive?.ReceiveGoodDetails.ToList().ForEach(item =>
            {
                inventoryList.Add(new Inventory
                {
                    ProductId = item.ProductId,
                    Qty = item.Quantity,
                    BatchNumber = item.BatchNumber,
                    ExpiryDate = item.ExpiryDate
                });
            });
            SaveInventory(inventoryList);
        }

        public void SaveInventory (List<Inventory> _inventoryList)
        {
            using (DistributionDbEntities context = new DistributionDbEntities())
            {
                context.Inventories.AddRange(_inventoryList);
                context.SaveChanges();
            }
        }

        public void SaveInventory(Inventory _inventory)
        {
            using (DistributionDbEntities context = new DistributionDbEntities())
            {
                context.Inventories.Add(_inventory);
                context.SaveChanges();
            }
        }

    }
}
