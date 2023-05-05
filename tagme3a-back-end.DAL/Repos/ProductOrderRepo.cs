using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.Data.Context;
using tagme3a_back_end.DAL.Data.Models;
using tagme3a_back_end.DAL.RepoInterfaces;

namespace tagme3a_back_end.DAL.Repos
{
    public class ProductOrderRepo : IProductOrderRepo
    {
        private readonly MainDbContext mainDbContext1;
        public ProductOrderRepo(MainDbContext mainDbContext) 
        {
            this.mainDbContext1 = mainDbContext;
        }   
        public void AddProductOrder(List<ProductOrder> prdOrders)
        {
           this.mainDbContext1.ProductOrders.AddRange(prdOrders);
            mainDbContext1.SaveChanges();
        }

        public void DeleteProductOrder(int ProductId, int OrderId)
        {
            throw new NotImplementedException();
        }

        public void EditProductOrder(ProductOrder productOrder)
        {
            throw new NotImplementedException();
        }

        public ProductOrder GetDetails(int ProductId, int OrderId)
        {
            throw new NotImplementedException();
        }

        public User GetProductOrder(string UserId)
        {
            throw new NotImplementedException();
        }
    }
}
