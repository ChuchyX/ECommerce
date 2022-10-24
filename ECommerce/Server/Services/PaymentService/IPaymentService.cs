using ECommerce.Shared;
using Stripe.Checkout;

namespace ECommerce.Server.Services.PaymentService
{
    public interface IPaymentService
    {
        Session CreateCheckoutSession(List<Product> cartItems);
    }
}
