using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Bosphorus.Serialization.Core;

namespace Bosphorus.Serialization.Default
{
    public class DefaultBinarySerializer : IBinarySerializer
    {
        private readonly BinaryFormatter formatter;

        public DefaultBinarySerializer()
        {
            formatter = new BinaryFormatter();
        }

        public string Serialize(object model)
        {
            using (MemoryStream memorystream = new MemoryStream())
            {
                formatter.Serialize(memorystream, model);
                byte[] bytes = memorystream.ToArray();
                string result = Encoding.Default.GetString(bytes);

                return result;
            }
        }

        public Object Deserialize(Type type, string input)
        {
            byte[] bytes = Encoding.Default.GetBytes(input);
            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                object result = formatter.Deserialize(memoryStream);

                return result;
            }
        }
    }
}
