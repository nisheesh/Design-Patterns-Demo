using DesignPatternsDemo.Decorator_Pattern.Component;

namespace DesignPatternsDemo.Decorator_Pattern.Concrete_Decorators
{
    class CherryDecorator : Decorator.Decorator
    {
        public CherryDecorator(IBakeryComponent baseComponent) : base(baseComponent)
        {
            this.m_Name = "Cherry";
            this.m_Price = 5.0;
        }
    }
}
