using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite // nesneler arası hiyerarşi ve nesnelere istediğimiz zaman ulaşabilme.
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee hilm = new Employee();
            hilm.Name = "Adem Hilmi Bozkurt";

            Employee salih = new Employee();
            salih.Name = "Salih Osman Bozkurt";

            Employee mehmet = new Employee();
            mehmet.Name = "Mehmet Emin Bozkurt";

            Contractor tatyana = new Contractor();
            tatyana.Name = "Tatyana Kozelkina";

            Employee zarife = new Employee();
            zarife.Name = "Zarife Bozkurt";

            Employee berna = new Employee();
            berna.Name = "Berna Çalışkan";

            Employee hazal = new Employee();
            hazal.Name = "Hazal Kalır";

            hilm.AddSubordinate(salih);
            hilm.AddSubordinate(mehmet);
            hilm.AddSubordinate(berna);
            salih.AddSubordinate(hazal);
            salih.AddSubordinate(zarife);
            mehmet.AddSubordinate(tatyana);

            Console.WriteLine(hilm.Name);
            foreach (Employee manager in hilm)
            {
                Console.WriteLine(" "); Console.WriteLine(manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine(employee.Name);
                }
            }

            Console.ReadKey();
        }
    }

    interface IPerson
    {
        string Name{ get; set; }
    }

    class Contractor : IPerson // Anlaşmalılar
    {
        public string Name { get; set; }
    }

    class Employee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>(); // liste ile kişileri tuttuk.
        public void AddSubordinate(IPerson person) // alt çalışan ekledik.
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinate(IPerson person) // alt çalışan silme metodu.
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator() // foreach ile gezmeyi sağlayalım.
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
