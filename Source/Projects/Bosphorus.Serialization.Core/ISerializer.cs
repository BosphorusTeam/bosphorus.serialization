namespace Bosphorus.Serialization.Core
{
    public interface ISerializer<TModel>
    {
        string Serialize(TModel model);

        TModel Deserialize(string input);
    }

    public interface ISerializer
    {
        string Serialize(object model);

        object Deserialize(string input);
    }
}
