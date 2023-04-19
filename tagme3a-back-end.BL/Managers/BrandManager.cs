using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.Brand;
using tagme3a_back_end.BL.DTOs.Category;
using tagme3a_back_end.BL.DTOs.Product;
using tagme3a_back_end.DAL.Data.Models;
using tagme3a_back_end.DAL.RepoInterfaces;
using tagme3a_back_end.DAL.Repos;

namespace tagme3a_back_end.BL.Managers
{
    public class BrandManager : IBrandManager
    {
        private readonly IBrandRepo brandRepo;
        public BrandManager (IBrandRepo brandRepo)
        {
            this.brandRepo = brandRepo;
        }
        public void DeleteBrand(int id)
        {
            this.brandRepo.DeleteBrand(id);
        }

        public IEnumerable<BrandDTO> GetAll()
        {
            return brandRepo.GetAll().Select(b=>new BrandDTO(
                Id:b.BrandId,
                Name:b.Name,
                Description:b.Description,
                Logo:b.Logo
                ));
        }

        public BrandWithProductsDTO GetBrandWithProducts(int id)
        {
            Brand brandFromDb = brandRepo.GetWithProductsById(id);
            if (brandFromDb == null) { return null!; }
            return new BrandWithProductsDTO
            {
                BrandId = brandFromDb.BrandId,
                Name = brandFromDb.Name,
                Description = brandFromDb.Description,
                Logo = brandFromDb.Logo,
                products = brandFromDb.Products.Select(
                    p => new ProductBrandCategoryDTO
                    {
                        Id = p.Id,
                        Description = p.Description,
                        Discount = p.Discount,
                        Name = p.Name,
                        Price = p.Price,
                        UnitInStocks = p.UnitInStocks,
                        ProductImages = p.ProductImages.Select(pi => Convert.ToBase64String(pi.Photo!)).ToList()
                    })
            };
        }

        public BrandDTO GetDetails(int id)
        {
            var brand = brandRepo.GetDetails(id);
            if (brand == null)
                return null!;
            return new BrandDTO
                (
                 brand.BrandId, brand.Name, brand.Description, brand.Logo!
                );
        }

        public void Insert(BrandInsertDTO dto)
        {
            byte[] imageBytes = Convert.FromBase64String(dto.Logo);
            Brand brand = new Brand()
            {
                Name = dto.Name,
                Description = dto.Description,
                Logo = imageBytes,
            };
            brandRepo.Insert(brand);
        }

        public void UpdateBrand(int id, BrandInsertDTO dto)
        {
            var brand = brandRepo.GetDetails(id);
            byte[] imageBytes = Convert.FromBase64String(dto.Logo);
            if (brand != null)
            {
                brand.Name = dto.Name;
                brand.Description = dto.Description;
                brand.Logo = imageBytes;
            }
            brandRepo.UpdateBrand(id, brand!);
        }
    }
}
