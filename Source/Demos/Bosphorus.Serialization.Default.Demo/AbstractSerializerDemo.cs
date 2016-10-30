using System;
using Bosphorus.Assemble.BootStrapper.Runner.Demo.ExecutableItem;
using Bosphorus.Serialization.Core.Serializer;
using Castle.Windsor;

namespace Bosphorus.Serialization.Default.Demo
{
    public abstract class AbstractSerializerDemo : AbstractMethodExecutionItemList
    {
        private readonly dynamic genericSerializer;

        protected AbstractSerializerDemo(IWindsorContainer container, dynamic genericSerializer) 
            : base(container)
        {
            this.genericSerializer = genericSerializer;
        }

        protected Customer BuildCustomer()
        {
            Customer customer = new Customer();
            customer.Age = 24;
            customer.Name = "Oğuz";

            return customer;
        }

        protected object TestSerialization<TModel>(TModel model)
        {
            var serialize = genericSerializer.Serialize(model);
            Console.WriteLine(serialize);
            return serialize;
        }

        protected TModel TestDeserialization<TModel>(TModel model)
        {
            var serialize = genericSerializer.Serialize(model);
            TModel deserialize = genericSerializer.Deserialize<TModel>(serialize);
            return deserialize;
        }

    }
}
