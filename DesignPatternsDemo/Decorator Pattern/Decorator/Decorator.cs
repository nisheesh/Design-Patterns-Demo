using DesignPatternsDemo.Decorator_Pattern.Component;

namespace DesignPatternsDemo.Decorator_Pattern.Decorator
{
    abstract class Decorator : IBakeryComponent
    {
        protected IBakeryComponent m_BaseComponent = null;

        protected string m_Name = "Undefined Decorator";
        protected double m_Price = 0.0;

        protected Decorator(IBakeryComponent baseComponent)
        {
            m_BaseComponent = baseComponent;
        }

        #region BakeryComponent Members

        string IBakeryComponent.GetName()
        {
            return $"{m_BaseComponent.GetName()}, {m_Name}";
        }

        double IBakeryComponent.GetPrice()
        {
            return m_Price + m_BaseComponent.GetPrice();
        }
        #endregion
    }
}
