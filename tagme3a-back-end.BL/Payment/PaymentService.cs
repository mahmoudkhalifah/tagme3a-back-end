using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tagme3a_back_end.BL.DTOs.OrderDTO;
using tagme3a_back_end.BL.DTOs.UserProductInCart;
using tagme3a_back_end.BL.Managers;
using tagme3a_back_end.BL.Managers.PCManager;
using tagme3a_back_end.DAL.Data.Models;
using tagme3a_back_end.DAL.RepoInterfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace tagme3a_back_end.BL.Payment
{
    public class PaymentService 
    {
        private readonly IUserProductInCartManager _userProductInCartManager;
        private readonly IConfiguration config;
        public PaymentService(IUserProductInCartManager userProductInCartManager, IConfiguration config)
        {
            _userProductInCartManager = userProductInCartManager;
            this.config = config;
        }

        //public async Task<Order> CreateOrUpdatePaymentIntent(string userId)
        //{
        //    var totalPrice = 0;
        //    var order = new OrderPostDTO();
        //    StripeConfiguration.ApiKey = config["StripeSettings:Secretkey"];
        //    var cart = this._userProductInCartManager.GetUserProductsInCart(userId);
        //    foreach(var product in cart.productReadDtos)
        //    {
        //        var detailswithQuantity = _userProductInCartManager.GetDetails(userId, product.Id);
        //        totalPrice = totalPrice + (int)(detailswithQuantity.Quantity * product.Price);
        //    }
        //    var service = new PaymentIntentService();
        //    PaymentIntent intent;
        //    var options = new PaymentIntentCreateOptions
        //    {
        //        Amount = totalPrice,
        //        Currency = "usd",
        //        PaymentMethodTypes = new List<string> { "card" }
        //    };
        //    intent = await service.CreateAsync(options);
        //    // throw new NotImplementedException();
        //}
    }
}
