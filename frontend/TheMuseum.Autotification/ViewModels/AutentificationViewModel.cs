using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using TheMuseum.Shared.Events;

namespace TheMuseum.Autotification.ViewModels;

internal class AutentificationViewModel:ReactiveObject
{
    // public DelegateCommand NavigateCommand { get; }

    // private readonly IRegionManager _regionManager;

    [Reactive]
    public string Test {  get; set; }

    public AutentificationViewModel(IEventAggregator eventAggregator) 
    {
        eventAggregator.GetEvent<TestEvent>().Subscribe(x=>Test = x);
        //NavigateCommand = new DelegateCommand(Navigate);
        // _regionManager = regionManager;
    }

    //private void Navigate()
    //{
    //    _regionManager.RequestNavigate("RegionOfAutentification", "RegionOfBiography");
    //}
}
