using Prism.Events;
using Prism.Regions;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Windows.Input;
using TheMuseum.Shared.Events;

namespace TheMuseum.Autotification.ViewModels;

internal class AutentificationViewModel:ReactiveObject
{

    private readonly IRegionManager _regionManager;
    private readonly IEventAggregator _eventAggregator;

    public ICommand LoginCommand { get; set; }

    [Reactive]
    public string Test {  get; set; }

    public AutentificationViewModel(IEventAggregator eventAggregator, IRegionManager regionManager) 
    {
        _regionManager = regionManager;
        _eventAggregator = eventAggregator;
        eventAggregator.GetEvent<TestEvent>().Subscribe(x=>Test = x);
        LoginCommand = ReactiveCommand.Create(Navigate);
    }

    private void Navigate()
    {
        if(Test != null)
        {

        }
        else
        {
            _eventAggregator.GetEvent<BiographyOpenEvent>().Publish();
            _regionManager.RequestNavigate("MainRegion", "BiographyView");
        }
    }
}
