using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Bosphorus.Serialization.Core.Serializer.Binary;

namespace Bosphorus.Serialization.Default.Serializer.Binary
{
    public class DefaultBinarySerializer<TModel> : IBinarySerializer<TModel>
    {
        private readonly BinaryFormatter formatter;

        public DefaultBinarySerializer()
        {
            formatter = new BinaryFormatter();
        }

        public string Serialize(TModel model)
        {
            using (MemoryStream memorystream = new MemoryStream())
            {
                formatter.Serialize(memorystream, model);
                byte[] bytes = memorystream.ToArray();
                string result = Encoding.Default.GetString(bytes);

                return result;
            }
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
    }
}
