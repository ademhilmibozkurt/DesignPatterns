using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton // bir nesneyi bir kere oluşturup ordan kullanmak için bu dizaynı kullanırız.
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateSingleton(); // şeklinde kullanılır.
            customerManager.Save();
            Console.ReadKey();
        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager;
        static object _lockObject = new object(); // thread safe singleton. yani bir nesne yokken iki kere üretilmesin diye.
        private CustomerManager() // ctor oluşturduk.
        {
            // ctoru nesne ye ulaşmak için yazdık.
            // ctoru nesne ye ulaşmak için yazdık.
        }

        public static CustomerManager CreateSingleton() // CusMan döndüren newlenemez bir metot.
        {
            //if (_customerManager == null)
            //{
            //    _customerManager = new CustomerManager();
            //}
            //return _customerManager;
            // return _customerManager ?? (_customerManager = new CustomerManager());
            // şeklinde de yazılabilir.

            lock (_lockObject) // lock kodu bu şekilde yazılır ts yapmayacaksak yukarı kullanılır.
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            } return _customerManager;
        }

        public void Save()
        {
            Console.WriteLine("Saved!!");
        }
    }
}
