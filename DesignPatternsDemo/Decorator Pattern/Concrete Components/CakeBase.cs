using DesignPatternsDemo.Decorator_Pattern.Component;

namespace DesignPatternsDemo.Decorator_Pattern.Concrete_Components
{
    class CakeBase : IBakeryComponent
    {
        private string m_Name = "Cake Base";
        private double m_Price = 300.0;

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
