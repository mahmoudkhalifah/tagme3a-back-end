using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.DAL.RepoInterfaces
{
    public interface IBrandRepo
    {
        IEnumerable<Brand> GetAll();
        public Brand GetDetails(int id);
        public void Insert(Brand brand);
        public void UpdateBrand(int id, Brand brand);
        public void DeleteBrand(int id);
        public Brand GetWithProductsById(int id);
        int SaveChanges();

    }
}
