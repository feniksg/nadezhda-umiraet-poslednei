using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using TheMuseum.Autotification;
using TheMuseum.Autotification.Services;
using TheMuseum.Autotification.Views;
using TheMuseum.Biography;
using TheMuseum.Biography.Views;
using TheMuseum.Views;

namespace TheMuseum;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
        moduleCatalog
            .AddModule<AutetificationModule>()
            .AddModule<BiographyModule>();
    }

    protected override Window CreateShell() => Container.Resolve<MainWindow>();
}
