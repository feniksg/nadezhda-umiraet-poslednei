using Prism.Events;
using Prism.Regions;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TheMuseum.Biography.Models;
using TheMuseum.Biography.Services;
using TheMuseum.Shared.Events;

namespace TheMuseum.Biography.ViewModels;

internal class BiographyViewModel : ReactiveObject
{
    private readonly IRegionManager _regionManager;
    private readonly IEventAggregator _eventAggregator;
    public BiographyViewModel(BiographyService biographyService, IRegionManager regionManager, IEventAggregator eventAggregator)
    {
        _regionManager = regionManager;
        _eventAggregator = eventAggregator;
        Artworks = new(biographyService.GetArtworks());
        TestCommand = ReactiveCommand.Create(Test);
    }
    public ObservableCollection<ArtworkModel> Artworks { get; }
    [Reactive] public ArtworkModel Artwork { get; set; }
    public ICommand TestCommand { get; init; }

    
    private void Test()
    {
        _regionManager.RequestNavigate("MainRegion", "AutentificationView");

        // Обмен данными между модулями

        _eventAggregator.GetEvent<TestEvent>().Publish(Artwork?.Name ?? "Chenibud");
    }
}
