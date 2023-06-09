﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.OrderDTO;
using tagme3a_back_end.BL.DTOs.UserProductInCart;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.BL.Managers
{
    public interface IUserProductInCartManager
    {
        public void AddProductInCart(UserProductInCartInsertDTO userProductInCart);
        public void AddLstProductInCart(List<UserPCInCartInsertDTO> userPCInCarts, string userId);

        public void DeleteProductInCart(string UserId, int ProductId);

        public void DeleteCarts(string UID);

        public void EditProductInCart(UserProductInCartInsertDTO userProductInCart);
        public UserProductInCartInsertDTO GetDetails(string UserId, int ProductId);
        public UserProductsInCartDTO GetUserProductsInCart(string UserId);

        public List<UserCartPrdName> GetUserCartPrdName(string UserId);

        public void UpdateCard(int PID, String UID, UserProductInCartInsertDTO UserProductInCartInsertDTO);

    }
}
