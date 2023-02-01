using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager hilmi = new Manager { Name = "Hilmi", Salary = 13300};
            Manager salih = new Manager { Name = "Salih", Salary = 9850 };
            Worker sultan = new Worker { Name = "Sultan", Salary = 5250 };
            Worker hasan = new Worker { Name = "Hasan", Salary = 6700 };

            hilmi.Subordinates.Add(salih);
            salih.Subordinates.Add(sultan);
            salih.Subordinates.Add(hasan);

            OrganisationalStructure structure = new OrganisationalStructure(hilmi);
            PayRollVisitor payRollVisitor = new PayRollVisitor();
            PayRise payRise = new PayRise();

            structure.Accept(payRollVisitor);
            structure.Accept(payRise);

            Console.ReadKey();
        }
    }

    class OrganisationalStructure
    {
        public EmployeeBase Employee;
        public OrganisationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }

        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }

    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }

    class Manager : EmployeeBase
    {
        public Manager()
        {
            Subordinates = new List<EmployeeBase>();
        }

        public List<EmployeeBase> Subordinates { get; set; }
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);

            foreach (var employee in Subordinates)
            {
                employee.Accept(visitor);
            }
        }
    }

    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }

    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);
    }

    class PayRollVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine($"{worker.Salary} Paid To Worker {worker.Name}");
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine($"{manager.Salary} Paid To Manager {manager.Name}");
        }
    }

    class PayRise : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine($"{worker.Name} 's salary increased to {worker.Salary*(decimal)1.1}");
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine($"{manager.Name} 's salary increased to {manager.Salary*(decimal)1.2}");
        }
    }
}
