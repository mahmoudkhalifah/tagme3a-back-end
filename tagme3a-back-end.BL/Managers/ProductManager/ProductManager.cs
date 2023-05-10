using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.Product;
using tagme3a_back_end.DAL.Data.Models;
using tagme3a_back_end.DAL.RepoInterfaces;
using tagme3a_back_end.DAL.Repos;

namespace tagme3a_back_end.BL.Managers.ProductManager
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepo _productRepo;

        public ProductManager(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public void AddProduct(ProductPostDto product)
        {
            Product prd = new Product()
            {
               //Id = product.Id,
               Name = product.Name,
               CategoryID = (int)product.CategoryID!,
               BrandID  = product.BrandID,
               Description = product.Description,
               Discount = product.Discount,
               Price = product.Price,
               UnitInStocks = product.UnitInStocks
            };
            if (product.ProductImages != null && product.ProductImages.Any())
            {
                foreach (var images in product.ProductImages)
                {
                    byte[] photo = Convert.FromBase64String(images);
                    var image = new ProductImage { Photo = photo };
                    prd.ProductImages.Add(image);
                }
            }
            _productRepo.AddProduct(prd);
        }

        public void DeleteProduct(int id)
        {
           _productRepo.DeleteProduct(id);
        }
        
        public IEnumerable<ProductReadDto> GetAllProduct()
        {
            var prds = _productRepo.GetAllProducts();
            return prds.Where(p=>p.UnitInStocks>0).Select(p => new ProductReadDto
            {
                Id = p.Id,
                Name = p.Name,
                CategoryID = p.CategoryID,//
                Description = p.Description,
                Discount = p.Discount,
                Price = p.Price,
                BrandID = p.BrandID,//
                ProductImages = p.ProductImages.Select(pi => Convert.ToBase64String(pi.Photo)).ToList(),
                UnitInStocks = p.UnitInStocks
            });
        }

        public ProductWithRelationsDTO GetProductWithPcOrderById(int id)
        {
            Product product = _productRepo.GetProductWithPcOrderById(id);
            if (product is null)
                return null;
            return new ProductWithRelationsDTO()
            {
                Id = product.Id,
                NumOrders = product.ProductOrders.Count(),
                NumPCs = product.ProductPCs.Count(),
            };
        }

        public IEnumerable<ProductReadDto> GetAllProduct(int brandId, int categoryId)
        {
            var prds = _productRepo.GetAllProducts();
            return prds.Where(p => p.CategoryID == categoryId && p.BrandID == brandId && p.UnitInStocks>0)
                .Select(p => new ProductReadDto
             {
                Id = p.Id,
                Name = p.Name,
                CategoryID = p.CategoryID,//
                Description = p.Description,
                Discount = p.Discount,
                Price = p.Price,
                BrandID = p.BrandID,//
                ProductImages = p.ProductImages.Select(pi => Convert.ToBase64String(pi.Photo)).ToList(),
                UnitInStocks = p.UnitInStocks
            });
        }

        public IEnumerable<ProductReadDto> GetAllProductAdmin()
        {
            var prds = _productRepo.GetAllProducts();
            return prds.Select(p => new ProductReadDto
            {
                Id = p.Id,
                Name = p.Name,
                CategoryID = p.CategoryID,//
                Description = p.Description,
                Discount = p.Discount,
                Price = p.Price,
                BrandID = p.BrandID,//
                ProductImages = p.ProductImages.Select(pi => Convert.ToBase64String(pi.Photo)).ToList(),
                UnitInStocks = p.UnitInStocks
            });
        }

        public ProductReadDto getProductbyId(int id)
        {
            var prd = _productRepo.GetProductById(id);

            if (prd != null)
            {
               var prdId =   new ProductReadDto
                {
                    Id = prd.Id,
                    Name = prd.Name,
                    CategoryID = prd.CategoryID,//
                    Description = prd.Description,
                    Discount = prd.Discount,
                    BrandID = prd.BrandID,//
                    Price = prd.Price,
                    UnitInStocks = prd.UnitInStocks,
                    ProductImages = prd.ProductImages
                    .Select(img => Convert.ToBase64String(img.Photo!))
                    .ToList()
                };
                return prdId;
            }
            else
            {
                return null;
            }
        
        }

        public void UpdateProduct(ProductPutDto product , int id)
        {
            var prd = _productRepo.GetProductById(id);
            if (prd != null)
            {
                prd.Name = product.Name;
                prd.CategoryID = (int)product.CategoryID!;
                prd.Description = product.Description;
                prd.Discount = product.Discount;
                prd.Price = product.Price;
                prd.UnitInStocks = product.UnitInStocks;
                prd.BrandID = product.BrandID;

                //prd.ProductImages = product.
                if (product.ProductImages != null && product.ProductImages.Any())
                {
                    var counter = 0;
                    foreach (var images in product.ProductImages)
                    {
                        byte[] data = Convert.FromBase64String(images);
                        var image = new ProductImage { Photo = data };
                        prd.ProductImages.ElementAt(counter).Photo = data;
                        counter++;
                    }
                }

            }
            _productRepo.UpdateProduct(prd!, id);
        }


    }
}
