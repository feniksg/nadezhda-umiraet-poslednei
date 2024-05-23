using Prism.Events;
using Prism.Regions;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
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
    public BiographyViewModel(BiographyService biographyService, IRegionManager regionManager, IEventAggregator eventAggregator)
    {
        _biographyService = biographyService;
        _regionManager = regionManager;
        _eventAggregator = eventAggregator;
        _eventAggregator.GetEvent<UserLoggedInEvent>().Subscribe(OnUserLoggedIn);
        Artworks = new ObservableCollection<ArtworkModel>();
        LoadArtworksAsync().ConfigureAwait(false);
        MenuItems = new ObservableCollection<string> { "Выйти" };
        MenuCommand = ReactiveCommand.Create<string>(ExecuteMenuCommand);

        IsMenuOpen = false;
        UserDisplayName = "user";

        AddCommand = ReactiveCommand.CreateFromTask(AddArtworkAsync);
        DeleteCommand = ReactiveCommand.CreateFromTask(DeleteArtworkAsync);
        SwapCommand = ReactiveCommand.Create(SwapArtworks);
        LogoutCommand = ReactiveCommand.Create(Logout);
    }
    public ObservableCollection<ArtworkModel> Artworks { get; }
    public ObservableCollection<string> MenuItems { get; set; }
    [Reactive] public ArtworkModel Artwork { get; set; }
    [Reactive] public NavigateItem NavigateItem { get; set; }
    [Reactive] public ContentItem ContentItem { get; set; }
    [Reactive] ArtworkModel SelectedArtwork { get; set; }
    [Reactive] public string UserDisplayName { get; set; }
    [Reactive] public bool IsMenuOpen { get; set; }

    public ICommand MenuCommand { get; }
    public ICommand AddCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand SwapCommand { get; }
    public ICommand LogoutCommand { get; }

    private void OnUserLoggedIn(string username)
    {
        UserDisplayName = username;
        UpdateMenuItems(username == "admin");
    }

    private void UpdateMenuItems(bool isAdmin)
    {
        MenuItems.Clear();
        if (isAdmin)
        {
            MenuItems.Add("Добавить");
            MenuItems.Add("Удалить");
            MenuItems.Add("Поменять местами");
        }
        MenuItems.Add("Выйти");
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
            case "Удалить":
                DeleteArtworkAsync().ConfigureAwait(false);
                break;
            case "Поменять местами":
                SwapArtworks();
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
        var addArtworkViewModel = new AddArtworkViewModel();
        var addArtworkView = new AddArtworkView { DataContext = addArtworkViewModel };

        var result = await Application.Current.Dispatcher.InvokeAsync(() => addArtworkView.ShowDialog()); 
        if (result.HasValue && result.Value)
        {
            var newArtwork = addArtworkView.Tag as ArtworkModel;
            if (newArtwork != null)
            {
                Artworks.Add(newArtwork);
                await _biographyService.AddArtworkAsync(newArtwork);
            }
        }
    }

    private async Task DeleteArtworkAsync()
    {
        if (SelectedArtwork != null)
        {
            Artworks.Remove(SelectedArtwork);
            await _biographyService.DeleteArtworkAsync(SelectedArtwork.Id);
        }
    }

    private void SwapArtworks()
    {
        if (Artworks.Count > 1)
        {
            var temp = Artworks[0];
            Artworks[0] = Artworks[1];
            Artworks[1] = temp;
        }
    }

    private void Logout()
    {
        Artworks.Clear();
        _eventAggregator.GetEvent<AutentificationOpenEvent>().Publish();
        _regionManager.RequestNavigate("MainRegion", "AutentificationView");  
    }

}
    