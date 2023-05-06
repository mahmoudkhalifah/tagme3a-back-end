using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.DAL.RepoInterfaces
{
    public interface IOrderRepo
    {
        void Insert(Order order);
        IEnumerable<Order> GetAll();

        Order ?GetOrder(int id);

        void Delete(int id);
        void Update(int id, Order updatedOrder);

         Order? GetWithAddressWithCityId(int id);

         Order? GetWithProduct(int id);

        //Product -Address -User
        Order? GetWithMoreDetails(int id);

       IEnumerable<Order> GetordersByUserID(string UserId);

        int GetOrderLastID(string UID);



    }
}
