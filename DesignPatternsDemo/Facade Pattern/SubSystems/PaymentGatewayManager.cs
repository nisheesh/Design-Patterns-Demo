using System;

namespace DesignPatternsDemo.Facade_Pattern.SubSystems
{
    interface IPaymentGateway
    {
        bool VerifyCardDetails(string cardNo);
        bool ProcessPayment(string cardNo, float cost);
    }


    class PaymentGatewayManager : IPaymentGateway
    {
        public bool VerifyCardDetails(string cardNo)
        {
            Console.WriteLine($"Card # {cardNo} has been verified and is accepted.");
            return true;
        }

        public bool ProcessPayment(string cardNo, float cost)
        {
           Console.WriteLine($"Card # {cardNo} is used to make a payment of Rs{cost}.");
           return true;
        }
    }
}
