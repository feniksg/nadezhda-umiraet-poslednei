using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TheMuseum.Biography.Models;
using TheMuseum.Biography.Services;
using TheMuseum.Biography.Views;
using TheMuseum.Shared.Events;

namespace TheMuseum.Biography.ViewModels;

internal class BiographyViewModel : ReactiveObject
{
    private readonly IRegionManager _regionManager;
    private readonly IEventAggregator _eventAggregator;
    private readonly BiographyService _biographyService;

    public ICommand TestCommand { get; set; }
    [Reactive]
    public Visibility ModFunctional { get; set; }
    public BiographyViewModel(BiographyService biographyService, IRegionManager regionManager, IEventAggregator eventAggregator)
    {
        _biographyService = biographyService;
        _regionManager = regionManager;
        _eventAggregator = eventAggregator;
        _eventAggregator.GetEvent<UserLoggedInEvent>().Subscribe(OnUserLoggedIn);
        Artworks = new ObservableCollection<ArtworkModel>();
        MenuItems = new ObservableCollection<string> { "Выйти" };
        MenuCommand = ReactiveCommand.Create<string>(ExecuteMenuCommand);
        ModFunctional = Visibility.Hidden;

        IsMenuOpen = false;
        UserDisplayName = "user";

        AddCommand = ReactiveCommand.CreateFromTask(AddArtworkAsync);
        SearchCommand = ReactiveCommand.CreateFromTask(LoadSearchedArtworkAsync);
        DeleteCommand = ReactiveCommand.CreateFromTask<int>(DeleteArtworkAsync);
        LogoutCommand = ReactiveCommand.Create(Logout);
    }
    public ObservableCollection<ArtworkModel> Artworks { get; }
    public ObservableCollection<string> MenuItems { get; set; }
    [Reactive] public ArtworkModel Artwork { get; set; }
    [Reactive] public string UserDisplayName { get; set; }
    [Reactive] public bool IsMenuOpen { get; set; }
    [Reactive] public string SearchText { get; set; }

    public ICommand MenuCommand { get; }
    public ICommand AddCommand { get; }
    public ICommand SearchCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand LogoutCommand { get; }

    private async void OnUserLoggedIn(string username)
    {
        UserDisplayName = username;
        UpdateMenuItems(username == "admin");
        await LoadArtworksAsync();
    }

    private void UpdateMenuItems(bool isAdmin)
    {
        MenuItems.Clear();
        if (isAdmin)
        {
            MenuItems.Add("Добавить");
            ModFunctional = Visibility.Visible;
        }
        MenuItems.Add("Выйти");
        ModFunctional = Visibility.Hidden;
    }

    private void ExecuteMenuCommand(string parameter)
    {
        switch (parameter)
        {
            case "Выйти":
                Logout();
                break;
            case "Добавить":
                AddArtworkAsync().ConfigureAwait(false);
                break;
            default:
                break;
        }
    }

    private async Task LoadArtworksAsync()
    {
        var artworks = await _biographyService.GetArtworksAsync();
        Artworks.Clear();
        foreach (var artwork in artworks)
        {
            Artworks.Add(artwork);
        }
    }

    private async Task AddArtworkAsync()
    {
        var addArtworkView = new AddArtworkView();
        var addArtworkViewModel = new AddArtworkViewModel(addArtworkView);
        addArtworkView.DataContext = addArtworkViewModel;

        var result = await Application.Current.Dispatcher.InvokeAsync(() => addArtworkView.ShowDialog()); 
        if (result.HasValue && result.Value)
        {
            var newArtwork = addArtworkView.Tag as ArtworkModel;
            if (newArtwork != null)
            {
                Artworks.Add(newArtwork);
                await _biographyService.AddArtworkAsync(newArtwork);
                await LoadArtworksAsync();
            }
        }
    }

    private async Task LoadSearchedArtworkAsync()
    {
        var artworks = await _biographyService.GetSearchedArtworksAsync(SearchText);
        Artworks.Clear();
        foreach (var artwork in artworks)
        {
            Artworks.Add(artwork);
        }
    }

    private async Task DeleteArtworkAsync(int id)
    {
        await _biographyService.DeleteArtworkAsync(id);
        await LoadArtworksAsync();
    }

    private void Logout()
    {
        Artworks.Clear();
        _eventAggregator.GetEvent<AutentificationOpenEvent>().Publish();
        _regionManager.RequestNavigate("MainRegion", "AutentificationView");
    }

}
    