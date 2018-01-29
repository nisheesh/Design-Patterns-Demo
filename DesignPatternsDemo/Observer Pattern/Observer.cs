using System;

namespace DesignPatternsDemo.Observer_Pattern
{
    public class Observer : IObserver
    {
        public string ObserverName { get; private set; }

        public Observer(string name)
        {
            this.ObserverName = name;
        }
        public void Update()
        {
            Console.WriteLine($"Hello {this.ObserverName}: A new product has arrived at the store.");
        }
    }

    interface IObserver
    {
        void Update();
    }
}
