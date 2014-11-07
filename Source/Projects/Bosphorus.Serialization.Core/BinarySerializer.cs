using System;
using Bosphorus.Container.Castle.Registry;

namespace Bosphorus.Serialization.Core
{
    public class BinarySerializer : AbstractSerializer
    {
        private readonly IServiceRegistry serviceRegistry;

        public BinarySerializer(IServiceRegistry serviceRegistry)
        {
            this.serviceRegistry = serviceRegistry;
        }

        protected override ISerializer<TModel> GetSerializer<TModel>()
        {
            Type serviceType = typeof(IBinarySerializer<TModel>);
            object instance = serviceRegistry.Get(serviceType);

            ISerializer<TModel> serializer = (IBinarySerializer<TModel>)instance;
            return serializer;

        }
    }
}