using Castle.Windsor;

namespace Bosphorus.Serialization.Core.Serializer
{
    public class GenericSerializer
    {
        private readonly IWindsorContainer container;

        public GenericSerializer(IWindsorContainer container)
        {
            this.container = container;
        }

        public TSerialized Serialize<TModel, TSerialized>(TModel model)
        {
            var serializer = container.Resolve<ISerializer<TModel, TSerialized>>();
            var result = serializer.Serialize(model);
            return result;
        }

        public TModel Deserialize<TModel, TSerialized>(TSerialized serialized)
        {
            var deserializer = container.Resolve<IDeserializer<TModel, TSerialized>>();
            var result = deserializer.Deserialize(serialized);
            return result;
        }
    }
}