using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Bosphorus.Serialization.Core.Serializer.Binary;

namespace Bosphorus.Serialization.Default.Serializer.Binary
{
    public class DefaultBinaryDeserializer<TModel> : IBinaryDeserializer<TModel>
    {
        private readonly BinaryFormatter formatter;

        public DefaultBinaryDeserializer(BinaryFormatter formatter)
        {
            this.formatter = formatter;
        }

        public TModel Deserialize(byte[] serialized)
        {
            using (MemoryStream memoryStream = new MemoryStream(serialized))
            {
                object result = formatter.Deserialize(memoryStream);

                return (TModel)result;
            }
        }
    }
}
