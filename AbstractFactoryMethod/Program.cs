using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryMethod // FactoryMethod gibidir ama bu nesne soyut.
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new MFactory());
            productManager.GetAll();

            Console.ReadKey();
        }
    }

    // burda logging ve caching yöntemlerdir. Memcache ve TrinityLogger birer yöntemdir.
    // şimdi bu yöntemleri oluşrutan fabrikaya ihtiyacımız var.
    public abstract class Logging
    {
        public abstract void Log(string maessage);
    }

    public class Log4NetLogger : Logging
    {
        public override void Log(string maessage)
        {
            Console.WriteLine("Logged with Log4Net! ");
        }
    }

    public class TrinityLogger : Logging
    {
        public override void Log(string maessage)
        {
            Console.WriteLine("Logged with TrinityLogger! ");
        }
    }

    public abstract class Caching
    {
        public abstract void Cache(string data);
    }

    public class MemCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with MemCache! ");
        }
    }

    public class ComCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with ComCache! ");
        }
    }

    public abstract class CrossCuttingConcernsFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCacher();
    }

    public class MFactory : CrossCuttingConcernsFactory // iki abstractfactory oluşturduk ve isteğe göre çaprazladık.
    {
        public override Caching CreateCacher()
        {
            return new ComCache();
        }

        public override Logging CreateLogger()
        {
            return new TrinityLogger();
        }
    }

    public class NetFactory : CrossCuttingConcernsFactory
    {
        public override Caching CreateCacher()
        {
            return new ComCache();
        }

        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }
    }

    public class ProductManager
    {
        private CrossCuttingConcernsFactory _cFactory; // dep inj yaptık ve metot gibi kullandık.
        private Logging _logging;
        private Caching _caching;

        public ProductManager(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
        {
            _cFactory = crossCuttingConcernsFactory;
            _logging = _cFactory.CreateLogger();
            _caching = _cFactory.CreateCacher();
        }
        public void GetAll()
        {
            _logging.Log("Logged!");
            _caching.Cache("Cached!");
            Console.WriteLine("Products Listed!");
        }
    }
}
