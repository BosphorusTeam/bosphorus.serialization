using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
