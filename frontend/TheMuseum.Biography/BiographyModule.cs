using Prism.Ioc;
using Prism.Modularity;
using TheMuseum.Biography.Services;
using TheMuseum.Biography.Views;

namespace TheMuseum.Biography;

public class BiographyModule : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {

    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<BiographyView>();
        containerRegistry.RegisterSingleton<BiographyService>();
    }
}
