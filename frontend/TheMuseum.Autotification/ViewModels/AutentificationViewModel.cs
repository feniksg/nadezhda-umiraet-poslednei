using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace TheMuseum.Autotification.ViewModels;

internal class AutentificationViewModel:ReactiveObject
{
    [Reactive]
    public int Test {  get; set; }
}
