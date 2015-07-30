using System;
using Castle.Windsor;

namespace Bosphorus.Serialization.Core
{
    public class XmlSerializer : AbstractSerializer
    {
        private readonly IWindsorContainer container;

        public XmlSerializer(IWindsorContainer container)
        {
            this.container = container;
        }

        protected override ISerializer<TModel> GetSerializer<TModel>()
        {
            Type serviceType = typeof(IXmlSerializer<TModel>);
            object instance = container.Resolve(serviceType);

            ISerializer<TModel> serializer = (IXmlSerializer<TModel>)instance;
            return serializer;

        }

        protected override object GetSerializer(Type modelType)
        {
            Type genericType = typeof(IXmlSerializer<>).MakeGenericType(modelType);
            object instance = container.Resolve(genericType);
            return instance;
        }
    }
}