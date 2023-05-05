using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.DAL.RepoInterfaces
{
    public interface IProductOrderRepo
    {
        public void AddProductOrder(List<ProductOrder>prdOrders);
        public void DeleteProductOrder(int ProductId, int OrderId);
        public void EditProductOrder(ProductOrder productOrder);
        public ProductOrder GetDetails(int ProductId, int OrderId);
        public User GetProductOrder(string UserId);
    }
}
