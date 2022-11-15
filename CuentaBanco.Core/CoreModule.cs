using Autofac;
using CuentaBanco.Core.Interfaces.UsesCases;
using CuentaBanco.Core.UsesCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBanco.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ClienteInteractor>().As<IClienteInteractor>().InstancePerLifetimeScope();
            builder.RegisterType<CuentaInteractor>().As<ICuentaInteractor>().InstancePerLifetimeScope();
            builder.RegisterType<MovimientosInteractor>().As<IMovimientosInteractor>().InstancePerLifetimeScope();
            builder.RegisterType<ReportesInteractor>().As<IReportesInteractor>().InstancePerLifetimeScope();
        }
    }
}
