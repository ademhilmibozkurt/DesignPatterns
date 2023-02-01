using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection // IoC container Ninject yüklendi.
{
    class Program // zaten .exe dosyalarının açılma hızlarında acayip bir hız artışı var.
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(); // ninject kullanımı için. // InSingletonScope çoklu kişilere eynı instance ı verir. bu da bellek kullanımını azaltır.
            kernel.Bind<IProductDal>().To<NhProductDal>().InSingletonScope(); // IproductDal olarak EfProductDal kullanıyoruz.

            ProductManager productManager = new ProductManager(kernel.Get<IProductDal>()); // bir instance ver.
            productManager.Save();

            Console.ReadKey();
        }
    }

    interface IProductDal
    {
        void Save();
    }

    class EfProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with Ef ..");
        }
    }

    class NhProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with Nh ..");
        }
    }

    class ProductManager
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Save()
        {
            _productDal.Save();
        }
    }


}
