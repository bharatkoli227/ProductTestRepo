using ProductModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBAL.ProductBAL
{
    public interface IProductBAL
    {
        bool CreateProduct(Product product);
    }
}
