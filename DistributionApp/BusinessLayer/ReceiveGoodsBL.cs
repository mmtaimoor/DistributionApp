using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DistributionApp.DataLayer;

namespace DistributionApp.BusinessLayer
{
    public class ReceiveGoodsBL
    {
        public ReceiveGoodsBL()
        {

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
                }
                else
                {
                    context.Entry(receiveGoods).CurrentValues.SetValues(_receiveGood);
                    context.SaveChanges();
                }
                
            }
        }
    }
}
