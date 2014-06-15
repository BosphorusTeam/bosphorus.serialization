using System;
using System.IO;
using System.Xml.Serialization;
using Bosphorus.Serialization.Core;

namespace Bosphorus.Serialization.Default
{
    public class DefaultXmlSerializer : IXmlSerializer
    {
        public string Serialize(object model)
        {
            Type type = model.GetType();
            XmlSerializer xmlSerializer = new XmlSerializer(type);
            using (TextWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, model);

                String result = textWriter.ToString();
                return result;
            }
        }

        public object Deserialize(Type type, string input)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(type);
            using (TextReader textReader = new StringReader(input))
            {
                object result = xmlSerializer.Deserialize(textReader);

                return result;
            }
        }
    }
}
