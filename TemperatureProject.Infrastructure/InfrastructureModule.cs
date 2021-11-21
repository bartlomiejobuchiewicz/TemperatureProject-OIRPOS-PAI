using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace TemperatureProject.Infrastructure
{
    public class InfrastructureModule: Module
    {
        private readonly TemperatureProjectSettings _settings;

        public InfrastructureModule(TemperatureProjectSettings settings)
        {
            _settings = settings;
        }

        protected override void Load(ContainerBuilder builder)
        {
            LoadConfigurations(builder);
            base.Load(builder);
        }

        private void LoadConfigurations(ContainerBuilder builder)
        {
        }
    }
}
