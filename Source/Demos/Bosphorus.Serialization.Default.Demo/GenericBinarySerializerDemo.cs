using Bosphorus.Serialization.Core.Serializer.Binary;
using Bosphorus.Serialization.Core.Serializer.Xml;
using Castle.Windsor;

namespace Bosphorus.Serialization.Default.Demo
{
    public class GenericBinarySerializerDemo : AbstractSerializerDemo
    {
        public GenericBinarySerializerDemo(IWindsorContainer container, GenericBinarySerializer genericSerializer) 
            : base(container, genericSerializer)
        {
        }

        public object Serialization_Customer()
        {
            Customer customer = BuildCustomer();
            var result = TestSerialization(customer);
            return result;
        }

        public Customer Deserialization_Customer()
        {
            Customer customer = BuildCustomer();
            var result = TestDeserialization(customer);
            return result;
        }

    }
}