using System;
using Castle.Windsor;

namespace Bosphorus.Serialization.Core
{
    public class JsonSerializer : AbstractSerializer
    {
        private readonly IWindsorContainer container;

        public JsonSerializer(IWindsorContainer container)
        {
            this.container = container;
        }

        protected override ISerializer<TModel> GetSerializer<TModel>()
        {
            Type serviceType = typeof(IJsonSerializer<TModel>);
            object instance = container.Resolve(serviceType);

            ISerializer<TModel> serializer = (IJsonSerializer<TModel>)instance;
            return serializer;
        }

        protected override object GetSerializer(Type modelType)
        {
            Type genericType = typeof(IJsonSerializer<>).MakeGenericType(modelType);
            object instance = container.Resolve(genericType);
            return instance;
        }
    }
}