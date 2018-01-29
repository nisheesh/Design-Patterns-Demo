using System;

namespace DesignPatternsDemo.Facade_Pattern.SubSystems
{
    interface ILogistics
    {
        void ShipProduct(string productName, string shippingAddress);
    }

    class LogisticsManager : ILogistics
    {
        public void ShipProduct(string productName, string shippingAddress)
        {
            Console.WriteLine($"Congratulations your product \"{productName}\" has been shipped at the following address: ");
            Console.WriteLine(shippingAddress);
        }
    }
}
