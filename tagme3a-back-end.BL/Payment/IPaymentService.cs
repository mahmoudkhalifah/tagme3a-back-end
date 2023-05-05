using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.UserProductInCart;
using tagme3a_back_end.DAL.Data.Models;

namespace tagme3a_back_end.BL.Payment
{
    public interface IPaymentService
    {
        Task<Order> CreateOrUpdatePaymentIntent(string userId);
    }
}
