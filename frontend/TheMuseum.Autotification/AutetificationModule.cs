using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using TheMuseum.Autotification.Views;

namespace TheMuseum.Autotification;

public class AutetificationModule : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {
        containerProvider.Resolve<IRegionManager>()
            .RegisterViewWithRegion("MainRegion", nameof(AutentificationView));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<AutentificationView>();
    }
}
