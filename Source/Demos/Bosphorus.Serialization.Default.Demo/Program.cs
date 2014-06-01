using Bosphorus.Container.Castle.Facade;
using Bosphorus.Serialization.Core;

namespace Bosphorus.Serialization.Default.Demo
{
    class Program : IProgram
    {
        private readonly IXmlSerializer xmlSerializer;
        private readonly IBinarySerializer binarySerializer;
        private readonly IJsonSerializer jsonSerializer;

        public Program(IXmlSerializer xmlSerializer, IBinarySerializer binarySerializer, IJsonSerializer jsonSerializer)
        {
            this.xmlSerializer = xmlSerializer;
            this.binarySerializer = binarySerializer;
            this.jsonSerializer = jsonSerializer;
        }

        public void Run(string[] args)
        {
            Customer customer = new Customer();
            customer.Age = 24;
            customer.Name = "Oğuz";

            xmlSerializer.Serialize(customer);
            binarySerializer.Serialize(customer);
            jsonSerializer.Serialize(customer);
        }

        static void Main(string[] args)
        {
            ConsoleRunner.Run<Program>(args);
        }
    }
}
