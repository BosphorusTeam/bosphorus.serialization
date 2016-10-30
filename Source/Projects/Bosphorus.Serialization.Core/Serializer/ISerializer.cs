namespace Bosphorus.Serialization.Core.Serializer
{
    public interface ISerializer<in TModel, out TSerialized>
    {
        TSerialized Serialize(TModel model);
    }

}
