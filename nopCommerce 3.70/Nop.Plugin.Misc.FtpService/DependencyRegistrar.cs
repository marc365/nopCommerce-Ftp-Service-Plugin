/*
 * (c) Nop Content 2016. All rights reserved.
 * User: github.com/marc365
 * Created: 2016
 */

using Autofac;
using FtpPlugin.Services;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;

namespace FtpPlugin
{
    public class SourceCodeDependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            builder.RegisterType<IFtpService>().As<IFtpService>().InstancePerLifetimeScope();
        }

        public int Order
        {
            get { return 0; }
        }

    }
}
