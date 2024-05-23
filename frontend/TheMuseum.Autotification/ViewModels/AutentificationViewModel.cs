using Accessibility;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Configuration;
using System.Windows;
using System.Windows.Input;
using TheMuseum.Autotification.Services;
using TheMuseum.Shared.Events;

namespace TheMuseum.Autotification.ViewModels;

internal class AutentificationViewModel:ReactiveObject
{
    private readonly IAutetificationService _autetificationService;
    private readonly IRegionManager _regionManager;
    private readonly IEventAggregator _eventAggregator;

    public ICommand LoginCommand { get; set; }

    [Reactive]
    public string Test {  get; set; }
    [Reactive]
    public string Username {  get; set; }
    [Reactive]
    public string Password { get; set; }
    [Reactive]
    public Visibility LoginErrorVisibility { get; set; }

    public AutentificationViewModel(IAutetificationService autetificationService, IEventAggregator eventAggregator, IRegionManager regionManager) 
    {
        _autetificationService = autetificationService;
        _regionManager = regionManager;
        _eventAggregator = eventAggregator;
        eventAggregator.GetEvent<TestEvent>().Subscribe(x=>Test = x);
        LoginCommand = ReactiveCommand.Create(Login);
        LoginErrorVisibility = Visibility.Collapsed;
    }
    private void Login()
    {
        if(_autetificationService.Authenticate(Username, Password))
        {
            _eventAggregator.GetEvent<BiographyOpenEvent>().Publish();
            _regionManager.RequestNavigate("MainRegion", "BiographyView");
            _eventAggregator.GetEvent<UserLoggedInEvent>().Publish(Username);
            LoginErrorVisibility = Visibility.Collapsed;
        }
        else
        {
            LoginErrorVisibility = Visibility.Visible;
        }
    }

}
