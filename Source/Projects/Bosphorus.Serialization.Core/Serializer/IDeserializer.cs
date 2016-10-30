namespace Bosphorus.Serialization.Core.Serializer
{
    public interface IDeserializer<out TModel, in TSerialized>
    {
         TModel Deserialize(TSerialized serialized);
    }

}
