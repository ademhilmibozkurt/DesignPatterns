using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer { FirstName = "Adem Hilmi", LastName = "Bozkurt", City = "Maraş", ID = 134457 };
            
            Customer customerM = (Customer)customer.Clone(); // klonlayıp cıustomere cast ettik.
            customerM.FirstName = "Salih";
            
            Console.WriteLine(customer.FirstName);
            Console.WriteLine(customerM.FirstName + customerM.LastName);

            Console.ReadKey();
        }
    }

    public abstract class Person // Person prototype dir. onun üzerinden klonlar oluştururuz.
    {
        public abstract Person Clone(); // klonlama için abstract method.
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone(); // klonlama .NET framework
        }
    }

    public class Employee : Person
    {
        public decimal Salary{ get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone(); 
        }
    }
}
