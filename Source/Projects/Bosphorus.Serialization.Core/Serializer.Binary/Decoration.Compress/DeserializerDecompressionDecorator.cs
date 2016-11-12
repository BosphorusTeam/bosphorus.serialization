using System.IO;
using System.IO.Compression;

namespace Bosphorus.Serialization.Core.Serializer.Binary.Decoration.Compress
{
    public class DeserializerDecompressionDecorator<TModel>: IBinaryDeserializer<TModel>
    {
        private readonly IBinaryDeserializer<TModel> decorated;

        public DeserializerDecompressionDecorator(IBinaryDeserializer<TModel> decorated)
        {
            this.decorated = decorated;
        }

        public TModel Deserialize(byte[] serialized)
        {
            var decompressed = Decompress(serialized);
            var result = decorated.Deserialize(decompressed);
            return result;
        }

        private byte[] Decompress(byte[] input)
        {
            using (var outputStream = new MemoryStream())
            {
                using (var inputStream = new MemoryStream(input))
                {
                    using (var zip = new GZipStream(inputStream, CompressionMode.Decompress))
                    {
                        zip.CopyTo(outputStream);
                    }
                }

                var result = outputStream.ToArray();
                return result;
            }
        }
    }
}
