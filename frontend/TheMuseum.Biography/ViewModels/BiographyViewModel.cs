using Prism.Events;
using Prism.Regions;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Input;
using TheMuseum.Biography.Models;
using TheMuseum.Biography.Services;
using TheMuseum.Shared.Events;

namespace TheMuseum.Biography.ViewModels;

internal class BiographyViewModel : ReactiveObject
{
    private readonly IRegionManager _regionManager;
    private readonly IEventAggregator _eventAggregator;

    public ICommand TestCommand { get; set; }
    public BiographyViewModel(BiographyService biographyService, IRegionManager regionManager, IEventAggregator eventAggregator)
    {
        _regionManager = regionManager;
        _eventAggregator = eventAggregator;
        _eventAggregator.GetEvent<UserLoggedInEvent>().Subscribe(OnUserLoggedIn);
        Artworks = new(biographyService.GetArtworks());
        // UserDisplayName = "user";
    }
    public ObservableCollection<ArtworkModel> Artworks { get; }
    public ObservableCollection<NavigateItem> NavigationItems { get; }
    public ObservableCollection<ContentItem> ContentItems { get; }
    [Reactive] public ArtworkModel Artwork { get; set; }
    [Reactive] public NavigateItem NavigateItem { get; set; }
    [Reactive] public ContentItem ContentItem { get; set; }
    [Reactive] public string UserDisplayName { get; set; }

 
    private void OnUserLoggedIn(string username)
    {
        UserDisplayName = username;
    }

}
    