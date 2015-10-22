using Bosphorus.Serialization.Core.Serializer.Xml;
using Castle.Windsor;

namespace Bosphorus.Serialization.Default.Demo
{
    public class GenericXmlSerializerDemo: AbstractSerializerDemo<GenericXmlSerializer>
    {
        public GenericXmlSerializerDemo(IWindsorContainer container, GenericXmlSerializer genericSerializer) 
            : base(container, genericSerializer)
        {
        }

        public string Serialization_Customer()
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