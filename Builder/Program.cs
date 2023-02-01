using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Builder // herhngi bir şeyi yapıcı gibi düşünebiliriz. mesela hamburger makinesi.
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirector director = new ProductDirector();
            var builder = new OldCustomerProductBuilder();
            director.GenerateProduct(builder);

            var model = builder.GetModel();
            Console.WriteLine(model.Id);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.UnitPrice);
            Console.WriteLine(model.Discount);
            Console.WriteLine(model.DiscountApplied);

            Console.ReadKey();
        }
    }

    class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public bool DiscountApplied { get; set; }
    }

    abstract class ProductBuilder // daha modüler olması için abstract
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();
    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void ApplyDiscount()
        {
            model.Discount = model.UnitPrice*(0.9m);
            model.DiscountApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }

        public override void GetProductData()
        {
            model.Id = 11232;
            model.CategoryName = "Beverages";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }
    }

    class OldCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void ApplyDiscount()
        {
            model.Discount = model.UnitPrice;
            model.DiscountApplied = false;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }

        public override void GetProductData()
        {
            model.Id = 11732;
            model.CategoryName = "Beverages";
            model.ProductName = "Tea";
            model.UnitPrice = 11;
        }
    }

    class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }

}
