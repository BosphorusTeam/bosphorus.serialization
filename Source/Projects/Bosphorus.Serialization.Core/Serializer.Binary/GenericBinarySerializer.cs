using System;
using Castle.Windsor;

namespace Bosphorus.Serialization.Core.Serializer.Binary
{
    public class GenericBinarySerializer
    {
        private readonly IWindsorContainer container;

        public GenericBinarySerializer(IWindsorContainer container)
        {
            this.container = container;
        }

        public byte[] Serialize<TModel>(TModel model)
        {
            var serializer = container.Resolve<IBinarySerializer<TModel>>();
            var result = serializer.Serialize(model);
            return result;
        }
        public TModel Deserialize<TModel>(byte[] serialized)
        {
            var deserializer = container.Resolve<IBinaryDeserializer<TModel>>();
            var result = deserializer.Deserialize(serialized);
            return result;
        }
    }
}