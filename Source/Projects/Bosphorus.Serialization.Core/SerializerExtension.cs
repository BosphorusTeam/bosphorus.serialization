using System;

namespace Bosphorus.Serialization.Core
{
    public static class SerializerExtension
    {
        public static string Serialize<TModel>(this ISerializer<TModel> extended, TModel model)
        {
            string result = extended.Serialize(model);

            return result;
        }

        public static TModel Deserialize<TModel>(this ISerializer<TModel> extended, string input)
        {
            Type type = typeof (TModel);
            var result = (TModel)extended.Deserialize(type, input);

            return result;
        }
    }
}
