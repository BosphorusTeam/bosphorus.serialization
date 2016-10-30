using System.Web.Script.Serialization;
using Bosphorus.Serialization.Core.Serializer.Json;

namespace Bosphorus.Serialization.Default.Serializer.Json
{
    public class DefaultJsonSerializer<TModel> : IJsonSerializer<TModel>
    {
        private readonly JavaScriptSerializer javaScriptSerializer;

        public DefaultJsonSerializer(JavaScriptSerializer javaScriptSerializer)
        {
            this.javaScriptSerializer = javaScriptSerializer;
        }

        public string Serialize(TModel model)
        {
            var result = javaScriptSerializer.Serialize(model);
            return result;
        }

    }
}
