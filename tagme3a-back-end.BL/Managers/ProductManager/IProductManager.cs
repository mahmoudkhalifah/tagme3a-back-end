using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.Product;

namespace tagme3a_back_end.BL.Managers.ProductManager
{
    public interface IProductManager
    {
         IEnumerable<ProductReadDto> GetAllProduct(int brandId,int categoryId);
        IEnumerable<ProductReadDto> GetAllProduct();

        public void AddProduct (ProductPostDto product);



        public void UpdateProduct (ProductPutDto product , int id);
        public ProductReadDto  getProductbyId(int id);
        public void DeleteProduct(int id);


    }
}
