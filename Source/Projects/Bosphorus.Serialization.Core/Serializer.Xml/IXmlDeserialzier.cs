namespace Bosphorus.Serialization.Core.Serializer.Xml
{
    public interface IXmlDeserializer<out TModel> : IDeserializer<TModel, string>
    {
    }
}