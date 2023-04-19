using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.DAL.RepoInterfaces
{
    public interface ICategoryRepo
    {
        IEnumerable<Category> GetAll();
        public Category GetDetails(int id);
        public void Insert(Category category);
        public void UpdateCategory(int id, Category category);
        public void DeleteCategory(int id);
        public Category GetWithProductsById(int id);
        int SaveChanges();
    }
}
