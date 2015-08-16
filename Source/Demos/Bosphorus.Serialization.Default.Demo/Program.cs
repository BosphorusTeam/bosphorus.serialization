using System;
using Bosphorus.BootStapper.Runner.Console;
using Bosphorus.Common.Core.Application;
using Bosphorus.Serialization.Core;
using Bosphorus.Serialization.Core.Serializer;
using Bosphorus.Serialization.Core.Serializer.Binary;
using Bosphorus.Serialization.Core.Serializer.Json;
using Bosphorus.Serialization.Core.Serializer.Xml;
using Environment = Bosphorus.Common.Core.Application.Environment;

namespace Bosphorus.Serialization.Default.Demo
{
    class Program : IProgram
    {
        private readonly GenericXmlSerializer genericXmlSerializer;
        private readonly GenericBinarySerializer genericBinarySerializer;
        private readonly GenericJsonSerializer genericJsonSerializer;

        public Program(GenericXmlSerializer genericXmlSerializer, GenericBinarySerializer genericBinarySerializer, GenericJsonSerializer genericJsonSerializer)
        {
            this.genericXmlSerializer = genericXmlSerializer;
            this.genericBinarySerializer = genericBinarySerializer;
            this.genericJsonSerializer = genericJsonSerializer;
        }

        public void Run(string[] args)
        {
            Customer customer = new Customer();
            customer.Age = 24;
            customer.Name = "Oğuz";

            string input = genericXmlSerializer.Serialize(customer);
            genericXmlSerializer.Deserialize(typeof (Customer), input);

            TestSerialization(customer, genericXmlSerializer);
            TestSerialization(customer, genericBinarySerializer);
            TestSerialization(customer, genericJsonSerializer);

            TestDeserialization(customer, genericXmlSerializer);
            TestDeserialization(customer, genericBinarySerializer);
            TestDeserialization(customer, genericJsonSerializer);
        }

        private void TestDeserialization<TModel>(TModel model, AbstractGenericSerializer serializer)
        {
            string serialize = serializer.Serialize(model);
            TModel deserialize = serializer.Deserialize<TModel>(serialize);
            Console.WriteLine(deserialize);
        }

        private void TestSerialization<TModel>(TModel model, AbstractGenericSerializer serializer)
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
