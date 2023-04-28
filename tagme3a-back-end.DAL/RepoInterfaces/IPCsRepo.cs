using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.DAL.RepoInterfaces
{
    public interface IPCsRepo
    {
        IEnumerable<PC> GetAll();
        public PC? GetDetails(int id);
        public bool InsertPC(PC pc);
        public bool InsertPrdPC(ProductPC pc);
        public bool UpdatePrdPC(int id , ProductPC pc);

        public bool UpdatePC(int id, PC pc);
        public bool DeletePC(int id);

        public IEnumerable<ProductPC> getAllPrdPc();

		public bool DeletePrdPC(int id, ProductPC Prdpc);

		int SaveChanges();

    }
}
