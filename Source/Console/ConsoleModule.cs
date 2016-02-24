using System;
using Autofac;
using CommandLine;

namespace Console
{
    internal class ConsoleModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(GetType().Assembly)
                .Where(type => type.Name.EndsWith("Command"))
                .Named<Command>(p => p.Name.Substring(0, p.Name.IndexOf("Command", StringComparison.Ordinal)).ToLower())
                .InstancePerDependency();
        }
    }
}