using System.IO;
using Bosphorus.Serialization.Core.Serializer.Xml;
using XmlSerializer = System.Xml.Serialization.XmlSerializer;

namespace Bosphorus.Serialization.Default.Serializer.Xml
{
    public class DefaultXmlDeserializer<TModel> : IXmlDeserializer<TModel>
    {
        private readonly XmlSerializer xmlSerializer;

        public DefaultXmlDeserializer()
        {
            xmlSerializer = new XmlSerializer(typeof(TModel));
        }

        public TModel Deserialize(string input)
        {
            using (TextReader textReader = new StringReader(input))
            {
                object result = xmlSerializer.Deserialize(textReader);
                return (TModel) result;
            }
        }
    }
}
