using Prism.Events;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using TheMuseum.Shared.Events;

namespace TheMuseum.Autotification.ViewModels;

internal class AutentificationViewModel:ReactiveObject
{
    
    [Reactive]
    public string Test {  get; set; }

    public AutentificationViewModel(IEventAggregator eventAggregator) 
    {
        eventAggregator.GetEvent<TestEvent>().Subscribe(x=>Test = x);
    }
}
