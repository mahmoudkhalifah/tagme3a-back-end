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
    public class UserProductInCartRepo : IUserProductInCartRepo
    {
        private readonly MainDbContext context;
        public UserProductInCartRepo(MainDbContext context ) 
        {
            this.context = context;
        }
        public void AddProductInCart(UserProductInCart userProductInCart)
        {
            context.UserProductInCarts.Add( userProductInCart );
            context.SaveChanges();
        }

        public void AddLstProductInCart(List<UserProductInCart> userProductInCart)
        {
            context.UserProductInCarts.AddRange(userProductInCart);
            context.SaveChanges();
        }

        public void DeleteProductInCart(string UserId, int ProductId)
        {
            var userProductInCart = context.UserProductInCarts.Find(UserId, ProductId);
            context.UserProductInCarts.Remove(userProductInCart!);
            context.SaveChanges();
        }
        public void EditProductInCart(UserProductInCart userProductInCart)
        {
            context.Entry(userProductInCart).State = EntityState.Modified;
            context.SaveChanges();
        }

        public UserProductInCart GetDetails(string UserId, int ProductId)
        {
            return context.UserProductInCarts.Find(UserId, ProductId)!;
        }

        public User GetUserProductsInCart(string UserId)
        {
            return context.Set<User>()
                     .Include(d => d.ProductsInCart)
                     .ThenInclude(d=>d.Product)
                     .FirstOrDefault(d => d.Id == UserId)!;
        }
    }
}
