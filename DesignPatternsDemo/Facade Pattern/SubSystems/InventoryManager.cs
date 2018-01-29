using System;

namespace DesignPatternsDemo.Facade_Pattern.SubSystems
{
    interface IInventory
    {
        void Update(int productId);
    }

    class InventoryManager : IInventory
    {
        public void Update(int productId)
        {
            Console.WriteLine($"Product #{productId} is subtracted from the store's inventory.");
        }
    }
}
