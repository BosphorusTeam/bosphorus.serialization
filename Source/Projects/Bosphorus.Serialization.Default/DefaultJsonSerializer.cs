using System;
using System.Web.Script.Serialization;
using Bosphorus.Serialization.Core;

namespace Bosphorus.Serialization.Default
{
    public class DefaultJsonSerializer<TModel> : IJsonSerializer<TModel>
    {
        private readonly JavaScriptSerializer javaScriptSerializer;

        public DefaultJsonSerializer()
        {
            javaScriptSerializer = new JavaScriptSerializer();
        }

        public string Serialize(TModel model)
        {
            String result = javaScriptSerializer.Serialize(model);
            return result;
        }

        public TModel Deserialize(string input)
        {
            TModel result = javaScriptSerializer.Deserialize<TModel>(input);
            return result;
        }
    }
}
