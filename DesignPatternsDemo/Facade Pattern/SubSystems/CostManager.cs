using System;

namespace DesignPatternsDemo.Facade_Pattern.SubSystems
{
    interface ICosting
    {
        float ApplyDiscounts(float price, float discountPercent);
    }


    class CostManager : ICosting
    {

        public float ApplyDiscounts(float price, float discountPercent)
        {
           Console.WriteLine($"A discount of {discountPercent}% has been applied on the product's price of Rs{price}");            
           return price - ((discountPercent / 100) * price);
        }
    }
}
