using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMuseum.Biography.Services;
using TheMuseum.Biography.Views;

namespace TheMuseum.Biography
{
    public class BiographyModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            containerProvider.Resolve<IRegionManager>()
                .RegisterViewWithRegion("RegionOfBiography", nameof(BiographyView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
             containerRegistry.RegisterForNavigation<BiographyView>();
            containerRegistry.RegisterSingleton<BiographyService>();
        }
    }
}
