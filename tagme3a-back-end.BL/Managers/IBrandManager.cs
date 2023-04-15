using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.Brand;

namespace tagme3a_back_end.BL.Managers
{
    public interface IBrandManager
    {
        IEnumerable<BrandDTO> GetAll();
        //IEnumerable<BrandWithProductsDTO> Get(int id);
        public BrandDTO GetDetails(int id);
        public void Insert(BrandInsertDTO brand);
        public void UpdateBrand(int id, BrandInsertDTO brand);
        public void DeleteBrand(int id);
    }
}
