using Autofac;
using CuentaBanco.Core.Interfaces.Repositories;
using CuentaBanco.Infrastructure.Data.EntityFrameworkSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBanco.Infrastructure
{
    public class InfraestructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RepositoryWrapper>().As<IRepositoryWrapper>().InstancePerLifetimeScope();
        }
    }
}
