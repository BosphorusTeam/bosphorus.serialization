using System;
using Bosphorus.Container.Castle.Registry;

namespace Bosphorus.Serialization.Core
{
    public class JsonSerializer : AbstractSerializer
    {
        private readonly IServiceRegistry serviceRegistry;

        public JsonSerializer(IServiceRegistry serviceRegistry)
        {
            this.serviceRegistry = serviceRegistry;
        }

        protected override ISerializer<TModel> GetSerializer<TModel>()
        {
            Type serviceType = typeof(IJsonSerializer<TModel>);
            object instance = serviceRegistry.Get(serviceType);

            ISerializer<TModel> serializer = (IJsonSerializer<TModel>)instance;
            return serializer;
        }
    }
}