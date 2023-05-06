using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.Product;
using tagme3a_back_end.DAL.Data.Models;
using tagme3a_back_end.DAL.RepoInterfaces;
using tagme3a_back_end.DAL.Repos;

namespace tagme3a_back_end.BL.Managers.SearchManager
{
    public class SearchManager : ISearchManager
    {
        private readonly ISearchRepo _searchRepo;

        public SearchManager(ISearchRepo searchRepo)
        {
            _searchRepo = searchRepo;
        }
        public IEnumerable<ProductReadDto> GetAllProduct(string productName)
        {
            var products = _searchRepo.SearchByName(productName);
            return products.Select(p => new ProductReadDto
            {
                Id = p.Id,
                Name = p.Name,
                CategoryID = p.CategoryID,
                Description = p.Description,
                Discount = p.Discount,
                Price = p.Price,
                BrandID = p.BrandID,
                ProductImages = p.ProductImages.Select(pi => Convert.ToBase64String(pi.Photo)).ToList(),
                UnitInStocks = p.UnitInStocks
            });
        }
    }
}
