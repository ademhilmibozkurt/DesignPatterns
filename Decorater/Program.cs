using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorater // elimizde bir temel nesne varken başka koşullarda başka şekilde kullanmak için uygulanır.
{
    class Program
    {
        static void Main(string[] args)
        {
            var personalCar = new PersonalCar { Make = "Mercedes", Model ="C63s 2017", HirePrice = 1950 };
            SpecialOffer specialOffer = new SpecialOffer(personalCar);
            specialOffer.DiscountPercentage = 10;

            Console.WriteLine($"Concrete : {personalCar.HirePrice}");
            Console.WriteLine($"Special Offer : {specialOffer.HirePrice}");

            Console.ReadKey();
        }
    }

    abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    class PersonalCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    class CommercialCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    abstract class CarDecoratorBase : CarBase
    {
        private CarBase _carBase; // dependency injection

        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }

    class SpecialOffer : CarDecoratorBase
    {
        public int DiscountPercentage { get; set; }
        private readonly CarBase _carBase;
        public SpecialOffer(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice {
            get { return _carBase.HirePrice -_carBase.HirePrice*DiscountPercentage/100; }
            set { } }
    }

}
