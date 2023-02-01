using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiton // singleton ın gelişmiş ve çoklu üretim versiyonu.
{
    class Program
    {
        static void Main(string[] args)
        {
            Camera camera1 = Camera.GetCamera("Sony");
            Camera camera2 = Camera.GetCamera("Nikon");
            Camera camera3 = Camera.GetCamera("Canon");
            Camera camera4 = Camera.GetCamera("Sony");

            Console.WriteLine(camera1.Id);
            Console.WriteLine(camera2.Id);
            Console.WriteLine(camera3.Id);
            Console.WriteLine(camera4.Id);

            Console.ReadKey();
        }
    }

    class Camera // Multiton
    {
        static Dictionary<string, Camera> _camera = new Dictionary<string, Camera>();
        static object _lock = new object();
        private string brand;
        public Guid Id { get; set; }

        public Camera()
        {
            Id = Guid.NewGuid();
        }

        public static Camera GetCamera(string brand)
        {
            lock (_lock)
            {
                if (!_camera.ContainsKey(brand))
                {
                    _camera.Add(brand, new Camera());
                }
            }
            return _camera[brand];
        }
    }





}
