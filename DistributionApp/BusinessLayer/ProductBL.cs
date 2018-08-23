using DistributionApp.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributionApp.BusinessLayer
{
    public class ProductBL
    {
        public ProductBL()
        {

        }

        public List<Product> GetProductList()
        {
            using (DistributionDbEntities context = new DistributionDbEntities())
            {
                return context.Products.ToList();
            }
        }

        public void SaveProduct(Product _product)
        {
            using (DistributionDbEntities context = new DistributionDbEntities())
            {
                var product = context.Products.FirstOrDefault(x => x.ProductId == _product.ProductId);
                if (product == null)
                {
                    context.Products.Add(_product);
                    context.SaveChanges();
                }
                else
                {
                    context.Entry(product).CurrentValues.SetValues(_product);
                    context.SaveChanges();
                }
            }
        }

        public Product FindProductById(int productId)
        {
            using (DistributionDbEntities context = new DistributionDbEntities())
            {
                return context.Products.FirstOrDefault(x => x.ProductId == productId);
            }
        }

    }
}
