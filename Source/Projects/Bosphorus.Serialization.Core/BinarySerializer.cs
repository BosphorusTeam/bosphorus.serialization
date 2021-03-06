﻿using System;
using Bosphorus.Container.Castle.Extra;

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

        protected override object GetSerializer(Type modelType)
        {
            Type genericType = typeof(IBinarySerializer<>).MakeGenericType(modelType);
            object instance = serviceRegistry.Get(genericType);
            return instance;
        }
    }
}