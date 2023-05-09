using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.DAL.RepoInterfaces
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetAllProducts();
        public Product GetProductById(int id);
        public Product GetProductWithPcOrderById(int id);
        public void AddProduct(Product product);

        public void UpdateProduct(Product product , int id);

        public void DeleteProduct(int id);

        int saveChanges();
    }
}
