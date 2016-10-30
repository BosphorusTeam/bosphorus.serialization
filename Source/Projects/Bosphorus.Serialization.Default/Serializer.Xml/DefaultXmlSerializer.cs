﻿using System.IO;
using Bosphorus.Serialization.Core.Serializer.Xml;
using XmlSerializer = System.Xml.Serialization.XmlSerializer;

namespace Bosphorus.Serialization.Default.Serializer.Xml
{
    public class DefaultXmlSerializer<TModel> : IXmlSerializer<TModel>
    {
        private readonly XmlSerializer xmlSerializer;

        public DefaultXmlSerializer()
        {
            xmlSerializer = new XmlSerializer(typeof(TModel));
        }

        public string Serialize(TModel model)
        {
            using (TextWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, model);
                var result = textWriter.ToString();
                return result;
            }
        }
    }
}
