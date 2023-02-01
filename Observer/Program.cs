using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer // abonelerin ihtiyaç olduğunda devreye girmesi için kullanılır.
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager();
            productManager.Attach(new CustomerObserver());
            productManager.Attach(new EmployeeObserver());
            productManager.UpdatePrice();

            Console.ReadKey();
        }
    }

    class ProductManager
    {
        List<Observer> _observers = new List<Observer>();
        public void UpdatePrice()
        {
            Console.WriteLine("Product Price Updated ..");
            Notify();
        }

        public void Attach(Observer observer) // tuttur.
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer) // kopar.
        {
            _observers.Remove(observer);
        }

        private void Notify() // bilgilendir.
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }

    abstract class Observer 
    {
        public abstract void Update();
    }

    class CustomerObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to Customer, Product Price Updated ..");
        }
    }

    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to Employee, Product Price Updated ..");
        }
    }


}
