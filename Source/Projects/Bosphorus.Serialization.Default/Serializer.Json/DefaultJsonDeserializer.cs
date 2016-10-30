
using System;
using System.Web.Script.Serialization;
using Bosphorus.Serialization.Core.Serializer.Json;

namespace Bosphorus.Serialization.Default.Serializer.Json
{
    public class DefaultJsonDeserializer<TModel> : IJsonDeserializer<TModel>
    {
        private readonly JavaScriptSerializer javaScriptSerializer;

        public DefaultJsonDeserializer(JavaScriptSerializer javaScriptSerializer)
        {
            this.javaScriptSerializer = javaScriptSerializer;
        }

        public TModel Deserialize(string input)
        {
            TModel result = javaScriptSerializer.Deserialize<TModel>(input);
            return result;
        }
    }
}
