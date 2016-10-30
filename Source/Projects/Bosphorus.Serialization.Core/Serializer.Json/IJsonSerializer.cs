namespace Bosphorus.Serialization.Core.Serializer.Json
{
    public interface IJsonSerializer<in TModel> : ISerializer<TModel, string>
    {
    }
}
