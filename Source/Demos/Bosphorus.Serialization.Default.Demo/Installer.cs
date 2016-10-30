using System.Runtime.Serialization.Formatters.Binary;
using System.Web.Script.Serialization;
using Bosphorus.Serialization.Core;
using Bosphorus.Serialization.Core.Serializer.Binary;
using Bosphorus.Serialization.Core.Serializer.Json;
using Bosphorus.Serialization.Core.Serializer.Xml;
using Bosphorus.Serialization.Default.Serializer.Binary;
using Bosphorus.Serialization.Default.Serializer.Json;
using Bosphorus.Serialization.Default.Serializer.Xml;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Serialization.Default.Demo
{
    public class Installer: IDemoInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For(typeof(IXmlSerializer<>))
                    .ImplementedBy(typeof(DefaultXmlSerializer<>)),

                Component
                    .For(typeof(IXmlDeserializer<>))
                    .ImplementedBy(typeof(DefaultXmlDeserializer<>)),

                Component
                    .For(typeof(IBinarySerializer<>))
                    .ImplementedBy(typeof(DefaultBinarySerializer<>)),

                Component
                    .For(typeof(IBinaryDeserializer<>))
                    .ImplementedBy(typeof(DefaultBinaryDeserializer<>)),

                Component
                    .For(typeof(IJsonSerializer<>))
                    .ImplementedBy(typeof(DefaultJsonSerializer<>)),

                Component
                    .For(typeof(IJsonDeserializer<>))
                    .ImplementedBy(typeof(DefaultJsonDeserializer<>)),

                Component
                    .For<BinaryFormatter>()
                    .UsingFactoryMethod(BuildBinaryFormatter),

                Component
                    .For<JavaScriptSerializer>()
                    .UsingFactoryMethod(BuildJavaScriptSerializer)
            );
        }

        private JavaScriptSerializer BuildJavaScriptSerializer(IKernel arg1, ComponentModel arg2, CreationContext arg3)
        {
            return new JavaScriptSerializer();
        }

        private BinaryFormatter BuildBinaryFormatter(IKernel arg1, ComponentModel arg2, CreationContext arg3)
        {
            return new BinaryFormatter();
        }
    }
}
