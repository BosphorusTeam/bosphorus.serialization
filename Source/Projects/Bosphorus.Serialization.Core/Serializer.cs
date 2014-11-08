using System;
using Bosphorus.Container.Castle.Registry;

namespace Bosphorus.Serialization.Core
{
    public class Serializer : AbstractSerializer
    {
        private readonly IServiceRegistry serviceRegistry;

        public Serializer(IServiceRegistry serviceRegistry)
        {
            this.serviceRegistry = serviceRegistry;
        }

        protected override ISerializer<TModel> GetSerializer<TModel>()
        {
            Type serviceType = typeof(ISerializer<TModel>);
            object instance = serviceRegistry.Get(serviceType);

            ISerializer<TModel> serializer = (ISerializer<TModel>)instance;
            return serializer;

        }

        protected override object GetSerializer(Type modelType)
        {
            Type genericType = typeof(ISerializer<>).MakeGenericType(modelType);
            object instance = serviceRegistry.Get(genericType);
            return instance;
        }
    }
}