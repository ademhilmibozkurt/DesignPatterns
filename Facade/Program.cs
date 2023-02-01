using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade // dış görünüm anlamındadır. factory gibi bazı sınıfları biraraya toplayıp kullanmayı amaçlar.
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();

            Console.ReadKey();
        }
    }

    class Logging : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged..");
        }
    }

    internal interface ILogger
    {
        void Log();
    }

    class Caching : ICacher
    {
        public void Cache()
        {
            Console.WriteLine("Cached..");
        }
    }

    internal interface ICacher
    {
        void Cache();
    }

    class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User cheched..");
        }
    }

    internal interface IAuthorize
    {
        void CheckUser();
    }

    class CustomerManager
    {
        private CroosCuttingConcernsFacade _concerns;
        public CustomerManager()
        {
            _concerns = new CroosCuttingConcernsFacade();
        }

        public void Save()
        {
            _concerns.Cacher.Cache();
            _concerns.Logger.Log();
            _concerns.Authorize.CheckUser();
            Console.WriteLine("Saved..");
        }
    }

    class CroosCuttingConcernsFacade
    {
        public ILogger Logger;
        public ICacher Cacher;
        public IAuthorize Authorize;

        public CroosCuttingConcernsFacade()
        {
            Logger = new Logging();
            Cacher = new Caching();
            Authorize = new Authorize();
        }
    }
    
}
