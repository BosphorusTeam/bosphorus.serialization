namespace Bosphorus.Serialization.Core.Serializer.Xml
{
    //TODO: Deserializer için default implementation type'ları register edilebilmeli
    public interface IXmlSerializer<in TModel> : ISerializer<TModel, string>
    {
    }
}
