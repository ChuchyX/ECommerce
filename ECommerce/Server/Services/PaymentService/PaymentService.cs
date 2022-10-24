using ECommerce.Shared;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using Product = ECommerce.Shared.Product;

namespace ECommerce.Server.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        public PaymentService()
        {
            StripeConfiguration.ApiKey = "sk_test_51Ln49QDvumlYvyL6nQdG3PodM0yeY8AfewYP0sZN6jQiDOQ3ww0OlXmoYLLleH8eUxtRsst2tvX5PZTiRqV8uCQd00mxhzpGV7";
        }
        public Session CreateCheckoutSession(List<Product> cartItems)
        {
            var lineItems = new List<SessionLineItemOptions>();
            cartItems.ForEach(ci => lineItems.Add(new SessionLineItemOptions { 
                PriceData = new SessionLineItemPriceDataOptions {
                    UnitAmountDecimal = ci.Price * 100,
                    Currency = "usd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = ci.Title,
                        Images = new List<string> { ci.Image }                       
                    }
                },
                Quantity = ci.Quantity
            }));
            var options = new SessionCreateOptions
            {
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = "https://localhost:7017/order-success",
                CancelUrl = "https://localhost:7017/cart",
            };

            var service = new SessionService();
            Session session = service.Create(options);

            return session;

        }
    }
}
