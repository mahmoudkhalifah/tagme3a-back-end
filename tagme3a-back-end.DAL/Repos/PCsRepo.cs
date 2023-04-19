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
    public class PCsRepo : IPCsRepo
    {
        private readonly MainDbContext _context;

        public PCsRepo(MainDbContext context)
        {
            this._context = context;
        }
        public bool DeletePC(int id)
        {
            try
            {
                var pc = GetDetails(id);
                
                if (pc == null)
                { return false; }

                _context.PCs.Remove(pc);
                SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public IEnumerable<PC> GetAll()
        {
            return _context.PCs.Include(p=>p.ProductsPC).ThenInclude(p=>p.Product)
                .ThenInclude(m=>m.ProductImages).ToList();
        }

        public PC? GetDetails(int id)
        {
            return _context.PCs.Include(p => p.ProductsPC).ThenInclude(prd => prd.Product)
              .ThenInclude(c => c.Category).ThenInclude(p => p.Products).ThenInclude(b => b.Brand)
              .ThenInclude(i =>i.Products).ThenInclude(i=>i.ProductImages).FirstOrDefault(c => c.PCId == id);
            
        }

        public bool InsertPC(PC pc)
        {
            try
            {
                _context.PCs.Add(pc);
                SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool InsertPrdPC(ProductPC pc)
        {
            try
            {
                _context.ProductPCs.Add(pc);
                SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public bool UpdatePC(int id, PC pc)
        {
            var Pc  = _context.PCs.Find(id);
            if (Pc == null)
                return false;
            try
            {

                Pc.BundleName = pc.BundleName;
                Pc.Image = pc.Image;
                Pc.TotalPrice = pc.TotalPrice;
                Pc.ProductsPC = pc.ProductsPC;

                SaveChanges();
                return true;
            }
            catch { return false; }

            
        }

        public bool UpdatePrdPC(int id  , ProductPC pc)
        {
            var prd = _context.ProductPCs.Find(id);
            
            if(prd == null)
                return false;

            try
            {
                prd.ProductId = pc.ProductId;
                prd.PCId = pc.PCId;
                prd.Quantity = pc.Quantity;
                SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
