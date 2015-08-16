using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Bosphorus.Container.Castle.Registration;
using Bosphorus.Container.Castle.Registration.Installer;
using Bosphorus.Serialization.Core.Serializer;
using Bosphorus.Serialization.Core.Serializer.Binary;
using Bosphorus.Serialization.Core.Serializer.Json;
using Bosphorus.Serialization.Core.Serializer.Xml;
using Castle.Core;
using Castle.Core.Internal;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Bosphorus.Serialization.Core
{
    public class Installer : AbstractWindsorInstaller, IInfrastructureInstaller
    {
        protected override void Install(IWindsorContainer container, IConfigurationStore store, FromTypesDescriptor allLoadedTypes)
        {
            //TODO: ISerializer için de default bir registration olmalı
            container.Register(
                Component
                    .For(typeof(IXmlSerializer<>))
                    .UsingFactoryMethod(Temp)
                    .IsFallback(),

                Component
                    .For<GenericSerializer>(),

                Component
                    .For<GenericXmlSerializer>(),

                Component
                    .For<GenericBinarySerializer>(),

                Component
                    .For<GenericJsonSerializer>()
            );
        }

        private object Temp(IKernel arg1, ComponentModel arg2, CreationContext arg3)
        {
            Type serviceType = arg2.Services.First().GetGenericTypeDefinition();

            IAssemblyProvider assemblyProvider = arg1.Resolve<IAssemblyProvider>();
            IEnumerable<Assembly> assemblies = assemblyProvider.GetAssemblies().ToList();
            IEnumerable<Type> selectMany = assemblies
                .SelectMany(x => x.GetTypes())
                .Where(x => serviceType.IsAssignableFrom(x))
                .ToList();

            ImplementationSelector implementationSelector = new ImplementationSelector(selectMany);
            var dialogResult = implementationSelector.ShowDialog();
            if (dialogResult != DialogResult.OK)
            {
                return null;
            }

            Type type = implementationSelector.Selected;
            //arg1.Register(Component.For(arg2.Services).)

            return type;
        }
    }
}
