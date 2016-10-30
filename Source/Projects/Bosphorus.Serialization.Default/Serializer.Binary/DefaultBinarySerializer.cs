using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Bosphorus.Serialization.Core.Serializer;
using Bosphorus.Serialization.Core.Serializer.Binary;

namespace Bosphorus.Serialization.Default.Serializer.Binary
{
    public class DefaultBinarySerializer<TModel> : IBinarySerializer<TModel>
    {
        private readonly BinaryFormatter formatter;

        public DefaultBinarySerializer(BinaryFormatter formatter)
        {
            this.formatter = formatter;
        }

        public TModel Deserialize(string input)
        {
            byte[] bytes = Encoding.Default.GetBytes(input);
            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                object result = formatter.Deserialize(memoryStream);

                return (TModel) result;
            }
        }

        public byte[] Serialize(TModel model)
        {
            using (MemoryStream memorystream = new MemoryStream())
            {
                formatter.Serialize(memorystream, model);
                byte[] result = memorystream.ToArray();
                return result;
            }
        }
    }
}
