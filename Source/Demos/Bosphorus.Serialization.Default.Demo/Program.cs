using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Bosphorus.Serialization.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Bosphorus.Serialization.Default.Demo
{
    class Program
    {
        private readonly static IWindsorContainer Container;

        static Program()
        {
            Container = new WindsorContainer();
            Container.Install(
                FromAssembly.InDirectory(new AssemblyFilter("."))
            );
        }

        static void Main(string[] args)
        {
            Customer customer = new Customer();
            customer.Age = 24;
            customer.Name = "Oğuz";

            Serialization<IXmlSerializer>(customer);
            Serialization<IBinarySerializer>(customer);
            Serialization<IJsonSerializer>(customer);
        }

        private static void Serialization<TSerializer>(Customer customer) where TSerializer : ISerializer
        {
            TSerializer serializer = Container.Resolve<TSerializer>();
            string result = serializer.Serialize(customer);
            Console.WriteLine(result);
            serializer.Deserialize<Customer>(result);
        }

    }
}
