using ProductModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductDAL.ProductRepository
{
    public interface IProductRepository
    {
        bool CreateProduct(Product product);
    }
}
