using Bosphorus.Serialization.Core;
using Bosphorus.Serialization.Core.Serializer.Binary;
using Bosphorus.Serialization.Core.Serializer.Json;
using Bosphorus.Serialization.Core.Serializer.Xml;
using Bosphorus.Serialization.Default.Serializer.Binary;
using Bosphorus.Serialization.Default.Serializer.Json;
using Bosphorus.Serialization.Default.Serializer.Xml;
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
                    .For(typeof(IBinarySerializer<>))
                    .ImplementedBy(typeof(DefaultBinarySerializer<>)),

                Component
                    .For(typeof(IJsonSerializer<>))
                    .ImplementedBy(typeof(DefaultJsonSerializer<>))
            );
        }
    }
}
