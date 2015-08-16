using System;
using System.IO;
using Bosphorus.Serialization.Core.Serializer.Xml;
using XmlSerializer = System.Xml.Serialization.XmlSerializer;

namespace Bosphorus.Serialization.Default.Serializer.Xml
{
    public class DefaultXmlSerializer<TModel> : IXmlSerializer<TModel>
    {
        private readonly Type type;

        public DefaultXmlSerializer()
        {
            type = typeof (TModel);
        }

        public string Serialize(TModel model)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(type);
            using (TextWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, model);

                String result = textWriter.ToString();
                return result;
            }
        }

        public TModel Deserialize(string input)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(type);
            using (TextReader textReader = new StringReader(input))
            {
                object result = xmlSerializer.Deserialize(textReader);

                return (TModel) result;
            }
        }
    }
}
