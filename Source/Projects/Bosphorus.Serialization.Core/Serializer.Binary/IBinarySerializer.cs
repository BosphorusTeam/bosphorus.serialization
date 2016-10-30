namespace Bosphorus.Serialization.Core.Serializer.Binary
{
    public interface IBinarySerializer<in TModel> : ISerializer<TModel, byte[]>
    {
    }
}
