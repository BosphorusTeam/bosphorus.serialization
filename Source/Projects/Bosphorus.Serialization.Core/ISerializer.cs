namespace Bosphorus.Serialization.Core
{
    public interface ISerializer<TModel>
    {
        string Serialize(TModel model);

        TModel Deserialize(string input);
    }
}
