using System.IO;
using Bosphorus.Serialization.Core.Serializer.Binary;
using Polenter.Serialization;

namespace Bosphorus.Serialization.Default.Serializer.Binary.Sharp
{
    //TODO: Make stateless
    public class SharpBinarySerializer<TModel> : IBinarySerializer<TModel>
    {
        public byte[] Serialize(TModel model)
        {
            var sharpSerializer = new SharpSerializer(true);
            using (MemoryStream memorystream = new MemoryStream())
            {
                sharpSerializer.Serialize(model, memorystream);
                byte[] result = memorystream.ToArray();
                return result;
            }
        }
    }
}
