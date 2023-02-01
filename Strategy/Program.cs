using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.calculatorBase = new After2010Calculator();
            customerManager.SaveCredit();

            Console.ReadKey();
        }
    }

    abstract class CreditCalculatorBase
    {
        public abstract void Calculate();
    }

    class Before2010Calculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated for old(before 2010) customer..");
        }
    }

    class After2010Calculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated for new(after 2010) customer..");
        }
    }

    class CustomerManager
    {
        public CreditCalculatorBase calculatorBase { get; set; }
        public void SaveCredit()
        {
            Console.WriteLine("Customer manager business ");
            calculatorBase.Calculate();
        }
    }

}
