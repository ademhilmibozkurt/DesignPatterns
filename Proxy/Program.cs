using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proxy // bir sınıftan bir metodu ikinci çağırışımızda tekrar hızlı erişim için kullanılır.
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreditBase manager = new CreditManagerProxy();
            CreditManagerProxy proxy = new CreditManagerProxy();
            Console.WriteLine(proxy.Calculate());
            Console.WriteLine(proxy.Calculate()); 

            Console.ReadKey();
        }
    }

    abstract class CreditBase
    {
        public abstract int Calculate();
    }

    class CreditManager : CreditBase
    {
        public override int Calculate()
        {
            int result = 1;
            for (int i = 1; i < 5; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }

            return result;
        }
    }

    class CreditManagerProxy : CreditBase // bunu yaparak ilkindeki 5 saniye beklemeyi ikincide 0 a indirdik.
    {
        private CreditManager _manager;
        private int _cachedValue;
        public override int Calculate()
        {
            if (_manager == null)
            {
                _manager = new CreditManager();
                _cachedValue = _manager.Calculate();
            }
            return _cachedValue;
        }
    }

}
