using System;
using System.Web.Script.Serialization;
using Bosphorus.Serialization.Core;

namespace Bosphorus.Serialization.Default
{
    public class DefaultJsonSerializer : IJsonSerializer
    {
        private readonly JavaScriptSerializer javaScriptSerializer;

        public DefaultJsonSerializer()
        {
            javaScriptSerializer = new JavaScriptSerializer();
        }

        public string Serialize(object model)
        {
            String result = javaScriptSerializer.Serialize(model);

            return result;
        }

        public object Deserialize(Type type, string input)
        {
            object result = javaScriptSerializer.Deserialize(input, type);

            return result;
        }
    }
}
