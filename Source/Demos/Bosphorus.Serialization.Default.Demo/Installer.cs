using Bosphorus.Container.Castle.Registration;
using Bosphorus.Container.Castle.Registration.Installer;
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
    public class Installer: AbstractWindsorInstaller, IInfrastructureInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
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
