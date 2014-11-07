using Bosphorus.Container.Castle.Registration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Serialization.Core
{
    public class Installer : AbstractWindsorInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            //TODO: ISerializer için de default bir registration olmalı
            container.Register(
                allLoadedTypes
                    .BasedOn(typeof(IBinarySerializer<>))
                    .WithService
                    .FirstInterface(),

                allLoadedTypes
                    .BasedOn(typeof(IXmlSerializer<>))
                    .WithService
                    .FirstInterface(),

                allLoadedTypes
                    .BasedOn(typeof(IJsonSerializer<>))
                    .WithService
                    .FirstInterface(),

                Component
                    .For<Serializer>(),

                Component
                    .For<XmlSerializer>(),

                Component
                    .For<BinarySerializer>(),

                Component
                    .For<JsonSerializer>()
            );
       }
    }
}
