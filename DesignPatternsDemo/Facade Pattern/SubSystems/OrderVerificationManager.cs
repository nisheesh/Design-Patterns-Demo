using System;

namespace DesignPatternsDemo.Facade_Pattern.SubSystems
{
    interface IOrderVerify
    {
        bool VerifyShippingAddress(int pincode);
    }

    class OrderVerificationManager : IOrderVerify
    {

        public bool VerifyShippingAddress(int pincode)
        {
            Console.WriteLine($"The product can be shipped to the pincode - {pincode}.");
            return true;
        }
    }
}
