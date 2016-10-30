using Castle.Windsor;

namespace Bosphorus.Serialization.Core.Serializer.Xml
{
    public class GenericXmlSerializer
    {
        private readonly IWindsorContainer container;

        public GenericXmlSerializer(IWindsorContainer container)
        {
            this.container = container;
        }
        public string Serialize<TModel>(TModel model)
        {
            var serializer = container.Resolve<IXmlSerializer<TModel>>();
            var result = serializer.Serialize(model);
            return result;
        }
        public TModel Deserialize<TModel>(string serialized)
        {
            var deserializer = container.Resolve<IXmlDeserializer<TModel>>();
            var result = deserializer.Deserialize(serialized);
            return result;
        }
    }
}