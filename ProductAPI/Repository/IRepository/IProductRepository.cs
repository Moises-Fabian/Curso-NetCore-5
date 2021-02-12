using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Repository.IRepository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetallProduct();

        Product GetProduct(int id);

        bool ProductoExists(string name);

        bool ProductoExists(int id);

        bool CreateProduct(Product product);

        bool UpdateProduct(Product product);

        bool DeleteProduct(Product product);

        bool Save();
    }
}
