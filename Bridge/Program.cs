using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bridge 
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.messageSender = new SMSSender(); // bridge i set etmek
            customerManager.UpdateCustomer();

            Console.ReadKey();
        }
    }

    abstract class MessageSenderBase
    {
        public void SaveMessage()
        {
            Console.WriteLine("Message Saved.. ");
        }

        public abstract void Send(Body body); // SMS or EMail tek kullanacağız.
    }

    class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    class MailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine($"{body.Title} was sent via Mail Sender.. ");
        }
    }

    class SMSSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine($"{body.Title} was sent via SMS Sender.. ");
        }
    }

    class CustomerManager // kişiyi bilgilendireceğiz.
    {
        public MessageSenderBase messageSender { get; set; }
        public void UpdateCustomer()
        {
            messageSender.Send(new Body { Title = "About Course"});
            Console.WriteLine("Customer Updated .. ");
        }
    }

}
