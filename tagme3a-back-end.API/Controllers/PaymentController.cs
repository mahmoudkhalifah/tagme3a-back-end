﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Stripe;
using tagme3a_back_end.BL.Managers;
using Microsoft.AspNetCore.Authorization;

namespace tagme3a_back_end.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IConfiguration config;
        public PaymentController(IConfiguration config)
        {
            this.config = config;
        }
        [Authorize(Constants.Authorize.User)]
        [HttpPost("create-payment-intent")]
        public async Task<IActionResult> CreatePaymentIntent([FromBody] int amount)
        {
            StripeConfiguration.ApiKey = config["StripeSettings:Secretkey"];

            var options = new PaymentIntentCreateOptions
            {
                Amount = amount,
                Currency = "EGP",
                PaymentMethodTypes = new List<string> { "card" },
            };

            var service = new PaymentIntentService();
            PaymentIntent paymentIntent = await service.CreateAsync(options);

            return Ok(new { clientSecret = paymentIntent.ClientSecret });
        }
    }
}
