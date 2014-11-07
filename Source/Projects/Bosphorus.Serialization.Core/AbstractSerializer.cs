namespace Bosphorus.Serialization.Core
{
    public abstract class AbstractSerializer
    {
        public string Serialize<TModel>(TModel model)
        {
            var serializer = GetSerializer<TModel>();
            string result = serializer.Serialize(model);
            return result;
        }

        protected abstract ISerializer<TModel> GetSerializer<TModel>();

        public TModel Deserialize<TModel>(string input)
        {
            var serializer = GetSerializer<TModel>();
            TModel result = serializer.Deserialize(input);
            return result;
        }

    }
}
