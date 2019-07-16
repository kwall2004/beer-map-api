using Autofac;
using BeerMapApi.Core.Interfaces;
using BeerMapApi.Core.Models;
using BeerMapApi.Infrastructure.Repositories;

namespace BeerMapApi.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<BreweryRepository>().As<IRepository<Brewery>>().InstancePerLifetimeScope();
        }
    }
}
