using System.IO;
using System.IO.Compression;

namespace Bosphorus.Serialization.Core.Serializer.Binary.Decoration.Compress
{
    public class SerializerCompressionDecorator<TModel> : IBinarySerializer<TModel>
    {
        private readonly IBinarySerializer<TModel> decorated;

        public SerializerCompressionDecorator(IBinarySerializer<TModel> decorated)
        {
            this.decorated = decorated;
        }

        public byte[] Serialize(TModel model)
        {
            var result = decorated.Serialize(model);
            var compressed = Compress(result);
            return compressed;
        }

        private static byte[] Compress(byte[] input)
        {
            using (var outputStream = new MemoryStream())
            {
                using (var zip = new GZipStream(outputStream, CompressionMode.Compress))
                {
                    zip.Write(input, 0, input.Length);
                }

                var result = outputStream.ToArray();
                return result;
            }
        }
    }
}
