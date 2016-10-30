using Bosphorus.Serialization.Core.Serializer.Json;
using Bosphorus.Serialization.Core.Serializer.Xml;
using Castle.Windsor;

namespace Bosphorus.Serialization.Default.Demo
{
    public class GenericJsonSerializerDemo : AbstractSerializerDemo
    {
        public GenericJsonSerializerDemo(IWindsorContainer container, GenericJsonSerializer genericSerializer) 
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