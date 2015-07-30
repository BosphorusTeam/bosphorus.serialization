using System;
using Castle.Windsor;

namespace Bosphorus.Serialization.Core
{
    public class Serializer : AbstractSerializer
    {
        private readonly IWindsorContainer container;

        public Serializer(IWindsorContainer container)
        {
            this.container = container;
        }

        protected override ISerializer<TModel> GetSerializer<TModel>()
        {
            Type serviceType = typeof(ISerializer<TModel>);
            object instance = container.Resolve(serviceType);

            ISerializer<TModel> serializer = (ISerializer<TModel>)instance;
            return serializer;

        }

        protected override object GetSerializer(Type modelType)
        {
            Type genericType = typeof(ISerializer<>).MakeGenericType(modelType);
            object instance = container.Resolve(genericType);
            return instance;
        }
    }
}