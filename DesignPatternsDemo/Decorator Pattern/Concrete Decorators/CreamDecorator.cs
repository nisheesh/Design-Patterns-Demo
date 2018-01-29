using DesignPatternsDemo.Decorator_Pattern.Component;

namespace DesignPatternsDemo.Decorator_Pattern.Concrete_Decorators
{
    class CreamDecorator : Decorator.Decorator
    {
        public CreamDecorator(IBakeryComponent baseComponent) : base(baseComponent)
        {
            this.m_Name = "Cream";
            this.m_Price = 10.0;
        }


    }

    class NamemDecorator : Decorator.Decorator
    {
        public NamemDecorator(IBakeryComponent baseComponent) : base(baseComponent)
        {
            this.m_Name = "NAme";
            this.m_Price = 500.0;
        }
        
    }
}
