using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command // komut.
{
    class Program
    {
        static void Main(string[] args)
        {
            StockManager manager = new StockManager();
            BuyStock buy = new BuyStock(manager);
            SellStock sell = new SellStock(manager);

            StockController controller = new StockController();
            controller.TakeOrder(buy);
            controller.TakeOrder(sell);
            controller.TakeOrder(buy);

            controller.PlaceOrders();Console.ReadKey();
        }
    }

    class StockManager
    {
        private string _name = "Acer Nitro 5 AN551-5";
        private int _quantity = 10;

        public void Buy()
        {
            Console.WriteLine($"Stock : {_name}, {_quantity} bought..");
        }

        public void Sell()
        {
            Console.WriteLine($"Stock : {_name}, {_quantity} sold..");
        }
    }

    interface IOrder
    {
        void Execute();
    }

    class BuyStock : IOrder
    {
        private StockManager _manager;
        public BuyStock(StockManager stockManager)
        {
            _manager = stockManager;
        }
        public void Execute()
        {
            _manager.Buy();
        }
    }

    class SellStock : IOrder
    {
        private StockManager _manager;
        public SellStock(StockManager stockManager)
        {
            _manager = stockManager;
        }
        public void Execute()
        {
            _manager.Sell();
        }
    }

    class StockController
    {
        List<IOrder> _orders = new List<IOrder>();
        public void TakeOrder(IOrder order)
        {
            _orders.Add(order);
        }

        public void PlaceOrders()
        {
            foreach (var order in _orders)
            {
                order.Execute();
            }

            _orders.Clear();
        }
    }


}
