using Microsoft.Extensions.DependencyInjection;
using Valhalla.Modules.Infrastructure.IoC.Application;
using Valhalla.Modules.Infrastructure.IoC.Infrastructure;

namespace Valhalla.Modules.Infrastructure.IoC
{
    public class RootBootstrapper
    {
        public void BootstrapperRegisterServices(IServiceCollection services)
        {
            new ApplicationBootstrapper().ChildServiceRegister(services);
            new InfrastructureBootstrapper().ChildServiceRegister(services);
        }
    }
}
