using ProductDAL.Data;
using ProductModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDAL.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool CreateProduct(Product product)
        {
			try
			{
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
                return true;
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
