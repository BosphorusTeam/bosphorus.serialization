using System.IO;
using Bosphorus.Serialization.Core.Serializer.Binary;
using Polenter.Serialization;

namespace Bosphorus.Serialization.Default.Serializer.Binary.Sharp
{
    //TODO: Make stateless
    public class SharpBinaryDeserializer<TModel> : IBinaryDeserializer<TModel>
    {
        public TModel Deserialize(byte[] serialized)
        {
            var sharpSerializer = new SharpSerializer(true);
            using (MemoryStream memoryStream = new MemoryStream(serialized))
            {
                var result = sharpSerializer.Deserialize(memoryStream);
                return (TModel)result;
            }
        }
    }
}
