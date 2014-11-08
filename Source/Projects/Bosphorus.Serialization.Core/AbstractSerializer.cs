using System;

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

        public TModel Deserialize<TModel>(string input)
        {
            var serializer = GetSerializer<TModel>();
            TModel result = serializer.Deserialize(input);
            return result;
        }

        public object Deserialize(Type modelType, string input)
        {
            dynamic serializer = GetSerializer(modelType);
            object result = serializer.Deserialize(input);
            return result;
        }

        protected abstract ISerializer<TModel> GetSerializer<TModel>();

        protected abstract object GetSerializer(Type modelType);

    }
}
