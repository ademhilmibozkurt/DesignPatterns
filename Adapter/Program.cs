using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter // farklı sistemlerin kendi sistemlerimize dahil edilmesi ile kullanım sağlar.
{
    class Program
    {
        static void Main(string[] args)
        {
            // ProductManager productManager = new ProductManager(new HbLogger());
            ProductManager productManager = new ProductManager(new AbLoggerAdapter());
            productManager.Save();

            Console.ReadKey();
        }

        class ProductManager
        {
            private ILogger _logger;
            public ProductManager(ILogger logger)
            {
                _logger = logger;
            }
            public void Save()
            {
                _logger.Log("User Data");
                Console.WriteLine("saved..");
            }
        }

        interface ILogger
        {
            void Log(string message);
        }

        class HbLogger : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine($"logged, {message}");
            }
        }

        // Nuget : Başkası yazdı dokunamıyoruz;
        class AbLogger
        {
            public void LogMessage(string message)
            {
                Console.WriteLine($"Logged with AbLogger, {message}");
            }
        }

        class AbLoggerAdapter : ILogger
        {
            public void Log(string message)
            {
                AbLogger abLogger = new AbLogger();
                abLogger.LogMessage(message);
            }
        }

    }
}
