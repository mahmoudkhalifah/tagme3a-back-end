using Microsoft.EntityFrameworkCore;
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
    public class BrandRepo : IBrandRepo
    {
        private readonly MainDbContext context;
        public BrandRepo(MainDbContext context) 
        {
            this.context = context;
        }  
        public void DeleteBrand(int id)
        {
           context.Brands.Remove(GetDetails(id));
           context.SaveChanges();
        }

        public IEnumerable<Brand> GetAll()
        {
            return context.Set<Brand>();
        }

        public Brand GetDetails(int id)
        {
            return context.Brands.Find(id)!;
        }

        public void Insert(Brand brand)
        {
            context.Brands.Add(brand);
            context.SaveChanges();
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public void UpdateBrand(int id, Brand brand)
        {
            context.Entry(brand).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
