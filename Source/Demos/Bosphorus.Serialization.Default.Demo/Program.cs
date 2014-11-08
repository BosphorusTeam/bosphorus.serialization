using System;
using Bosphorus.BootStapper.Common;
using Bosphorus.BootStapper.Program;
using Bosphorus.BootStapper.Runner;
using Bosphorus.Serialization.Core;
using Environment = Bosphorus.BootStapper.Common.Environment;

namespace Bosphorus.Serialization.Default.Demo
{
    class Program : IProgram
    {
        private readonly XmlSerializer xmlSerializer;
        private readonly BinarySerializer binarySerializer;
        private readonly JsonSerializer jsonSerializer;

        public Program(XmlSerializer xmlSerializer, BinarySerializer binarySerializer, JsonSerializer jsonSerializer)
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

            string input = xmlSerializer.Serialize(customer);
            xmlSerializer.Deserialize(typeof (Customer), input);

            TestSerialization(customer, xmlSerializer);
            TestSerialization(customer, binarySerializer);
            TestSerialization(customer, jsonSerializer);

            TestDeserialization(customer, xmlSerializer);
            TestDeserialization(customer, binarySerializer);
            TestDeserialization(customer, jsonSerializer);

            CustomModel customModel = new CustomModel();
            customModel.Customer = customer;
            customModel.Type = typeof (Customer);

            TestSerialization(customModel, xmlSerializer);
        }

        private void TestDeserialization<TModel>(TModel model, AbstractSerializer serializer)
        {
            string serialize = serializer.Serialize(model);
            TModel deserialize = serializer.Deserialize<TModel>(serialize);
            Console.WriteLine(deserialize);
        }

        private void TestSerialization<TModel>(TModel model, AbstractSerializer serializer)
        {
            string serialize = serializer.Serialize(model);
            Console.WriteLine(serialize);
        }

        static void Main(string[] args)
        {
            ConsoleRunner.Run<Program>(Environment.Development, Perspective.Debug, args);
        }
    }
}
