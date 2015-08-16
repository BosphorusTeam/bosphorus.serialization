using System;
using Castle.Windsor;

namespace Bosphorus.Serialization.Core.Serializer
{
    public class GenericSerializer : AbstractGenericSerializer
    {
        private readonly IWindsorContainer container;

        public GenericSerializer(IWindsorContainer container)
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