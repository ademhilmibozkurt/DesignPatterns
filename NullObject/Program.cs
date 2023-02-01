using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject // hiçbirşey yapmayan işsiz bir nesne oluşturacağız :).
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager manager = new CustomerManager(NullLogger.GetLogger());
            manager.Save();

            Console.ReadKey();
        }
    }

    class CustomerManager
    {
        private ILogger _logger;
        public CustomerManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            Console.WriteLine("Saved .."); _logger.Log();
        }
    }

    interface ILogger
    {
        void Log();
    }

    class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Log4Net ..");
        }
    }

    class NLogLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with NLog ..");
        }
    }

    class NullLogger : ILogger
    {
        private static NullLogger _nullLogger;
        private static object _lock = new object();

        private NullLogger()
        {
        }

        public static NullLogger GetLogger()
        {
            lock (_lock)
            {
                if (_nullLogger == null)
                {
                    _nullLogger = new NullLogger();
                }
            } return _nullLogger;
        } // singleton deseni
        public void Log()
        {
        }
    }

    class CustomerManagerTester
    {
        public void Test()
        {
            CustomerManager manager = new CustomerManager(NullLogger.GetLogger());
            manager.Save();
        }
    }


}
