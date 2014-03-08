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
            container.Register(
                allLoadedTypes
                    .BasedOn(typeof(IBinarySerializer))
                    .WithService.FirstInterface(),
                allLoadedTypes
                    .BasedOn(typeof(IXmlSerializer))
                    .WithService.FirstInterface(),
                allLoadedTypes
                    .BasedOn(typeof(IJsonSerializer))
                    .WithService.FirstInterface()
            );
       }
    }
}
