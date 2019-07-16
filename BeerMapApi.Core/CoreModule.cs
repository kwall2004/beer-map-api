using Autofac;
using BeerMapApi.Core.Interfaces;
using BeerMapApi.Core.Models;
using BeerMapApi.Core.UseCases;

namespace BeerMapApi.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<BreweryUseCase>().As<IUseCase<Brewery>>().InstancePerLifetimeScope();
        }
    }
}
