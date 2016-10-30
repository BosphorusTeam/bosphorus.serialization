namespace Bosphorus.Serialization.Core.Serializer.Binary
{
    public interface IBinaryDeserializer<out TModel>: IDeserializer<TModel, byte[]>
    {
    }

}
