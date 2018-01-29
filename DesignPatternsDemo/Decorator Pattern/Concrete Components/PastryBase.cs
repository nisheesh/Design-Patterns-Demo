using DesignPatternsDemo.Decorator_Pattern.Component;

namespace DesignPatternsDemo.Decorator_Pattern.Concrete_Components
{
    class PastryBase : IBakeryComponent
    {
        // In real world these values will typically come from some data store
        private string m_Name = "Pastry Base";
        private double m_Price = 20.0;

        public string GetName()
        {
            return m_Name;
        }

        public double GetPrice()
        {
            return m_Price;
        }
    }
}
