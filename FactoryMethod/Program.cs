using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod // bunun amacı bir fabrika oluşturup çeşitli nesneleri gruplayarak çalıştırmamızı sağlar.
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactoryM());
            customerManager.Save(); 

            Console.ReadKey();
        }
    }

    public class LoggerFactory : ILoggerFactory // inherit ettik.
    {
        public ILogger CreateLogger() // asıl iş kısmı burasıdır. logger ihtiyaca göre kullanılır.
        {
            return new HbLogger();
        }
    }

    public class LoggerFactoryM : ILoggerFactory // ikinci fabrika
    {
        
        public ILogger CreateLogger()
        {
            return new HbLogger();
        }
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger(); // her iki fabrika için implemente edilmesi için CreateLogger() buraya eklenir.
    }

    public interface ILogger // bu interface ile bağımlılıktan kurtulduk.
    {
        void Log();
    }

    public class HbLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with HbLogger!");
        }
    }

    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public void Save()
        {
            Console.WriteLine("Saved!!");
            ILogger logger = new LoggerFactory().CreateLogger();
            logger.Log();
        }
    }
}
