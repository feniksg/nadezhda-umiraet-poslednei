using Prism.Ioc;
using Prism.Modularity;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Windows;
using TheMuseum.Autotification;

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
            .AddModule<AutetificationModel>();
    }

    protected override Window CreateShell() => Container.Resolve<MainWindow>();
}
