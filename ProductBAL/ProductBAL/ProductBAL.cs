using ProductDAL.ProductRepository;
using ProductModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBAL.ProductBAL
{
    public class ProductBAL : IProductBAL
    {
        private readonly IProductRepository repository;

        public ProductBAL(IProductRepository repository)
        {
            this.repository = repository;
        }
        public bool CreateProduct(Product product)
        {
            try
            {
                return repository.CreateProduct(product);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
