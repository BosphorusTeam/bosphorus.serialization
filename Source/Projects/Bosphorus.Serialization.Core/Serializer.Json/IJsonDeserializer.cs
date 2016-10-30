namespace Bosphorus.Serialization.Core.Serializer.Json
{
    public interface IJsonDeserializer<out TModel>: IDeserializer<TModel, string>
    {
    }
}