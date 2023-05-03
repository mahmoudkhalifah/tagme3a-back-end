using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.DAL.RepoInterfaces
{
    public interface IUserProductInCartRepo
    {
        public void AddProductInCart(UserProductInCart userProductInCart);
        public void DeleteProductInCart(string UserId, int ProductId);
        public void AddLstProductInCart(List<UserProductInCart> userProductInCart);

        public void EditProductInCart(UserProductInCart userProductInCart);
        public UserProductInCart GetDetails(string UserId, int ProductId);
        public User GetUserProductsInCart(string UserId);
        public void EditProductInCartbyUIDPID(UserProductInCart userProductInCart, string UID, int PID);

    }
}
