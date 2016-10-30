using Castle.Windsor;

namespace Bosphorus.Serialization.Core.Serializer.Json
{
    public class GenericJsonSerializer
    {
        private readonly IWindsorContainer container;

        public GenericJsonSerializer(IWindsorContainer container)
        {
            this.container = container;
        }

        public string Serialize<TModel>(TModel model)
        {
            var serializer = container.Resolve<IJsonSerializer<TModel>>();
            var result = serializer.Serialize(model);
            return result;
        }
        public TModel Deserialize<TModel>(string serialized)
        {
            var deserializer = container.Resolve<IJsonDeserializer<TModel>>();
            var result = deserializer.Deserialize(serialized);
            return result;
        }
    }
}