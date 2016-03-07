using System.Linq;
using Autofac.Core;
using Common.Logging;

namespace PersonalAssistant.Logging
{
    public class LoggingModule : IModule
    {
        public void Configure(IComponentRegistry componentRegistry)
        {
            componentRegistry.Registered += ComponentRegistry_Registered;
        }

        private void ComponentRegistry_Registered(object sender, ComponentRegisteredEventArgs e)
        {
            e.ComponentRegistration.Preparing += ComponentRegistration_Preparing;
        }

        private void ComponentRegistration_Preparing(object sender, PreparingEventArgs e)
        {
            var t = e.Component.Activator.LimitType;
            e.Parameters = e.Parameters.Union(new[]
            {
                new ResolvedParameter((p, i) => p.ParameterType == typeof (ILog), (p, i) => LogManager.GetLogger(t))
            });
        }
    }
}