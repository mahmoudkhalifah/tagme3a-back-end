using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.UserProductInCart;
using tagme3a_back_end.DAL.Data.Models;
using tagme3a_back_end.DAL.RepoInterfaces;

namespace tagme3a_back_end.BL.Managers
{
    public class UserProductInCartManager : IUserProductInCartManager
    {
        private readonly IUserProductInCartRepo userProductInCartRepo;
        public UserProductInCartManager(IUserProductInCartRepo userProductInCartRepo)
        {
            this.userProductInCartRepo = userProductInCartRepo;
        }
        public void AddProductInCart(UserProductInCartInsertDTO userProductInCart)
        {
            var _userProductInCart = new UserProductInCart() {
                ProductId = userProductInCart.ProductId,
                UserId = userProductInCart.UserId,
                Quantity=userProductInCart.Quantity
            };
            userProductInCartRepo.AddProductInCart(_userProductInCart);
        }


        public void AddLstProductInCart(List<UserPCInCartInsertDTO> userPCInCarts , string userId)
        {
            
            var userProductsInCart = userPCInCarts.Select(userProduct => new UserProductInCart
            {
                ProductId = userProduct.ProductId,
                UserId = userId,
                Quantity = userProduct.ProductId
            }).ToList();

            userProductInCartRepo.AddLstProductInCart(userProductsInCart);

        }

        public void DeleteProductInCart(string UserId, int ProductId)
        {
            userProductInCartRepo.DeleteProductInCart(UserId, ProductId);
        }

        public void EditProductInCart(UserProductInCartInsertDTO userProductInCart)
        {
            throw new NotImplementedException();
        }

        public UserProductInCartInsertDTO GetDetails(string UserId, int ProductId)
        {
            var userProductInCart = userProductInCartRepo.GetDetails(UserId, ProductId);
            return new UserProductInCartInsertDTO() {
            ProductId = userProductInCart.ProductId,
            Quantity = userProductInCart.Quantity,
            UserId=userProductInCart.UserId};
        }

        public UserProductsInCartDTO GetUserProductsInCart(string UserId)
        {
            var data = userProductInCartRepo.GetUserProductsInCart(UserId);
            if (data == null)
                return null!;
            var t = new UserProductsInCartDTO()
            {
                UserId = UserId,
                productReadDtos = data.ProductsInCart.Select(p => new DTOs.Product.ProductReadDto
                {
                    Name = p.Product!.Name ,
                    Price = p.Product.Price,
                    BrandID = p.Product.BrandID,
                    Description = p.Product.Description,
                    Discount = p.Product.Discount,
                    Id = p.Product.Id,
                    CategoryID = p.Product.CategoryID,
                    UnitInStocks = p.Product.UnitInStocks,
                    ProductImages = p.Product.ProductImages.Select(pi => Convert.ToBase64String(pi.Photo!)).ToList()
                })
            };
            return t;
        }
    }
}
